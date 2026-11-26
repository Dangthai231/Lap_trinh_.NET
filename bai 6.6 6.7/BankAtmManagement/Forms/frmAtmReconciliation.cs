using System.Diagnostics;
using BankAtmManagement.Models;
using BankAtmManagement.Services;

namespace BankAtmManagement.Forms;

/// <summary>
/// Form Con 2: Phân hệ đối soát sao kê giao dịch ATM bất đồng bộ (async/await & CancellationTokenSource).
/// </summary>
public partial class frmAtmReconciliation : Form
{
    private readonly AtmReconciliationService _reconciliationService = new();
    private CancellationTokenSource? _cts;
    private bool _isRunning;

    public frmAtmReconciliation()
    {
        InitializeComponent();
        ConfigureDiscrepancyGrid();
        LoadScopeOptions();
    }

    private void ConfigureDiscrepancyGrid()
    {
        dgvDiscrepancies.AutoGenerateColumns = false;
        dgvDiscrepancies.EnableHeadersVisualStyles = false;
        dgvDiscrepancies.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 52, 96);
        dgvDiscrepancies.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvDiscrepancies.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dgvDiscrepancies.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        dgvDiscrepancies.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

        dgvDiscrepancies.Columns.AddRange(
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.TransactionId),
                HeaderText = "Mã giao dịch",
                FillWeight = 16
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.StationCode),
                HeaderText = "Mã trạm",
                FillWeight = 12
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.TransactionType),
                HeaderText = "Loại giao dịch",
                FillWeight = 18
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.CoreAmount),
                HeaderText = "Số tiền Core (VNĐ)",
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.AtmJournalAmount),
                HeaderText = "Số tiền ATM (VNĐ)",
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.Difference),
                HeaderText = "Chênh lệch",
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    ForeColor = Color.Firebrick,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.Status),
                HeaderText = "Nguyên nhân / Ghi chú",
                FillWeight = 22
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(ReconciliationDiscrepancy.TransactionTime),
                HeaderText = "Thời gian GD",
                FillWeight = 14,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm:ss dd/MM" }
            }
        );
    }

    private void LoadScopeOptions()
    {
        cboStationScope.Items.Clear();
        cboStationScope.Items.Add("Tất cả trạm ATM");
        foreach (var station in AtmDataStore.GetAll())
        {
            cboStationScope.Items.Add(station.StationCode);
        }
        cboStationScope.SelectedIndex = 0;
    }

    private void SetRunningState(bool running)
    {
        _isRunning = running;
        btnRunReconciliation.Enabled = !running;
        btnStopReconciliation.Enabled = running;
        dtpReconcileDate.Enabled = !running;
        cboStationScope.Enabled = !running;
    }

    private void UpdateParentProgress(int percent, string text)
    {
        if (MdiParent is frmBankAtmMain parent && !parent.IsDisposed)
        {
            parent.UpdateReconciliationProgress(percent, text);
        }
    }

    private void AppendLog(string line)
    {
        lstLogs.Items.Add(line);
        lstLogs.TopIndex = Math.Max(0, lstLogs.Items.Count - 1);
    }

    private async void btnRunReconciliation_Click(object? sender, EventArgs e)
    {
        if (_isRunning)
            return;

        _cts?.Dispose();
        _cts = new CancellationTokenSource();

        SetRunningState(true);
        dgvDiscrepancies.DataSource = null;
        lstLogs.Items.Clear();
        prgLocal.Value = 0;
        lblPercent.Text = "0%";
        lblStage.Text = "Đang khởi tạo phiên đối soát...";
        lblStage.ForeColor = Color.FromArgb(15, 98, 254);

        var elapsedClock = Stopwatch.StartNew();
        var scope = cboStationScope.SelectedItem?.ToString();
        var date = dtpReconcileDate.Value.Date;

        var progress = new Progress<ReconciliationProgress>(p =>
        {
            if (IsDisposed || Disposing)
                return;

            prgLocal.Value = Math.Clamp(p.Percent, 0, 100);
            lblPercent.Text = $"{p.Percent}%";
            lblStage.Text = p.StageMessage;
            lblStats.Text =
                $"Đã đối chiếu: {p.ProcessedCount:N0} / {p.TotalCount:N0} giao dịch | " +
                $"Sai lệch phát hiện: {p.DiscrepancyCount} | Thời gian: {elapsedClock.Elapsed.TotalSeconds:F1}s";

            if (!string.IsNullOrWhiteSpace(p.LogLine))
            {
                AppendLog(p.LogLine);
            }

            UpdateParentProgress(p.Percent, $"Đang đối soát ATM: {p.Percent}% ({p.ProcessedCount:N0}/{p.TotalCount:N0})");
        });

        try
        {
            var summary = await _reconciliationService.RunReconciliationAsync(
                date,
                scope,
                progress,
                _cts.Token);

            if (IsDisposed || Disposing)
                return;

            dgvDiscrepancies.DataSource = summary.Discrepancies;

            if (summary.WasCancelled)
            {
                lblStage.Text = "Tiến trình đối soát đã bị người dùng dừng giữa chừng.";
                lblStage.ForeColor = Color.FromArgb(180, 83, 9);
                AppendLog($"[{DateTime.Now:HH:mm:ss}] ĐÃ DỪNG ĐỐI SOÁT sau {summary.ElapsedSeconds:F2}s ({summary.ProcessedTransactions:N0}/{summary.TotalTransactions:N0} giao dịch).");
                UpdateParentProgress(0, "Tiến độ đối soát: Đã dừng bởi người dùng");
            }
            else
            {
                prgLocal.Value = 100;
                lblPercent.Text = "100%";
                lblStage.Text = $"Hoàn tất đối soát! Khớp {summary.MatchedCount:N0} GD, phát hiện {summary.DiscrepancyCount} sai lệch.";
                lblStage.ForeColor = Color.FromArgb(16, 124, 65);
                lblStats.Text =
                    $"Đã đối chiếu: {summary.ProcessedTransactions:N0} / {summary.TotalTransactions:N0} giao dịch | " +
                    $"Tổng giá trị: {summary.TotalVolume:N0} VNĐ | Sai lệch: {summary.DiscrepancyCount} | Thời gian: {summary.ElapsedSeconds:F2}s";

                UpdateParentProgress(100, $"Đối soát hoàn tất ({summary.ElapsedSeconds:F1}s) - {summary.DiscrepancyCount} sai lệch");
            }
        }
        catch (Exception ex)
        {
            if (!IsDisposed)
            {
                lblStage.Text = $"Lỗi đối soát: {ex.Message}";
                lblStage.ForeColor = Color.Firebrick;
                AppendLog($"[{DateTime.Now:HH:mm:ss}] LỖI: {ex.Message}");
                UpdateParentProgress(0, "Tiến độ đối soát: Gặp lỗi");
            }
        }
        finally
        {
            elapsedClock.Stop();
            if (!IsDisposed)
            {
                SetRunningState(false);
            }
            _cts?.Dispose();
            _cts = null;
        }
    }

    private void btnStopReconciliation_Click(object? sender, EventArgs e)
    {
        if (!_isRunning || _cts is null)
            return;

        btnStopReconciliation.Enabled = false;
        lblStage.Text = "Đang gửi tín hiệu hủy tiến trình đối soát...";
        AppendLog($"[{DateTime.Now:HH:mm:ss}] Người dùng yêu cầu dừng đối soát...");
        _cts.Cancel();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (_isRunning && _cts is not null)
        {
            _cts.Cancel();
            UpdateParentProgress(0, "Tiến độ đối soát: Đã hủy do đóng cửa sổ");
        }
        base.OnFormClosing(e);
    }
}
