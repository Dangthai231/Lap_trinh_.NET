/* =====================================================================
   BÀI 6.3: HỆ THỐNG QUẢN LÝ CÔNG VIỆC & TIẾN ĐỘ DỰ ÁN
   CSDL: ProjectTaskDB
   Tác giả: Đặng Hồng Thái - MSV: 24810310241 - Lớp: D19CNPM3
   Mục đích: Khởi tạo cơ sở dữ liệu và chèn dữ liệu mẫu
   Cách chạy: Mở file trong SSMS hoặc chạy qua sqlcmd
   ===================================================================== */

USE master;
GO

-- Xóa CSDL cũ nếu đã tồn tại để tạo mới tinh
IF DB_ID(N'ProjectTaskDB') IS NOT NULL
BEGIN
    ALTER DATABASE ProjectTaskDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ProjectTaskDB;
END
GO

CREATE DATABASE ProjectTaskDB;
GO

USE ProjectTaskDB;
GO

/* =====================================================================
   1. BẢNG DUAN (Dự án)
   ===================================================================== */
CREATE TABLE DuAn
(
    MaDuAn      INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn     NVARCHAR(150) NOT NULL,
    NgayBatDau  DATETIME NULL,
    NgayKetThuc DATETIME NULL,
    TrangThai   NVARCHAR(50) NULL -- 'Đang chạy', 'Hoàn thành', 'Tạm dừng'
);
GO

/* =====================================================================
   2. BẢNG THANHVIEN (Thành viên nhóm)
   ===================================================================== */
CREATE TABLE ThanhVien
(
    MaThanhVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    Email       VARCHAR(100) NOT NULL CONSTRAINT UQ_ThanhVien_Email UNIQUE,
    ChuyenMon   NVARCHAR(100) NULL
);
GO

/* =====================================================================
   3. BẢNG CONGVIEC (Công việc / Task)
   ===================================================================== */
CREATE TABLE CongViec
(
    MaTask    INT IDENTITY(1,1) PRIMARY KEY,
    MaDuAn    INT NOT NULL,
    TenTask   NVARCHAR(200) NOT NULL,
    MoTa      NVARCHAR(MAX) NULL,
    HanNop    DATETIME NULL,
    DoUuTien  NVARCHAR(20) NULL, -- 'Cao', 'Trung bình', 'Thấp'
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_CongViec_TrangThai DEFAULT N'To Do', -- 'To Do', 'In Progress', 'Review', 'Done'
    CONSTRAINT FK_CongViec_DuAn FOREIGN KEY (MaDuAn) REFERENCES DuAn(MaDuAn) ON DELETE CASCADE
);
GO

/* =====================================================================
   4. BẢNG PHANCONG (Phân công công việc)
   ===================================================================== */
CREATE TABLE PhanCong
(
    MaTask      INT NOT NULL,
    MaThanhVien INT NOT NULL,
    NgayGiao    DATETIME NOT NULL CONSTRAINT DF_PhanCong_NgayGiao DEFAULT GETDATE(),
    CONSTRAINT PK_PhanCong PRIMARY KEY (MaTask, MaThanhVien),
    CONSTRAINT FK_PhanCong_CongViec FOREIGN KEY (MaTask) REFERENCES CongViec(MaTask) ON DELETE CASCADE,
    CONSTRAINT FK_PhanCong_ThanhVien FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien) ON DELETE CASCADE
);
GO

/* =====================================================================
   DỮ LIỆU MẪU (SEED DATA)
   ===================================================================== */

-- 1. Thêm Dự án mẫu
INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES
(N'Xây dựng Hệ thống Quản lý Bán hàng .NET', '2026-10-01', '2026-12-31', N'Đang chạy'),
(N'Nâng cấp Cổng thông tin Sinh viên EPU',   '2026-11-01', '2026-12-15', N'Đang chạy'),
(N'Thiết kế Website Tuyển sinh 2026',        '2026-09-01', '2026-10-30', N'Hoàn thành');
GO

-- 2. Thêm Thành viên mẫu
INSERT INTO ThanhVien (HoTen, Email, ChuyenMon) VALUES
(N'Đặng Hồng Thái', 'danghongthai@epu.edu.vn', N'Fullstack / Team Leader'),
(N'Nguyễn Văn An',   'an.nv@epu.edu.vn',        N'Backend Developer (C#, SQL)'),
(N'Trần Thị Bình',   'binh.tt@epu.edu.vn',      N'Frontend / UI Designer'),
(N'Lê Hoàng Long',   'long.lh@epu.edu.vn',      N'QA / Software Tester'),
(N'Phạm Minh Đức',   'duc.pm@epu.edu.vn',       N'DevOps / Database Admin');
GO

-- 3. Thêm Công việc mẫu
-- Dự án 1: Xây dựng Hệ thống Quản lý Bán hàng .NET (MaDuAn = 1)
INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(1, N'Thiết kế CSDL SQL Server SalesDB',       N'Tạo bảng SanPham, KhachHang, HoaDon, ChiTietHoaDon kèm ràng buộc toàn vẹn', '2026-10-15', N'Cao',        N'Done'),
(1, N'Xây dựng lớp DTO và DataProvider',       N'Viết thư viện kết nối cơ sở dữ liệu parameterized chống SQL Injection',       '2026-10-25', N'Cao',        N'Done'),
(1, N'Phát triển Form Bán hàng POS',           N'Giao diện tính tiền, chọn sản phẩm, tính tổng tiền và in hóa đơn',           '2026-11-15', N'Cao',        N'In Progress'), -- Task trễ hạn (15/11 < 19/11)
(1, N'Viết module Báo cáo Thống kê Doanh thu', N'Thống kê theo ngày, sản phẩm bán chạy và vẽ biểu đồ tăng trưởng',           '2026-11-25', N'Trung bình', N'To Do'),
(1, N'Kiểm thử hộp đen các chức năng CRUD',    N'Test case thêm sửa xóa dữ liệu và kiểm tra các ràng buộc validation',       '2026-11-22', N'Trung bình', N'Review');

-- Dự án 2: Nâng cấp Cổng thông tin Sinh viên EPU (MaDuAn = 2)
INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(2, N'Tối ưu hóa tốc độ tải trang Đăng ký tín chỉ', N'Đánh index và tối ưu stored procedure truy vấn lịch học',          '2026-11-10', N'Cao',        N'In Progress'), -- Task trễ hạn (10/11 < 19/11)
(2, N'Tích hợp Cổng thanh toán học phí VNPAY',      N'Kết nối API VNPAY sandbox và xác thực IPN thanh toán',               '2026-11-18', N'Cao',        N'To Do'),       -- Task trễ hạn (18/11 < 19/11)
(2, N'Cải tiến giao diện Xem điểm trên Mobile',     N'Responsive UI và bổ sung biểu đồ GPA qua từng học kỳ',               '2026-11-30', N'Thấp',       N'To Do'),
(2, N'Viết tài liệu hướng dẫn sử dụng cho sinh viên',N'Tạo file PDF và video hướng dẫn ngắn gọn các tính năng mới',       '2026-12-05', N'Thấp',       N'Review');

-- Dự án 3: Thiết kế Website Tuyển sinh 2026 (MaDuAn = 3)
INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(3, N'Khảo sát yêu cầu phòng đào tạo',  N'Thu thập biểu mẫu hồ sơ và thông tin các ngành xét tuyển năm 2026', '2026-09-10', N'Trung bình', N'Done'),
(3, N'Triển khai lên Web Server IIS',   N'Deploy web application và cấu hình HTTPS SSL certificate',          '2026-10-28', N'Cao',        N'Done');
GO

-- 4. Phân công công việc mẫu
-- Task 1: Thái + An
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (1, 1, '2026-10-02'), (1, 2, '2026-10-02');
-- Task 2: An
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (2, 2, '2026-10-16');
-- Task 3: Thái + Bình
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (3, 1, '2026-10-26'), (3, 3, '2026-10-26');
-- Task 4: An + Thái
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (4, 1, '2026-11-01'), (4, 2, '2026-11-01');
-- Task 5: Long
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (5, 4, '2026-11-05');
-- Task 6: Đức + An
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (6, 2, '2026-11-02'), (6, 5, '2026-11-02');
-- Task 7: An + Đức
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (7, 2, '2026-11-05'), (7, 5, '2026-11-05');
-- Task 8: Bình
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (8, 3, '2026-11-12');
-- Task 9: Long + Bình
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (9, 3, '2026-11-15'), (9, 4, '2026-11-15');
-- Task 10: Thái
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (10, 1, '2026-09-02');
-- Task 11: Đức
INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (11, 5, '2026-10-15');
GO
