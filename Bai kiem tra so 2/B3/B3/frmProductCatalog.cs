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
        private BindingList<Product> products = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();
        private int productIdCounter = 1;

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        private void frmProductCatalog_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo dữ liệu ComboBox (Kế thừa từ B1/B2)
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện" });

            // 2. Cấu hình Binding
            bindingSource.DataSource = products;
            
            // 3. Cấu hình DataGridView
            SetupDataGridView();
            dgvProducts.DataSource = bindingSource;

            // 4. Đăng ký sự kiện
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
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại", Width = 100 });
            
            DataGridViewTextBoxColumn priceCol = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", Width = 100 };
            priceCol.DefaultCellStyle.Format = "N0";
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
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            Product? selected = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (selected != null)
            {
                if (MessageBox.Show($"Xóa sản phẩm {selected.ProductName}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
