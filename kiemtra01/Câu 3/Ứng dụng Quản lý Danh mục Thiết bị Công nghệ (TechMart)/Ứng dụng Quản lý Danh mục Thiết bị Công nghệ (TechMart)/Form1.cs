using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ứng_dụng_Quản_lý_Danh_mục_Thiết_bị_Công_nghệ__TechMart_
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _productList;
        private BindingList<Product> _filteredList;
        private BindingSource _bindingSource;
        private BindingList<Category> _categoryList;
        private bool _isUpdating;

        public Form1()
        {
            InitializeComponent();
            InitDataGridViewColumns();
            InitCategoryCombo();
            InitBindingData();
            WireEvents();
            UpdateStatusCount();
        }

        #region Khởi tạo
        private void InitDataGridViewColumns()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductId",
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductName",
                DataPropertyName = "ProductName",
                HeaderText = "Tên SP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                DataPropertyName = "Category",
                HeaderText = "Danh Mục",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            var priceCol = new DataGridViewTextBoxColumn
            {
                Name = "colUnitPrice",
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn Giá",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            priceCol.DefaultCellStyle.Format = "N0";
            priceCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(priceCol);

            var qtyCol = new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                DataPropertyName = "Quantity",
                HeaderText = "Số Lượng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            qtyCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            qtyCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(qtyCol);
        }

        private void InitCategoryCombo()
        {
            _categoryList = new BindingList<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };
            cboCategory.DataSource = _categoryList;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = 0;
        }

        private void InitBindingData()
        {
            _productList = new BindingList<Product>();
            _filteredList = _productList;
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _filteredList;
            dgvProducts.DataSource = _bindingSource;

            _productList.ListChanged += (s, e) => UpdateStatusCount();
        }

        private void WireEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnChooseImage.Click += btnChooseImage_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            exportCSVToolStripMenuItem.Click += exportCSVToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            txtProductName.Validating += ValidateProductName;
            txtUnitPrice.Validating += ValidateUnitPrice;
            txtQuantity.Validating += ValidateQuantity;
        }
        #endregion

        #region Validation với ErrorProvider
        private void ValidateProductName(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên SP không được để trống");
            }
            else
            {
                errorProvider.SetError(txtProductName, string.Empty);
            }
        }

        private void ValidateUnitPrice(object sender, CancelEventArgs e)
        {
            decimal price;
            if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out price)
                || price <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0");
            }
            else
            {
                errorProvider.SetError(txtUnitPrice, string.Empty);
            }
        }

        private void ValidateQuantity(object sender, CancelEventArgs e)
        {
            int qty;
            if (!int.TryParse(txtQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out qty)
                || qty < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên >= 0");
            }
            else
            {
                errorProvider.SetError(txtQuantity, string.Empty);
            }
        }

        private bool ValidateAll()
        {
            var ok = true;
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên SP không được để trống");
                ok = false;
            }
            decimal price;
            if (!decimal.TryParse(txtUnitPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out price)
                || price <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0");
                ok = false;
            }
            int qty;
            if (!int.TryParse(txtQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out qty)
                || qty < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên >= 0");
                ok = false;
            }
            return ok;
        }
        #endregion

        #region CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập vào!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtProductId.Text) &&
                _productList.Any(p => p.ProductId == txtProductId.Text.Trim()))
            {
                MessageBox.Show("Mã SP đã tồn tại, vui lòng nhập mã khác!", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ReadProductFromInputs();
            _productList.Add(product);
            ClearInputs();
            txtSearch.Clear();
            dgvProducts.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng trên bảng để cập nhật!", "Chưa chọn dòng",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateAll())
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu nhập vào!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var current = _bindingSource.Current as Product;
            if (current == null) return;

            var newId = txtProductId.Text.Trim();
            if (current.ProductId != newId && _productList.Any(p => p.ProductId == newId))
            {
                MessageBox.Show("Mã SP mới đã tồn tại, vui lòng nhập mã khác!", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isUpdating = true;
            current.ProductId = newId;
            current.ProductName = txtProductName.Text.Trim();
            current.UnitPrice = decimal.Parse(txtUnitPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            current.Quantity = int.Parse(txtQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            var cat = cboCategory.SelectedItem as Category;
            current.Category = cat != null ? cat.Name : string.Empty;
            current.ImagePath = picAvatar.Image != null ? (picAvatar.Tag as string ?? string.Empty) : string.Empty;
            _bindingSource.ResetBindings(false);
            _isUpdating = false;

            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng trên bảng để xóa!", "Chưa chọn dòng",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var current = _bindingSource.Current as Product;
            if (current == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm '{current.ProductName}' không?",
                "Xác nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _productList.Remove(current);
                ClearInputs();
            }
        }
        #endregion

        #region Các sự kiện khác
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var img = Image.FromFile(openFileDialog.FileName);
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = img;
                    picAvatar.Tag = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var keyword = (txtSearch.Text ?? string.Empty).Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                _filteredList = _productList;
            }
            else
            {
                var filtered = _productList
                    .Where(p => (p.ProductName ?? string.Empty).ToLower().Contains(keyword))
                    .ToList();
                _filteredList = new BindingList<Product>(filtered);
            }
            _bindingSource.DataSource = _filteredList;
            _bindingSource.ResetBindings(false);
            UpdateStatusCount();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_isUpdating) return;
            var current = _bindingSource.Current as Product;
            if (current == null) return;
            LoadProductToInputs(current);
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_productList.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống, không có gì để export!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveFileDialog.FileName = $"TechMart_Products_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng,Đường dẫn Ảnh");
                foreach (var p in _productList)
                {
                    sb.AppendFormat("{0},{1},{2},{3},{4},{5}",
                        CsvEscape(p.ProductId),
                        CsvEscape(p.ProductName),
                        CsvEscape(p.Category),
                        p.UnitPrice.ToString("N0", CultureInfo.InvariantCulture),
                        p.Quantity.ToString(),
                        CsvEscape(p.ImagePath));
                    sb.AppendLine();
                }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Export CSV thành công: " + saveFileDialog.FileName, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export CSV thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string CsvEscape(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper
        private Product ReadProductFromInputs()
        {
            var cat = cboCategory.SelectedItem as Category;
            return new Product
            {
                ProductId = txtProductId.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                UnitPrice = decimal.Parse(txtUnitPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture),
                Quantity = int.Parse(txtQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture),
                Category = cat != null ? cat.Name : string.Empty,
                ImagePath = picAvatar.Tag as string ?? string.Empty
            };
        }

        private void LoadProductToInputs(Product p)
        {
            txtProductId.Text = p.ProductId ?? string.Empty;
            txtProductName.Text = p.ProductName ?? string.Empty;
            txtUnitPrice.Text = p.UnitPrice.ToString(CultureInfo.InvariantCulture);
            txtQuantity.Text = p.Quantity.ToString();

            var cat = _categoryList.FirstOrDefault(c => c.Name == p.Category);
            if (cat != null) cboCategory.SelectedItem = cat;

            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            picAvatar.Tag = p.ImagePath;
            if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
            {
                try { picAvatar.Image = Image.FromFile(p.ImagePath); }
                catch { /* ignore */ }
            }
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "0";
            if (_categoryList.Count > 0) cboCategory.SelectedIndex = 0;
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            picAvatar.Tag = null;
            errorProvider.Clear();
        }

        private void UpdateStatusCount()
        {
            var list = _bindingSource.DataSource as ICollection<Product>;
            var count = list != null ? list.Count : (_productList != null ? _productList.Count : 0);
            lblStatusCount.Text = "Tổng số sản phẩm: " + count;
        }
        #endregion
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
