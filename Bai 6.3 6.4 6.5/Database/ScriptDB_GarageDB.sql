/* =====================================================================
   BÀI 6.4: HỆ THỐNG QUẢN LÝ GARAGE VÀ BẢO DƯỠNG XE Ô TÔ
   CSDL: GarageDB
   Tác giả: Đặng Hồng Thái - MSV: 24810310241 - Lớp: D19CNPM3
   Mục đích: Khởi tạo cơ sở dữ liệu và chèn dữ liệu mẫu
   ===================================================================== */

USE master;
GO

-- Xóa CSDL cũ nếu tồn tại
IF DB_ID(N'GarageDB') IS NOT NULL
BEGIN
    ALTER DATABASE GarageDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GarageDB;
END
GO

CREATE DATABASE GarageDB;
GO

USE GarageDB;
GO

/* =====================================================================
   1. BẢNG KHACHHANG (Chủ xe)
   ===================================================================== */
CREATE TABLE KhachHang
(
    MaKH      INT IDENTITY(1,1) PRIMARY KEY,
    TenKH     NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL CONSTRAINT UQ_KhachHang_DienThoai UNIQUE,
    DiaChi    NVARCHAR(200) NULL
);
GO

/* =====================================================================
   2. BẢNG XE (Thông tin ô tô)
   ===================================================================== */
CREATE TABLE Xe
(
    BienSo     VARCHAR(20) PRIMARY KEY,
    MaKH       INT NOT NULL,
    HieuXe     NVARCHAR(50) NULL, -- 'Toyota', 'Honda', 'VinFast', 'Mazda', 'Ford', 'Hyundai',...
    NamSanXuat INT NULL,
    CONSTRAINT FK_Xe_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE
);
GO

/* =====================================================================
   3. BẢNG PHUTUNG (Phụ tùng / Vật tư)
   ===================================================================== */
CREATE TABLE PhuTung
(
    MaPhuTung   INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuTung  NVARCHAR(150) NOT NULL,
    DonGia      DECIMAL(18,2) NOT NULL CONSTRAINT DF_PhuTung_DonGia DEFAULT 0,
    SoLuongTon  INT NOT NULL CONSTRAINT DF_PhuTung_SoLuongTon DEFAULT 0 CONSTRAINT CK_PhuTung_SoLuongTon CHECK (SoLuongTon >= 0)
);
GO

/* =====================================================================
   4. BẢNG PHIEUSUACHUA (Phiếu sửa chữa)
   ===================================================================== */
CREATE TABLE PhieuSuaChua
(
    MaPhieu     INT IDENTITY(1,1) PRIMARY KEY,
    BienSo      VARCHAR(20) NOT NULL,
    NgayNhan    DATETIME NOT NULL CONSTRAINT DF_PhieuSuaChua_NgayNhan DEFAULT GETDATE(),
    NoiDungSua  NVARCHAR(MAX) NULL,
    TongTien    DECIMAL(18,2) NOT NULL CONSTRAINT DF_PhieuSuaChua_TongTien DEFAULT 0,
    TrangThai   NVARCHAR(30) NOT NULL CONSTRAINT DF_PhieuSuaChua_TrangThai DEFAULT N'Đang sửa', -- 'Đang sửa', 'Đã hoàn thành', 'Đã thanh toán'
    CONSTRAINT FK_PhieuSuaChua_Xe FOREIGN KEY (BienSo) REFERENCES Xe(BienSo) ON DELETE CASCADE
);
GO

/* =====================================================================
   5. BẢNG CHITIETSUACHUA (Chi tiết phụ tùng & tiền công)
   ===================================================================== */
CREATE TABLE ChiTietSuaChua
(
    MaPhieu   INT NOT NULL,
    MaPhuTung INT NOT NULL,
    SoLuong   INT NOT NULL CONSTRAINT CK_ChiTietSuaChua_SoLuong CHECK (SoLuong > 0),
    TienCong  DECIMAL(18,2) NOT NULL CONSTRAINT DF_ChiTietSuaChua_TienCong DEFAULT 0,
    CONSTRAINT PK_ChiTietSuaChua PRIMARY KEY (MaPhieu, MaPhuTung),
    CONSTRAINT FK_ChiTietSuaChua_Phieu FOREIGN KEY (MaPhieu) REFERENCES PhieuSuaChua(MaPhieu) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietSuaChua_PhuTung FOREIGN KEY (MaPhuTung) REFERENCES PhuTung(MaPhuTung)
);
GO

/* =====================================================================
   DỮ LIỆU MẪU (SEED DATA)
   ===================================================================== */

-- 1. Thêm Khách hàng mẫu
INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) VALUES
(N'Đặng Hồng Thái', '0981234567', N'Cầu Giấy, Hà Nội'),
(N'Nguyễn Văn An',   '0912345678', N'Bắc Từ Liêm, Hà Nội'),
(N'Trần Thị Bình',   '0978901234', N'Nam Từ Liêm, Hà Nội'),
(N'Lê Hoàng Long',   '0965432109', N'Đống Đa, Hà Nội'),
(N'Phạm Minh Đức',   '0903456789', N'Hà Đông, Hà Nội');
GO

-- 2. Thêm Xe mẫu
INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES
('30A-888.88', 1, N'VinFast VF8', 2023),
('29C-123.45', 2, N'Toyota Corolla Cross', 2022),
('30H-999.99', 3, N'Honda CR-V', 2021),
('29A-555.66', 4, N'Mazda CX-5', 2024),
('30E-678.90', 5, N'Hyundai SantaFe', 2020);
GO

-- 3. Thêm Phụ tùng / Vật tư mẫu
INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES
(N'Nhớt động cơ Castrol Magnatec 5W-30 (Can 4L)', 750000,  50),
(N'Lọc nhớt chính hãng (Oil Filter)',              180000,  35),
(N'Lọc gió động cơ (Air Filter)',                  280000,  20),
(N'Lọc gió điều hòa than hoạt tính (Cabin Filter)',250000,  25),
(N'Nước làm mát động cơ pha sẵn Coolant (Can 4L)', 320000,  15),
(N'Dầu phanh DOT 4 cao cấp (Chai 1L)',             150000,  18),
(N'Bugi Iridium cao cấp (Bộ 4 chiếc)',             850000,  12),
(N'Má phanh trước chính hãng (Bộ 2 bánh)',        1250000,   8),
(N'Má phanh sau chính hãng (Bộ 2 bánh)',          1100000,   8),
(N'Gạt mưa Silicon cao cấp (Cặp 2 cây)',           350000,  30);
GO

-- 4. Thêm Phiếu sửa chữa mẫu
-- Phiếu 1: 30A-888.88 (Đã thanh toán)
INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) VALUES
('30A-888.88', '2026-11-15 08:30:00', N'Bảo dưỡng cấp 20.000 km: Thay nhớt, lọc nhớt, vệ sinh phanh', 1230000, N'Đã thanh toán');

-- Phiếu 2: 29C-123.45 (Đã hoàn thành)
INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) VALUES
('29C-123.45', '2026-11-18 10:00:00', N'Thay má phanh trước, thay dầu phanh và lọc gió động cơ', 1980000, N'Đã hoàn thành');

-- Phiếu 3: 30H-999.99 (Đang sửa)
INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) VALUES
('30H-999.99', '2026-11-19 07:45:00', N'Kiểm tra định kỳ: Thay nhớt, lọc gió cabin, kiểm tra bugi', 1400000, N'Đang sửa');
GO

-- 5. Chi tiết phụ tùng & tiền công mẫu
-- Phiếu 1:
INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES
(1, 1, 1, 150000), -- 750k + 150k = 900k
(1, 2, 1, 150000); -- 180k + 150k = 330k -> Tổng = 1.230.000 đ

-- Phiếu 2:
INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES
(2, 8, 1, 250000), -- 1250k + 250k = 1500k
(2, 6, 1, 80000),  -- 150k + 80k = 230k
(2, 3, 1, 100000); -- 280k + 100k = 380k -> Tổng = 1.980.000 đ

-- Phiếu 3:
INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES
(3, 1, 1, 150000), -- 750k + 150k = 900k
(3, 4, 1, 100000), -- 250k + 100k = 350k
(3, 2, 1, 0);      -- 180k + 0 = 180k -> Tổng = 1.430.000 đ (làm tròn hoặc theo chi phí thực)
GO
