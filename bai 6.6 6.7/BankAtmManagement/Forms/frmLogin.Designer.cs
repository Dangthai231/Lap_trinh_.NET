#nullable enable
namespace BankAtmManagement.Forms;

partial class frmLogin
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.pnlHeader = new Panel();
        this.lblTitle = new Label();
        this.lblSubtitle = new Label();
        this.lblTellerLabel = new Label();
        this.txtTellerName = new TextBox();
        this.lblPasswordLabel = new Label();
        this.txtPassword = new TextBox();
        this.lblHint = new Label();
        this.lblError = new Label();
        this.btnConfirm = new Button();
        this.btnCancel = new Button();
        this.pnlHeader.SuspendLayout();
        this.SuspendLayout();

        // pnlHeader
        this.pnlHeader.BackColor = Color.FromArgb(15, 52, 96);
        this.pnlHeader.Controls.Add(this.lblSubtitle);
        this.pnlHeader.Controls.Add(this.lblTitle);
        this.pnlHeader.Dock = DockStyle.Top;
        this.pnlHeader.Location = new Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new Size(420, 76);
        this.pnlHeader.TabIndex = 0;

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.White;
        this.lblTitle.Location = new Point(20, 14);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(250, 25);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG ATM";

        // lblSubtitle
        this.lblSubtitle.AutoSize = true;
        this.lblSubtitle.Font = new Font("Segoe UI", 9F);
        this.lblSubtitle.ForeColor = Color.FromArgb(190, 215, 245);
        this.lblSubtitle.Location = new Point(22, 44);
        this.lblSubtitle.Name = "lblSubtitle";
        this.lblSubtitle.Size = new Size(270, 15);
        this.lblSubtitle.TabIndex = 1;
        this.lblSubtitle.Text = "Xác thực Giao dịch viên điều hành mạng lưới ATM";

        // lblTellerLabel
        this.lblTellerLabel.AutoSize = true;
        this.lblTellerLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblTellerLabel.Location = new Point(24, 96);
        this.lblTellerLabel.Name = "lblTellerLabel";
        this.lblTellerLabel.Size = new Size(140, 17);
        this.lblTellerLabel.TabIndex = 1;
        this.lblTellerLabel.Text = "Tên Giao dịch viên:";

        // txtTellerName
        this.txtTellerName.Font = new Font("Segoe UI", 10F);
        this.txtTellerName.Location = new Point(24, 118);
        this.txtTellerName.Name = "txtTellerName";
        this.txtTellerName.Size = new Size(370, 25);
        this.txtTellerName.TabIndex = 2;

        // lblPasswordLabel
        this.lblPasswordLabel.AutoSize = true;
        this.lblPasswordLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblPasswordLabel.Location = new Point(24, 155);
        this.lblPasswordLabel.Name = "lblPasswordLabel";
        this.lblPasswordLabel.Size = new Size(80, 17);
        this.lblPasswordLabel.TabIndex = 3;
        this.lblPasswordLabel.Text = "Mật khẩu:";

        // txtPassword
        this.txtPassword.Font = new Font("Segoe UI", 10F);
        this.txtPassword.Location = new Point(24, 177);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new Size(370, 25);
        this.txtPassword.TabIndex = 4;
        this.txtPassword.UseSystemPasswordChar = true;

        // lblHint
        this.lblHint.AutoSize = true;
        this.lblHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        this.lblHint.ForeColor = Color.DimGray;
        this.lblHint.Location = new Point(24, 208);
        this.lblHint.Name = "lblHint";
        this.lblHint.Size = new Size(220, 15);
        this.lblHint.TabIndex = 5;
        this.lblHint.Text = "Mật khẩu mặc định (demo): 123456";

        // lblError
        this.lblError.AutoSize = true;
        this.lblError.Font = new Font("Segoe UI", 9F);
        this.lblError.ForeColor = Color.Firebrick;
        this.lblError.Location = new Point(24, 232);
        this.lblError.Name = "lblError";
        this.lblError.Size = new Size(0, 15);
        this.lblError.TabIndex = 6;

        // btnConfirm
        this.btnConfirm.BackColor = Color.FromArgb(15, 98, 254);
        this.btnConfirm.FlatStyle = FlatStyle.Flat;
        this.btnConfirm.FlatAppearance.BorderSize = 0;
        this.btnConfirm.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.btnConfirm.ForeColor = Color.White;
        this.btnConfirm.Location = new Point(164, 260);
        this.btnConfirm.Name = "btnConfirm";
        this.btnConfirm.Size = new Size(125, 34);
        this.btnConfirm.TabIndex = 7;
        this.btnConfirm.Text = "Đăng nhập";
        this.btnConfirm.UseVisualStyleBackColor = false;
        this.btnConfirm.Click += this.btnConfirm_Click;

        // btnCancel
        this.btnCancel.BackColor = Color.FromArgb(230, 234, 240);
        this.btnCancel.FlatStyle = FlatStyle.Flat;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.Font = new Font("Segoe UI", 9.5F);
        this.btnCancel.ForeColor = Color.FromArgb(40, 48, 60);
        this.btnCancel.Location = new Point(297, 260);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new Size(97, 34);
        this.btnCancel.TabIndex = 8;
        this.btnCancel.Text = "Thoát";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += this.btnCancel_Click;

        // frmLogin
        this.AcceptButton = this.btnConfirm;
        this.CancelButton = this.btnCancel;
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(420, 312);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnConfirm);
        this.Controls.Add(this.lblError);
        this.Controls.Add(this.lblHint);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.lblPasswordLabel);
        this.Controls.Add(this.txtTellerName);
        this.Controls.Add(this.lblTellerLabel);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmLogin";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Xác thực Giao dịch viên";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Panel pnlHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblTellerLabel = null!;
    private TextBox txtTellerName = null!;
    private Label lblPasswordLabel = null!;
    private TextBox txtPassword = null!;
    private Label lblHint = null!;
    private Label lblError = null!;
    private Button btnConfirm = null!;
    private Button btnCancel = null!;
}
