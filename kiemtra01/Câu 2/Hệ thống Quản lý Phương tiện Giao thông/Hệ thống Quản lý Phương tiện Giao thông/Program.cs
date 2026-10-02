using System;
using System.Collections.Generic;
using System.Linq;
public abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;
    public string MaPT
    {
        get => _maPT;
        set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value;
    }
    public string TenHang
    {
        get => _tenHang;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên hãng không được để trống.");
            _tenHang = value;
        }
    }
    public int NamSanXuat
    {
        get => _namSanXuat;
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Năm sản xuất không hợp lệ!");
            _namSanXuat = value;
        }
    }
    public decimal GiaGoc
    {
        get => _giaGoc;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá gốc bắt buộc > 0.");
            _giaGoc = value;
        }
    }
    public PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }
    public abstract decimal TinhGiaLanBanh();
    public virtual string GetInfo()
    {
        return $"Mã PT: {MaPT}, Hãng: {TenHang}, Năm SX: {NamSanXuat}, Giá gốc: {GiaGoc:N0} VNĐ";
    }
}
public class OTo : PhuongTien
{
    public int SoChoNgoi { get; set; }
    public double DungTichDongCo { get; set; }

    public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int soChoNgoi, double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (soChoNgoi <= 0) throw new ArgumentException("Số chỗ ngồi phải > 0");
        if (dungTichDongCo <= 0) throw new ArgumentException("Dung tích động cơ phải > 0");

        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }
    public override decimal TinhGiaLanBanh()
    {
        decimal thueTruocBa = SoChoNgoi <= 9 ? 0.12m * GiaGoc : 0.10m * GiaGoc;
        decimal thueTieuThuDacBiet = SoChoNgoi <= 9 ? 0.30m * GiaGoc : 0;

        return GiaGoc + thueTruocBa + thueTieuThuDacBiet;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Số chỗ ngồi: {SoChoNgoi}, Dung tích: {DungTichDongCo}L";
    }
}
public class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (dungTichXylanh <= 0) throw new ArgumentException("Dung tích xi-lanh phải > 0");
        DungTichXylanh = dungTichXylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        decimal thueTruocBa = DungTichXylanh < 175 ? 0.02m * GiaGoc : 0.05m * GiaGoc;
        return GiaGoc + thueTruocBa;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Dung tích xi-lanh: {DungTichXylanh}cc";
    }
}
public class QuanLyPhuongTien
{
    private List<PhuongTien> _danhSachPT = new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        _danhSachPT.Add(pt);
    }

    public void DisplayAll()
    {
        foreach (var pt in _danhSachPT)
        {
            Console.WriteLine(pt.GetInfo() + $" => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        if (_danhSachPT.Count == 0) return null;

        PhuongTien maxPt = _danhSachPT[0];
        foreach (var pt in _danhSachPT)
        {
            if (pt.TinhGiaLanBanh() > maxPt.TinhGiaLanBanh())
            {
                maxPt = pt;
            }
        }
        return maxPt;
    }

    public List<PhuongTien> SearchByName(string keyword)
    {
        return _danhSachPT
            .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        QuanLyPhuongTien quanLy = new QuanLyPhuongTien();
        int choice = -1;

        do
        {
            Console.WriteLine("\n====== HỆ THỐNG QUẢN LÝ PHƯƠNG TIỆN ======");
            Console.WriteLine("1. Thêm Ô tô");
            Console.WriteLine("2. Thêm Xe máy");
            Console.WriteLine("3. Hiển thị toàn bộ danh sách");
            Console.WriteLine("4. Tìm phương tiện có giá lăn bánh cao nhất");
            Console.WriteLine("5. Tìm kiếm theo hãng");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Mời bạn chọn chức năng (0-5): ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập số!");
                continue;
            }

            Console.WriteLine(); // Xuống dòng cho đẹp

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--- THÊM Ô TÔ ---");
                        Console.Write("Nhập mã phương tiện: "); string maOto = Console.ReadLine();
                        Console.Write("Nhập tên hãng: "); string hangOto = Console.ReadLine();
                        Console.Write("Nhập năm sản xuất: "); int namOto = int.Parse(Console.ReadLine());
                        Console.Write("Nhập giá gốc (VNĐ): "); decimal giaOto = decimal.Parse(Console.ReadLine());
                        Console.Write("Nhập số chỗ ngồi: "); int choNgoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập dung tích động cơ (Lít): "); double dungTich = double.Parse(Console.ReadLine());

                        OTo oto = new OTo(maOto, hangOto, namOto, giaOto, choNgoi, dungTich);
                        quanLy.AddPhuongTien(oto);
                        Console.WriteLine("=> Thêm Ô tô thành công!");
                        break;

                    case 2:
                        Console.WriteLine("--- THÊM XE MÁY ---");
                        Console.Write("Nhập mã phương tiện: "); string maXeMay = Console.ReadLine();
                        Console.Write("Nhập tên hãng: "); string hangXeMay = Console.ReadLine();
                        Console.Write("Nhập năm sản xuất: "); int namXeMay = int.Parse(Console.ReadLine());
                        Console.Write("Nhập giá gốc (VNĐ): "); decimal giaXeMay = decimal.Parse(Console.ReadLine());
                        Console.Write("Nhập dung tích xi-lanh (cc): "); int phanKhoi = int.Parse(Console.ReadLine());

                        XeMay xeMay = new XeMay(maXeMay, hangXeMay, namXeMay, giaXeMay, phanKhoi);
                        quanLy.AddPhuongTien(xeMay);
                        Console.WriteLine("=> Thêm Xe máy thành công!");
                        break;

                    case 3:
                        Console.WriteLine("--- DANH SÁCH PHƯƠNG TIỆN ---");
                        quanLy.DisplayAll();
                        break;

                    case 4:
                        Console.WriteLine("--- PHƯƠNG TIỆN GIÁ LĂN BÁNH CAO NHẤT ---");
                        PhuongTien maxPt = quanLy.FindMaxGiaLanBanh();
                        if (maxPt != null)
                        {
                            Console.WriteLine(maxPt.GetInfo() + $" => {maxPt.TinhGiaLanBanh():N0} VNĐ");
                        }
                        else
                        {
                            Console.WriteLine("Danh sách đang trống!");
                        }
                        break;

                    case 5:
                        Console.Write("Nhập tên hãng cần tìm: ");
                        string keyword = Console.ReadLine();
                        var result = quanLy.SearchByName(keyword);

                        if (result.Count > 0)
                        {
                            Console.WriteLine($"\nĐã tìm thấy {result.Count} phương tiện của hãng '{keyword}':");
                            foreach (var pt in result)
                            {
                                Console.WriteLine(pt.GetInfo() + $" => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy phương tiện nào của hãng '{keyword}'.");
                        }   
                        break;

                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;

                    default:
                        Console.WriteLine("Chức năng không tồn tại. Vui lòng chọn lại!");
                        break;
                }
            }
            // Bắt các lỗi khi nhập sai định dạng (chữ vào số) hoặc vi phạm Validation ở Constructor
            catch (FormatException)
            {
                Console.WriteLine("\n[LỖI] Nhập sai định dạng dữ liệu (ví dụ: nhập chữ vào trường bắt buộc nhập số).");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[LỖI VALIDATION] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[LỖI HỆ THỐNG] Đã có lỗi xảy ra: {ex.Message}");
            }

        } while (choice != 0);
    }
}