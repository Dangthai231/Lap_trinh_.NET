namespace B2
{
    partial class frmInventoryManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryManager));
            menuStrip1 = new MenuStrip();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem1 = new ToolStripMenuItem();
            saveReportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            importCSVToolStripMenuItem = new ToolStripMenuItem();
            exportCSVToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblTotalQuantity = new ToolStripStatusLabel();
            lblTotalValue = new ToolStripStatusLabel();
            lblTime = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            txtProductName = new TextBox();
            label1 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            label3 = new Label();
            text2 = new Label();
            text = new Label();
            txtProductId = new TextBox();
            numQuantity = new NumericUpDown();
            cboCategory = new ComboBox();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            dgvProducts = new DataGridView();
            ofdImage = new OpenFileDialog();
            openFileDialog1 = new OpenFileDialog();
            ofdImportCSV = new OpenFileDialog();
            sfdExportCSV = new SaveFileDialog();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1748, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem1, saveReportToolStripMenuItem, exitToolStripMenuItem });
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(70, 24);
            openFileToolStripMenuItem.Text = "System";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // openFileToolStripMenuItem1
            // 
            openFileToolStripMenuItem1.Name = "openFileToolStripMenuItem1";
            openFileToolStripMenuItem1.Size = new Size(172, 26);
            openFileToolStripMenuItem1.Text = "Open File";
            openFileToolStripMenuItem1.Click += ImportCSV_Click;
            // 
            // saveReportToolStripMenuItem
            // 
            saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            saveReportToolStripMenuItem.Size = new Size(172, 26);
            saveReportToolStripMenuItem.Text = "Save Report";
            saveReportToolStripMenuItem.Click += ExportCSV_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(172, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importCSVToolStripMenuItem, exportCSVToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // importCSVToolStripMenuItem
            // 
            importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            importCSVToolStripMenuItem.Size = new Size(224, 26);
            importCSVToolStripMenuItem.Text = "Import CSV";
            importCSVToolStripMenuItem.Click += ImportCSV_Click;
            // 
            // exportCSVToolStripMenuItem
            // 
            exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            exportCSVToolStripMenuItem.Size = new Size(224, 26);
            exportCSVToolStripMenuItem.Text = "Export CSV";
            exportCSVToolStripMenuItem.Click += ExportCSV_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1748, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(29, 24);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(29, 24);
            toolStripButton4.Text = "toolStripButton4";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTotalQuantity, lblTotalValue, lblTime });
            statusStrip1.Location = new Point(0, 432);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1748, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.Name = "lblTotalQuantity";
            lblTotalQuantity.Size = new Size(78, 20);
            lblTotalQuantity.Text = "Tổng SP: 0";
            lblTotalQuantity.Click += toolStripStatusLabel1_Click;
            // 
            // lblTotalValue
            // 
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(110, 20);
            lblTotalValue.Text = "Tổng giá trị: 0đ";
            // 
            // lblTime
            // 
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(74, 20);
            lblTime.Text = "Thời gian:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(text2);
            groupBox1.Controls.Add(text);
            groupBox1.Controls.Add(txtProductId);
            groupBox1.Controls.Add(numQuantity);
            groupBox1.Controls.Add(cboCategory);
            groupBox1.Location = new Point(12, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 298);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(126, 105);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(151, 27);
            txtProductName.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 254);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 10;
            label1.Text = "Số lượng";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(126, 204);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(151, 27);
            txtPrice.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 207);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 8;
            label4.Text = "Đơn giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 166);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 7;
            label3.Text = "Loại";
            // 
            // text2
            // 
            text2.AutoSize = true;
            text2.Location = new Point(13, 104);
            text2.Name = "text2";
            text2.Size = new Size(100, 20);
            text2.TabIndex = 6;
            text2.Text = "Tên sản phẩm";
            // 
            // text
            // 
            text.AutoSize = true;
            text.Location = new Point(13, 45);
            text.Name = "text";
            text.Size = new Size(98, 20);
            text.TabIndex = 5;
            text.Text = "Mã sản phẩm";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(127, 38);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(151, 27);
            txtProductId.TabIndex = 4;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(127, 252);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 27);
            numQuantity.TabIndex = 2;
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(127, 158);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 1;
            // 
            // picProductImage
            // 
            picProductImage.Location = new Point(330, 39);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(940, 317);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 11;
            picProductImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(667, 369);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(256, 29);
            btnChooseImage.TabIndex = 12;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(1381, 58);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(300, 188);
            dgvProducts.TabIndex = 13;
            // 
            // ofdImage
            // 
            ofdImage.FileName = "openFileDialog1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // ofdImportCSV
            // 
            ofdImportCSV.FileName = "openFileDialog2";
            // 
            // sfdExportCSV
            // 
            sfdExportCSV.FileOk += sfdExportCSV_FileOk;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1395, 281);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(1525, 284);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1525, 331);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 16;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1395, 331);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmInventoryManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1748, 458);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvProducts);
            Controls.Add(btnChooseImage);
            Controls.Add(picProductImage);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmInventoryManager";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem1;
        private ToolStripMenuItem saveReportToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem importCSVToolStripMenuItem;
        private ToolStripMenuItem exportCSVToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTotalQuantity;
        private ToolStripStatusLabel lblTotalValue;
        private ToolStripStatusLabel lblTime;
        private GroupBox groupBox1;
        private NumericUpDown numQuantity;
        private ComboBox cboCategory;
        private Label label4;
        private Label label3;
        private Label text2;
        private Label text;
        private TextBox txtProductId;
        private TextBox txtPrice;
        private Label label1;
        private PictureBox picProductImage;
        private Button btnChooseImage;
        private DataGridView dgvProducts;
        private OpenFileDialog ofdImage;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog ofdImportCSV;
        private SaveFileDialog sfdExportCSV;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private TextBox txtProductName;
    }
}
