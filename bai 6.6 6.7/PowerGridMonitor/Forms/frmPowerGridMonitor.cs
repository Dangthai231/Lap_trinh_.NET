using PowerGridMonitor.Models;

namespace PowerGridMonitor.Forms;

/// <summary>
/// Bài 6.7: Trung tâm Điều độ & Giám sát Lưới điện Thời gian thực (Cross-Thread Safety).
/// </summary>
public partial class frmPowerGridMonitor : Form
{
    private CancellationTokenSource? _scadaCts;
    private Task? _monitoringTask;
    private volatile bool _isMonitoring;
    private volatile string _selectedSubstation = "Trạm 110kV Hà Đông";
    private int _cycleCounter;

    public frmPowerGridMonitor()
    {
        InitializeComponent();
        InitializeSubstations();
        ConfigureGridLogs();
    }

    private void InitializeSubstations()
    {
        cboSubstation.Items.AddRange(new object[]
        {
            "Trạm 110kV Hà Đông",
            "Trạm 220kV Chèm",
            "Trạm 110kV Mai Động",
            "Trạm 220kV Long Biên",
            "Trạm 110kV Cầu Giấy"
        });
        cboSubstation.SelectedIndex = 0;
        _selectedSubstation = cboSubstation.SelectedItem?.ToString() ?? "Trạm 110kV Hà Đông";
    }

    /// <summary>
    /// Cấu hình DataGridView (dgvGridLogs) thủ công hoàn toàn bằng code.
    /// </summary>
    private void ConfigureGridLogs()
    {
        dgvGridLogs.Columns.Clear();
        dgvGridLogs.AutoGenerateColumns = false;
        dgvGridLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvGridLogs.EnableHeadersVisualStyles = false;
        dgvGridLogs.ColumnHeadersHeight = 34;
        dgvGridLogs.RowTemplate.Height = 28;
        dgvGridLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 42, 74);
        dgvGridLogs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvGridLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dgvGridLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colTimestamp",
            HeaderText = "Thời điểm sự cố",
            FillWeight = 18
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colSubstation",
            HeaderText = "Trạm biến áp",
            FillWeight = 22
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colCycle",
            HeaderText = "Chu kỳ",
            FillWeight = 10,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colVoltage",
            HeaderText = "Điện áp (kV)",
            FillWeight = 14,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colLoad",
            HeaderText = "Mức tải (%)",
            FillWeight = 13,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                ForeColor = Color.Firebrick,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            }
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colStatus",
            HeaderText = "Trạng thái",
            FillWeight = 13,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                ForeColor = Color.Firebrick,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            }
        });
        dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colNote",
            HeaderText = "Cảnh báo điều độ",
            FillWeight = 25
        });
    }

    private void cboSubstation_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboSubstation.SelectedItem is string station)
        {
            _selectedSubstation = station;
        }
    }

    private void btnStartScada_Click(object? sender, EventArgs e)
    {
        if (_isMonitoring)
            return;

        _scadaCts?.Dispose();
        _scadaCts = new CancellationTokenSource();
        var token = _scadaCts.Token;

        _isMonitoring = true;
        _cycleCounter = 0;
        btnStartScada.Enabled = false;
        btnDisconnect.Enabled = true;

        lblScadaState.ForeColor = Color.FromArgb(16, 124, 65);
        lblScadaState.Text = $"● SCADA: Đang giám sát ({_selectedSubstation})";
        lblLoadAlert.Text = "Đang thu thập dữ liệu thời gian thực...";
        lblLoadAlert.ForeColor = Color.FromArgb(15, 98, 254);

        // Chạy vòng lặp ngầm định kỳ 2 giây/lần trên Background Thread
        _monitoringTask = Task.Run(() => RunScadaBackgroundLoopAsync(token), token);
    }

    /// <summary>
    /// Tiến trình chạy ngầm trên Thread phụ. Tuyệt đối KHÔNG truy cập trực tiếp UI Control tại đây.
    /// </summary>
    private async Task RunScadaBackgroundLoopAsync(CancellationToken cancellationToken)
    {
        var rng = new Random();

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                int currentCycle = Interlocked.Increment(ref _cycleCounter);
                double voltageKv = Math.Round(108.0 + rng.NextDouble() * 7.0, 2); // 108kV - 115kV
                int loadPercent = rng.Next(50, 99); // 50% - 98%

                var sample = new TelemetrySample
                {
                    SubstationName = _selectedSubstation,
                    VoltageKv = voltageKv,
                    LoadPercent = loadPercent,
                    Timestamp = DateTime.Now,
                    CycleNumber = currentCycle
                };

                // Chuyển ngữ cảnh về Main UI Thread bằng InvokeRequired + this.Invoke
                ApplyTelemetryThreadSafe(sample, cancellationToken);

                // Định kỳ 2 giây/lần
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            // Dừng vòng lặp bình thường khi người dùng nhấn Ngắt Kết nối hoặc đóng Form
        }
    }

    /// <summary>
    /// Quy tắc Thread Safety bắt buộc: kiểm tra InvokeRequired và dùng this.Invoke(new Action(...))
    /// trước khi cập nhật lblVoltage, lblLoadPercent, StatusStrip hay dgvGridLogs.
    /// </summary>
    private void ApplyTelemetryThreadSafe(TelemetrySample sample, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested || IsDisposed || Disposing || !IsHandleCreated)
            return;

        if (this.InvokeRequired)
        {
            try
            {
                this.Invoke(new Action(() => ApplyTelemetryThreadSafe(sample, cancellationToken)));
            }
            catch (ObjectDisposedException)
            {
                // Form đã đóng trong lúc thread phụ gửi gói tin
            }
            catch (InvalidOperationException)
            {
                // Handle chưa sẵn sàng hoặc đang bị hủy
            }
            return;
        }

        // Từ đây trở xuống chắc chắn đang thực thi trên Main UI Thread
        if (cancellationToken.IsCancellationRequested || IsDisposed || Disposing)
            return;

        lblVoltage.Text = $"{sample.VoltageKv:F2} kV";
        lblLoadPercent.Text = $"{sample.LoadPercent} %";
        prgLoadBar.Value = Math.Clamp(sample.LoadPercent, prgLoadBar.Minimum, prgLoadBar.Maximum);

        if (sample.IsOverload)
        {
            lblLoadPercent.ForeColor = Color.FromArgb(220, 38, 38);
            lblLoadAlert.ForeColor = Color.FromArgb(220, 38, 38);
            lblLoadAlert.Text = $"CẢNH BÁO QUÁ TẢI (> {TelemetrySample.OverloadThresholdPercent}%)!";

            int rowIndex = dgvGridLogs.Rows.Add(
                sample.Timestamp.ToString("HH:mm:ss dd/MM/yyyy"),
                sample.SubstationName,
                sample.CycleNumber,
                $"{sample.VoltageKv:F2}",
                $"{sample.LoadPercent}%",
                sample.StatusText,
                $"Vượt ngưỡng an toàn ({sample.LoadPercent}% > {TelemetrySample.OverloadThresholdPercent}%) - Cần san tải!");

            dgvGridLogs.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
            dgvGridLogs.FirstDisplayedScrollingRowIndex = rowIndex;
        }
        else
        {
            lblLoadPercent.ForeColor = Color.FromArgb(16, 124, 65);
            lblLoadAlert.ForeColor = Color.FromArgb(16, 124, 65);
            lblLoadAlert.Text = $"Trạng thái: Ổn định (≤ {TelemetrySample.OverloadThresholdPercent}%)";
        }

        lblScadaState.Text = $"● SCADA: Đang giám sát ({sample.SubstationName})";
        lblLastPacketTime.Text = $"Thời gian nhận gói tin cuối: {sample.Timestamp:HH:mm:ss}";
        lblTotalCycles.Text = $"Tổng số chu kỳ đã quét: {sample.CycleNumber}";
    }

    private void btnDisconnect_Click(object? sender, EventArgs e)
    {
        StopScadaMonitoring();
    }

    private void StopScadaMonitoring()
    {
        if (!_isMonitoring)
            return;

        _isMonitoring = false;
        _scadaCts?.Cancel();

        btnStartScada.Enabled = true;
        btnDisconnect.Enabled = false;

        if (!IsDisposed && !Disposing)
        {
            lblScadaState.ForeColor = Color.FromArgb(180, 83, 9);
            lblScadaState.Text = "● SCADA: Đã ngắt kết nối";
            lblLoadAlert.ForeColor = Color.DimGray;
            lblLoadAlert.Text = "Đã ngắt kết nối luồng giám sát SCADA.";
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _isMonitoring = false;
        _scadaCts?.Cancel();
        base.OnFormClosing(e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _scadaCts?.Dispose();
        _scadaCts = null;
        base.OnFormClosed(e);
    }
}
