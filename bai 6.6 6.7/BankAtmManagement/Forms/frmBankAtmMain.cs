namespace BankAtmManagement.Forms;

/// <summary>
/// Form Cha MDI điều hành mạng lưới cây ATM ngân hàng.
/// </summary>
public partial class frmBankAtmMain : Form
{
    private string _currentTeller = "Trần Hoàng Nam (GDV-001)";

    public frmBankAtmMain()
    {
        InitializeComponent();
        ApplyMdiBackgroundStyle();
        UpdateSessionDisplay(isConnected: true, tellerName: _currentTeller);
    }

    private void ApplyMdiBackgroundStyle()
    {
        foreach (Control ctrl in Controls)
        {
            if (ctrl is MdiClient mdiClient)
            {
                mdiClient.BackColor = Color.FromArgb(228, 234, 243);
                break;
            }
        }
    }

    /// <summary>
    /// Điều hướng MDI chuẩn mực: duyệt qua this.MdiChildren, nếu đã tồn tại thì Activate(),
    /// nếu chưa có thì khởi tạo mới, gán MdiParent = this và hiển thị.
    /// </summary>
    private void OpenOrActivateChild<T>(Func<T> factory) where T : Form
    {
        foreach (Form child in MdiChildren)
        {
            if (child is T existing)
            {
                if (existing.WindowState == FormWindowState.Minimized)
                    existing.WindowState = FormWindowState.Normal;

                existing.Activate();
                return;
            }
        }

        T newForm = factory();
        newForm.MdiParent = this;
        newForm.Show();
    }

    /// <summary>
    /// Cập nhật thanh tiến trình ToolStripProgressBar trên StatusStrip của Form cha từ tiến trình đối soát.
    /// </summary>
    public void UpdateReconciliationProgress(int percent, string statusText)
    {
        if (IsDisposed || Disposing)
            return;

        if (InvokeRequired)
        {
            BeginInvoke(() => UpdateReconciliationProgress(percent, statusText));
            return;
        }

        int clamped = Math.Clamp(percent, prgReconciliation.Minimum, prgReconciliation.Maximum);
        prgReconciliation.Value = clamped;
        lblProgressText.Text = statusText;
    }

    private void UpdateSessionDisplay(bool isConnected, string tellerName, string? customCoreText = null)
    {
        lblTeller.Text = string.IsNullOrWhiteSpace(tellerName)
            ? "Giao dịch viên trực: (Chưa đăng nhập)"
            : $"Giao dịch viên trực: {tellerName}";

        if (isConnected)
        {
            lblCoreStatus.ForeColor = Color.FromArgb(16, 124, 65);
            lblCoreStatus.Text = customCoreText ?? "● Core Banking: Đã kết nối (Online)";
        }
        else
        {
            lblCoreStatus.ForeColor = Color.Firebrick;
            lblCoreStatus.Text = customCoreText ?? "● Core Banking: Ngắt kết nối (Offline)";
        }
    }

    private void mnuAtmStations_Click(object? sender, EventArgs e)
    {
        OpenOrActivateChild(() => new frmAtmStations());
    }

    private void mnuAtmReconciliation_Click(object? sender, EventArgs e)
    {
        OpenOrActivateChild(() => new frmAtmReconciliation());
    }

    private void mnuCascade_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void mnuTileHorizontal_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void mnuTileVertical_Click(object? sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }

    private void mnuCloseAll_Click(object? sender, EventArgs e)
    {
        foreach (Form child in MdiChildren.ToArray())
        {
            child.Close();
        }
    }

    private void mnuLockScreen_Click(object? sender, EventArgs e)
    {
        UpdateSessionDisplay(isConnected: false, tellerName: _currentTeller, "● Core Banking: Đang khóa màn hình");

        using var lockDialog = new frmLogin(AuthDialogMode.LockScreen, _currentTeller);
        if (lockDialog.ShowDialog(this) == DialogResult.OK)
        {
            _currentTeller = lockDialog.AuthenticatedTellerName;
            UpdateSessionDisplay(isConnected: true, tellerName: _currentTeller);
        }
        else
        {
            Application.Exit();
        }
    }

    private void mnuLogout_Click(object? sender, EventArgs e)
    {
        var confirm = MessageBox.Show(
            "Bạn có muốn đăng xuất phiên làm việc hiện tại và đóng toàn bộ cửa sổ nghiệp vụ không?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
            return;

        foreach (Form child in MdiChildren.ToArray())
        {
            child.Close();
        }

        UpdateSessionDisplay(isConnected: false, tellerName: string.Empty);
        UpdateReconciliationProgress(0, "Tiến độ đối soát: Sẵn sàng");

        using var loginDialog = new frmLogin(AuthDialogMode.Login, _currentTeller);
        if (loginDialog.ShowDialog(this) == DialogResult.OK)
        {
            _currentTeller = loginDialog.AuthenticatedTellerName;
            UpdateSessionDisplay(isConnected: true, tellerName: _currentTeller);
        }
        else
        {
            Application.Exit();
        }
    }

    private void mnuExit_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
