/* =====================================================================
   SCRIPT TẠO CẢ 2 CSDL: SalesDB (Bài 6.1) và HRMDB (Bài 6.2)
   Mở file trong SQL Server Management Studio -> bấm Execute (F5)
   ===================================================================== */

/* ############################ BÀI 6.1 ############################ */
/* =====================================================================
   BÀI 6.1 - HỆ THỐNG QUẢN LÝ BÁN HÀNG & SIÊU THỊ MINI
   Script khởi tạo CSDL SalesDB và chèn dữ liệu mẫu
   Cách chạy: mở file này trong SQL Server Management Studio (SSMS)
              -> bấm Execute (F5)
   ===================================================================== */
USE master;
GO

-- Xóa CSDL cũ (nếu có) để tạo lại từ đầu
IF DB_ID(N'SalesDB') IS NOT NULL
BEGIN
    ALTER DATABASE SalesDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SalesDB;
END
GO

CREATE DATABASE SalesDB;
GO

USE SalesDB;
GO

/* ---------- 1. NHÂN VIÊN ---------- */
CREATE TABLE NhanVien
(
    MaNV        INT IDENTITY(1,1) PRIMARY KEY,
    TenNV       NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15)   NULL CONSTRAINT UQ_NhanVien_SDT UNIQUE,
    ChucVu      NVARCHAR(50)  NULL
);
GO

/* ---------- 2. KHÁCH HÀNG ---------- */
CREATE TABLE KhachHang
(
    MaKH        INT IDENTITY(1,1) PRIMARY KEY,
    TenKH       NVARCHAR(100) NOT NULL,
    DienThoai   VARCHAR(15)   NULL CONSTRAINT UQ_KhachHang_DienThoai UNIQUE,
    DiemTichLuy INT NOT NULL CONSTRAINT DF_KhachHang_Diem DEFAULT 0
);
GO

/* ---------- 3. SẢN PHẨM ---------- */
CREATE TABLE SanPham
(
    MaSP       VARCHAR(20)   PRIMARY KEY,
    TenSP      NVARCHAR(150) NOT NULL,
    GiaBan     DECIMAL(18,2) NOT NULL CONSTRAINT CK_SanPham_GiaBan CHECK (GiaBan > 0),
    SoLuongTon INT           NOT NULL CONSTRAINT CK_SanPham_SoLuongTon CHECK (SoLuongTon >= 0)
);
GO

/* ---------- 4. HÓA ĐƠN ---------- */
CREATE TABLE HoaDon
(
    MaHD     INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap  DATETIME NOT NULL CONSTRAINT DF_HoaDon_NgayLap DEFAULT GETDATE(),
    MaNV     INT NOT NULL CONSTRAINT FK_HoaDon_NhanVien REFERENCES NhanVien(MaNV),
    MaKH     INT NULL     CONSTRAINT FK_HoaDon_KhachHang REFERENCES KhachHang(MaKH),   -- NULL = khách lẻ
    TongTien DECIMAL(18,2) NOT NULL CONSTRAINT DF_HoaDon_TongTien DEFAULT 0
);
GO

/* ---------- 5. CHI TIẾT HÓA ĐƠN ---------- */
CREATE TABLE ChiTietHoaDon
(
    MaHD    INT         NOT NULL CONSTRAINT FK_CTHD_HoaDon  REFERENCES HoaDon(MaHD),
    MaSP    VARCHAR(20) NOT NULL CONSTRAINT FK_CTHD_SanPham REFERENCES SanPham(MaSP),
    SoLuong INT         NOT NULL CONSTRAINT CK_CTHD_SoLuong CHECK (SoLuong > 0),
    DonGia  DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaSP)
);
GO

/* =====================================================================
   DỮ LIỆU MẪU
   ===================================================================== */
INSERT INTO NhanVien (TenNV, SoDienThoai, ChucVu) VALUES
(N'Vương Thanh Thúy', '0901000001', N'Quản lý'),
(N'Nguyễn Thị Lan',   '0901000002', N'Thu ngân'),
(N'Trần Văn Minh',    '0901000003', N'Thu ngân');

INSERT INTO KhachHang (TenKH, DienThoai, DiemTichLuy) VALUES
(N'Lê Thị Hoa',     '0912000001', 12),
(N'Phạm Quốc Huy',  '0912000002', 5),
(N'Đỗ Minh Anh',    '0912000003', 0),
(N'Hoàng Văn Nam',  '0912000004', 30);

INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES
('8934563138165', N'Mì Hảo Hảo tôm chua cay',      4500,  200),
('8934588063053', N'Nước suối Aquafina 500ml',      6000,  150),
('8935049501503', N'Sữa tươi Vinamilk 1L',          32000, 60),
('8934673573234', N'Bánh Oreo socola 133g',         18000, 80),
('8936036020038', N'Dầu ăn Neptune 1L',             52000, 40),
('8934822101011', N'Gạo ST25 túi 5kg',              185000, 25),
('8935001700012', N'Nước ngọt Coca-Cola 330ml',     10000, 120),
('8934868142504', N'Kem đánh răng P/S 230g',        35000, 50),
('8936017360788', N'Bột giặt OMO 800g',             45000, 30),
('8934563619015', N'Nước mắm Nam Ngư 500ml',        28000, 8);

/* Một vài hóa đơn mẫu để màn hình Thống kê có dữ liệu */
INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) VALUES
(DATEADD(DAY, -2, GETDATE()), 2, 1, 214000),
(DATEADD(DAY, -1, GETDATE()), 3, NULL, 57000),
(GETDATE(),                   2, 2, 104000);

INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES
(1, '8934822101011', 1, 185000),
(1, '8934563138165', 2, 4500),
(1, '8935001700012', 2, 10000),
(2, '8934563138165', 6, 4500),
(2, '8934588063053', 2, 6000),
(2, '8934673573234', 1, 18000),
(3, '8935049501503', 2, 32000),
(3, '8935001700012', 4, 10000);
GO

PRINT N'Đã tạo xong CSDL SalesDB.';
GO

/* ############################ BÀI 6.2 ############################ */
/* =====================================================================
   BÀI 6.2 - HỆ THỐNG QUẢN LÝ NHÂN SỰ & TÍNH LƯƠNG
   Script khởi tạo CSDL HRMDB và chèn dữ liệu mẫu
   Cách chạy: mở file này trong SQL Server Management Studio (SSMS)
              -> bấm Execute (F5)
   ===================================================================== */
USE master;
GO

IF DB_ID(N'HRMDB') IS NOT NULL
BEGIN
    ALTER DATABASE HRMDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HRMDB;
END
GO

CREATE DATABASE HRMDB;
GO

USE HRMDB;
GO

/* ---------- 1. PHÒNG BAN ---------- */
CREATE TABLE PhongBan
(
    MaPB  INT IDENTITY(1,1) PRIMARY KEY,
    TenPB NVARCHAR(100) NOT NULL,
    Mota  NVARCHAR(255) NULL
);
GO

/* ---------- 2. NHÂN VIÊN ---------- */
CREATE TABLE NhanVien
(
    MaNV       INT IDENTITY(1,1) PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    NgaySinh   DATETIME NULL,
    CCCD       VARCHAR(20) NULL CONSTRAINT UQ_NhanVien_CCCD UNIQUE,
    MaPB       INT NULL CONSTRAINT FK_NhanVien_PhongBan REFERENCES PhongBan(MaPB),
    LuongCoBan DECIMAL(18,2) NOT NULL CONSTRAINT CK_NhanVien_LuongCoBan CHECK (LuongCoBan > 0),
    HeSoLuong  FLOAT NOT NULL CONSTRAINT DF_NhanVien_HeSoLuong DEFAULT 1.0
);
GO

/* ---------- 3. BẢNG CHẤM CÔNG THÁNG ---------- */
CREATE TABLE BangChamCong
(
    MaCong     INT IDENTITY(1,1) PRIMARY KEY,
    MaNV       INT NOT NULL CONSTRAINT FK_BangChamCong_NhanVien REFERENCES NhanVien(MaNV),
    ThangNam   VARCHAR(7) NOT NULL,                       -- Ví dụ: '11/2026'
    SoNgayCong FLOAT NOT NULL CONSTRAINT DF_BangChamCong_SoNgayCong DEFAULT 0
               CONSTRAINT CK_BangChamCong_SoNgayCong CHECK (SoNgayCong >= 0 AND SoNgayCong <= 31),
    SoGioOT    FLOAT NOT NULL CONSTRAINT DF_BangChamCong_SoGioOT DEFAULT 0
               CONSTRAINT CK_BangChamCong_SoGioOT CHECK (SoGioOT >= 0),
    DaChot     BIT NOT NULL CONSTRAINT DF_BangChamCong_DaChot DEFAULT 0,   -- 1 = đã chốt lương, khóa không cho sửa
    CONSTRAINT UQ_BangChamCong_NV_Thang UNIQUE (MaNV, ThangNam)
);
GO

/* ---------- 4. BẢNG LƯƠNG CHI TIẾT ----------
   Đề yêu cầu MaLuong là khóa chính tự tăng và (MaNV, ThangNam) cũng là khóa,
   nên (MaNV, ThangNam) được đặt thành ràng buộc UNIQUE: mỗi nhân viên chỉ có 1 dòng lương mỗi tháng. */
CREATE TABLE BangLuong
(
    MaLuong  INT IDENTITY(1,1) PRIMARY KEY,
    MaNV     INT NOT NULL CONSTRAINT FK_BangLuong_NhanVien REFERENCES NhanVien(MaNV),
    ThangNam VARCHAR(7) NOT NULL,
    ThucLinh DECIMAL(18,2) NOT NULL,
    CONSTRAINT UQ_BangLuong_NV_Thang UNIQUE (MaNV, ThangNam)
);
GO

/* =====================================================================
   DỮ LIỆU MẪU
   ===================================================================== */
INSERT INTO PhongBan (TenPB, Mota) VALUES
(N'Phòng Hành chính - Nhân sự', N'Quản lý hồ sơ, tuyển dụng, chấm công'),
(N'Phòng Kế toán',              N'Tính lương, thuế, báo cáo tài chính'),
(N'Phòng Kỹ thuật',             N'Phát triển và bảo trì phần mềm'),
(N'Phòng Kinh doanh',           N'Bán hàng và chăm sóc khách hàng');

INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) VALUES
(N'Vương Thanh Thúy',  '2004-05-12', '001304012345', 1, 9000000,  1.5),
(N'Nguyễn Văn An',     '1995-03-20', '001095003456', 1, 8000000,  1.2),
(N'Trần Thị Bích',     '1990-08-15', '001190008765', 2, 10000000, 1.8),
(N'Lê Minh Cường',     '1998-11-02', '001098011234', 2, 8500000,  1.3),
(N'Phạm Thu Dung',     '1993-01-25', '001193001122', 3, 12000000, 2.0),
(N'Hoàng Đức Em',      '1999-07-07', '001099007788', 3, 11000000, 1.6),
(N'Vũ Thị Giang',      '2000-12-30', '001300012299', 3, 10500000, 1.4),
(N'Đặng Quốc Hải',     '1992-04-18', '001092004433', 4, 7500000,  1.5),
(N'Bùi Thị Hoa',       '1997-09-09', '001197009900', 4, 7000000,  1.2);

/* Chấm công + bảng lương ĐÃ CHỐT của tháng trước (để màn hình Báo cáo có dữ liệu) */
DECLARE @ThangTruoc VARCHAR(7) =
    RIGHT('0' + CAST(MONTH(DATEADD(MONTH, -1, GETDATE())) AS VARCHAR(2)), 2) + '/' +
    CAST(YEAR(DATEADD(MONTH, -1, GETDATE())) AS VARCHAR(4));

INSERT INTO BangChamCong (MaNV, ThangNam, SoNgayCong, SoGioOT, DaChot) VALUES
(1, @ThangTruoc, 22, 4, 1),
(2, @ThangTruoc, 21, 0, 1),
(3, @ThangTruoc, 22, 6, 1),
(4, @ThangTruoc, 20, 2, 1),
(5, @ThangTruoc, 22, 10, 1),
(6, @ThangTruoc, 19.5, 8, 1),
(7, @ThangTruoc, 22, 0, 1),
(8, @ThangTruoc, 18, 3, 1),
(9, @ThangTruoc, 22, 5, 1);

-- ThucLinh = (LuongCoBan * HeSoLuong / 22) * SoNgayCong + SoGioOT * 50000
INSERT INTO BangLuong (MaNV, ThangNam, ThucLinh)
SELECT nv.MaNV, cc.ThangNam,
       CAST(ROUND((nv.LuongCoBan * nv.HeSoLuong / 22) * cc.SoNgayCong + cc.SoGioOT * 50000, 0) AS DECIMAL(18,2))
FROM BangChamCong cc
JOIN NhanVien nv ON nv.MaNV = cc.MaNV
WHERE cc.ThangNam = @ThangTruoc;
GO

PRINT N'Đã tạo xong CSDL HRMDB.';
GO
