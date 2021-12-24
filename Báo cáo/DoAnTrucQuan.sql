use manageschedule
go
--Bảng thông tin tài khoản
create table THONGTINTAIKHOAN
(
	HoVaTen		nvarchar(100),
	Nganh		nvarchar(50),
	KhoaHoc		tinyint,
	HeDaoTao	nvarchar(30),
	Email		varchar(50),
	TaiKhoan	varchar(25),
	MatKhau		varchar(300),

	constraint PK_THONGTINTAIKHOAN primary key (TaiKhoan)
)
go

select * from dbo.THONGTINTAIKHOAN
--Bảng thông tin tài khoản
--Bảng thông tin thời khóa biểu
create table THONGTINTKB
(
	username varchar(25)  not null,
	mamon varchar(10) not null,
	tenmon nvarchar(100),
	malop varchar(20) not null,
	thu varchar(3) not null,
	tiet varchar(6) not null,
	stt varchar(6) not null
)

alter table thongtintkb
add constraint pk_TKB primary key (username,malop,mamon,tiet,stt)
alter table thongtintkb
add constraint fk_TKB_user foreign key (username) references THONGTINTAIKHOAN (TAIKHOAN)


select * 
into MAINTKB
from THONGTINTKB

delete from MAINTKB
--Bảng thông tin thời khóa biểu
--Bảng Sự kiện,thông báo, avatar
CREATE TABLE SUKIEN (
USERNAME varchar(25) NOT NULL,
IDSK int IDENTITY(1,1),
TIEUDE nvarchar(35) not null,
NGAY datetime NOT NULL,
TOINGAY datetime null,
MONHOC nvarchar(20) null,
MOTA ntext null,

CONSTRAINT SK_PK PRIMARY KEY (IDSK),
CONSTRAINT SK_FK_USER FOREIGN KEY (USERNAME) REFERENCES THONGTINTAIKHOAN(TaiKhoan),
)

CREATE TABLE THONGBAO (
USERNAME varchar(25) NOT NULL,
IDSK int,
GIATRI int,
DONVI nchar(6),
THOIGIAN datetime,
CONSTRAINT TB_PK PRIMARY KEY (USERNAME, IDSK, GIATRI, DONVI),
CONSTRAINT TB_FK_ID FOREIGN KEY (IDSK) REFERENCES SUKIEN(IDSK),
CONSTRAINT TB_FK_USER FOREIGN KEY (USERNAME) REFERENCES THONGTINTAIKHOAN(TaiKhoan)
)

create table AVATAR
(
TaiKhoan varchar(25),
strAVATAR text null,
constraint AVATAR_PK PRIMARY KEY (TaiKhoan),
constraint AVATAR_FK_TaiKhoan FOREIGN KEY (TaiKhoan) REFERENCES THONGTINTAIKHOAN(TaiKhoan)
)
 
set dateformat dmy
--Bảng Sự kiện,thông báo, avatar