namespace Bai5_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCategory = new Label();
            cboCategory = new ComboBox();
            grpAvailable = new GroupBox();
            lstAvailableServices = new ListBox();
            btnSelect = new Button();
            btnRemove = new Button();
            btnClearAll = new Button();
            grpSelected = new GroupBox();
            lstSelectedServices = new ListBox();
            grpTinhTien = new GroupBox();
            lblTongTien = new Label();
            lblTongTienValue = new Label();
            lblChietKhau = new Label();
            nudChietKhau = new NumericUpDown();
            lblTienGiam = new Label();
            lblTienGiamValue = new Label();
            lblMaGiamGia = new Label();
            txtMaGiamGia = new TextBox();
            btnApDung = new Button();
            lblThanhTien = new Label();
            lblThanhTienValue = new Label();
            grpAvailable.SuspendLayout();
            grpSelected.SuspendLayout();
            grpTinhTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudChietKhau).BeginInit();
            SuspendLayout();
            //
            // lblCategory
            //
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(14, 16);
            lblCategory.Name = "lblCategory";
            lblCategory.Text = "Loại dịch vụ:";
            //
            // cboCategory
            //
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[] { "Khám bệnh", "Xét nghiệm", "Chụp X-Quang", "Vắc-xin" });
            cboCategory.Location = new Point(105, 12);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(220, 23);
            cboCategory.TabIndex = 0;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            //
            // grpAvailable
            //
            grpAvailable.Controls.Add(lstAvailableServices);
            grpAvailable.Location = new Point(12, 46);
            grpAvailable.Name = "grpAvailable";
            grpAvailable.Size = new Size(320, 300);
            grpAvailable.TabIndex = 1;
            grpAvailable.TabStop = false;
            grpAvailable.Text = "Dịch vụ hiện có";
            //
            // lstAvailableServices
            //
            lstAvailableServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstAvailableServices.IntegralHeight = false;
            lstAvailableServices.Location = new Point(10, 22);
            lstAvailableServices.Size = new Size(300, 268);
            lstAvailableServices.ItemHeight = 15;
            lstAvailableServices.Name = "lstAvailableServices";
            lstAvailableServices.TabIndex = 0;
            lstAvailableServices.DoubleClick += lstAvailableServices_DoubleClick;
            //
            // btnSelect
            //
            btnSelect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSelect.Location = new Point(344, 120);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(56, 36);
            btnSelect.TabIndex = 2;
            btnSelect.Text = ">";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            //
            // btnRemove
            //
            btnRemove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemove.Location = new Point(344, 166);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(56, 36);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            //
            // btnClearAll
            //
            btnClearAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearAll.Location = new Point(344, 212);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(56, 36);
            btnClearAll.TabIndex = 4;
            btnClearAll.Text = "<<";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            //
            // grpSelected
            //
            grpSelected.Controls.Add(lstSelectedServices);
            grpSelected.Location = new Point(412, 46);
            grpSelected.Name = "grpSelected";
            grpSelected.Size = new Size(340, 300);
            grpSelected.TabIndex = 5;
            grpSelected.TabStop = false;
            grpSelected.Text = "Dịch vụ đã chọn";
            //
            // lstSelectedServices
            //
            lstSelectedServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstSelectedServices.IntegralHeight = false;
            lstSelectedServices.Location = new Point(10, 22);
            lstSelectedServices.Size = new Size(320, 268);
            lstSelectedServices.ItemHeight = 15;
            lstSelectedServices.Name = "lstSelectedServices";
            lstSelectedServices.TabIndex = 0;
            lstSelectedServices.DoubleClick += lstSelectedServices_DoubleClick;
            //
            // grpTinhTien
            //
            grpTinhTien.Controls.Add(lblTongTien);
            grpTinhTien.Controls.Add(lblTongTienValue);
            grpTinhTien.Controls.Add(lblChietKhau);
            grpTinhTien.Controls.Add(nudChietKhau);
            grpTinhTien.Controls.Add(lblTienGiam);
            grpTinhTien.Controls.Add(lblTienGiamValue);
            grpTinhTien.Controls.Add(lblMaGiamGia);
            grpTinhTien.Controls.Add(txtMaGiamGia);
            grpTinhTien.Controls.Add(btnApDung);
            grpTinhTien.Controls.Add(lblThanhTien);
            grpTinhTien.Controls.Add(lblThanhTienValue);
            grpTinhTien.Location = new Point(12, 356);
            grpTinhTien.Name = "grpTinhTien";
            grpTinhTien.Size = new Size(740, 132);
            grpTinhTien.TabIndex = 6;
            grpTinhTien.TabStop = false;
            grpTinhTien.Text = "Tính tiền";
            //
            // lblTongTien
            //
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(16, 30);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Text = "Tổng tiền chưa giảm:";
            //
            // lblTongTienValue
            //
            lblTongTienValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongTienValue.Location = new Point(165, 30);
            lblTongTienValue.Name = "lblTongTienValue";
            lblTongTienValue.Size = new Size(160, 18);
            lblTongTienValue.Text = "0 đ";
            lblTongTienValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblChietKhau
            //
            lblChietKhau.AutoSize = true;
            lblChietKhau.Location = new Point(400, 30);
            lblChietKhau.Name = "lblChietKhau";
            lblChietKhau.Text = "Tỷ lệ chiết khấu (%):";
            //
            // nudChietKhau
            //
            nudChietKhau.Location = new Point(540, 27);
            nudChietKhau.Name = "nudChietKhau";
            nudChietKhau.Size = new Size(70, 23);
            nudChietKhau.TabIndex = 0;
            nudChietKhau.TextAlign = HorizontalAlignment.Right;
            nudChietKhau.ValueChanged += nudChietKhau_ValueChanged;
            //
            // lblTienGiam
            //
            lblTienGiam.AutoSize = true;
            lblTienGiam.Location = new Point(16, 62);
            lblTienGiam.Name = "lblTienGiam";
            lblTienGiam.Text = "Tiền được giảm:";
            //
            // lblTienGiamValue
            //
            lblTienGiamValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTienGiamValue.Location = new Point(165, 62);
            lblTienGiamValue.Name = "lblTienGiamValue";
            lblTienGiamValue.Size = new Size(160, 18);
            lblTienGiamValue.Text = "0 đ";
            lblTienGiamValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblMaGiamGia
            //
            lblMaGiamGia.AutoSize = true;
            lblMaGiamGia.Location = new Point(400, 62);
            lblMaGiamGia.Name = "lblMaGiamGia";
            lblMaGiamGia.Text = "Mã giảm giá:";
            //
            // txtMaGiamGia
            //
            txtMaGiamGia.CharacterCasing = CharacterCasing.Upper;
            txtMaGiamGia.Location = new Point(540, 59);
            txtMaGiamGia.Name = "txtMaGiamGia";
            txtMaGiamGia.Size = new Size(100, 23);
            txtMaGiamGia.TabIndex = 1;
            //
            // btnApDung
            //
            btnApDung.Location = new Point(648, 58);
            btnApDung.Name = "btnApDung";
            btnApDung.Size = new Size(78, 25);
            btnApDung.TabIndex = 2;
            btnApDung.Text = "Áp dụng";
            btnApDung.UseVisualStyleBackColor = true;
            btnApDung.Click += btnApDung_Click;
            //
            // lblThanhTien
            //
            lblThanhTien.AutoSize = true;
            lblThanhTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThanhTien.Location = new Point(16, 96);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.Text = "Thành tiền thanh toán:";
            //
            // lblThanhTienValue
            //
            lblThanhTienValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblThanhTienValue.ForeColor = Color.Firebrick;
            lblThanhTienValue.Location = new Point(165, 93);
            lblThanhTienValue.Name = "lblThanhTienValue";
            lblThanhTienValue.Size = new Size(160, 24);
            lblThanhTienValue.Text = "0 đ";
            lblThanhTienValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 500);
            Controls.Add(lblCategory);
            Controls.Add(cboCategory);
            Controls.Add(grpAvailable);
            Controls.Add(btnSelect);
            Controls.Add(btnRemove);
            Controls.Add(btnClearAll);
            Controls.Add(grpSelected);
            Controls.Add(grpTinhTien);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5.2 - Bảng tính tiền dịch vụ và chiết khấu";
            grpAvailable.ResumeLayout(false);
            grpSelected.ResumeLayout(false);
            grpTinhTien.ResumeLayout(false);
            grpTinhTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudChietKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategory;
        private ComboBox cboCategory;
        private GroupBox grpAvailable;
        private ListBox lstAvailableServices;
        private Button btnSelect;
        private Button btnRemove;
        private Button btnClearAll;
        private GroupBox grpSelected;
        private ListBox lstSelectedServices;
        private GroupBox grpTinhTien;
        private Label lblTongTien;
        private Label lblTongTienValue;
        private Label lblChietKhau;
        private NumericUpDown nudChietKhau;
        private Label lblTienGiam;
        private Label lblTienGiamValue;
        private Label lblMaGiamGia;
        private TextBox txtMaGiamGia;
        private Button btnApDung;
        private Label lblThanhTien;
        private Label lblThanhTienValue;
    }
}
