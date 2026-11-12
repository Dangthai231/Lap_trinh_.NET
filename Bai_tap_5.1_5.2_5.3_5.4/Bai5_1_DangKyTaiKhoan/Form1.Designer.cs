namespace Bai5_1
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
            components = new System.ComponentModel.Container();
            grpTaiKhoan = new GroupBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblXacNhan = new Label();
            txtXacNhanMatKhau = new TextBox();
            grpBoSung = new GroupBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            pnlGioiTinh = new Panel();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            chkDieuKhoan = new CheckBox();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            epCheck = new ErrorProvider(components);
            grpTaiKhoan.SuspendLayout();
            grpBoSung.SuspendLayout();
            pnlGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epCheck).BeginInit();
            SuspendLayout();
            //
            // grpTaiKhoan
            //
            grpTaiKhoan.Controls.Add(lblTenDangNhap);
            grpTaiKhoan.Controls.Add(txtTenDangNhap);
            grpTaiKhoan.Controls.Add(lblMatKhau);
            grpTaiKhoan.Controls.Add(txtMatKhau);
            grpTaiKhoan.Controls.Add(lblXacNhan);
            grpTaiKhoan.Controls.Add(txtXacNhanMatKhau);
            grpTaiKhoan.Location = new Point(12, 12);
            grpTaiKhoan.Name = "grpTaiKhoan";
            grpTaiKhoan.Size = new Size(430, 135);
            grpTaiKhoan.TabIndex = 0;
            grpTaiKhoan.TabStop = false;
            grpTaiKhoan.Text = "Thông tin cá nhân";
            //
            // lblTenDangNhap
            //
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(15, 33);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Text = "Tên đăng nhập:";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(155, 30);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(240, 23);
            txtTenDangNhap.TabIndex = 0;
            txtTenDangNhap.TextChanged += O_Changed;
            //
            // lblMatKhau
            //
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(15, 66);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Text = "Mật khẩu:";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(155, 63);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(240, 23);
            txtMatKhau.TabIndex = 1;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.TextChanged += O_Changed;
            //
            // lblXacNhan
            //
            lblXacNhan.AutoSize = true;
            lblXacNhan.Location = new Point(15, 99);
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.Text = "Xác nhận mật khẩu:";
            //
            // txtXacNhanMatKhau
            //
            txtXacNhanMatKhau.Location = new Point(155, 96);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(240, 23);
            txtXacNhanMatKhau.TabIndex = 2;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.TextChanged += O_Changed;
            //
            // grpBoSung
            //
            grpBoSung.Controls.Add(lblNgaySinh);
            grpBoSung.Controls.Add(dtpNgaySinh);
            grpBoSung.Controls.Add(lblGioiTinh);
            grpBoSung.Controls.Add(pnlGioiTinh);
            grpBoSung.Controls.Add(chkDieuKhoan);
            grpBoSung.Location = new Point(12, 157);
            grpBoSung.Name = "grpBoSung";
            grpBoSung.Size = new Size(430, 135);
            grpBoSung.TabIndex = 1;
            grpBoSung.TabStop = false;
            grpBoSung.Text = "Thông tin bổ sung";
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(15, 33);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh:";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(155, 30);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(140, 23);
            dtpNgaySinh.TabIndex = 0;
            dtpNgaySinh.ValueChanged += O_Changed;
            //
            // lblGioiTinh
            //
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(15, 66);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Text = "Giới tính:";
            //
            // pnlGioiTinh
            //
            pnlGioiTinh.Controls.Add(rdoNam);
            pnlGioiTinh.Controls.Add(rdoNu);
            pnlGioiTinh.Location = new Point(155, 60);
            pnlGioiTinh.Name = "pnlGioiTinh";
            pnlGioiTinh.Size = new Size(160, 28);
            pnlGioiTinh.TabIndex = 1;
            //
            // rdoNam
            //
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(0, 4);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(60, 19);
            rdoNam.TabIndex = 0;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            rdoNam.CheckedChanged += O_Changed;
            //
            // rdoNu
            //
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(80, 4);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(60, 19);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            rdoNu.CheckedChanged += O_Changed;
            //
            // chkDieuKhoan
            //
            chkDieuKhoan.AutoSize = true;
            chkDieuKhoan.Location = new Point(18, 100);
            chkDieuKhoan.Name = "chkDieuKhoan";
            chkDieuKhoan.Size = new Size(230, 19);
            chkDieuKhoan.TabIndex = 2;
            chkDieuKhoan.Text = "Tôi đồng ý với Điều khoản dịch vụ";
            chkDieuKhoan.UseVisualStyleBackColor = true;
            chkDieuKhoan.CheckedChanged += O_Changed;
            //
            // btnDangKy
            //
            btnDangKy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDangKy.Location = new Point(110, 305);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(115, 34);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(235, 305);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(115, 34);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // epCheck
            //
            epCheck.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epCheck.ContainerControl = this;
            //
            // Form1
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 355);
            Controls.Add(grpTaiKhoan);
            Controls.Add(grpBoSung);
            Controls.Add(btnDangKy);
            Controls.Add(btnLamMoi);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5.1 - Đăng ký tài khoản";
            Load += Form1_Load;
            grpTaiKhoan.ResumeLayout(false);
            grpTaiKhoan.PerformLayout();
            grpBoSung.ResumeLayout(false);
            grpBoSung.PerformLayout();
            pnlGioiTinh.ResumeLayout(false);
            pnlGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epCheck).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpTaiKhoan;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblXacNhan;
        private TextBox txtXacNhanMatKhau;
        private GroupBox grpBoSung;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private Panel pnlGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private CheckBox chkDieuKhoan;
        private Button btnDangKy;
        private Button btnLamMoi;
        private ErrorProvider epCheck;
    }
}
