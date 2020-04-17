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
	   TongTien real
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
	   PhuThu bit,
	   TienPhong money,
	   TraTruoc money,
	   ThanhTien money
)

CREATE TABLE PHIEUTHUEPHONG
(
     MaPhieu nvarchar(20) primary key,
	 MaKH nvarchar(20) references KHACHHANG(MaKH),
	 MaPhong nvarchar(20) references PHONG(MaPhong),
	 NgayNhan datetime,
)
