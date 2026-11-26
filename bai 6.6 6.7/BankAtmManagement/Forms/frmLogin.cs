namespace BankAtmManagement.Forms;

public enum AuthDialogMode
{
    Login,
    LockScreen
}

/// <summary>
/// Hộp thoại đăng nhập / mở khóa màn hình cho Giao dịch viên trực.
/// </summary>
public partial class frmLogin : Form
{
    private const string DemoPassword = "123456";
    private readonly AuthDialogMode _mode;

    public string AuthenticatedTellerName { get; private set; }

    public frmLogin(AuthDialogMode mode, string currentTellerName)
    {
        _mode = mode;
        AuthenticatedTellerName = currentTellerName;

        InitializeComponent();

        txtTellerName.Text = string.IsNullOrWhiteSpace(currentTellerName)
            ? "Trần Hoàng Nam (GDV-001)"
            : currentTellerName;

        if (_mode == AuthDialogMode.LockScreen)
        {
            Text = "Khóa màn hình điều hành ATM";
            lblTitle.Text = "MÀN HÌNH ĐANG BỊ KHÓA";
            lblSubtitle.Text = "Nhập mật khẩu Giao dịch viên để tiếp tục phiên làm việc";
            txtTellerName.ReadOnly = true;
            txtTellerName.BackColor = Color.FromArgb(242, 245, 249);
            btnConfirm.Text = "Mở khóa";
            btnCancel.Text = "Thoát App";
        }
        else
        {
            Text = "Đăng nhập Giao dịch viên";
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG ATM";
            lblSubtitle.Text = "Kết nối Core Banking & điều hành mạng lưới ATM";
            btnConfirm.Text = "Đăng nhập";
            btnCancel.Text = "Thoát App";
        }

        Shown += (_, _) => txtPassword.Focus();
    }

    private void btnConfirm_Click(object? sender, EventArgs e)
    {
        var teller = txtTellerName.Text.Trim();
        if (string.IsNullOrWhiteSpace(teller))
        {
            lblError.Text = "Vui lòng nhập tên Giao dịch viên.";
            txtTellerName.Focus();
            return;
        }

        if (txtPassword.Text != DemoPassword)
        {
            lblError.Text = "Mật khẩu không chính xác (demo: 123456).";
            txtPassword.SelectAll();
            txtPassword.Focus();
            return;
        }

        AuthenticatedTellerName = teller;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
