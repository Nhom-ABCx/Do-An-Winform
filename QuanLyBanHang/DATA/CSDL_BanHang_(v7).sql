USE [master]
GO
-- hay thay doi lien ket den SQL truoc khi thuc hien chay
CREATE DATABASE [CSDL_BanHang] ON  PRIMARY 
( NAME = N'banhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CSDL_BanHang.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'banhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CSDL_BanHang_log.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
USE [CSDL_BanHang]
GO
--TAO BANG Loai Tai Khoan
CREATE TABLE [dbo].[LoaiTK] (
	[MaLoai]	VARCHAR(10)	 NOT NULL,
    [TenLoai]   NVARCHAR (15)    NULL,
    [Mota]    NVARCHAR (100)	 NULL,
    PRIMARY KEY CLUSTERED ([MaLoai] ASC)
);
GO
insert LoaiTK values
('AD',N'ADMIN',N'Tài khoản Admin'),
('KH',N'Khách hàng',N'Tài khoản dành cho khách hàng'),
('NV',N'Nhân Viên',N'Tài khoản nhân viên'),
('QLKho',N'Quản Lý Kho',N'Tài khoản quản lý kho'),
('QLNS',N'Quản Lý Nhân Sự',N'Tài khoản Quản lý nhân sự, tuyển dụng, quản lý nhân viên'),
('ThuNgan',N'Thu Ngân',N'Tài khoản Thu ngân, quản lý tiền các loại')
GO
--TAO BANG TAI KHOAN
CREATE TABLE [dbo].[TaiKhoan] (
	[MaTK]		VARCHAR	(10) NOT NULL,
    [MaLoai]	VARCHAR (10) NOT NULL,
    [eMail]     VARCHAR (50) NOT NULL UNIQUE,
    [MatKhau]   VARCHAR (50) NOT NULL,
    [Phone]     VARCHAR (24)     NULL UNIQUE,
    [NgayKhoiTao]	DATE		 NULL DEFAULT GETDATE(),
    [TrangThai] BIT	DEFAULT 0 NULL,  --số nguyên 0,1,null
    PRIMARY KEY CLUSTERED ([MaTK] ASC),
    FOREIGN KEY ([MaLoai]) REFERENCES [dbo].[LoaiTK] ([MaLoai]),
);
GO
insert TaiKhoan values
('Admin','AD','Admin@gmail.com','Msyeszv9','0621775982','1976/03/30','1'),
('KH001','KH','kh001@gmail.com','Uzgapjc9','0658378906','1982/09/06','1'),
('KH002','KH','kh002@gmail.com','Ooppwqg7','0491128355','1988/04/04','0'),
('KH003','KH','kh003@gmail.com','Yhcftpf2','0772730324','1983/10/26','1'),
('KH004','KH','kh004@gmail.com','Eictoqw8','0306030371','1989/11/24','1'),
('KH005','KH','kh005@gmail.com','Yurfulx1','0138095506','1976/07/30','0'),
('KH006','KH','kh006@gmail.com','Mzrlwvs1','0364367922','2005/05/07','1'),
('KH007','KH','kh007@gmail.com','Jtcoqgm7','0470447656','2009/04/04','0'),
('KH008','KH','kh008@gmail.com','Hmydtdl5','0408400461','1975/04/02','0'),
('KH009','KH','kh009@gmail.com','Nvginfs1','0976540784','2001/09/17','1'),
('KH010','KH','kh010@gmail.com','Xlgnhvy0','0616118092','1997/03/05','1'),
('KH011','KH','kh011@gmail.com','Tpvmsml5','0335324636','1988/12/31','1'),
('KH012','KH','kh012@gmail.com','Nacgmwd2','0451064863','2010/03/09','1'),
('KH013','KH','kh013@gmail.com','Yitokrz4','0308598100','1991/05/01','1'),
('KH014','KH','kh014@gmail.com','Nwfufqt2','0388547071','1999/09/26','0'),
('KH015','KH','kh015@gmail.com','Qbrvbgy3','0759335720','2014/02/22','1'),
('NV001','NV','nv001@gmail.com','Rcsvono0','0110863628','1988/03/20','1'),
('NV002','NV','nv002@gmail.com','Wwtpebq4','0821079941','2002/01/03','1'),
('NV003','NV','nv003@gmail.com','Lhdmxyv1','0220052308','1987/08/18','1'),
('NV004','NV','nv004@gmail.com','Uacdctr2','0757585537','1991/09/21','1'),
('NV005','NV','nv005@gmail.com','Rxnnwrq4','0106306545','2015/06/27','1'),
('QLKho006','QLKho','qlkho001@gmail.com','Dnapxkq5','0261126684','1975/07/06','1'),
('QLKho007','QLKho','qlkho002@gmail.com','Rbhqrzo7','0454582014','1983/12/09','1'),
('QLKho008','QLKho','qlkho003@gmail.com','Hpqrfiz2','0519366915','1998/09/05','0'),
('QLNS009','QLNS','qlns001@gmail.com','Tdmweis3','0847015790','2010/02/10','1'),
('ThuNgan010','ThuNgan','ThuNgan001@gmail.com','Vqonmdm0','0975659537','1992/10/15','1'),
('ThuNgan011','ThuNgan','ThuNgan002@gmail.com','Qnfjcln6','0230999609','2012/02/12','1'),
('ThuNgan012','ThuNgan','ThuNgan003@gmail.com','Ztvkblv1','0328836098','1980/09/25','1')
GO
--TAO BANG NHANVIEN
CREATE TABLE [dbo].[NhanVien] (
    [MaNV]			VARCHAR	 (15)  NOT NULL,
    [HoTenNV]		NVARCHAR (100)NULL,
    [NgaySinh]		DATE		  NULL,
    [GioiTinh]		NVARCHAR (3)  NULL,
    [DiaChi]		NVARCHAR (100)NULL,
    [MaTK]			VARCHAR(10)	  NULL,
    [LuongCB]			MONEY		  NULL DEFAULT 24000,
    [TongGioLam]	INT			  NULL,  -- tong số giờ làm việc
    [URL]		VARCHAR	(254)	  NULL,
    [TrangThai]		BIT	DEFAULT 0 NULL,  --số nguyên 0,1,null
    PRIMARY KEY CLUSTERED ([MaNV] ASC),
    FOREIGN KEY ([MaTK]) REFERENCES [dbo].[TaiKhoan] ([MaTK]),
    CHECK(GioiTinh=N'Nam' or GioiTinh=N'Nữ'),
    CHECK(YEAR(GETDATE())-YEAR(NgaySinh)>=18)
);
GO
create trigger LuongCB
on NhanVien
after insert,update as
begin
	update NhanVien
	set LuongCB=50000 where MaTK in (select NhanVien.MaTK from NhanVien,TaiKhoan,LoaiTK where NhanVien.MaTK=TaiKhoan.MaTK and TaiKhoan.MaLoai=LoaiTK.MaLoai and LoaiTK.MaLoai='AD')
	update NhanVien
	Set LuongCB=40000 where MaTK in (select NhanVien.MaTK from NhanVien,TaiKhoan,LoaiTK where NhanVien.MaTK=TaiKhoan.MaTK and TaiKhoan.MaLoai=LoaiTK.MaLoai and LoaiTK.MaLoai='QLNS')
	update NhanVien
	set LuongCB=30000 where MaTK in (select NhanVien.MaTK from NhanVien,TaiKhoan,LoaiTK where NhanVien.MaTK=TaiKhoan.MaTK and TaiKhoan.MaLoai=LoaiTK.MaLoai and LoaiTK.MaLoai='QLKho')
	update NhanVien
	set LuongCB=20000 where MaTK in (select NhanVien.MaTK from NhanVien,TaiKhoan,LoaiTK where NhanVien.MaTK=TaiKhoan.MaTK and TaiKhoan.MaLoai=LoaiTK.MaLoai and LoaiTK.MaLoai='ThuNgan')
	update NhanVien
	set LuongCB=10000 where MaTK in (select NhanVien.MaTK from NhanVien,TaiKhoan,LoaiTK where NhanVien.MaTK=TaiKhoan.MaTK and TaiKhoan.MaLoai=LoaiTK.MaLoai and LoaiTK.MaLoai='NV')
end
GO
insert NhanVien values('000',N'Administrator','1998/03/19',N'Nữ',N'TP HCM','Admin',null,null,'user admin.png',1)
insert NhanVien values('001',N'Bà Huyện Thanh Quan','1997/08/16',N'Nam',N'O7, Cao Bá Nhạ, Hậu Giang','NV001',null,null,'remove_user.png',1)
insert NhanVien values('002',N'Nguyễn Hữu Cảnh','1989/04/01',N'Nữ',N'P7, Đồng Khởi, Lào Cai','NV002',null,null,'send_user.png',1)
insert NhanVien values('003',N'Alexandre de Rhodes','1997/04/21',N'Nam',N'B0, Lê Lai, Thái Bình','NV003',null,null,'user.png',1)
insert NhanVien values('004',N'Hồ Huấn Nghiệp','1998/06/19',N'Nữ',N'J5, Nguyễn Hữu Cầu, Thanh Hóa','NV004',null,null,'user.png',1)
insert NhanVien values('005',N'Hàm Nghi','2002/11/15',N'Nữ',N'D4, Huỳnh Khương Ninh, Tiền Giang','NV005',null,null,'user.png',1)
insert NhanVien values('006',N'Hồ Tùng Mậu','1985/06/17',N'Nam',N'P1, Bùi Viện, Hải Phòng','QLKho006',null,null,'offline_user.png',1)
insert NhanVien values('007',N'Nguyễn Cư Trinh','1992/04/01',N'Nam',N'W7, Mai Thị Lựu, Trà Vinh','QLKho007',null,null,'offline_user.png',1)
insert NhanVien values('008',N'Bùi Viện','1990/09/14',N'Nữ',N'D3, Nam Quốc Cang, Bình Định','QLKho008',null,null,'add_user.png',1)
insert NhanVien values('009',N'Lý Tự Trọng','1987/06/11',N'Nam',N'V6, Chu Mạnh Trinh, Tuyên Quang','QLNS009',null,null,'send_user.png',1)
insert NhanVien values('010',N'Lý Văn Phức','1979/05/15',N'Nữ',N'F7, Nguyễn Huệ, Kon Tum','ThuNgan010',null,null,'edit_user.png',1)
insert NhanVien values('011',N'Nguyễn Du','2001/07/21',N'Nữ',N'D9, Nguyễn Phi Khanh, Thái Bình','ThuNgan011',null,null,'edit_user.png',1)
insert NhanVien values('012',N'Cao Thắng','1988/11/27',N'Nữ',N'O6, Alexandre de Rhodes, Hậu Giang','ThuNgan012',null,null,'edit_user.png',1)
GO
--TAO BANG Ngay Lam Viec
CREATE TABLE [dbo].[NgayLamViec] (
    [Ngay]		DATE	NOT NULL DEFAULT GETDATE(),
    [MaNV]		VARCHAR (15)NULL,
    [GioBD]		TIME			NULL,
    [GioKT]		TIME			NULL,
    [SoGio]		INT				NULL,
    FOREIGN KEY ([MaNV]) REFERENCES [dbo].[NhanVien] ([MaNV]),
);
GO
create trigger SoGio
on NgayLamViec
after insert,update as
begin
	update NgayLamViec
	set SoGio =(select DATEDIFF(HOUR,CONVERT(datetime,GioBD),CONVERT(datetime,GioKT)) from NgayLamViec where MaNV=(select MaNV from inserted where inserted.MaNV=MaNV) and Ngay=(select Ngay from inserted where inserted.Ngay=Ngay))
	where MaNV=(select MaNV from inserted where inserted.MaNV=MaNV)and Ngay=(select Ngay from inserted where inserted.Ngay=Ngay)
end
GO
create trigger TongGioLam
on NgayLamViec
after insert,update as
begin
	update NhanVien
	set TongGioLam =(select SUM(SoGio) from NgayLamViec
				 where NhanVien.MaNV=NgayLamViec.MaNV 
				  group by NgayLamViec.MaNV)
end
GO
insert NgayLamViec values('2021/01/11','005','07:30:00.0000000','11:30:00.0000000',null)
insert NgayLamViec values('2021/01/15','009','12:30:00.0000000','16:30:00.0000000',null)
insert NgayLamViec values('2021/01/22','010','12:30:00.0000000','16:30:00.0000000',null)
insert NgayLamViec values('2021/03/18','011','07:30:00.0000000','11:30:00.0000000',null)
insert NgayLamViec values('2021/01/27','007','18:30:00.0000000','22:30:00.0000000',null)
insert NgayLamViec values('2021/04/07','005','18:30:00.0000000','22:30:00.0000000',null)
insert NgayLamViec values('2021/03/30','006','07:30:00.0000000','11:30:00.0000000',null)
insert NgayLamViec values('2021/04/28','008','18:30:00.0000000','22:30:00.0000000',null)
insert NgayLamViec values('2021/01/04','000','12:30:00.0000000','16:30:00.0000000',null)
insert NgayLamViec values('2021/04/29','009','18:30:00.0000000','22:30:00.0000000',null)
insert NgayLamViec values('2021/01/29','007','18:30:00.0000000','22:30:00.0000000',null)
GO
--TAO BANG KHACH HANG
CREATE TABLE [dbo].[KhachHang] (
    [MaKh]	   VARCHAR  (15)  NOT NULL,
    [HoTenKh]  NVARCHAR (100) NULL,
    [DiaChi]   NVARCHAR (100) NULL,
    [MaTK]		VARCHAR(10)	  NULL,
    [TrangThai] BIT	DEFAULT 0 NULL,  --số nguyên 0,1,null
    PRIMARY KEY CLUSTERED ([MaKh] ASC),
    FOREIGN KEY ([MaTK]) REFERENCES [dbo].[TaiKhoan] ([MaTK])
);
GO
insert KhachHang values
('001',N'Khách 1',N'Việt Nam','KH001',1),
('002',N'Khách 2',N'Trung Quốc','KH002',0),
('003',N'Khách 3',N'Lào Cai','KH003',1),
('004',N'Khách 4',N'Mỹ Tho','KH004',0),
('005',N'Khách 5',N'Singapore','KH005',0),
('006',N'Khách 6',N'Ấn Độ','KH006',0),
('007',N'Khách 7',N'Châu Phi','KH007',0),
('008',N'Khách 8',N'Campuchia','KH008',0),
('009',N'Khách 9',N'Cuba','KH009',1),
('010',N'Khách 10',N'Japan','KH010',1),
('011',N'Khách 11',N'Korea','KH011',1),
('012',N'Khách 12',N'Mông cổ','KH012',1),
('013',N'Khách 13',N'Pháp','KH013',1),
('014',N'Khách 14',N'Nga','KH014',1),
('015',N'Khách 15',N'Việt Nam','KH015',1)
GO
--TAO BANG LOAI SAN PHAM
CREATE TABLE [dbo].[LoaiSanPham] (
	[MaLoai]  CHAR  (3)  NOT NULL,
    [TenLoai] NVARCHAR (50)		 NULL,
    [Mota]    NVARCHAR (100)	 NULL,
    PRIMARY KEY CLUSTERED ([MaLoai] ASC)
);
GO
insert LoaiSanPham values
('DLx',N'Điện lạnh',null),
('DTx',N'Điện thoại',N'Smart Phone'),
('LTx',N'LapTop',null),
('MAx',N'Máy ảnh',null),
('MTB',N'Máy tính bảng',null),
('PKx',N'Phụ kiện',null)
GO
--TAO BANG  NHA CUNG CAP
CREATE TABLE [dbo].[NhaCungCap] (
    [MaNcc]		CHAR	(3)	  NOT NULL,
    [TenNcc]		NVARCHAR(100)	  NULL,
    [Diachi]	NVARCHAR(100)	  NULL,
    [Phone]		VARCHAR	(24)	  NULL,
    [eMail]		VARCHAR	(50)	  NULL,
    PRIMARY KEY CLUSTERED ([MaNcc] ASC)
);
GO
insert NhaCungCap values
('CAN',N'Cannon',N'V2, Lê Thị Riêng, Hà Nam',0172331178,'Cannon@gmail.com'),
('IPh',N'IPhone',N'N3, Hoàng Sa, Tây Ninh',0839435894,'IPhone@gmail.com'),
('MIx',N'Xiaomi',N'Z7, Lê Thánh Tôn, Lào Cai',0977786246,'Xiaomi@gmail.com'),
('SNK',N'SaNaKy',N'E4, Lê Anh Xuân, Phú Yên',0486800539,'SaNaKy@gmail.com'),
('SNY',N'SONY',N'V2, Lê Thị Riêng, Hà Nam',0180284667,'SONY@gmail.com'),
('SAM',N'SamSung',N'M8, Nguyễn Cư Trinh, Lai Châu',0257267331,'SamSung@gmail.com'),
('VIV',N'ViVo',N'R1, Lê Công Kiều, Hải Phòng',0427871806,'ViVo@gmail.com'),
('ELE',N'Electrolux',N'F3, Nguyễn Cảnh Chân, Khánh Hòa',0275281380,'Electrolux@gmail.com'),
('LGx',N'LG',N'N1, Nam Quốc Cang, Nam Định',0453153710,'LG@gmail.com'),
('TOS',N'Toshiba',N'J4, Calmette, Hà Nam',0111760833,'Toshiba@gmail.com'),
('ACE',N'Acer',N'F9, Nguyễn Hữu Cầu, Cao Bằng',0449952292,'Acer@gmail.com'),
('ASU',N'ASUS',N'H6, Huỳnh Khương Ninh, Hà Tĩnh',0635035498,'ASUS@gmail.com')
GO
--TAO BANG SAN PHAM
CREATE TABLE [dbo].[SanPham] (
    [MaSp]      VARCHAR	 (15)  NOT NULL,
    [TenSp]     NVARCHAR (25) NULL,
    [MoTa]      NVARCHAR (200) NULL,
    [SoLuong]   INT            NULL, --số lượng nhập
    [GiaNhap]   MONEY          NULL,
    [GiaBan]   MONEY		   NULL,
	[NgayNhap] DATETIME      NULL DEFAULT GETDATE(),
    [MaNcc]      CHAR  (3)	   NULL,
    [Loai]		CHAR (3)   NULL,
    [TrangThai] BIT	DEFAULT 0  NULL,  --số nguyên 0,1,null
    [URL]		VARCHAR	(254)  NULL,
    PRIMARY KEY CLUSTERED ([MaSp] ASC),
    FOREIGN KEY ([MaNcc]) REFERENCES [dbo].[NhaCungCap] ([MaNcc]),
    FOREIGN KEY ([Loai]) REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
);
GO
insert SanPham values
('DLx-ELE-001',N'Máy giặt Electrolux 10 Kg','2 Năm',22,4169244,6699725,'2017/12/22','ELE','DLx',1,'electrolux-eww1042aewa-11-300x300.jpg'),
('DLx-LGx-001',N'Máy giặt Beko 9Kg','2 Năm',45,5586315,6125437,'2019/08/28','LGx','DLx',1,'beko-wcv9612xb0st-9-300x300.jpg'),
('DLx-SAM-001',N'Samsung Inverter 12','2 Năm',47,2916675,6537566,'2015/09/17','SAM','DLx',1,'samsung-wa12t5360bv-sv-11-300x300.jpg'),
('DLx-TOS-001',N'Máy giặt Toshiba 9.5 Kg','32Gb',37,1396375,7623487,'2017/10/12','TOS','DLx',1,'toshiba-tw-bk105g4v-mg-300x300.jpg'),
('DTx-MIx-001',N'Điện thoại xiaomi-mi-a1','1 Năm FullBox',48,1630419,4691434,'2019/03/12','MIx','DTx',1,'xiaomi-mi-a1-32gb-vang-dong-200x200.jpg'),
('DTx-MIx-002',N'Điện thoại xiaomi-mi-a2','16Gb',48,3735416,9585183,'2015/01/22','MIx','DTx',1,'xiaomi-mi-a1-vang-hong-400x400.jpg'),
('DTx-MIx-003',N'Đt xiaomi-redmi-5-plus','32Gb',15,3508215,5418497,'2018/09/04','MIx','DTx',1,'xiaomi-redmi-5-plus-2-1-400x400.jpg'),
('DTx-MIx-004',N'Điện thoại xiaomi-mi-a1','1 Năm FullBox',30,7009326,7408616,'2016/08/27','MIx','DTx',1,'xiaomi-mi-a1-32gb-vang-dong-200x200.jpg'),
('DTx-MIx-005',N'Điện thoại xiaomi-mi-a2','16Gb',6,4606603,6297164,'2016/05/05','MIx','DTx',1,'xiaomi-mi-a1-vang-hong-400x400.jpg'),
('DTx-MIx-006',N'Đt xiaomi-redmi-5-plus','32Gb',48,8423740,9352331,'2021/02/20','MIx','DTx',1,'xiaomi-redmi-5-plus-2-1-400x400.jpg'),
('DTx-MIx-007',N'Điện thoại xiaomi-mi-a1','1 Năm FullBox',23,5047949,6722180,'2015/05/06','MIx','DTx',1,'xiaomi-mi-a1-32gb-vang-dong-200x200.jpg'),
('DTx-MIx-008',N'Điện thoại xiaomi-mi-a2','16Gb',36,1679069,1858983,'2021/01/17','MIx','DTx',1,'xiaomi-mi-a1-vang-hong-400x400.jpg'),
('DTx-MIx-009',N'Đt xiaomi-redmi-5-plus','1 Năm FullBox',36,4454712,6798532,'2017/10/24','MIx','DTx',1,'xiaomi-redmi-5-plus-2-1-400x400.jpg'),
('DTx-SAM-001',N'samsung-galaxy-tab-e-96','1 Năm FullBox',1,8937769,8970484,'2015/02/14','SAM','DTx',1,'samsung-galaxy-tab-e-96-sm-t561-thumb-400x400.jpg'),
('DTx-SAM-002',N'samsung-galaxy-tab-e-96','1 Năm FullBox',28,8722461,9966976,'2018/11/24','SAM','DTx',1,'samsung-galaxy-tab-e-96-sm-t561-thumb-400x400.jpg'),
('DTx-SAM-003',N'samsung-galaxy-tab-e-96','1 Năm FullBox',3,7477782,9192689,'2021/01/13','SAM','DTx',1,'samsung-galaxy-tab-e-96-sm-t561-thumb-400x400.jpg'),
('DTx-VIV-001',N'Điện thoại vivo-y85-red','I3',20,4093311,8735953,'2018/03/27','VIV','DTx',1,'vivo-y85-red-docquyen-400x400.jpg'),
('LTx-ACE-001',N'LapTop acer-aspire-a314','I7',6,2408650,7906451,'2017/03/28','ACE','LTx',1,'acer-aspire-a314-31-c2ux-nxgnssv008-ava-1-400x400.jpg'),
('LTx-ACE-002',N'LapTop acer-aspire-a715','I5',46,5433788,7155777,'2020/01/30','ACE','LTx',1,'acer-aspire-a715-72g-54pc-gxbsv003-4503-400x400.jpg'),
('LTx-ASU-001',N'LapTop asus-s510ua-i5','I3',25,8728876,9755741,'2018/08/31','ASU','LTx',1,'asus-s510ua-i5-8250u-bq414t-dai-dien-450x300-400x400.jpg'),
('LTx-ASU-002',N'LapTop asus-x44lua-i3','Full box',47,6070088,8899565,'2018/07/23','ASU','LTx',1,'asus-x441ua-i3-6100u-wx027t-450-300-400x400.png'),
('MAx-CAN-001',N'Máy ảnh Cannon EOS 6D','Full box',11,1952281,7849098,'2018/03/18','CAN','MAx',1,'canon-eos-80d-kit-efs-18135mm-f3556-is-usm(1).jpg'),
('MAx-CAN-002',N'Máy ảnh Canon Ixus 185','Full box',1,3059792,3265682,'2015/02/22','CAN','MAx',1,'canon-ixus-185-den(1).jpg'),
('MAx-CAN-003',N'Máy ảnh Canon EOS M50','Full box',27,5608582,6409446,'2015/09/04','CAN','MAx',1,'canon-eos-m50-kit-1545mm-den(2).jpg'),
('MAx-CAN-004',N'Máy ảnh Canon Ixus 285','Full box',22,4653526,9338302,'2020/06/18','CAN','MAx',1,'canon-ixus-285-hs-bac(1).jpg'),
('MAx-CAN-005',N'Máy ảnh Canon Powershot ','Test',17,9487084,9834307,'2017/05/29','CAN','MAx',1,'may-anh-canon-powershot-g7-x-mark-iii-hang-nhap-khau(3).jpg'),
('PKx-SAM-001',N'cap-lightning-2m-evalu','Test',45,3923905,9641385,'2017/09/16','SAM','PKx',1,'cap-lightning-2m-evalu-ltl-04-xanh-navi-avatar-1-600x600.jpg'),
('PKx-SAM-002',N'cap-lightning-20cm-esaver','Test',10,5319765,7934943,'2018/05/13','SAM','PKx',1,'cap-lightning-20cm-esaver-gate-0759p-avatar-1-600x600.jpg'),
('PKx-SAM-003',N'cap-micro-1m-esaver','Test',18,5844500,8778372,'2017/04/21','SAM','PKx',1,'cap-micro-1m-esaver-ds118br-tb-avatar-1-600x600.jpg'),
('PKx-TOS-001',N'cap-micro-usb-20cm','Test',1,2842587,3109420,'2021/04/14','TOS','PKx',1,'cap-micro-usb-20cm-x-mobile-mu03-den-avatar-1-600x600.jpg'),
('PKx-TOS-002',N'tai-nghe-chup-tai-kanen','',1,7550001,9730847,'2015/11/07','TOS','PKx',1,'tai-nghe-chup-tai-kanen-ip-892-2-5-600x600.jpg')
GO
--TAO BANG HOA DON
CREATE TABLE [dbo].[HoaDon] (
    [MaHD]      VARCHAR (20)  NOT NULL,
    [NgayLapHD] DATETIME      NULL DEFAULT GETDATE(),
    [MaNV]      VARCHAR (15)  NULL,
    [MaKh]      VARCHAR	 (15) NULL,
    [DChiGiao] NVARCHAR (100) NULL,
    [TongTien] MONEY NULL,
    [TrangThai] BIT	DEFAULT 0 NULL,  --0 chưa giao chưa bán, 1 đã giao đã bán,
    PRIMARY KEY CLUSTERED ([MaHD] ASC),
    FOREIGN KEY ([MaKh]) REFERENCES [dbo].[KhachHang] ([MaKh]),
    FOREIGN KEY ([MaNV]) REFERENCES [dbo].[NhanVien] ([MaNV]),
);
GO
insert HoaDon values
('001','2021/01/27','010','005',null,null,1),
('002','2021/01/15','009','005',null,null,0),
('003','2021/01/11','005','010',null,null,0),
('004','2021/03/30','007','005',null,null,1),
('005','2021/03/30','007','004',null,null,1),
('006','2021/04/29','009','014',null,null,0),
('007','2021/04/07','005','003',null,null,0),
('008','2021/01/11','005','012',null,null,1),
('009','2021/01/29','010','007',null,null,0),
('010','2021/04/29','009','014',null,null,0),
('011','2021/01/11','005','015',null,null,1),
('012','2021/01/29','010','009',null,null,1),
('013','2021/01/27','010','003',null,null,1),
('014','2021/01/15','009','010',null,null,1),
('015','2021/01/15','009','010',null,null,0),
('016','2021/03/30','007','011',null,null,1),
('017','2021/01/27','010','013',null,null,1),
('018','2021/01/29','010','004',null,null,0),
('019','2021/01/29','010','015',null,null,1),
('020','2021/04/07','005','012',null,null,0),
('021','2021/01/29','010','009',null,null,1),
('022','2021/04/29','009','012',null,null,0),
('023','2021/01/27','010','003',null,null,1),
('024','2021/01/27','010','002',null,null,1),
('025','2021/04/28','000','009',null,null,1),
('026','2021/01/29','010','003',null,null,0),
('027','2021/01/29','010','015',null,null,0),
('028','2021/01/15','009','009',null,null,1),
('029','2021/01/29','010','003',null,null,1),
('030','2021/01/15','009','015',null,null,0)
GO
CREATE TABLE [dbo].[CT_HoaDon] (
    [MaHD]      VARCHAR (20)  NOT NULL,
    [MaSp]		VARCHAR (15)  NOT NULL,
    [SoLuong]   INT				  NULL,
    [GiaGiam]   MONEY			  NULL DEFAULT 0,
    [ChietKhau] int			  NULL DEFAULT 0, --chiet khau theo dang %, vi du    5 => 5%
    [ThanhTien]	MONEY			  NULL,
    PRIMARY KEY CLUSTERED ([MaHD] ASC, [MaSp] ASC),
    FOREIGN KEY ([MaHD]) REFERENCES [dbo].[HoaDon] ([MaHD]),
    FOREIGN KEY ([MaSp]) REFERENCES [dbo].[SanPham] ([MaSp])
);
GO
create trigger ThanhTien
on CT_HoaDon
after insert,update as
begin
	update CT_HoaDon
	set ThanhTien =(select SUM((CT_HoaDon.SoLuong*GiaBan)-(CT_HoaDon.SoLuong*GiaBan*ChietKhau)-GiaGiam) from CT_HoaDon,SanPham
					where MaHD=(select MaHD from inserted where inserted.MaHD=MaHD)and CT_HoaDon.MaSp=(select MaSp from inserted where inserted.MaSp=MaSp) and SanPham.MaSp=(select MaSp from inserted where inserted.MaSp=MaSp)
					group by MaHD)
	where MaHD=(select MaHD from inserted where inserted.MaHD=MaHD)and CT_HoaDon.MaSp=(select MaSp from inserted where inserted.MaSp=MaSp)
end
GO
create trigger TongTien
on CT_HoaDon
after insert,update as
begin
	update HoaDon
	set TongTien =(select SUM(ThanhTien) from CT_HoaDon
					where MaHD=(select MaHD from inserted where inserted.MaHD=MaHD)
					group by MaHD)
	where MaHD=(select MaHD from inserted where inserted.MaHD=MaHD)
end
GO
insert CT_HoaDon values('022','MAx-CAN-003',2,0,0,0)
insert CT_HoaDon values('030','DTx-SAM-002',1,0,0,0)
insert CT_HoaDon values('009','DTx-MIx-005',2,0,0,0)
insert CT_HoaDon values('029','DLx-SAM-001',2,0,0,0)
insert CT_HoaDon values('024','DTx-SAM-002',1,0,0,0)
insert CT_HoaDon values('030','DLx-ELE-001',3,0,0,0)
insert CT_HoaDon values('010','MAx-CAN-003',1,0,0,0)
insert CT_HoaDon values('015','LTx-ASU-001',3,0,0,0)
insert CT_HoaDon values('007','LTx-ACE-001',2,0,0,0)
insert CT_HoaDon values('025','DTx-SAM-002',2,0,0,0)
insert CT_HoaDon values('018','PKx-SAM-001',1,0,0,0)
insert CT_HoaDon values('006','LTx-ASU-002',3,0,0,0)
insert CT_HoaDon values('007','DTx-MIx-001',3,0,0,0)
insert CT_HoaDon values('013','DLx-LGx-001',1,0,0,0)
insert CT_HoaDon values('004','DTx-VIV-001',3,0,0,0)
insert CT_HoaDon values('027','LTx-ACE-001',1,0,0,0)
insert CT_HoaDon values('001','PKx-SAM-001',3,0,0,0)
insert CT_HoaDon values('014','MAx-CAN-002',3,0,0,0)
insert CT_HoaDon values('014','DTx-MIx-002',1,0,0,0)
insert CT_HoaDon values('015','DTx-MIx-003',2,0,0,0)
insert CT_HoaDon values('026','DTx-VIV-001',1,0,0,0)
insert CT_HoaDon values('014','PKx-TOS-002',3,0,0,0)
insert CT_HoaDon values('008','LTx-ASU-001',3,0,0,0)
insert CT_HoaDon values('014','DTx-VIV-001',2,0,0,0)
insert CT_HoaDon values('014','MAx-CAN-005',3,0,0,0)
insert CT_HoaDon values('011','DTx-MIx-002',1,0,0,0)
insert CT_HoaDon values('018','DTx-MIx-009',1,0,0,0)
insert CT_HoaDon values('026','PKx-SAM-003',2,0,0,0)
insert CT_HoaDon values('026','DTx-SAM-002',3,0,0,0)
insert CT_HoaDon values('016','PKx-SAM-001',1,0,0,0)
insert CT_HoaDon values('005','MAx-CAN-004',3,0,0,0)
insert CT_HoaDon values('025','DTx-MIx-006',3,0,0,0)
insert CT_HoaDon values('013','DTx-SAM-002',2,0,0,0)
insert CT_HoaDon values('024','DTx-SAM-003',1,0,0,0)
insert CT_HoaDon values('009','DTx-SAM-001',2,0,0,0)
insert CT_HoaDon values('002','DLx-ELE-001',3,0,0,0)
insert CT_HoaDon values('021','DTx-SAM-001',3,0,0,0)
insert CT_HoaDon values('003','DTx-MIx-004',2,0,0,0)
insert CT_HoaDon values('024','DTx-MIx-008',1,0,0,0)
insert CT_HoaDon values('020','LTx-ASU-002',2,0,0,0)
insert CT_HoaDon values('023','DLx-SAM-001',3,0,0,0)
insert CT_HoaDon values('012','DTx-SAM-003',1,0,0,0)
insert CT_HoaDon values('012','PKx-SAM-001',2,0,0,0)
insert CT_HoaDon values('002','DTx-MIx-003',2,0,0,0)
insert CT_HoaDon values('006','PKx-SAM-003',2,0,0,0)
insert CT_HoaDon values('005','PKx-SAM-003',1,0,0,0)
insert CT_HoaDon values('001','DTx-MIx-007',1,0,0,0)
insert CT_HoaDon values('013','PKx-SAM-002',3,0,0,0)
insert CT_HoaDon values('024','LTx-ACE-001',1,0,0,0)
insert CT_HoaDon values('023','MAx-CAN-004',2,0,0,0)
insert CT_HoaDon values('017','DTx-MIx-006',1,0,0,0)
insert CT_HoaDon values('017','MAx-CAN-003',2,0,0,0)
insert CT_HoaDon values('011','DTx-SAM-002',1,0,0,0)
insert CT_HoaDon values('021','PKx-SAM-003',3,0,0,0)
insert CT_HoaDon values('014','LTx-ACE-001',3,0,0,0)
insert CT_HoaDon values('018','DTx-SAM-003',3,0,0,0)
insert CT_HoaDon values('026','DTx-MIx-003',3,0,0,0)
insert CT_HoaDon values('030','DTx-MIx-006',3,0,0,0)
insert CT_HoaDon values('030','LTx-ACE-002',3,0,0,0)
insert CT_HoaDon values('022','DTx-SAM-002',3,0,0,0)
insert CT_HoaDon values('024','LTx-ASU-002',1,0,0,0)
insert CT_HoaDon values('019','PKx-TOS-002',2,0,0,0)
insert CT_HoaDon values('022','DTx-MIx-002',2,0,0,0)
insert CT_HoaDon values('009','PKx-SAM-003',1,0,0,0)
insert CT_HoaDon values('016','PKx-SAM-002',1,0,0,0)
insert CT_HoaDon values('007','MAx-CAN-002',3,0,0,0)
insert CT_HoaDon values('025','LTx-ASU-002',1,0,0,0)
insert CT_HoaDon values('008','DTx-MIx-006',3,0,0,0)
insert CT_HoaDon values('010','DTx-SAM-001',1,0,0,0)
insert CT_HoaDon values('014','DTx-SAM-002',2,0,0,0)
insert CT_HoaDon values('015','MAx-CAN-001',1,0,0,0)
insert CT_HoaDon values('020','DTx-MIx-009',3,0,0,0)
insert CT_HoaDon values('021','DTx-MIx-009',2,0,0,0)
insert CT_HoaDon values('025','DLx-LGx-001',1,0,0,0)
insert CT_HoaDon values('008','PKx-TOS-002',1,0,0,0)
insert CT_HoaDon values('002','DTx-SAM-002',1,0,0,0)
insert CT_HoaDon values('025','DTx-SAM-001',1,0,0,0)
insert CT_HoaDon values('007','MAx-CAN-005',3,0,0,0)
insert CT_HoaDon values('001','PKx-SAM-002',1,0,0,0)
insert CT_HoaDon values('027','DTx-MIx-007',3,0,0,0)
insert CT_HoaDon values('007','DTx-MIx-006',3,0,0,0)
insert CT_HoaDon values('006','DTx-SAM-001',1,0,0,0)
insert CT_HoaDon values('016','LTx-ASU-001',1,0,0,0)
GO
create proc TimKiemKhachHangTheoTen(@TenKh nvarchar(100))
as select * from KhachHang 
where HoTenKh like '%'+@TenKh+'%'
GO
create proc TimKiemKhachHangTheoMa(@MaKh nvarchar(15))
as select * from KhachHang 
where MaKh like '%'+@MaKh+'%'
GO

--insert vô tầm 3-7 dòng mỗi bảng, nội dung theo cái web bán hàng điện tử của php
-- cái nào không biết insert ra sao thì để   null,null

--insert vô hết xong chạy thử cái trên dc comment xem dc hay ko

--select * from LoaiTK
--select * from TaiKhoan
--select * from NhanVien
--select * from NgayLamViec
--select * from KhachHang
--select * from LoaiSanPham
--select * from NhaCungCap
--select * from SanPham
--select * from HoaDon
--select * from CT_HoaDon

--use master
--drop database CSDL_BanHang