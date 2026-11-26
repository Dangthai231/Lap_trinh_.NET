using BankAtmManagement.Models;
using BankAtmManagement.Services;

namespace BankAtmManagement.Forms;

/// <summary>
/// Form Con 1: Quản lý danh sách các trạm ATM, tồn quỹ hiện tại và ảnh chụp hiện trường.
/// </summary>
public partial class frmAtmStations : Form
{
    private string? _selectedPhotoPath;
    private bool _isBindingGrid;

    public frmAtmStations()
    {
        InitializeComponent();
        ConfigureGridAppearance();
        InitializeDropdowns();
        LoadStations();
    }

    private void ConfigureGridAppearance()
    {
        dgvStations.AutoGenerateColumns = false;
        dgvStations.EnableHeadersVisualStyles = false;
        dgvStations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 52, 96);
        dgvStations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvStations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dgvStations.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
        dgvStations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        dgvStations.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dgvStations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

        dgvStations.Columns.AddRange(
            new DataGridViewTextBoxColumn
            {
                Name = "colCode",
                DataPropertyName = nameof(AtmStation.StationCode),
                HeaderText = "Mã trạm",
                FillWeight = 16
            },
            new DataGridViewTextBoxColumn
            {
                Name = "colAddress",
                DataPropertyName = nameof(AtmStation.LocationAddress),
                HeaderText = "Địa chỉ đặt máy",
                FillWeight = 38
            },
            new DataGridViewTextBoxColumn
            {
                Name = "colBalance",
                DataPropertyName = nameof(AtmStation.CashBalance),
                HeaderText = "Tồn quỹ (VNĐ)",
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            },
            new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                DataPropertyName = nameof(AtmStation.Status),
                HeaderText = "Trạng thái",
                FillWeight = 15
            },
            new DataGridViewTextBoxColumn
            {
                Name = "colPhoto",
                DataPropertyName = nameof(AtmStation.HasPhotoDisplay),
                HeaderText = "Ảnh hiện trường",
                FillWeight = 13
            }
        );
    }

    private void InitializeDropdowns()
    {
        cboStatus.Items.AddRange(AtmDataStore.ValidStatuses);
        cboStatus.SelectedIndex = 0;

        cboStatusFilter.Items.Add("Tất cả");
        cboStatusFilter.Items.AddRange(AtmDataStore.ValidStatuses);
        cboStatusFilter.SelectedIndex = 0;
    }

    private void LoadStations(string? selectStationCode = null)
    {
        _isBindingGrid = true;
        try
        {
            var list = AtmDataStore.GetAll(txtSearch.Text, cboStatusFilter.SelectedItem?.ToString());
            dgvStations.DataSource = null;
            dgvStations.DataSource = list;

            var allStations = AtmDataStore.GetAll();
            int activeCount = allStations.Count(s => s.Status == "Hoạt động");
            decimal totalCash = allStations.Sum(s => s.CashBalance);
            lblSummary.Text = $"Tổng số trạm: {allStations.Count} (Hoạt động: {activeCount}) | Tổng tồn quỹ: {totalCash:N0} VNĐ";

            if (!string.IsNullOrWhiteSpace(selectStationCode))
            {
                foreach (DataGridViewRow row in dgvStations.Rows)
                {
                    if (row.DataBoundItem is AtmStation item &&
                        item.StationCode.Equals(selectStationCode, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        dgvStations.CurrentCell = row.Cells[0];
                        BindStationToEditor(item);
                        return;
                    }
                }
            }

            if (dgvStations.Rows.Count > 0 && dgvStations.Rows[0].DataBoundItem is AtmStation first)
            {
                dgvStations.Rows[0].Selected = true;
                BindStationToEditor(first);
            }
            else
            {
                ClearEditor();
            }
        }
        finally
        {
            _isBindingGrid = false;
        }
    }

    private void BindStationToEditor(AtmStation station)
    {
        txtStationCode.Text = station.StationCode;
        txtLocationAddress.Text = station.LocationAddress;
        numCashBalance.Value = Math.Clamp(station.CashBalance, numCashBalance.Minimum, numCashBalance.Maximum);
        cboStatus.SelectedItem = AtmDataStore.ValidStatuses.Contains(station.Status)
            ? station.Status
            : AtmDataStore.ValidStatuses[0];

        LoadPhotoPreview(station.PhotoPath);
    }

    private void ClearEditor()
    {
        txtStationCode.Clear();
        txtLocationAddress.Clear();
        numCashBalance.Value = 500_000_000m;
        cboStatus.SelectedIndex = 0;
        LoadPhotoPreview(null);
        txtStationCode.Focus();
    }

    private void LoadPhotoPreview(string? path)
    {
        _selectedPhotoPath = path;

        var previous = picStationPhoto.Image;
        picStationPhoto.Image = null;
        previous?.Dispose();

        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            try
            {
                // Đọc qua MemoryStream để tránh khóa tệp ảnh trên đĩa
                byte[] bytes = File.ReadAllBytes(path);
                using var ms = new MemoryStream(bytes);
                using var tempImage = Image.FromStream(ms);
                picStationPhoto.Image = new Bitmap(tempImage);
                lblPhotoPath.Text = path;
                lblPhotoPath.ForeColor = Color.FromArgb(22, 101, 52);
            }
            catch (Exception ex)
            {
                lblPhotoPath.Text = $"Không thể đọc ảnh: {ex.Message}";
                lblPhotoPath.ForeColor = Color.Firebrick;
                _selectedPhotoPath = null;
            }
        }
        else
        {
            lblPhotoPath.Text = "Chưa đính kèm ảnh hiện trường.";
            lblPhotoPath.ForeColor = Color.DimGray;
        }
    }

    private AtmStation BuildModelFromEditor() => new()
    {
        StationCode = txtStationCode.Text.Trim().ToUpperInvariant(),
        LocationAddress = txtLocationAddress.Text.Trim(),
        CashBalance = numCashBalance.Value,
        Status = cboStatus.SelectedItem?.ToString() ?? "Hoạt động",
        PhotoPath = _selectedPhotoPath
    };

    private void FilterChanged(object? sender, EventArgs e)
    {
        LoadStations();
    }

    private void dgvStations_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isBindingGrid)
            return;

        if (dgvStations.CurrentRow?.DataBoundItem is AtmStation station)
        {
            BindStationToEditor(station);
        }
    }

    private void dgvStations_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvStations.Columns[e.ColumnIndex].Name != "colStatus" || e.Value is null)
            return;

        string status = e.Value.ToString() ?? string.Empty;
        e.CellStyle!.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        e.CellStyle.ForeColor = status switch
        {
            "Hoạt động" => Color.FromArgb(16, 124, 65),
            "Sắp hết tiền" => Color.FromArgb(180, 83, 9),
            "Bảo trì" => Color.FromArgb(29, 78, 216),
            "Ngừng kết nối" => Color.FromArgb(185, 28, 28),
            _ => Color.Black
        };
    }

    private void btnBrowsePhoto_Click(object? sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            LoadPhotoPreview(openFileDialog.FileName);
        }
    }

    private void btnClearPhoto_Click(object? sender, EventArgs e)
    {
        LoadPhotoPreview(null);
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        var model = BuildModelFromEditor();
        var (success, message) = AtmDataStore.Add(model);
        if (!success)
        {
            MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        LoadStations(model.StationCode);
        MessageBox.Show(this, message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        var model = BuildModelFromEditor();
        var (success, message) = AtmDataStore.Update(model);
        if (!success)
        {
            MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        LoadStations(model.StationCode);
        MessageBox.Show(this, message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        var code = txtStationCode.Text.Trim();
        if (string.IsNullOrWhiteSpace(code))
        {
            MessageBox.Show(this, "Vui lòng chọn trạm ATM cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            this,
            $"Bạn có chắc chắn muốn xóa trạm ATM '{code}'?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
            return;

        var (success, message) = AtmDataStore.Delete(code);
        if (!success)
        {
            MessageBox.Show(this, message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        LoadStations();
    }

    private void btnReset_Click(object? sender, EventArgs e)
    {
        dgvStations.ClearSelection();
        ClearEditor();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        picStationPhoto.Image?.Dispose();
        picStationPhoto.Image = null;
        base.OnFormClosed(e);
    }
}
