using System.Diagnostics;
using BankAtmManagement.Models;

namespace BankAtmManagement.Services;

/// <summary>
/// Dịch vụ mô phỏng đối soát hàng trăm nghìn giao dịch ATM bất đồng bộ (async/await + Task.Run).
/// </summary>
public sealed class AtmReconciliationService
{
    /// <summary>
    /// Chạy đối soát bất đồng bộ trong khoảng 4.5 - 5.5 giây mà không làm treo UI Thread.
    /// </summary>
    public async Task<ReconciliationSummary> RunReconciliationAsync(
        DateTime reconciliationDate,
        string? stationScope,
        IProgress<ReconciliationProgress>? progress,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        var stations = AtmDataStore.GetAll();
        var targetCodes = (!string.IsNullOrWhiteSpace(stationScope) &&
                           !stationScope.Equals("Tất cả trạm ATM", StringComparison.OrdinalIgnoreCase))
            ? [stationScope]
            : stations.Select(s => s.StationCode).ToArray();

        if (targetCodes.Length == 0)
            targetCodes = ["ATM-HN-001"];

        // Mô phỏng 240,000 giao dịch nếu toàn mạng lưới, hoặc ~45,000 nếu đối soát 1 trạm
        int totalTransactions = targetCodes.Length > 1 ? 240_000 : 45_000;
        const int totalSteps = 50; // 50 * ~100ms = ~5.0 giây (đúng yêu cầu 4 - 6 giây)
        int batchSize = totalTransactions / totalSteps;

        var discrepancies = new List<ReconciliationDiscrepancy>();
        decimal totalVolume = 0m;
        int processed = 0;
        bool wasCancelled = false;

        try
        {
            await Task.Run(async () =>
            {
                var rng = new Random(reconciliationDate.DayOfYear * 1009 + targetCodes.Length);

                string[] txTypes = ["Rút tiền mặt", "Chuyển khoản nội bộ", "Chuyển khoản Napas 247", "Vấn tin / Đổi PIN"];
                string[] discrepancyReasons =
                [
                    "Hụt quỹ / Timeout nhả tiền",
                    "Trừ Core nhưng ATM chưa nhả tiền",
                    "Chênh lệch nhật ký điện tử (EJ)"
                ];

                progress?.Report(new ReconciliationProgress
                {
                    Percent = 0,
                    StageMessage = "Đang kết nối Core Banking & tải sao kê nhật ký ATM...",
                    ProcessedCount = 0,
                    TotalCount = totalTransactions,
                    DiscrepancyCount = 0,
                    LogLine = $"[{DateTime.Now:HH:mm:ss}] Bắt đầu tải {totalTransactions:N0} giao dịch ngày {reconciliationDate:dd/MM/yyyy}..."
                });

                for (int step = 1; step <= totalSteps; step++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Giả lập độ trễ xử lý & truy xuất dữ liệu từ máy chủ (~100ms/lô -> ~5 giây tổng cộng)
                    await Task.Delay(100, cancellationToken).ConfigureAwait(false);

                    // Tính toán CPU nhẹ trên thread nền cho lô giao dịch
                    int currentBatch = (step == totalSteps) ? (totalTransactions - processed) : batchSize;
                    decimal batchVolume = 0m;
                    for (int i = 0; i < currentBatch; i++)
                    {
                        batchVolume += (rng.Next(1, 20) * 100_000m);
                    }

                    processed += currentBatch;
                    totalVolume += batchVolume;

                    // Phát sinh ngẫu nhiên một vài giao dịch lệch số liệu ở các mốc nhất định
                    string? logLine = null;
                    if (step is 10 or 22 or 35 or 44)
                    {
                        string station = targetCodes[rng.Next(targetCodes.Length)];
                        string txType = txTypes[rng.Next(txTypes.Length)];
                        decimal coreAmt = rng.Next(2, 25) * 500_000m;
                        decimal atmAmt = step == 22 ? 0m : coreAmt - 500_000m;
                        string reason = discrepancyReasons[rng.Next(discrepancyReasons.Length)];

                        var item = new ReconciliationDiscrepancy
                        {
                            TransactionId = $"TX{reconciliationDate:yyMMdd}-{rng.Next(100000, 999999)}",
                            StationCode = station,
                            TransactionType = txType,
                            CoreAmount = coreAmt,
                            AtmJournalAmount = atmAmt,
                            Status = reason,
                            TransactionTime = reconciliationDate.Date
                                .AddHours(rng.Next(6, 23))
                                .AddMinutes(rng.Next(0, 60))
                                .AddSeconds(rng.Next(0, 60))
                        };
                        discrepancies.Add(item);
                        logLine = $"[{DateTime.Now:HH:mm:ss}] CẢNH BÁO lệch {item.TransactionId} tại {station}: {reason}";
                    }
                    else if (step == 1)
                    {
                        logLine = $"[{DateTime.Now:HH:mm:ss}] Đã nhận gói dữ liệu Core Banking, bắt đầu đối chiếu chéo...";
                    }
                    else if (step == 25)
                    {
                        logLine = $"[{DateTime.Now:HH:mm:ss}] Đã xử lý 50% khối lượng ({processed:N0}/{totalTransactions:N0} giao dịch)...";
                    }
                    else if (step == totalSteps)
                    {
                        logLine = $"[{DateTime.Now:HH:mm:ss}] Hoàn tất đối chiếu {processed:N0} giao dịch. Phát hiện {discrepancies.Count} sai lệch.";
                    }

                    int percent = (int)Math.Round(step * 100.0 / totalSteps);
                    string stage = percent switch
                    {
                        < 25 => "Đang giải mã nhật ký điện tử (EJ) từ các trạm ATM...",
                        < 65 => "Đang đối chiếu giao dịch rút tiền & chuyển khoản với Core Banking...",
                        < 95 => "Đang kiểm tra giao dịch treo, hoàn trả tự động & chênh lệch quỹ...",
                        _ => "Đang tổng hợp báo cáo đối soát cuối ngày..."
                    };

                    progress?.Report(new ReconciliationProgress
                    {
                        Percent = percent,
                        StageMessage = stage,
                        ProcessedCount = processed,
                        TotalCount = totalTransactions,
                        DiscrepancyCount = discrepancies.Count,
                        LogLine = logLine
                    });
                }
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            wasCancelled = true;
        }

        stopwatch.Stop();

        return new ReconciliationSummary
        {
            TotalTransactions = totalTransactions,
            ProcessedTransactions = processed,
            MatchedCount = Math.Max(0, processed - discrepancies.Count),
            TotalVolume = totalVolume,
            ElapsedSeconds = stopwatch.Elapsed.TotalSeconds,
            WasCancelled = wasCancelled,
            Discrepancies = discrepancies
        };
    }
}
