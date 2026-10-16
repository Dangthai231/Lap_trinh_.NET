using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B3
{
    public partial class frmProductCatalog : Form
    {
        // Kế thừa từ Bài 1 & 2: Sử dụng BindingList và BindingSource để quản lý dữ liệu
        private BindingList<Product> products = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private int productIdCounter = 1;

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        private void frmProductCatalog_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo dữ liệu ComboBox (Kế thừa từ Bài 1 & 2)
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện" });

            // 2. Cấu hình Data Binding
            bindingSource.DataSource = products;
            
            // 3. Cấu hình DataGridView (Kế thừa từ Bài 1: AutoGenerateColumns = false)
            SetupDataGridView();
            dgvProducts.DataSource = bindingSource;

            // 4. Xử lý sự kiện đổ dữ liệu ngược lên form (Kế thừa từ Bài 1 & 2)
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;

            // Dữ liệu mẫu ban đầu
            products.Add(new Product { ProductId = "SP001", ProductName = "iPhone 15 Pro", Category = "Điện thoại", Price = 30000000, Quantity = 10 });
            productIdCounter = 2;
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên sản phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại sản phẩm", Width = 120 });
            
            DataGridViewTextBoxColumn priceCol = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", Width = 120 };
            priceCol.DefaultCellStyle.Format = "N0"; // Định dạng số nguyên
            dgvProducts.Columns.Add(priceCol);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 80 });
        }

        private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem != null)
            {
                Product selected = (Product)dgvProducts.CurrentRow.DataBoundItem;
                txtProductId.Text = selected.ProductId;
                txtProductName.Text = selected.ProductName;
                cboCategory.SelectedItem = selected.Category;
                txtPrice.Text = selected.Price.ToString();
                numQuantity.Value = selected.Quantity;

                // Kế thừa từ Bài 2: Hiển thị ảnh sản phẩm
                if (!string.IsNullOrEmpty(selected.ImagePath) && File.Exists(selected.ImagePath))
                {
                    picProductImage.Image = Image.FromFile(selected.ImagePath);
                    picProductImage.Tag = selected.ImagePath;
                }
                else
                {
                    picProductImage.Image = null;
                    picProductImage.Tag = null;
                }
            }
        }

        // Kế thừa từ Bài 1: Kiểm soát dữ liệu đầu vào (Validation & ErrorProvider)
        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống.");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại sản phẩm.");
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số dương.");
                isValid = false;
            }

            return isValid;
        }

        // Kế thừa từ Bài 2: Hộp thoại chọn ảnh
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                picProductImage.Image = Image.FromFile(ofdImage.FileName);
                picProductImage.Tag = ofdImage.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Product newProduct = new Product
            {
                ProductId = "SP" + productIdCounter.ToString("D3"),
                ProductName = txtProductName.Text.Trim(),
                Category = cboCategory.SelectedItem?.ToString() ?? "",
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value,
                ImagePath = picProductImage.Tag?.ToString() ?? ""
            };

            products.Add(newProduct);
            productIdCounter++;
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || !ValidateInput()) return;

            Product? selected = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (selected != null)
            {
                selected.ProductName = txtProductName.Text.Trim();
                selected.Category = cboCategory.SelectedItem?.ToString() ?? "";
                selected.Price = decimal.Parse(txtPrice.Text);
                selected.Quantity = (int)numQuantity.Value;
                selected.ImagePath = picProductImage.Tag?.ToString() ?? selected.ImagePath;

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            Product? selected = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (selected != null)
            {
                if (MessageBox.Show($"Xác nhận xóa sản phẩm: {selected.ProductName}?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    products.Remove(selected);
                    btnClear_Click(sender, e);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            picProductImage.Image = null;
            picProductImage.Tag = null;
            errorProvider1.Clear();
            dgvProducts.ClearSelection();
        }
    }
}
