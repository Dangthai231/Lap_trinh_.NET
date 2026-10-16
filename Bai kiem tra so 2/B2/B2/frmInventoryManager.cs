using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace B2
{

    public partial class frmInventoryManager : Form
    {
        private BindingList<Product> productList;
        private BindingSource bindingSource;
        private int productIdCounter = 1;

        public frmInventoryManager()
        {
            InitializeComponent();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void UpdateStatusStrip()
        {
            int totalQuantity = productList.Sum(p => p.Quantity);
            decimal totalValue = productList.Sum(p => p.Price * p.Quantity);

            lblTotalQuantity.Text = "Tổng SP: " + totalQuantity;
            lblTotalValue.Text = "Tổng giá trị: " + totalValue.ToString("C0");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox data
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện" });

            // Setup Binding
            productList = new BindingList<Product>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = productList;

            // Setup DataGridView
            SetupDataGridView();
            dgvProducts.DataSource = bindingSource;

            // Event Handlers
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            this.FormClosing += Form1_FormClosing;

            // Initialize Timer for real-time clock
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateStatusStrip();
        }
        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên sản phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại", Width = 100 });

            DataGridViewTextBoxColumn priceCol = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", Width = 100 };
            priceCol.DefaultCellStyle.Format = "C0";
            dgvProducts.Columns.Add(priceCol);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ImagePath", HeaderText = "Đường dẫn ảnh", Width = 150 });
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                picProductImage.Image = Image.FromFile(ofdImage.FileName);
                picProductImage.Tag = ofdImage.FileName; // Store path temporarily
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Product newProduct = new Product
            {
                ProductId = "SP" + productIdCounter.ToString("D3"),
                ProductName = text2.Text.Trim(),
                Category = cboCategory.SelectedItem.ToString(),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value,
                ImagePath = picProductImage.Tag?.ToString() ?? ""
            };

            productIdCounter++;
            productList.Add(newProduct);
            UpdateStatusStrip();
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || !ValidateInput()) return;

            Product selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            selectedProduct.ProductName = text2.Text.Trim();
            selectedProduct.Category = cboCategory.SelectedItem.ToString();
            selectedProduct.Price = decimal.Parse(txtPrice.Text);
            selectedProduct.Quantity = (int)numQuantity.Value;
            selectedProduct.ImagePath = picProductImage.Tag?.ToString() ?? selectedProduct.ImagePath;

            bindingSource.ResetBindings(false);
            UpdateStatusStrip();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            Product selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc muốn xóa '{selectedProduct.ProductName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                productList.Remove(selectedProduct);
                UpdateStatusStrip();
                btnClear_Click(sender, e);
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
            dgvProducts.ClearSelection();
        }
        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem != null)
            {
                Product selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
                text.Text = selectedProduct.ProductId;
                text2.Text = selectedProduct.ProductName;
                cboCategory.SelectedItem = selectedProduct.Category;
                txtPrice.Text = selectedProduct.Price.ToString();
                numQuantity.Value = selectedProduct.Quantity;

                if (!string.IsNullOrEmpty(selectedProduct.ImagePath) && File.Exists(selectedProduct.ImagePath))
                {
                    picProductImage.Image = Image.FromFile(selectedProduct.ImagePath);
                    picProductImage.Tag = selectedProduct.ImagePath;
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
            // Basic validation logic (expand as needed, similar to Exercise 1)
            if (string.IsNullOrWhiteSpace(text2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.");
                return false;
            }
            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.");
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal p) || p < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return false;
            }
            return true;
        }

        // CSV Export/Import Methods
        private void ExportCSV_Click(object sender, EventArgs e)
        {
            sfdExportCSV.Filter = "CSV files (*.csv)|*.csv";
            if (sfdExportCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfdExportCSV.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("ProductId,ProductName,Category,Price,Quantity,ImagePath");
                    foreach (var p in productList)
                    {
                        sw.WriteLine($"{p.ProductId},{p.ProductName},{p.Category},{p.Price},{p.Quantity},{p.ImagePath}");
                    }
                }
                MessageBox.Show("Xuất file thành công!");
            }
        }

        private void ImportCSV_Click(object sender, EventArgs e)
        {
            ofdImportCSV.Filter = "CSV files (*.csv)|*.csv";
            if (ofdImportCSV.ShowDialog() == DialogResult.OK)
            {
                productList.Clear();
                string[] lines = File.ReadAllLines(ofdImportCSV.FileName);

                for (int i = 1; i < lines.Length; i++) // Bỏ qua dòng tiêu đề
                {
                    // NÂNG CẤP 1: Cắt cột bằng cả dấu phẩy (',') HOẶC dấu chấm phẩy (';')
                    string[] parts = lines[i].Split(new char[] { ',', ';' });

                    // NÂNG CẤP 2: Chấp nhận file cũ có 5 cột hoặc file mới có 6 cột trở lên
                    if (parts.Length >= 5)
                    {
                        productList.Add(new Product
                        {
                            ProductId = parts[0],
                            ProductName = parts[1],
                            Category = parts[2],
                            Price = decimal.Parse(parts[3]),
                            Quantity = int.Parse(parts[4]),
                            // Nếu có cột thứ 6 (ảnh) thì lấy, không có thì để trống ""
                            ImagePath = parts.Length >= 6 ? parts[5] : ""
                        });
                    }
                }

                // Cập nhật lại giao diện
                bindingSource.ResetBindings(false);
                UpdateStatusStrip();
                MessageBox.Show("Nhập file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // This will trigger Form1_FormClosing
        }

        private void sfdExportCSV_FileOk(object sender, CancelEventArgs e)
        {
            sfdExportCSV.Filter = "CSV files (*.csv)|*.csv";
            if (sfdExportCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfdExportCSV.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("ProductId,ProductName,Category,Price,Quantity,ImagePath");
                    foreach (var p in productList)
                    {
                        sw.WriteLine($"{p.ProductId},{p.ProductName},{p.Category},{p.Price},{p.Quantity},{p.ImagePath}");
                    }
                }
                MessageBox.Show("Xuất file thành công!");
            }
        }
    }
}
