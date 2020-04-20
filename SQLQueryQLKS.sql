CREATE DATABASE QUANLYKHACHSAN


CREATE TABLE QUYEN(
     MaQuyen int primary key ,
	 TenQuyen nvarchar(50)

)

CREATE TABLE BOPHAN
(
     IDBoPhan int primary key ,
	 TenBoPhan nvarchar(50)
)

CREATE TABLE NHANVIEN(
      MaNV nvarchar(20) primary key,
	  HoTenNV nvarchar(50),
	  CMND nchar(15),
	  NgaySinh date,
	  GioiTinh nvarchar(3),
	  SDT nchar(10),
	  DiaChi nvarchar(50),
	  MaQuyen int references QUYEN(MaQuyen),
	  IDBoPhan int references BOPHAN(IDBoPhan)
)

CREATE TABLE TAIKHOAN
(
     
     ID nvarchar(100) primary key ,
	 MatKhau nvarchar(50) NOT NULL,
	 MaNV nvarchar(20) references NHANVIEN(MaNV)
)
CREATE TABLE KHACHHANG(
       MaKH nvarchar(20) primary key,
	   TenKH nvarchar(50),
	   CMND nchar(15),
	   SDT nchar(10),
	   GioiTinh  nvarchar(3),
	   DiaChi nvarchar(50)
)
CREATE TABLE LOAIPHONG
(
      MaLoaiPhong nvarchar(20) primary key,
	  TenLoaiPhong nvarchar(50),
	  GiaPhong money,
	  SoNgChuan int,
	  SoNgToiDa int
)


CREATE TABLE PHONG
(
      MaPhong nvarchar(20) primary key,
	  SoPhong nchar(10),
	  MaLoaiPhong nvarchar(20) references LOAIPHONG(MaLoaiPhong),
	  TrangThai nchar(10)
)


CREATE TABLE DICHVU
(
      MaDV nvarchar(20) primary key,
	  TenDV nvarchar(50) ,
	  GiaDV money,
	 
)
CREATE TABLE THIETBI(
       MaTB nvarchar(20) primary key,
	   TenTB nvarchar(50),
	   GhiChu nvarchar(50) NULL
)
CREATE TABLE THIETBI_SD(
	   MaPhong nvarchar(20) references PHONG(MaPhong),
	   MaTB nvarchar(20) references THIETBI(MaTB),
	   primary key (MaPhong, MaTB) ,
	   SoLuong int
)
CREATE TABLE DICHVU_SD(
	   MaPhong nvarchar(20) references PHONG(MaPhong),
	   MaDV nvarchar(20) references DICHVU(MaDV),
	   primary key (MaPhong,MaDV),
	   SoLuong int,
	  
)

CREATE TABLE HOADON(
       MaHD nvarchar(20) primary key,
	   MaKH nvarchar(20) references KHACHHANG(MaKH),
	   MaNV nvarchar(20) references NHANVIEN(MaNV),
	   NgayLap datetime,
	   TongTien money
)
CREATE TABLE CHITIETHD(
       MaHD nvarchar(20) references HOADON (MaHD),
	   MaPhong nvarchar(20) references PHONG(MaPhong),
	   primary key(MaHD,MaPhong),
	   GiamGia real,
	   NgayNhan datetime,
	   NgayTra datetime,
	   SoNgay int,
	   ThanhTien money
)

CREATE TABLE PHIEUTHUEPHONG
(
    MaPhieu nvarchar(20) primary key,
	 MaKH nvarchar(20) references KHACHHANG(MaKH),
	 MaPhong nvarchar(20) references PHONG(MaPhong),
	 NgayNhan datetime,
)

INSERT INTO QUYEN Values(1,N'Quản lý'),
                         (2,N'Tiếp tân')
INSERT INTO BOPHAN Values(1,N'Quản lý'),
                         (2,N'Chăm sóc khách hàng')   
INSERT INTO NHANVIEN Values('1',N'Trần Quang Huy','1615089812','1998/08/23','Nam','0983467832',N'Hà Nội',1,1)
 INSERT INTO TAIKHOAN    VALUES('ID01','huy123','1')                       
INSERT INTO KHACHHANG VALUES ('KH01',N'Trần Văn Hưởng','1615023234','0353485333','Nam',N'Nam Định')		
INSERT INTO LOAIPHONG VALUES ('LP01','Stardard',2000000,2,4)
  INSERT INTO LOAIPHONG VALUES ('LP02','Superior',3000000,2,4),
							  ('LP03','Deluxe',5000000,2,6),
							  ('LP04','Suite',7000000,2,6)

INSERT INTO PHONG VALUES ('P01','P101','LP01',N'Đã ở'),
                          ('P02','P102','LP01',N'Trống'),
						  ('P03','P103','LP01',N'Trống'),
						  ('P04','P104','LP01',N'Trống'),
						  ('P05','P201','LP02',N'Trống'),
						  ('P06','P202','LP02',N'Trống'),
						  ('P07','P203','LP02',N'Trống'),
						  ('P08','P204','LP02',N'Trống'),
						  ('P09','P301','LP03',N'Trống')
INSERT INTO DICHVU VALUES ('DV01',N'Mì tôm',5000),
                           ('DV02',N'Nước ngọt',10000),
						   ('DV03',N'Spa',100000),
						   ('DV04',N'Giặt là',100000),
						   ('DV05',N'Xe đưa đón',500000)
INSERT INTO THIETBI VALUES ('TB01',N'Ti vi',NULL),
                            ('TB02',N'Điều hòa',NULL),
							('TB03',N'Nóng lạnh',NULL),
							('TB04',N'Quạt',NULL)
INSERT INTO THIETBI_SD VALUES ('P01','TB01',1),
                               ('P01','TB02',1),
							   ('P01','TB03',1),
							   ('P01','TB04',1)
                                                      
INSERT INTO DICHVU_SD VALUES ('P01','DV01',1)  
INSERT INTO PHIEUTHUEPHONG VALUES('MP101','KH01','P01','2020/02/20 8:00:00') 
INSERT INTO HOADON VALUES('111','KH01','1','2020/02/20 8:00:00',2050000)    
INSERT INTO CHITIETHD VALUES('111','P01','0','2020/02/20 8:00:00','2020/02/21 8:00:00',1,2000000) 
   

           			         