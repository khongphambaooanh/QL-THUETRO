Create database QL_THUETRO_BO
Go
Use QL_THUETRO_BO
Go

Create table NHANVIEN
(
	MaNV varchar(10) primary key not null,
	HoTenNV nvarchar(100) not null,
	NgaySinhNV date,
	GioiTinhNV bit default(1),
	DiaChiNV nvarchar(100),
	SdtNV varchar(15),
	SoCMND varchar(50),
	AnhNV	Varchar(100)
)
Go 

Create Table KHACHHANG
(
	MaKH	varchar(100) primary key not null,
	HoTen	Nvarchar(50),
	NgaySinh	Date,
	GioiTinh bit default(1),
	DiachiKH	Nvarchar(200),
	DienThoaiKH	Varchar(50),
	CMND varchar(20),
	AnhKH	Varchar(100),
	Email Varchar(100),
	MaPT varchar(10) not null foreign key references PHONGTRO(MaPT)
	On update cascade
	On delete cascade
)
Go

Create table LOAIPHONGTRO
(
	MaLPT varchar(10) primary key not null,
	TenLPT nvarchar(200)
)
Go

Create Table PHONGTRO
(
	MaPT varchar(10) primary key not null,
	DienTich nvarchar(100),
	TiecIch nvarchar(200),
	DonGia Decimal(18,0)	Check(DonGia>=0),
	TrangThai nvarchar(100),
	NgayCapNhat	Date,
	AnhPT	Varchar(100),
	MaLPT varchar(10) not null foreign key references LOAIPHONGTRO(MaLPT)
	On update cascade
	On delete cascade
)
Go

Create table DATPHONG
(
	MaDP int identity (0,1) primary key,
	NgayDat date,
	MaPT varchar(10) not null foreign key references PHONGTRO(MaPT),
	--MaNV varchar(10) not null foreign key references NHANVIEN(MaNV),
	MaKH varchar(100) not null foreign key references KHACHHANG(MaKH)
	On update cascade
	On delete cascade
)
Go
--Create Table PHONGCHUATHUE
--(
--	MaPCT varchar(10) primary key not null,
--	DienTichP nvarchar(100),
--	TiecIchP nvarchar(200),
--	DonGiaP Decimal(18,0)	Check(DonGiaP>=0),
--	TrangThaiP nvarchar(100),
--	NgayCN	Date,
--	AnhPCT	Varchar(100),
--	MaLPT varchar(10) not null foreign key references LOAIPHONGTRO(MaLPT)
--	On update cascade
--	On delete cascade
--)
--Go

Create Table HOPDONG
(
	MaHD varchar(10) primary key not null,
	NgayTaoHD date,
	TienCoc Decimal(18,0)	Check(TienCoc>=0),
	GhiChu nvarchar(100) null,
	MaPT varchar(10) not null foreign key references PHONGTRO(MaPT),
	MaNV varchar(10) not null foreign key references NHANVIEN(MaNV),
	MaKH varchar(100) not null foreign key references KHACHHANG(MaKH)
	On update cascade
	On delete cascade
)
Go

Create Table PHIEUTHUTIEN
(
	SoPhieu varchar(10) primary key not null,
	NgayThu date,
	ThangCanThu nvarchar(50),
	TienThue Decimal(18,0)	Check(TienThue>=0),
	TienDien Decimal(18,0)	Check(TienDien>=0),
	TienNuoc Decimal(18,0)	Check(TienNuoc>=0),
	TrangThai nvarchar(100),
	MaKH varchar(100) not null foreign key references KHACHHANG(MaKH),
	MaNV varchar(10) not null foreign key references NHANVIEN(MaNV),
	MaPT varchar(10) not null foreign key references PHONGTRO(MaPT)
	On update cascade
	On delete cascade
)
Go

Create Table SUCO
(
	MaSC varchar(10) primary key not null,
	TenSC nvarchar(300)
)
Go

Create Table BIENBANSUCO
(
	SoBB varchar(10) primary key not null,
	NgayLap date,
	LyDo nvarchar(1000),
	HinhThucXuLy nvarchar(1000),
	MaSC varchar(10) not null foreign key references SUCO(MaSC),
	MaPT varchar(10) not null foreign key references PHONGTRO(MaPT),
	MaNV varchar(10) not null foreign key references NHANVIEN(MaNV),
	MaKH varchar(100) not null foreign key references KHACHHANG(MaKH)
	On update cascade
	On delete cascade
)
Go

--Create Table HOADONBOITHUONG
--(
--	SoHD varchar(10) primary key not null,
--	NgayThanhToan date,
--	TienThanhToan Decimal(18,0)	Check(TienThanhToan>=0),
--	MaNV varchar(10) not null foreign key references NHANVIEN(MaNV),
--	MaKH varchar(10) not null foreign key references KHACHHANG(MaKH),
--	SoBB varchar(10) not null foreign key references BIENBANSUCO(SoBB)
--	On update cascade
--	On delete cascade
--)
--Go


Insert into NHANVIEN values
	('NV01',N'Huỳnh Trọng Phú','10/7/2000',1,N'p Cam Phúc Bắc, Cam Ranh, Khánh Hòa','0983 994 342','225679654','NV01.jpg'),
	('NV02',N'Lê Hồng Nhi','4/12/2000',0,N'Thị trấn Vạn Giã, Khánh Hòa','0981 648 550','225822743','NV02.jpg'),
	('NV03',N'Nguyễn Như Ngọc','5/15/2000',0,N'tp Tuy Hòa, Phú Yên','0399 211 550','225822641','NV03.jpg')
Select *from NHANVIEN
Go

--Insert into KHACHHANG values
--	('KH01',N'Khổng Phạm Bảo Oanh','9/9/2000',0,N'Đặng Trần Côn, p Cam Phúc Bắc, Cam Ranh - Khánh Hòa','0347 284 529','225822995','KH01.jpg','PT01'),
--	('KH02',N'Đinh Văn Thiện','3/10/1992',1,N'Thị xã Ninh Hòa, Khánh Hòa','0567 888 777','225822773','KH02.jpg','PT02'),
--	('KH03',N'Nguyễn Minh Lâm','3/18/2000',1,N'Thị trấn Vạn Giã, Vạn Ninh, Khánh Hòa','0987 271 271','225822657','KH03.jpg','PT03'),
--	('KH04',N'Nguyễn Trọng Hiếu','7/21/2002',1,N'Thị trấn Vạn Giã, Khánh Hòa','0347 284 529','225754233','KH04.jpg','PT03'),
--	('KH05',N'Nguyễn Lâm Tâm Như','6/23/2000',0,N'Cam An Nam, tp Cam Ranh - Khánh Hòa','0347 284 522','225822706','KH05.jpg','PT05'),
--	('KH06',N'Lê Thị Mỹ Diệu','10/7/2000',0,N'tp Quảng Ngãi','0987 735 648','225651342','KH06.jpg','PT05')
--Select *from KHACHHANG
--Go

Insert into KHACHHANG values
	('KH01',N'Khổng Phạm Bảo Oanh','9/9/2000',0,N'Đặng Trần Côn, p Cam Phúc Bắc, Cam Ranh - Khánh Hòa','0347 284 529','225822995','KH01.jpg','oanhkhong.090900@gmail.com','PT01'),
	('KH02',N'Đinh Văn Thiện','3/10/1992',1,N'Thị xã Ninh Hòa, Khánh Hòa','0567 888 777','225822773','KH02.jpg','thien123@gmail.com','PT02'),
	('KH03',N'Nguyễn Minh Lâm','3/18/2000',1,N'Thị trấn Vạn Giã, Vạn Ninh, Khánh Hòa','0987 271 271','225822657','KH03.jpg','lamnguyen18@gmail.com','PT03'),
	('KH04',N'Nguyễn Trọng Hiếu','7/21/2002',1,N'Thị trấn Vạn Giã, Khánh Hòa','0347 284 529','225754233','KH04.jpg','hieuhieu21@gmail.com','PT03'),
	('KH05',N'Nguyễn Lâm Tâm Như','6/23/2000',0,N'Cam An Nam, tp Cam Ranh - Khánh Hòa','0347 284 522','225822706','KH05.jpg','tamnhu79@gmail.com','PT05'),
	('KH06',N'Lê Thị Mỹ Diệu','10/7/2000',0,N'tp Quảng Ngãi','0987 735 648','225651342','KH06.jpg','mydieu710@gmail.com','PT05')
Select *from KHACHHANG
Go

Insert into LOAIPHONGTRO values
	('LP01',N'Phòng trọ thông thường'),
	('LP02',N'Phòng trọ cỡ nhỏ'),
	('LP03',N'Phòng trọ rộng')
Select *from LOAIPHONGTRO
Go

Insert into PHONGTRO Values
	('PT01',N'12 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1000000,N'Đã cho thuê','5/10/2007','p1.jpg','LP01'),
	('PT02',N'12 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1000000,N'Đã cho thuê','5/12/2007','p2.jpg','LP01'),
	('PT03',N'12 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1000000,N'Đã cho thuê','5/15/2007','p3.jpg','LP01'),
	('PT05',N'10 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',900000,N'Đã cho thuê','5/17/2007','p5.jpg','LP02'),
	('PT04',N'12 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1000000,N'Còn trống','5/16/2007','p4.jpg','LP01'),
	('PT06',N'10 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',900000,N'Còn trống','5/17/2007','p6.jpg','LP02'),
	('PT07',N'10 mét vuông',N'1 nhà vệ sinh, 1 bếp, điện, nước',800000,N'Còn trống','5/17/2007','p7.jpg','LP02'),
	('PT08',N'14 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1200000,N'Còn trống','6/2/2007','p8.jpg','LP03'),
	('PT09',N'14 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1200000,N'Còn trống','6/2/2007','p9.jpg','LP03'),
	('PT10',N'14 mét vuông',N'1 nhà vệ sinh, 1 bếp, 1 tủ gỗ, điện, nước',1200000,N'Còn trống','6/3/2007','p10.jpg','LP03')
Select *from PHONGTRO
Go


Insert into HOPDONG Values
	('HD01','9/1/2018',500000,null,'PT01','NV02','KH01'),
	('HD02','8/10/2014',500000,null,'PT02','NV02','KH02'),
	('HD03','3/1/2022',500000,null,'PT03','NV03','KH03'),
	('HD04','11/5/2019',500000,null,'PT05','NV03','KH05')
Select *from HOPDONG
Go

Insert into PHIEUTHUTIEN Values
	('P01','2/1/2022',N'Tháng 1',1000000,235000,17000,N'Đã thu','KH01','NV02','PT01'),
	('P02','2/1/2022',N'Tháng 1',1000000,125000,17000,N'Đã thu','KH02','NV02','PT02'),
	('P03','2/1/2022',N'Tháng 1',900000,340000,34000,N'Đã thu','KH05','NV03','PT05'),

	('P04','3/1/2022',N'Tháng 2',1000000,326000,17000,N'Đã thu','KH01','NV02','PT01'),
	('P05','3/1/2022',N'Tháng 2',1000000,180000,17000,N'Đã thu','KH02','NV02','PT02'),
	('P06','3/1/2022',N'Tháng 2',900000,315000,17000,N'Đã thu','KH05','NV03','PT05'),

	('P07','4/1/2022',N'Tháng 3',1000000,334000,17000,N'Đã thu','KH01','NV02','PT01'),
	('P08','4/1/2022',N'Tháng 3',1000000,202000,17000,N'Đã thu','KH02','NV02','PT02'),
	('P09','4/1/2022',N'Tháng 3',1000000,274000,17000,N'Đã thu','KH03','NV03','PT03'),
	('P10','4/1/2022',N'Tháng 3',900000,298000,17000,N'Đã thu','KH05','NV03','PT05'),

	('P11','5/1/2022',N'Tháng 4',1000000,308000,34000,N'Đã thu','KH01','NV01','PT01'),
	('P12','5/1/2022',N'Tháng 4',1000000,256000,17000,N'Đã thu','KH02','NV01','PT02'),
	('P13','5/1/2022',N'Tháng 4',1000000,370000,17000,N'Đã thu','KH03','NV01','PT03'),
	('P14','5/1/2022',N'Tháng 4',900000,323000,17000,N'Đã thu','KH05','NV01','PT05')
Select *from PHIEUTHUTIEN
Go

Insert into SUCO Values
	('SC01',N'Cháy bóng đèn'),
	('SC02',N'Nổ bình gas'),
	('SC03',N'Tắt ống bồn cầu'),
	('SC04',N'Vỡ cửa ra vào'),
	('SC05',N'Hỏng đồng hồ nước'),
	('SC06',N'Điện quá tải cháy cầu giao'),
	('SC07',N'Mâu thuẫn giữa các phòng'),
	('SC08',N'Cho người ngoài vào trọ, làm mất tài sản của các phòng khác')
Select *from SUCO
Go

Insert into BIENBANSUCO Values
	('BB01','9/10/2019',N'Nhiều lần cho giấy khô vào bồn dẫn đến tắt nghẽn.',N'Bồi thường tiền theo yêu cầu của bên cho thuê','SC03','PT02','NV02','KH02'),
	('BB02','4/27/2022',N'Tắt - bật nhiều lần gây ra cháy bóng đèn.',N'Bồi thường tiền theo yêu cầu của bên cho thuê','SC01','PT03','NV03','KH03')
Select *from BIENBANSUCO
Go



--dữ liệu tài khoản user:
create table Users
(
	idUser int identity(1,1) primary key,
	Firstname nvarchar(100),
	Lastname nvarchar(100),
	Email nvarchar(50),
	Password nvarchar(50)
)
Go
--Dữ liệu cập nhật: Tài khoản quản trị
Create table Admin
(
	UserAdmin varchar(30) primary key,
	PassAdmin varchar(30) not null,
	Hoten nVarchar(50)
)
Go
Insert into Admin values('admin','123',N'Khổng Phạm Bảo Oanh')
Insert into Admin values('user','000','Mr Oanh')
select *from Admin

Create table TaiKhoan
(
	Id int identity primary key,
	username char(20),
	password char(20),
	Admin bit,
	HoTen nvarchar(50)
)
Go
Insert into TaiKhoan Values
	('admin','123',1,N'Khổng Phạm Bảo Oanh'),
	('nang','123',0,N'Lê Văn Năng')