using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace B1
{
    public partial class frmDeviceManager : Form
    {
        // Sử dụng BindingList và BindingSource để hỗ trợ Data Binding 2 chiều
        private BindingList<Device> deviceList;
        private BindingSource bindingSource;
        private int deviceIdCounter = 1; // Dùng để tự động tăng ID
        public frmDeviceManager()
        {
            InitializeComponent();
        }
        private void frmDeviceManager_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo dữ liệu ComboBox
            // 1. Khởi tạo dữ liệu ComboBox
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện" });

            // 2. Cấu hình BindingSource và BindingList
            deviceList = new BindingList<Device>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = deviceList;

            // Cấu hình DataGridView bằng code
            SetupDataGridView();

            // Gán dữ liệu cho Grid
            dgvDevices.DataSource = bindingSource;

            // Xử lý sự kiện click để đổ dữ liệu ngược lên form
            dgvDevices.SelectionChanged += DgvDevices_SelectionChanged;
        }
        private void SetupDataGridView()
        {
            dgvDevices.AutoGenerateColumns = false; // Không tự động sinh cột

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeviceId",
                HeaderText = "Mã TB",
                Width = 80
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeviceName",
                HeaderText = "Tên thiết bị",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Phân bổ tỷ lệ cột hợp lý
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Loại thiết bị",
                Width = 120
            });

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn giá",
                Width = 120
            };
            priceColumn.DefaultCellStyle.Format = "C0"; // Định dạng tiền tệ
            dgvDevices.Columns.Add(priceColumn);

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Width = 80
            });
        }
        private void DgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow != null && dgvDevices.CurrentRow.DataBoundItem != null)
            {
                Device selectedDevice = (Device)dgvDevices.CurrentRow.DataBoundItem;
                txtDeviceId.Text = selectedDevice.DeviceId;
                txtDeviceName.Text = selectedDevice.DeviceName;
                cboCategory.SelectedItem = selectedDevice.Category; // Đã sửa tên ở đây
                txtPrice.Text = selectedDevice.Price.ToString();
                numQuantity.Value = selectedDevice.Quantity;
            }
        }
        // Kiểm soát dữ liệu đầu vào (Validation)
        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider1.SetError(txtDeviceName, "Tên thiết bị không được để trống.");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại thiết bị.");
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá không hợp lệ hoặc nhỏ hơn 0.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Tự động tạo mã thiết bị
            string newId = "TB" + deviceIdCounter.ToString("D3");
            deviceIdCounter++;

            Device newDevice = new Device
            {
                DeviceId = newId,
                DeviceName = txtDeviceName.Text.Trim(),
                Category = cboCategory.SelectedItem.ToString(),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value
            };

            // Thêm vào list, BindingSource tự động cập nhật DataGridView
            deviceList.Add(newDevice);
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null) return;
            if (!ValidateInput()) return;

            Device selectedDevice = (Device)dgvDevices.CurrentRow.DataBoundItem;

            // Cập nhật thông tin
            selectedDevice.DeviceName = txtDeviceName.Text.Trim();
            selectedDevice.Category = cboCategory.SelectedItem.ToString();
            selectedDevice.Price = decimal.Parse(txtPrice.Text);
            selectedDevice.Quantity = (int)numQuantity.Value;

            // Làm mới Grid để hiển thị thông tin cập nhật
            bindingSource.ResetBindings(false);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null) return;

            Device selectedDevice = (Device)dgvDevices.CurrentRow.DataBoundItem;

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thiết bị '{selectedDevice.DeviceName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                deviceList.Remove(selectedDevice);
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDeviceId.Clear();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1; 
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider1.Clear();
            dgvDevices.ClearSelection();
        }
    }
}
