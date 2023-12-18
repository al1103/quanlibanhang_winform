CREATE TABLE [dbo].[NhanVien] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ten] VARCHAR(50) NOT NULL,
    [diaChi] VARCHAR(255) NOT NULL,
    [soDienThoai] VARCHAR(11) NOT NULL,
    [boPhanID] INT NOT NULL
);

go
CREATE TABLE ChiTietDonHangNhap (
  [id] INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key identifier
  [donHangID]  varchar(11), -- Foreign key referencing DonHangNhap table
  [NhanVienID] INT NOT NULL FOREIGN KEY REFERENCES NhanVien(id), -- Foreign key referencing NhanVien table
  [NhaPhanPhoiID] INT NOT NULL FOREIGN KEY REFERENCES NhaPhanPhoi(id), -- Foreign key referencing NhaPhanPhoi table
  [Date] DATETIME NOT NULL, -- Date and time of the entry
  [hangHoaID] INT NOT NULL FOREIGN KEY REFERENCES HangHoa(id), -- Foreign key referencing HangHoa table
  [soLuong] INT NOT NULL, -- Quantity of the purchased item
  [donGia]  varchar(11) NOT NULL, -- Unit price of the item
  [thanhTien] varchar(11)
);


go
CREATE TABLE [dbo].[KhachHang] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ten] VARCHAR(50) NOT NULL,
    [diaChi] VARCHAR(255) NOT NULL,
    [soDienThoai] VARCHAR(11) NOT NULL
);
go
CREATE TABLE [dbo].[HangHoa] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [maHang] VARCHAR(20) NOT NULL,
    [tenHang] VARCHAR(50) NOT NULL,
    [nhomHangHoaID] INT NOT NULL,
    [donViTinh] NVARCHAR(50) NOT NULL,
    [hanSuDung] DATE NOT NULL,
    [giaBan] FLOAT NOT NULL
);
go
CREATE TABLE [dbo].[DonHang] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[MaHD] varchar(20),
    [ngayLap] DATE NOT NULL,
    [tongTien] FLOAT NOT NULL,
	[Kieu] Varchar(11) 
);

go
CREATE TABLE [dbo].[CongNo] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [khachHangID] INT NOT NULL,
    [tongTien] FLOAT NOT NULL
);
go
CREATE TABLE [dbo].[ChiTietDonHang] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [donHangID] varchar(20),
	[NhanVienID] INT,
	[KhachHangID] INT ,
	[Date] date,
    [hangHoaID] INT NOT NULL,	
    [soLuong] INT NOT NULL,
    [donGia] FLOAT NOT NULL,
    [thanhTien] FLOAT NOT NULL
);
go


CREATE TABLE [dbo].[BoPhan] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ten] VARCHAR(50) NOT NULL
);
go
CREATE TABLE [dbo].[NhomHangHoa] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ten] NVARCHAR(50) NOT NULL
);
go
CREATE TABLE [dbo].[ThuChi] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ngay] DATE NOT NULL,
    [soTien] FLOAT NOT NULL,
    [nhanVienID] INT NOT NULL
);
go
CREATE TABLE [dbo].[XuatKho] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ngayXuat] DATE NOT NULL,
    [soLuong] INT NOT NULL,
    [donGia] FLOAT NOT NULL,
    [tongTien] FLOAT NOT NULL,
    [hangHoaID] INT NOT NULL
);
go
CREATE TABLE [dbo].[NhapKho](
    [id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ngayNhap] [date] NOT NULL,
    [soLuong] [int] NOT NULL,
    [donGia] [float] NOT NULL,
    [tongTien] [float] NOT NULL,
    [hangHoaID] [int] NOT NULL
	)
	go

ALTER TABLE [dbo].[ThuChi]
ADD CONSTRAINT FK_ThuChi_NhanVien FOREIGN KEY([nhanVienID]) REFERENCES [dbo].[NhanVien]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[XuatKho]
ADD CONSTRAINT FK_XuatKho_HangHoa FOREIGN KEY([hangHoaID]) REFERENCES [dbo].[HangHoa]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[NhapKho]
ADD CONSTRAINT FK_NhapKho_HangHoa FOREIGN KEY([hangHoaID]) REFERENCES [dbo].[HangHoa]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[NhanVien]
ADD CONSTRAINT FK_NhanVien_BoPhan FOREIGN KEY([boPhanID]) REFERENCES [dbo].[BoPhan]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[HangHoa]
ADD CONSTRAINT FK_HangHoa_NhomHangHoa FOREIGN KEY([nhomHangHoaID]) REFERENCES [dbo].[NhomHangHoa]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[DonHang]
ADD CONSTRAINT FK_DonHang_NhanVien FOREIGN KEY([nhanVienID]) REFERENCES [dbo].[NhanVien]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[DonHang]
ADD CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY([khachHangID]) REFERENCES [dbo].[KhachHang]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[CongNo]
ADD CONSTRAINT FK_CongNo_KhachHang FOREIGN KEY([khachHangID]) REFERENCES [dbo].[KhachHang]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[ChiTietDonHang]
ADD CONSTRAINT FK_ChiTietDonHang_HangHoa FOREIGN KEY([hangHoaID]) REFERENCES [dbo].[HangHoa]([id]) ON DELETE CASCADE;
go
ALTER TABLE [dbo].[ChiTietDonHang]
ADD CONSTRAINT FK_ChiTietDonHang_DonHang FOREIGN KEY([donHangID]) REFERENCES [dbo].[DonHang]([id]) ON DELETE CASCADE;
go
-- [dbo].[BoPhan]
INSERT INTO [dbo].[BoPhan] ([ten]) VALUES
('Quản lý nhân sự'),
('Kế toán'),
('Bán hàng'),
('Kỹ thuật'),
('Nhân sự'),
('Marketing'),
('Quản lý sản xuất'),
('IT'),
('Dịch vụ khách hàng'),
('Nghiên cứu và phát triển');

-- [dbo].[ChiTietDonHang]
INSERT INTO [dbo].[ChiTietDonHang] ([donHangID], [hangHoaID], [soLuong], [donGia], [thanhTien]) VALUES
(6, 5, 10, 5.5, 55),
(6, 2, 8, 7.2, 57.6),
(2, 3, 15, 3.8, 57),
(2, 7, 5, 6.0, 30),
(3, 2, 12, 8.5, 102),
(3, 3, 6, 4.0, 24),
(4, 8, 20, 6.5, 130),
(4, 3, 7, 5.0, 35),
(5, 2, 15, 7.2, 108),
(5, 9, 10, 6.0, 60);


-- [dbo].[CongNo]
INSERT INTO [dbo].[CongNo] ([khachHangID], [tongTien]) VALUES
(1, 150),
(2, 200),
(3, 120),
(4, 80),
(5, 100),
(6, 180),
(7, 90),
(8, 150),
(9, 200),
(10, 120);

-- [dbo].[DonHang]
INSERT INTO [dbo].[DonHang] ([ngayLap], [tongTien], [khachHangID], [nhanVienID]) VALUES
('2023-12-13', 100, 1, 1),
('2023-12-14', 120, 2, 2),
('2023-12-15', 80, 3, 3),
('2023-12-16', 110, 4, 4),
('2023-12-17', 90, 5, 5),
('2023-12-18', 150, 6, 6),
('2023-12-19', 70, 7, 7),
('2023-12-20', 130, 8, 8),
('2023-12-21', 200, 9, 9),
('2023-12-22', 85, 10, 10);

-- [dbo].[HangHoa]
INSERT INTO [dbo].[HangHoa] ([maHang], [tenHang], [nhomHangHoaID], [donViTinh], [hanSuDung], [giaBan],[nhaPhanPhoiID]) VALUES
('MH001', 'Áo thun', 1, 'Cái', '2024-01-01', 10 ,1),
('MH002', 'Quần jeans', 2, 'Cái', '2023-12-31', 15,2),
('MH003', 'Giày thể thao', 1, 'Đôi', '2023-12-30', 4,3),
('MH004', 'Điện thoại di động', 3, 'Cái', '2023-12-30', 500,4),
('MH005', 'Laptop', 3, 'Cái', '2023-12-30', 1000,5),
('MH006', 'Máy tính bảng', 3, 'Cái', '2023-12-30', 300,6),
('MH007', 'Bàn làm việc', 4, 'Cái', '2023-12-30', 200,6),
('MH008', 'Ghế xoay', 4, 'Cái', '2023-12-30', 150,4),
('MH009', 'Quạt điện', 5, 'Cái', '2023-12-30', 30,7),
('MH010', 'Đèn led', 6, 'Cái', '2023-12-30', 12,2);

-- [dbo].[KhachHang]
INSERT INTO [dbo].[KhachHang] ([ten], [diaChi], [soDienThoai]) VALUES
('Khách hàng A', 'Địa chỉ A', '123456789'),
('Khách hàng B', 'Địa chỉ B', '987654321'),
('Khách hàng C', 'Địa chỉ C', '456123789'),
('Khách hàng D', 'Địa chỉ D', '111222333'),
('Khách hàng E', 'Địa chỉ E', '444555666'),
('Khách hàng F', 'Địa chỉ F', '777888999'),
('Khách hàng G', 'Địa chỉ G', '000111222'),
('Khách hàng H', 'Địa chỉ H', '333444555'),
('Khách hàng I', 'Địa chỉ I', '666777888'),
('Khách hàng J', 'Địa chỉ J', '999000111');

-- [dbo].[NhanVien]
INSERT INTO [dbo].[NhanVien] ([ten], [diaChi], [soDienThoai], [boPhanID]) VALUES
('Nhân viên A', 'Địa chỉ NV A', '111111111', 1),
('Nhân viên B', 'Địa chỉ NV B', '222222222', 2),
('Nhân viên C', 'Địa chỉ NV C', '333333333', 3),
('Nhân viên D', 'Địa chỉ NV D', '444444444', 4),
('Nhân viên E', 'Địa chỉ NV E', '555555555', 5),
('Nhân viên F', 'Địa chỉ NV F', '666666666', 6),
('Nhân viên G', 'Địa chỉ NV G', '777777777', 7),
('Nhân viên H', 'Địa chỉ NV H', '888888888', 8),
('Nhân viên I', 'Địa chỉ NV I', '999999999', 9),
('Nhân viên J', 'Địa chỉ NV J', '000000000', 10);

-- [dbo].[NhomHangHoa]
INSERT INTO [dbo].[NhomHangHoa] ([ten]) VALUES
('Thời trang'),
('Điện tử'),
('Đồ gia dụng'),
('Máy tính'),
('Văn phòng phẩm'),
('Đèn và thiết bị chiếu sáng'),
('Dịch vụ'),
('Thể thao và giải trí'),
('Phụ kiện thời trang'),
('Điện lạnh');

-- [dbo].[ThuChi]
INSERT INTO [dbo].[ThuChi] ([ngay], [soTien], [nhanVienID]) VALUES
('2023-12-13', 50, 1),
('2023-12-14', 70, 2),
('2023-12-15', 30, 3),
('2023-12-16', 40, 4),
('2023-12-17', 25, 5),
('2023-12-18', 60, 6),
('2023-12-19', 35, 7),
('2023-12-20', 45, 8),
('2023-12-21', 80, 9),
('2023-12-22', 20, 10);

-- [dbo].[XuatKho]
INSERT INTO [dbo].[XuatKho] ([ngayXuat], [soLuong], [donGia], [tongTien], [hangHoaID]) VALUES
('2023-12-13', 20, 8, 160, 9),
('2023-12-14', 15, 12, 180, 2),
('2023-12-15', 25, 5, 125, 3),
('2023-12-16', 18, 7, 126, 4),
('2023-12-17', 30, 10, 300, 5),
('2023-12-18', 22, 15, 330, 6),
('2023-12-19', 12, 4, 48, 7),
('2023-12-20', 28, 6, 168, 8),
('2023-12-21', 40, 9, 360, 9),
('2023-12-22', 14, 11, 154, 10);

INSERT INTO [dbo].[NhapKho] ([ngayNhap], [soLuong], [donGia], [tongTien], [hangHoaID]) VALUES
('2023-12-13', 20, 8, 160, 9),
('2023-12-14', 15, 12, 180, 2),
('2023-12-15', 25, 5, 125, 3),
('2023-12-16', 18, 7, 126, 4),
('2023-12-17', 30, 10, 300, 5),
('2023-12-18', 22, 15, 330, 6),
('2023-12-19', 12, 4, 48, 7),
('2023-12-20', 28, 6, 168, 8),
('2023-12-21', 40, 9, 360, 9),
('2023-12-22', 14, 11, 154, 10);

go
create Table NhaPhanPhoi(
 [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ten] VARCHAR(50) NOT NULL ,
	diaChi NVARCHAR(50) NOT NULL, 
soDienThoai VARCHAR(11) 
);

-- Thêm cột nhaPhanPhoiID vào bảng HangHoa
ALTER TABLE HangHoa
ADD nhaPhanPhoiID INT; -- Cột mới để lưu thông tin về nhà phân phối

-- Tạo khóa ngoại liên kết với bảng NhaPhanPhoi
ALTER TABLE HangHoa
ADD CONSTRAINT FK_HangHoa_NhaPhanPhoi FOREIGN KEY (nhaPhanPhoiID) REFERENCES NhaPhanPhoi(id);
-- Thêm dữ liệu cho bảng NhaPhanPhoi
INSERT INTO NhaPhanPhoi (ten, diaChi, soDienThoai)
VALUES
('Công ty TNHH Phân Phối Thực Phẩm Minh Anh', '123 Nguyễn Văn Linh, Quận 1, TP.HCM', '0123456789'),
('Công ty CP Phân Phối Điện Máy Hưng Thịnh', '456 Lê Lợi, Quận 5, TP.HCM', '0987654321'),
('Đại Lý Mỹ Phẩm Lan Anh', '789 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '0365478952'),
('Cửa Hàng Vật Liệu Xây Dựng Hoàng Gia', '101 Lê Thánh Tôn, Quận 3, TP.HCM', '0909123456'),
('Nhà Phân Phối Thiết Bị Y Tế Minh Hải', '231 Cách Mạng Tháng 8, Quận 10, TP.HCM', '0765432198'),
('Công Ty TNHH Nha Khoa Ngọc Hòa', '56 Nguyễn Huệ, Quận 7, TP.HCM', '0321876543'),
('Đại Lý Sơn Nước Đông Á', '876 Huỳnh Văn Bánh, Quận Phú Nhuận, TP.HCM', '0918234567'),
('Cửa Hàng Máy Tính An Phát', '456 Lê Hồng Phong, Quận Tân Bình, TP.HCM', '0976543210'),
('Công Ty TNHH Dược Phẩm Minh Tâm', '321 Hoàng Hoa Thám, Quận Tân Phú, TP.HCM', '0854321098'),
('Siêu Thị Thực Phẩm Xanh', '999 Trần Hưng Đạo, Quận Bình Thạnh, TP.HCM', '0945678901');
go

