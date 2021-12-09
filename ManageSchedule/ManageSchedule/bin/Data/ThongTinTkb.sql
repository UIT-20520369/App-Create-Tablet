create table THONGTINTKB
(
	username varchar(25)  not null,
	mamon varchar(10) not null,
	tenmon nvarchar(100),
	malop varchar(20) not null,
	thu varchar(3) not null,
	tiet varchar(6) not null,
	stt varchar(6) null
)
alter table thongtintkb
add constraint pk_TKB primary key (username,malop,mamon,tiet,stt)

insert into THONGTINTKB
values ('20520369','IT001',N'Nhập môn lập trình','IT001.M13','6','1234','1')
insert into THONGTINTKB
values ('20520369','IT012',N'Tổ chức cấu trúc và máy tính II','IT012.M13','5','123','1')
insert into THONGTINTKB
values ('20520369','MA003',N'Đại số tuyến tính','MA003.M13','3','12345','1')
insert into THONGTINTKB
values ('20520369','MA006',N'Giải tích','MA006.M11.ANTN','3','67890','1')
insert into THONGTINTKB
values ('20520369','ENG03',N'Anh văn 3','ENG03.M18','2','90','1')
insert into THONGTINTKB
values ('20520369','ENG03',N'Anh văn 3','ENG03.M18','6','678','1')

insert into THONGTINTKB
values ('20520369','SS007',N'Triết học Mác-Lênin','SS007.L25','2','123','2')
insert into THONGTINTKB
values ('20520369','MA004',N'Cấu trúc rời rạc','MA004.L28','3','1234','2')
insert into THONGTINTKB
values ('20520369','MA005',N'Xác suất thống kê','MA005.L24','3','67890','2')
insert into THONGTINTKB
values ('20520369','IT002',N'Lập trình hướng đối tượng','IT002.L24','5','678','2')
insert into THONGTINTKB
values ('20520369','IT003',N'Cấu trúc dữ liệu và giải thuật','IT003.L26','7','678','2')
insert into THONGTINTKB
values ('20520369','SS004',N'Kỹ năng nghề nghiệp','SS004.L23','4','45','2')

insert into THONGTINTKB
values ('20520369','IT007',N'Hệ điều hành','IT007.M11','2','678','3')
insert into THONGTINTKB
values ('20520369','SS003',N'Tư tưởng Hồ Chí Minh','SS003.M16','3','67','3')
insert into THONGTINTKB
values ('20520369','SS010',N'Lịch sử Đảng Cộng Sản Việt Nam','SS010.M13','4','23','3')
insert into THONGTINTKB
values ('20520369','IT005',N'Nhập môn mạng máy tính','IT005.M16','5','123','3')
insert into THONGTINTKB
values ('20520369','IT004',N'Cơ sở dữ liệu','IT004.M19','6','678','3')
insert into THONGTINTKB
values ('20520369','IT008',N'Lập trình trực quan','IT008.M12','7','1234','3')

select * 
into MAINTKB
from THONGTINTKB

delete from THONGTINTKB where username='anbuibz66'