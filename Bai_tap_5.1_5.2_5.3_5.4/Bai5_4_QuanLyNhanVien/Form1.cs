using System.Drawing.Drawing2D;

namespace Bai5_4
{
    public partial class Form1 : Form
    {
        // Danh sách toàn bộ nhân viên (dữ liệu mẫu)
        private readonly List<NhanVien> dsNhanVien = new List<NhanVien>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaoIcon();
            TaoDuLieuMau();
            TaoCayPhongBan();

            lsvEmployees.TileSize = new Size(260, 56);
            cboView.SelectedIndex = 0;          // mặc định: Details
        }

        // ===================== 1. DỮ LIỆU MẪU & CÂY PHÒNG BAN =====================

        private void TaoDuLieuMau()
        {
            ThemNV("NV001", "Nguyễn Văn An", "Trưởng nhóm", 2019, 3, 15, "N01", "Phát triển phần mềm");
            ThemNV("NV002", "Trần Thị Bích", "Lập trình viên", 2021, 6, 1, "N01", "Phát triển phần mềm");
            ThemNV("NV003", "Lê Minh Cường", "Lập trình viên", 2022, 9, 12, "N01", "Phát triển phần mềm");
            ThemNV("NV004", "Phạm Thu Dung", "Trưởng nhóm", 2020, 1, 6, "N02", "Kiểm thử");
            ThemNV("NV005", "Hoàng Đức Em", "Kiểm thử viên", 2023, 2, 20, "N02", "Kiểm thử");
            ThemNV("NV006", "Vũ Thị Giang", "Kiểm thử viên", 2024, 4, 8, "N02", "Kiểm thử");

            ThemNV("NV007", "Đặng Quốc Hải", "Trưởng nhóm", 2018, 8, 1, "N03", "Bán hàng");
            ThemNV("NV008", "Bùi Thị Hoa", "Nhân viên bán hàng", 2022, 3, 14, "N03", "Bán hàng");
            ThemNV("NV009", "Đỗ Văn Khánh", "Nhân viên bán hàng", 2023, 7, 3, "N03", "Bán hàng");
            ThemNV("NV010", "Ngô Thị Lan", "Trưởng nhóm", 2019, 11, 11, "N04", "Marketing");
            ThemNV("NV011", "Dương Minh Long", "Chuyên viên marketing", 2021, 10, 5, "N04", "Marketing");
            ThemNV("NV012", "Lý Thu Mai", "Thiết kế đồ họa", 2024, 1, 15, "N04", "Marketing");

            ThemNV("NV013", "Phan Văn Nam", "Trưởng nhóm", 2017, 5, 2, "N05", "Tuyển dụng");
            ThemNV("NV014", "Trịnh Thị Oanh", "Chuyên viên tuyển dụng", 2022, 12, 1, "N05", "Tuyển dụng");
            ThemNV("NV015", "Mai Quốc Phong", "Trưởng nhóm", 2020, 9, 9, "N06", "Đào tạo");
            ThemNV("NV016", "Hồ Thị Quyên", "Chuyên viên đào tạo", 2023, 3, 27, "N06", "Đào tạo");
        }

        private void ThemNV(string ma, string ten, string chucVu, int nam, int thang, int ngay, string maNhom, string tenNhom)
        {
            dsNhanVien.Add(new NhanVien(ma, ten, chucVu, new DateTime(nam, thang, ngay), maNhom, tenNhom));
        }

        // Công ty -> Phòng ban -> Nhóm. Tag của Node nhóm = mã nhóm.
        private void TaoCayPhongBan()
        {
            tvDepartments.BeginUpdate();
            tvDepartments.Nodes.Clear();

            TreeNode congTy = TaoNode("Công ty ABC", "CTY", 0);

            TreeNode kyThuat = TaoNode("Phòng Kỹ thuật", "PB01", 1);
            kyThuat.Nodes.Add(TaoNode("Nhóm Phát triển phần mềm", "N01", 2));
            kyThuat.Nodes.Add(TaoNode("Nhóm Kiểm thử", "N02", 2));

            TreeNode kinhDoanh = TaoNode("Phòng Kinh doanh", "PB02", 1);
            kinhDoanh.Nodes.Add(TaoNode("Nhóm Bán hàng", "N03", 2));
            kinhDoanh.Nodes.Add(TaoNode("Nhóm Marketing", "N04", 2));

            TreeNode nhanSu = TaoNode("Phòng Nhân sự", "PB03", 1);
            nhanSu.Nodes.Add(TaoNode("Nhóm Tuyển dụng", "N05", 2));
            nhanSu.Nodes.Add(TaoNode("Nhóm Đào tạo", "N06", 2));

            congTy.Nodes.Add(kyThuat);
            congTy.Nodes.Add(kinhDoanh);
            congTy.Nodes.Add(nhanSu);
            tvDepartments.Nodes.Add(congTy);

            tvDepartments.ExpandAll();
            tvDepartments.SelectedNode = null;
            tvDepartments.EndUpdate();
        }

        private static TreeNode TaoNode(string ten, string ma, int icon)
        {
            TreeNode node = new TreeNode(ten);
            node.Tag = ma;
            node.ImageIndex = icon;
            node.SelectedImageIndex = icon;
            return node;
        }

        // ===================== 2. CHỌN NODE -> LỌC NHÂN VIÊN =====================

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            // Lấy tất cả mã nhóm nằm dưới Node vừa chọn (chọn phòng ban -> lấy hết các nhóm của phòng)
            List<string> cacNhom = new List<string>();
            LayMaNhom(e.Node, cacNhom);

            List<NhanVien> ketQua = dsNhanVien.Where(nv => cacNhom.Contains(nv.MaNhom)).ToList();
            HienThiNhanVien(ketQua);

            lblTieuDe.Text = e.Node.Text;
            lblTrangThai.Text = "Đang xem: " + e.Node.FullPath.Replace("\\", " > ") + "   |   " + ketQua.Count + " nhân viên";
        }

        private static void LayMaNhom(TreeNode node, List<string> kq)
        {
            if (node.Nodes.Count == 0)
            {
                kq.Add(node.Tag as string);     // Node lá = Nhóm
                return;
            }
            foreach (TreeNode con in node.Nodes) LayMaNhom(con, kq);
        }

        private void HienThiNhanVien(List<NhanVien> ds)
        {
            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();
            foreach (NhanVien nv in ds)
            {
                ListViewItem item = new ListViewItem(nv.MaNV);
                item.SubItems.Add(nv.HoTen);
                item.SubItems.Add(nv.ChucVu);
                item.SubItems.Add(nv.NgayVaoLam.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.TenNhom);
                item.ImageIndex = nv.ChucVu.StartsWith("Trưởng") ? 1 : 0;   // trưởng nhóm có icon riêng
                item.Tag = nv;
                lsvEmployees.Items.Add(item);
            }
            lsvEmployees.EndUpdate();
        }

        // ===================== 3. ĐỔI CHẾ ĐỘ XEM =====================

        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboView.SelectedIndex)
            {
                case 0: lsvEmployees.View = View.Details; break;
                case 1: lsvEmployees.View = View.SmallIcon; break;
                case 2: lsvEmployees.View = View.LargeIcon; break;
                case 3: lsvEmployees.View = View.Tile; break;
                case 4: lsvEmployees.View = View.List; break;
            }
        }

        // ===================== ICON (vẽ bằng code, không cần file ảnh) =====================

        private void TaoIcon()
        {
            imgTree.Images.Add(VeToaNha());                               // 0: Công ty
            imgTree.Images.Add(VeThuMuc());                               // 1: Phòng ban
            imgTree.Images.Add(VeNguoi(16, Color.SeaGreen, true));         // 2: Nhóm

            imgSmall.Images.Add(VeNguoi(16, Color.SteelBlue, false));      // 0: Nhân viên
            imgSmall.Images.Add(VeNguoi(16, Color.DarkOrange, false));     // 1: Trưởng nhóm
            imgLarge.Images.Add(VeNguoi(32, Color.SteelBlue, false));
            imgLarge.Images.Add(VeNguoi(32, Color.DarkOrange, false));
        }

        private static Bitmap VeToaNha()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.SteelBlue, 3, 1, 10, 14);
                for (int y = 3; y <= 11; y += 4)
                {
                    g.FillRectangle(Brushes.White, 5, y, 2, 2);
                    g.FillRectangle(Brushes.White, 9, y, 2, 2);
                }
            }
            return bmp;
        }

        private static Bitmap VeThuMuc()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush nen = new SolidBrush(Color.FromArgb(240, 180, 40)))
            using (Brush tab = new SolidBrush(Color.FromArgb(210, 150, 20)))
            {
                g.FillRectangle(tab, 1, 3, 6, 3);
                g.FillRectangle(nen, 1, 5, 14, 9);
            }
            return bmp;
        }

        // nhom = true: vẽ 2 người (biểu tượng nhóm)
        private static Bitmap VeNguoi(int s, Color mau, bool nhom)
        {
            Bitmap bmp = new Bitmap(s, s);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush b = new SolidBrush(mau))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float k = s / 16f;
                if (nhom)
                {
                    using (Brush b2 = new SolidBrush(ControlPaint.Light(mau)))
                    {
                        g.FillEllipse(b2, 8 * k, 2 * k, 5 * k, 5 * k);
                        g.FillPie(b2, 6 * k, 8 * k, 9 * k, 12 * k, 180, 180);
                    }
                    g.FillEllipse(b, 3 * k, 3 * k, 5 * k, 5 * k);
                    g.FillPie(b, 1 * k, 9 * k, 9 * k, 12 * k, 180, 180);
                }
                else
                {
                    g.FillEllipse(b, 5 * k, 1 * k, 6 * k, 6 * k);
                    g.FillPie(b, 2 * k, 8 * k, 12 * k, 14 * k, 180, 180);
                }
            }
            return bmp;
        }
    }
}
