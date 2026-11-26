namespace BankAtmManagement.Models;

/// <summary>
/// Tiến độ xử lý đối soát giao dịch ATM báo cáo về UI thread.
/// </summary>
public sealed class ReconciliationProgress
{
    public int Percent { get; init; }
    public string StageMessage { get; init; } = string.Empty;
    public int ProcessedCount { get; init; }
    public int TotalCount { get; init; }
    public int DiscrepancyCount { get; init; }
    public string? LogLine { get; init; }
}

/// <summary>
/// Một bản ghi giao dịch có chênh lệch phát hiện trong quá trình đối soát.
/// </summary>
public sealed class ReconciliationDiscrepancy
{
    public string TransactionId { get; init; } = string.Empty;
    public string StationCode { get; init; } = string.Empty;
    public string TransactionType { get; init; } = string.Empty;
    public decimal CoreAmount { get; init; }
    public decimal AtmJournalAmount { get; init; }
    public decimal Difference => AtmJournalAmount - CoreAmount;
    public string Status { get; init; } = string.Empty;
    public DateTime TransactionTime { get; init; }
}

/// <summary>
/// Tổng hợp kết quả sau khi hoàn tất hoặc dừng đối soát.
/// </summary>
public sealed class ReconciliationSummary
{
    public int TotalTransactions { get; init; }
    public int ProcessedTransactions { get; init; }
    public int MatchedCount { get; init; }
    public int DiscrepancyCount => Discrepancies.Count;
    public decimal TotalVolume { get; init; }
    public double ElapsedSeconds { get; init; }
    public bool WasCancelled { get; init; }
    public List<ReconciliationDiscrepancy> Discrepancies { get; init; } = [];
}
