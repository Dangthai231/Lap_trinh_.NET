namespace Bai5_4
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
            splMain = new SplitContainer();
            tvDepartments = new TreeView();
            imgTree = new ImageList(components);
            lsvEmployees = new ListView();
            colMaNV = new ColumnHeader();
            colHoTen = new ColumnHeader();
            colChucVu = new ColumnHeader();
            colNgayVaoLam = new ColumnHeader();
            colNhom = new ColumnHeader();
            imgLarge = new ImageList(components);
            imgSmall = new ImageList(components);
            pnlTop = new Panel();
            lblTieuDe = new Label();
            lblCheDoXem = new Label();
            cboView = new ComboBox();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splMain).BeginInit();
            splMain.Panel1.SuspendLayout();
            splMain.Panel2.SuspendLayout();
            splMain.SuspendLayout();
            pnlTop.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            //
            // splMain
            //
            splMain.Dock = DockStyle.Fill;
            splMain.Location = new Point(0, 0);
            splMain.Name = "splMain";
            //
            // splMain.Panel1
            //
            splMain.Panel1.Controls.Add(tvDepartments);
            splMain.Panel1.Padding = new Padding(6, 6, 0, 6);
            splMain.Panel1MinSize = 180;
            //
            // splMain.Panel2
            //
            splMain.Panel2.Controls.Add(lsvEmployees);
            splMain.Panel2.Controls.Add(pnlTop);
            splMain.Panel2.Padding = new Padding(0, 0, 6, 6);
            splMain.Size = new Size(984, 539);
            splMain.SplitterDistance = 270;
            splMain.TabIndex = 0;
            //
            // tvDepartments
            //
            tvDepartments.Dock = DockStyle.Fill;
            tvDepartments.FullRowSelect = true;
            tvDepartments.HideSelection = false;
            tvDepartments.ImageIndex = 0;
            tvDepartments.ImageList = imgTree;
            tvDepartments.ItemHeight = 24;
            tvDepartments.Name = "tvDepartments";
            tvDepartments.SelectedImageIndex = 0;
            tvDepartments.TabIndex = 0;
            tvDepartments.AfterSelect += tvDepartments_AfterSelect;
            //
            // imgTree
            //
            imgTree.ColorDepth = ColorDepth.Depth32Bit;
            imgTree.ImageSize = new Size(16, 16);
            imgTree.TransparentColor = Color.Transparent;
            //
            // lsvEmployees
            //
            lsvEmployees.Columns.AddRange(new ColumnHeader[] { colMaNV, colHoTen, colChucVu, colNgayVaoLam, colNhom });
            lsvEmployees.Dock = DockStyle.Fill;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.LargeImageList = imgLarge;
            lsvEmployees.MultiSelect = false;
            lsvEmployees.Name = "lsvEmployees";
            lsvEmployees.SmallImageList = imgSmall;
            lsvEmployees.TabIndex = 1;
            lsvEmployees.UseCompatibleStateImageBehavior = false;
            lsvEmployees.View = View.Details;
            //
            // colMaNV
            //
            colMaNV.Text = "Mã NV";
            colMaNV.Width = 90;
            //
            // colHoTen
            //
            colHoTen.Text = "Họ Tên";
            colHoTen.Width = 190;
            //
            // colChucVu
            //
            colChucVu.Text = "Chức vụ";
            colChucVu.Width = 150;
            //
            // colNgayVaoLam
            //
            colNgayVaoLam.Text = "Ngày vào làm";
            colNgayVaoLam.TextAlign = HorizontalAlignment.Center;
            colNgayVaoLam.Width = 110;
            //
            // colNhom
            //
            colNhom.Text = "Nhóm";
            colNhom.Width = 140;
            //
            // imgLarge
            //
            imgLarge.ColorDepth = ColorDepth.Depth32Bit;
            imgLarge.ImageSize = new Size(32, 32);
            imgLarge.TransparentColor = Color.Transparent;
            //
            // imgSmall
            //
            imgSmall.ColorDepth = ColorDepth.Depth32Bit;
            imgSmall.ImageSize = new Size(16, 16);
            imgSmall.TransparentColor = Color.Transparent;
            //
            // pnlTop
            //
            pnlTop.Controls.Add(lblTieuDe);
            pnlTop.Controls.Add(lblCheDoXem);
            pnlTop.Controls.Add(cboView);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(704, 44);
            pnlTop.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTieuDe.AutoEllipsis = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.SteelBlue;
            lblTieuDe.Location = new Point(4, 10);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(430, 24);
            lblTieuDe.Text = "Danh sách nhân viên";
            //
            // lblCheDoXem
            //
            lblCheDoXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCheDoXem.AutoSize = true;
            lblCheDoXem.Location = new Point(444, 14);
            lblCheDoXem.Name = "lblCheDoXem";
            lblCheDoXem.Text = "Chế độ xem:";
            //
            // cboView
            //
            cboView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboView.DropDownStyle = ComboBoxStyle.DropDownList;
            cboView.Items.AddRange(new object[] { "Details", "SmallIcon", "LargeIcon", "Tile", "List" });
            cboView.Location = new Point(530, 10);
            cboView.Name = "cboView";
            cboView.Size = new Size(170, 23);
            cboView.TabIndex = 0;
            cboView.SelectedIndexChanged += cboView_SelectedIndexChanged;
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 22);
            statusStrip1.TabIndex = 1;
            //
            // lblTrangThai
            //
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(300, 17);
            lblTrangThai.Text = "Chọn công ty / phòng ban / nhóm ở cây bên trái để xem nhân viên.";
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(splMain);
            Controls.Add(statusStrip1);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5.4 - Quản lý nhân viên theo phòng ban";
            Load += Form1_Load;
            splMain.Panel1.ResumeLayout(false);
            splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splMain).EndInit();
            splMain.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splMain;
        private TreeView tvDepartments;
        private ImageList imgTree;
        private ListView lsvEmployees;
        private ColumnHeader colMaNV;
        private ColumnHeader colHoTen;
        private ColumnHeader colChucVu;
        private ColumnHeader colNgayVaoLam;
        private ColumnHeader colNhom;
        private ImageList imgLarge;
        private ImageList imgSmall;
        private Panel pnlTop;
        private Label lblTieuDe;
        private Label lblCheDoXem;
        private ComboBox cboView;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
    }
}
