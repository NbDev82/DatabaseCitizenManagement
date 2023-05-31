/*
DROP DATABASE CityzenManagement
CREATE DATABASE CityzenManagement
GO
*/

USE CityzenManagement
GO

CREATE table [Citizens](
	MaCD varchar(10) PRIMARY KEY,
	HoTen NVARCHAR(max) NOT NULL,
	GioiTinh NVARCHAR(max) NOT NULL, -- Nam | Nữ
	NgheNghiep NVARCHAR(max) NOT NULL DEFAULT N'NONE',
	DanToc NVARCHAR(max) NOT NULL,
	TonGiao NVARCHAR(max) NOT NULL DEFAULT N'NONE',
	TinhTrang NVARCHAR(max) DEFAULT N'Còn sống' NOT NULL, -- Đã chết | Còn sống
	TinhTrangHonNhan bit NOT NULL DEFAULT 0, -- 0: Độc thân
)
/*
drop table [Citizens]
*/
CREATE TABLE [Accounts](
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	matkhau nvarchar(max)  NOT NULL,
	phanquyen bit /*chỉ nhận 2 giá trị 0 hoặc 1*/
)
/*
drop table [Accounts]
*/
CREATE TABLE [Births] (
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    NgaySinh DATE  NOT NULL,
	NoiSinh NVARCHAR(255) NOT NULL,
    MaCD_Cha varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    MaCD_Me varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    NgayKhai DATE NOT NULL DEFAULT GETDATE(),
	NgayDuyet DATE NULL
);
GO
/*
drop table [Births]
*/


CREATE TABLE [Users_Deleted](
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	NguoiKhai varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
	NguyenNhan NVARCHAR(max) NOT NULL DEFAULT N'NONE',
	NgayTu DATE NOT NULL,
	NgayKhai DATE NOT NULL DEFAULT GETDATE(),
	NgayDuyet DATE NULL -- Đã duyệt | Chưa duyệt
)
GO
/*
drop table [Users_Deleted]
*/
CREATE TABLE [Households](
	MaHo varchar(10) PRIMARY KEY,
	ChuHo varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	TinhThanh NVARCHAR(255) NOT NULL,
	QuanHuyen NVARCHAR(255) NOT NULL,
	PhuongXa NVARCHAR(255) NOT NULL,
	NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
	TrangThai NVARCHAR(255) NOT NULL DEFAULT N'NONE', -- 1: Đã duyệt | 0: Chưa duyệt
)
GO
/*
drop table [Households]
*/
ALTER TABLE [Citizens]
ADD MaHoKhau varchar(10) FOREIGN KEY REFERENCES [Households](MaHo) NULL;

CREATE TABLE [Detail_Households](
	MaHo varchar(10) FOREIGN KEY REFERENCES [Households](MaHo),
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	TinhTrangCuTru NVARCHAR(255) NOT NULL DEFAULT N'Thường trú', -- 1: Thường trú | 0: Tạm vắng | 2: Tạm trú
	QuanHeVoiChuHo NVARCHAR(255) NOT NULL DEFAULT N'NONE',
	NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
	TrangThai NVARCHAR(255) DEFAULT N'NONE' NOT NULL, -- 1: Đã duyệt | 0: Chưa duyệt | 2: Đã xác nhận
	PRIMARY KEY (MaHo, MaCD)
)
GO
/*
drop table [Detail_Households]
*/
----------------




CREATE TABLE [People_Marriage](
	MaHN varchar(10) PRIMARY KEY,
	MaCDChong varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	MaCDVo varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	Loai NVARCHAR(255) NOT NULL DEFAULT N'Kết hôn', -- 1: Kết hôn | 0: Ly hôn
	NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
	XacNhanLan1 varchar(10) REFERENCES [Citizens](MaCD) DEFAULT NULL,
	XacNhanLan2 varchar(10) REFERENCES [Citizens](MaCD) DEFAULT NULL,
	TrangThai NVARCHAR(255) NOT NULL DEFAULT N'Chưa duyệt'-- 1: Đã duyệt | 0: Chưa duyệt
)
GO
/*
drop table [People_Marriage]
*/
CREATE TABLE [Mails](
	MaMail varchar(10) PRIMARY KEY,
	TieuDe NVARCHAR(MAX) NOT NULL DEFAULT N'NONE',
	Ngay DATE NOT NULL DEFAULT GETDATE(),
	NguoiGui varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	NguoiNhan varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	NoiDung NVARCHAR(MAX) NOT NULL
)
GO
/*
drop table [Mails]
*/
CREATE TABLE Temporarily_Absent (
	ID varchar(10) PRIMARY KEY,
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
    MaCCCD VARCHAR(max) NOT NULL,
    Tinh NVARCHAR(max) NOT NULL,
    Huyen NVARCHAR(max) NOT NULL,
    Xa NVARCHAR(max) NOT NULL,
    LyDo NVARCHAR(max) NOT NULL,
    thoi_gian_bat_dau DATE NOT NULL,
    thoi_gian_ket_thuc DATE NOT NULL,
	TrangThai NVARCHAR(max) NOT NULL DEFAULT N'Chưa duyệt',
);
/*
drop table Temporarily_Absent
*/

CREATE TABLE Temporarily_Staying (
	ID varchar(10) PRIMARY KEY,
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
    MaCCCD VARCHAR(max) NOT NULL,
    Tinh NVARCHAR(max) NOT NULL,
    Huyen NVARCHAR(max) NOT NULL,
    Xa NVARCHAR(max) NOT NULL,
    LyDo NVARCHAR(max) NOT NULL,
    thoi_gian_bat_dau DATE NOT NULL,
	TrangThai NVARCHAR(max) NOT NULL DEFAULT N'Chưa duyệt',
);
/*
drop table [Temporarily_Staying]
*/

CREATE table [Certificates](
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
	MaCCCD AS 'CCCD' + RIGHT('00000000' + CAST(ID AS VARCHAR(8)), 8) PERSISTED,
	MaCD varchar(10) FOREIGN KEY REFERENCES [Citizens](MaCD),
	QuocTich NVARCHAR(max) NOT NULL,
	QueQuan NVARCHAR(max) NOT NULL,
	NoiThuongTru NVARCHAR(max) NOT NULL,
	HanSuDung Date NULL,
	DacDiemNhanDang NVARCHAR(max) NOT NULL DEFAULT N'Không',
	Avatar image NOT NULL
)
/*
drop table [Certificates]
*/
/*CREATE table [Avatars](
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) UNIQUE NOT NULL,
	Avatar Image
)*/

GO
--KHOA----------------------------------------------------------------------------------------------------------------------


CREATE OR ALTER VIEW PERSONAL_INFORMATION
AS
SELECT *
FROM [Citizens]
--Tạo view hòm thư
GO
CREATE OR ALTER VIEW MAILBOX
AS
SELECT MaMail, TieuDe, Ngay, ctz1.HoTen AS TenNguoiGui, m.NguoiGui as MaNguoiGui,ctz2.HoTen AS TenNguoiNhan, m.NguoiNhan as MaNguoiNhan, NoiDung
FROM 
	Mails m
	INNER JOIN [Citizens] ctz1 ON m.NguoiGui = ctz1.MaCD
	INNER JOIN [Citizens] ctz2 ON m.NguoiNhan = ctz2.MaCD
GO


ALTER TABLE [Births]
ADD CONSTRAINT CHK_Births_NgKhaiNgDuyet CHECK (NgayDuyet is null OR NgayDuyet >= NgayKhai)


ALTER TABLE [People_Marriage]
ADD  CONSTRAINT CHK_People_Marriage_Loai CHECK (Loai = N'Kết hôn' OR Loai = N'Ly hôn')

GO


--TRIGGER



-- Trigger cho việc thêm công dân đã chết vào [Users_Deleted]
CREATE or ALTER TRIGGER [trg_Citizen_Delete] ON [Users_Deleted]
FOR INSERT
AS
BEGIN
	DECLARE @MaCD varchar(10);
	DECLARE @CheckMaCD INT;
	SELECT @MaCD = MaCD FROM inserted;
	-- Kiểm tra xem công dân đã chết hay chưa
	SELECT @CheckMaCD = COUNT(*) FROM Citizens WHERE Citizens.MaCD = @MaCD AND Citizens.TinhTrang = N'Đã chết'
	IF @CheckMaCD > 0
	BEGIN
		RAISERROR('Không thể thêm công dân đã chết vào bảng Users_Deleted!', 16, 1);
		ROLLBACK TRANSACTION;
	END
	ELSE
	BEGIN
		UPDATE [Citizens]
		SET TinhTrang = N'Đã chết'
		WHERE MaCD = @MaCD
	END
END
go
-- Trigger cho việc kiểm tra xem người khai có phải chủ hộ không trong [Users_Deleted] 
CREATE TRIGGER [Check_Death_NguoiKhai] 
ON [Users_Deleted]
FOR INSERT
AS
BEGIN
    DECLARE @MaCD varchar(10), @NguoiKhai varchar(10), @ChuHo varchar(10), @MaHoKhau varchar(10)
    SELECT @MaCD = i.MaCD, @NguoiKhai = i.NguoiKhai, @MaHoKhau = c.MaHoKhau
    FROM inserted i
    JOIN [Citizens] c ON i.MaCD = c.MaCD

    SELECT @ChuHo = h.ChuHo
    FROM [Households] h
    WHERE h.MaHo = @MaHoKhau

    IF @NguoiKhai != @ChuHo
    BEGIN
        RAISERROR ('Nguoi khai phai la chu ho trong cung ho khau', 16, 1)
        ROLLBACK TRANSACTION
    END
END
/*
DROP TABLE

*/


--KHOA
--Trigger cho việc tính toán Hạn sử dụng của bảng Certificates 
GO
CREATE OR ALTER TRIGGER [trg_Certificates_calHanSuDung]
ON [Certificates]
AFTER INSERT
AS
BEGIN
	UPDATE [Certificates]
	SET HanSuDung = DATEADD(YEAR, 10, GETDATE())
	WHERE MaCD IN (SELECT MaCD FROM inserted);
END;

--Trigger cho việc kiểm tra MaCDChong có giới tính nam và MaCDVo có giới tính nữ
GO
CREATE OR ALTER TRIGGER [trg_People_Marriage_GioiTinhVoChong]
ON [People_Marriage]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @MaCDChong varchar(10), @MaCDVo varchar(10), 
			@gtChong nvarchar(max), @gtVo nvarchar(max),
			@tuoiChong int, @tuoiVo int

	SELECT @MaCDChonG = MaCDChong, @MaCDVo = MaCDVo
	FROM inserted

	SELECT @gtChong = GioiTinh 
	FROM Citizens
	WHERE MaCD = @MaCDChong

	SELECT @gtVo = GioiTinh
	FROM Citizens
	WHERE MaCD = @MaCDVo

	SELECT @tuoiChong = YEAR(GETDATE()) - YEAR(NgaySinh)
	FROM Births
	WHERE MaCD = @MaCDChong

	SELECT @tuoiVo = YEAR(GETDATE()) - YEAR(NgaySinh)
	FROM Births
	WHERE MaCD = @MaCDVo

	IF(@gtChong != 'Nam' OR @tuoiChong < 20)
	BEGIN
		ROLLBACK TRAN
		RAISERROR (N'Thông tin người chồng không hợp lệ (GT: nam, tuổi >= 20', 16, 1)
	END;

	IF(@gtVo != N'Nữ' OR @tuoiVo < 18)
	BEGIN
		ROLLBACK TRAN
		RAISERROR (N'hông tin người chồng không hợp lệ (GT: nữ, tuổi >= 18', 16, 1)
	END
END;
	
--Trigger cho việc kiểm tra 1 MaCD ko thể có 2 chủ hộ
GO
CREATE OR ALTER TRIGGER [trg_Detail_Households_MaCD]
ON [Detail_Households]
AFTER INSERT
AS
BEGIN
	DECLARE @SoHo int
	SELECT @SoHo = COUNT(MaHo)
	FROM Detail_Households
	WHERE MaCD IN (SELECT MaCD FROM inserted)
	GROUP BY MaCD;

	if(@SoHo > 1)
	BEGIN
		ROLLBACK TRAN
		RAISERROR (N'Một công dân không thể có hai hộ khẩu', 16, 1)
	END;
END;

--Function
--Function lấy danh sách các công dân tạm vắng
--Theo Huyện
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoHuyen(@Huyen nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Huyen = @Huyen )

--Theo xã
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoXa(@Xa nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Xa = @Xa )
--Theo tỉnh
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoTinh(@Tinh nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Tinh = @Tinh )

--Function lấy danh sách CD có cùng chủ hộ
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoTinh(@ChuHo nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang
	FROM Citizens cti
	WHERE cti.MaCD IN (SELECT MaCD FROM Detail_Households WHERE MaHo = @ChuHo))
--Khoa----------------------------------------------------------------------------------------------------------------------






GO
--MẠNH----------------------------------------------------------------------------------------------------------------------
-- Ngày duyệt phải lớn hơn ngày khai
ALTER TABLE [Births]
ADD CONSTRAINT [CK_Births_Validation] CHECK (NgayDuyet > NgayKhai);

-- Mã chủ hộ không được trùng (Households) -- thêm UNIQUE vào trường ChuHo


ALTER TABLE [Households]
ADD CONSTRAINT UC_ChuHo UNIQUE (ChuHo);
GO

-- Tính toán tuổi của một người (Births)
CREATE FUNCTION dbo.Fn_CalculateAge(@MaCD int)
RETURNS int
AS
BEGIN
    DECLARE @age int;

    SELECT @age = DATEDIFF(YEAR, NgaySinh, GETDATE()) - 
        CASE WHEN MONTH(NgaySinh) > MONTH(GETDATE()) 
            OR (MONTH(NgaySinh) = MONTH(GETDATE()) AND DAY(NgaySinh) > DAY(GETDATE())) 
            THEN 1 ELSE 0 END
    FROM Births
    WHERE MaCD = @MaCD;

    RETURN @age;
END;
-- SELECT dbo.Fn_CalculateAge(2)
GO
-- Hàm tính số lượng người cùng trong 1 hộ khẩu (thông số truyền vào là mã hộ) (Detail_Households)
CREATE FUNCTION dbo.Fn_CountPeopleInHousehold(@MaHo int)
RETURNS int
AS
BEGIN
    DECLARE @count int;

    SELECT @count = COUNT(*)
    FROM Detail_Households
    WHERE MaHo = @MaHo;

    RETURN @count;
END;
-- SELECT dbo.Fn_CountPeopleInHousehold(1)
GO
--  Trả về chuỗi địa chỉ tỉnh+ huyện+ xã  (Temporarily_Absent)
CREATE FUNCTION dbo.Fn_GetAddress(@MaCD int)
RETURNS nvarchar(max)
AS
BEGIN
    DECLARE @address nvarchar(max);

    SELECT @address = CONCAT(Tinh, ', ', Huyen, ', ', Xa)
    FROM Temporarily_Absent
    WHERE MaCD = @MaCD;

    RETURN @address;
END;
-- SELECT dbo.Fn_GetAddress(1) as Address;
GO
-- Hàm đếm số lượng người tạm trú tại 1 khu vực (tham số: thành phố, huyện, xã)
CREATE FUNCTION dbo.Fn_CountTemporarilyStaying(@Tinh NVARCHAR(max), @Huyen NVARCHAR(max), @Xa NVARCHAR(max))
RETURNS int
AS
BEGIN
    DECLARE @count int;

    SELECT @count = COUNT(*)
    FROM Temporarily_Staying
    WHERE Tinh = @Tinh AND Huyen = @Huyen AND Xa = @Xa;

    RETURN @count;
END;
-- SELECT dbo.Fn_CountTemporarilyStaying('', '', '')
GO
-- Tính số người chết trong năm(truyền vào năm cần xem)
CREATE FUNCTION dbo.Fn_CountDeathInYear(@year int)
RETURNS int
AS
BEGIN
    DECLARE @count int;

    SELECT @count = COUNT(*)
    FROM Users_Deleted
    WHERE YEAR(NgayTu) = @year;

    RETURN @count;
END;
-- SELECT dbo.Fn_CountDeathInYear(2022)
GO
-- Liệt kê các công dân hiện chưa có cccd (citizens)
CREATE VIEW [Citizens_Without_Certificates]
AS
SELECT MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang
FROM Citizens
WHERE MaCD NOT IN (SELECT MaCD FROM Certificates);
GO
/*SELECT * FROM Citizens_Without_Certificates;*/

GO
-- Hàm đếm số lượng hộ trong khu vực cụ thể(tỉnh,huyện,xã)
CREATE FUNCTION Fn_CountHouseholdsInArea
(
    @tinhThanh NVARCHAR(max),
    @quanHuyen NVARCHAR(max),
    @phuongXa NVARCHAR(max)
)
RETURNS INT
AS
BEGIN
    DECLARE @soLuongHo INT

    SELECT @soLuongHo = COUNT(*)
    FROM Households AS H
    WHERE H.TinhThanh = @tinhThanh
        AND H.QuanHuyen = @quanHuyen
        AND H.PhuongXa = @phuongXa;

    RETURN @soLuongHo;
END

--drop function Fn_CountHouseholdsInArea

--SELECT dbo.Fn_CountHouseholdsInArea(N'Hà Nội', N'Ba Đình', N'Trúc Bạch') as CountHouseholdsInArea
--Mạnh









--HOÀNG
GO
--CONSTRAINT
--Độ dài mật khẩu lớn hơn hoặc bằng 5
ALTER TABLE [Accounts]
ADD CONSTRAINT CK_Accounts_MatKhau_Length CHECK (LEN(matkhau) >= 5);
--Vừa search, theo quy định thì NgayKhai - NgaySinh >= 60(Hoàng)(Births)
ALTER TABLE [Births]
ADD CONSTRAINT CK_Births_NgayKhai_NgaySinh CHECK (DATEDIFF(day, NgaySinh, NgayKhai) >= 60);
--Giới tính chỉ gồm 1 trong ba giá trị (nam, nữ, khác)(Hoàng)(citizens)
ALTER TABLE [Citizens]
ADD CONSTRAINT CK_Citizens_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'));

--thời gian kết thúc phải lớn hơn thời gian bắt đầu(Hoàng)(Temporarily_Absent)
ALTER TABLE Temporarily_Absent
ADD CONSTRAINT CK_Temporarily_Absent_ThoiGian CHECK (thoi_gian_ket_thuc > thoi_gian_bat_dau);

--ngày khai phải lớn hơn ngày tử(Hoàng)(Users_Deleted)
ALTER TABLE [Users_Deleted]
ADD CONSTRAINT CK_Users_Deleted_NgayKhai CHECK (NgayKhai > NgayTu);
GO
--PROCEDURE
CREATE OR ALTER PROCEDURE PROC_RegisterCertificate (@macd varchar(10), @quoctich nvarchar(max), @quequan nvarchar(max), @noithuongtru nvarchar(max), @dacdiemnhandang nvarchar(max), @img image)
AS
BEGIN
	INSERT INTO Certificates (MaCD, QuocTich, QueQuan, NoiThuongTru, DacDiemNhanDang, Avatar)
    VALUES (@macd,@quoctich,@quequan,@noithuongtru,@dacdiemnhandang,@img)
END
--EXEC PROC_RegisterCertificate 'CD0001',N'Việt Nam', N'Kon Tum', N'TP. HCM', N'Không', 'D:\198289325_275721070910950_5711389170938825569_n.jpg'
-- chuyển

ALTER TABLE [Users_Deleted]
ADD CONSTRAINT CK_Users_Deleted_NgayDuyet CHECK (NgayDuyet is null or NgayDuyet > NgayKhai);
GO
--TRIGGER

--ngày duyệt phải lớn hơn ngày khai(Hoàng)(Users_Deleted)

--Quản lý phải là người gửi hoặc người nhận(Hoàng)(Mails)
--CREATE or ALTER TRIGGER TR_Mails_CheckQuanLy
--ON [Mails]
--AFTER INSERT
--AS
--BEGIN
    
--    -- Check if the sender or recipient is a manager
--    IF EXISTS (
--        SELECT 1
--        FROM [Mails] AS M
--        INNER JOIN [Accounts] AS A ON M.NguoiGui = A.MaCD OR M.NguoiNhan = A.MaCD
--        WHERE M.MaMail IN (SELECT MaMail FROM inserted)
--        AND A.phanquyen = 1
--    )
--    BEGIN
--        -- Allow the insert operation
--        PRINT 'Insert operation allowed.';
--    END
--    ELSE
--    BEGIN
--        -- Rollback the insert operation
--        PRINT 'Insert operation denied. Manager must be the sender or recipient.';
--        ROLLBACK TRANSACTION;
--    END
--END;
GO

--Cập nhật trạng thái hộ khẩu của công dân khi thêm, xóa công dân ra khỏi [Detail_Households](Hoàng)(Detail_Households)

-- Trigger cho việc thêm mới công dân vào [Detail_Households]
CREATE TRIGGER [trg_AddCitizenToHousehold]
ON [Detail_Households]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHo varchar(10), @MaCD varchar(10);
    SELECT @MaHo = inserted.MaHo, @MaCD = inserted.MaCD 
	FROM inserted;
    
    -- Kiểm tra xem công dân đã có hộ khẩu trước đó hay chưa
    IF EXISTS(SELECT 1 FROM [Citizens] WHERE MaCD = @MaCD AND MaHoKhau IS NOT NULL)
    BEGIN
        RAISERROR('Citizen already has a household, cannot add to another household', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
    
    -- Cập nhật trạng thái hộ khẩu của công dân
    UPDATE [Citizens] SET MaHoKhau = @MaHo WHERE MaCD = @MaCD;
END
GO

-- Trigger cho việc xóa công dân ra khỏi [Detail_Households]
CREATE TRIGGER [dbo].[trg_RemoveCitizenFromHousehold]
ON [dbo].[Detail_Households]
AFTER DELETE
AS
BEGIN
    DECLARE @MaHo varchar(10), @MaCD varchar(10);
    SELECT @MaHo = deleted.MaHo, @MaCD = deleted.MaCD FROM deleted;
    
    -- Cập nhật trạng thái hộ khẩu của công dân
    UPDATE [Citizens] SET MaHoKhau = NULL WHERE MaCD = @MaCD;
END
GO
-- trigger cho việc cập nhật trạng thái hộ khẩu khi thêm 1 công dân vào [Detail_Households]
CREATE TRIGGER TR_UpdateHouseholdStatus
ON [Detail_Households]
FOR INSERT, DELETE
AS
BEGIN
    -- Update household status after inserting new citizen
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE [Citizens]
        SET MaHoKhau = I.MaHo
        FROM [Citizens] AS C
        INNER JOIN inserted AS I ON C.MaCD = I.MaCD;
    END
END;


--FUNCTION
GO
-- Kiểm tra đăng nhập
CREATE OR ALTER FUNCTION FN_CheckAuthentication(@username varchar(10), @password nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT * FROM Accounts ac WHERE ac.MaCD = @username AND ac.matkhau = @password
)
/*
SELECT *
FROM dbo.FN_CheckAuthentication('CD0001', '12345');*/

GO
--DROP FUNCTION  GetCitizensByProvince
--Liệt kê các công dân có quê quán ở 1 tỉnh (truyền vào tên tỉnh ), ( truyền ra danh sách công dân )(Hoàng)(Certificates)
CREATE FUNCTION dbo.GetCitizensByProvince( @Province NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN
(
    SELECT C.MaCD, C.HoTen, C.GioiTinh, Certi.QueQuan, C.NgheNghiep, C.DanToc, C.TonGiao, C.TinhTrang
    FROM [Citizens] AS C
    INNER JOIN [Certificates] AS Certi ON C.MaCD = Certi.MaCD
    WHERE Certi.QueQuan LIKE '%' + LOWER(@Province) + '%'
);
GO
--Hàm tìm danh sách các hộ trong 1 khu vực ( truyền vào: tỉnh thành, huyện, phường), truyền ra (danh sách các hộ) (Hoàng)(Households)
CREATE FUNCTION dbo.GetHouseholdsByLocation( @TinhThanh NVARCHAR(255), @QuanHuyen NVARCHAR(255), @PhuongXa NVARCHAR(255))
RETURNS TABLE
AS
RETURN
(
    SELECT MaHo, ChuHo, TinhThanh, QuanHuyen, PhuongXa, NgayDangKy, TrangThai
    FROM [Households]
    WHERE TinhThanh = @TinhThanh AND QuanHuyen = @QuanHuyen AND PhuongXa = @PhuongXa
);
--hoàng

-----VIEW------------------------------------------------------------------------------------------------------------------
GO
-----CCCD---------------------------Hoàng
CREATE OR ALTER VIEW V_GetCertificates
AS
	SELECT c.MaCD, ce.MaCCCD, c.HoTen, ce.DacDiemNhanDang, ce.NoiThuongTru, ce.QueQuan, ce.QuocTich, b.NgaySinh, ce.HanSuDung, c.GioiTinh
	FROM Citizens c, Certificates ce, Births b
	WHERE c.MaCD = ce.MaCD AND c.MaCD = b.MaCD
GO
--drop view V_GetCertificates
-- hàm tìm CCCD của công dân có MaCD là tham số truyền vào, trả về bảng
CREATE OR ALTER FUNCTION FN_GetCertificates(@macd varchar(10)) --(Certificate) của hoàng
RETURNS TABLE
AS
RETURN(
	SELECT MaCD,MaCCCD ,HoTen ,DacDiemNhanDang ,NoiThuongTru ,QueQuan,QuocTich,NgaySinh,HanSuDung,GioiTinh 
	FROM V_GetCertificates v 
	WHERE v.MaCD = @macd)
--drop FUNCTION FN_GetCertificates
-- SELECT * FROM FN_GetCertificates('CD0030')
GO
CREATE VIEW V_GetDataUser --(Certificate) của hoàng
AS
	SELECT c.MaCD, ce.MaCCCD, c.HoTen, ce.DacDiemNhanDang, ce.NoiThuongTru, ce.QueQuan, ce.QuocTich, b.NgaySinh, ce.HanSuDung, c.GioiTinh, ce.Avatar, ac.phanquyen
	FROM Citizens c, Certificates ce, Births b, Accounts ac
	WHERE c.MaCD = ce.MaCD AND c.MaCD = b.MaCD AND c.MaCD = ac.MaCD
GO
--SELECT * FROM V_GetDataUser
-- hàm trả về dữ liệu của công dân có MaCD là tham số truyền vào, trả ra bảng
CREATE FUNCTION FN_GetDataUser(@macd varchar(10)) --(Certificate) của hoàng
RETURNS TABLE
AS
RETURN(
	SELECT * FROM V_GetDataUser v WHERE v.MaCD = @macd
)
--SELECT * FROM FN_GetDataUser('CD0030')
-- drop view V_GetCertificates

/*  DECLARE @macd int = 1
select * 
from V_GetCertificates v1
where v1.MaCD = @macd   */


---Công------------------
﻿-- Contraint

--  Ngày sinh không được lớn hơn ngày hiện tại(Công)(Births)
GO
ALTER TABLE Births 
ADD CONSTRAINT check_ngaysinhhople CHECK(NgaySinh<GETDATE())

-- Trạng thái chỉ có 2 trạng thái “duyet” và “chua duyet” (Công)(Households)
--USE Backup_CityzenManagement
GO
ALTER TABLE Households 
ADD CONSTRAINT check_trangthai_Households CHECK(TrangThai IN(N'Duyệt', N'Chưa duyệt'))

--Trigger
go
-- Công dân phải trên 16 tuổi(insert,update)(Công)(Certificates)
CREATE OR ALTER TRIGGER [dbo].[trg_CheckTuoiCongDan]
ON Certificates
for INSERT,UPDATE 
AS
BEGIN
	DECLARE @TUOI INT
	SELECT @TUOI=YEAR(GETDATE())-YEAR(NgaySinh)
	FROM Certificates ce,Births bi
	Where ce.MaCD=bi.MaCD
	if(@TUOI<16)
	begin 
		rollback tran 
		print 'Tuổi của công dân phải đủ 16'
	end
END

GO

-- Khi delete, chạy qua Detail_Households xóa hết thành viên trong hộ khẩu có MaHo này.(Công)(Households)

GO
CREATE TRIGGER [dbo].[trg_DELETE_DetailHouseHolds]
ON Households
FOR DELETE 
AS
BEGIN
	DELETE FROM Detail_Households WHERE MaHo IN (SELECT MaHo from deleted);
END

-- Kiểm tra xem công dân đã chết hay chưa khi thêm(Công)(Users_Deleted)


-- Procedure 

--Đưa ra thông tin chi tiết của công dân ở bảng Citizens, Houserholds, Births(Công)(citizens)


GO
CREATE OR ALTER PROC [dbo].[spud_thongtinCongDan]
AS
BEGIN
	SELECT ci.MaCD,ci.HoTen,ci.GioiTinh,ci.NgheNghiep,ci.DanToc,ci.TonGiao,ci.TinhTrang,ci.TinhTrang,ci.MaHoKhau,
	bi.NgaySinh,bi.NgaySinh,bi.NoiSinh,bi.MaCD_Cha,bi.MaCD_Me,bi.MaCD_Cha,bi.MaCD_Me,bi.NgayKhai,bi.NgayDuyet,
	ho.ChuHo,ho.TinhThanh,ho.QuanHuyen,ho.PhuongXa,ho.NgayDangKy,ho.TrangThai
	FROM Citizens ci,Households ho,Births bi
	WHERE ci.MaCD=bi.MaCD AND ho.MaHo=ci.MaHoKhau
END

-- Thủ tục xuất ra danh sách công dân tạm trú ở khu vực (tham số:thành phố, huyện, xã )
-- mà chưa được duyệt(Công)(Temporarily_Staying)
GO
CREATE OR ALTER PROC [dbo].[spud_CongDanTamTru_ChuaDuyet](@Tinh nvarchar(max),@huyen nvarchar(max),@xa nvarchar(max))
AS
BEGIN
	SELECT *
	FROM Temporarily_Staying
	WHERE TrangThai='Chưa duyệt' AND Tinh=@Tinh AND Huyen=@huyen AND Xa=@xa
END;



-- Function

--  Hàm tính số lượng công dân hiện có(Công)(citizens)
go
CREATE OR ALTER FUNCTION [dbo].[Fn_TinhTongDanCu]()
RETURNS	INT 
AS
BEGIN
	DECLARE @COUNT INT
	SELECT @COUNT=COUNT(*) 
	FROM Citizens;
	RETURN @COUNT;
END

-- Liệt kê những công dân có hạn sử dụng năm nay, hoặc năm sau đi thay thế cccd.(Công)(Certificates)
GO
CREATE OR ALTER FUNCTION [dbo].[Fn_CongDanSapHetHanSuDung]()
RETURNS @SapHetHan TABLE (ID int,MaCCCD nvarchar(12),MaCD varchar(10),QuocTich nvarchar(max),QueQuan nvarchar(max),NoiThuongTru nvarchar(max),HanSuDung nvarchar(max),DacDiemNhanDang nvarchar(max),Anh image)
AS
BEGIN
	INSERT INTO @SapHetHan(ID,MaCCCD,MaCD,QuocTich,QueQuan,NoiThuongTru,HanSuDung,DacDiemNhanDang,Anh)
	SELECT *
	FROM Certificates
	WHERE YEAR(HanSuDung)=YEAR(GETDATE())AND YEAR(HanSuDung)=( YEAR(GETDATE()) + 1 );
	return 
END

--go
--select *
--from Fn_CongDanSapHetHanSuDung();
----Công------------------------------------------------------------




--DATA
/*USE CityzenManagement
GO*/
GO
INSERT INTO Citizens (MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang)
VALUES
('CD0001', N'Nguyen Van A', N'Nam', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0002', N'Tran Thi B', N'Nữ', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0003', N'Le Van C', N'Nam', N'Cong nhan', N'Kinh', N'Khong', N'Còn sống'),
('CD0004', N'Hoang Thi D', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0005', N'Pham Van E', N'Nam', N'Ky su', N'Kinh', N'Cong giao', N'Còn sống'),
('CD0006', N'Doan Thi F', N'Nữ', N'Nhan vien van phong', N'Kinh', N'Khong', N'Còn sống'),
('CD0007', N'Nguyen Van G', N'Nam', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0008', N'Tran Thi H', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0009', N'Le Van I', N'Nam', N'Bac si', N'Kinh', N'Khong', N'Còn sống'),
('CD0010', N'Hoang Thi K', N'Nữ', N'Du hoc sinh', N'Kinh', N'Khong', N'Còn sống'),
('CD0011', N'Nguyen Van D', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0012', N'Tran Thi E', N'Nữ', N'Kỹ sư', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0013', N'Le Van F', N'Nam', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0014', N'Pham Thi G', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0015', N'Hoang Van H', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0016', N'Vo Thi I', N'Nữ', N'Bác sĩ', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0017', N'Truong Van K', N'Nam', N'Du học sinh', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0018', N'Nguyen Thi L', N'Nữ', N'Nhân viên văn phòng', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0019', N'Tran Van M', N'Nam', N'Kỹ sư', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0020', N'Le Thi N', N'Nữ', N'Công nhân', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0021', N'Pham Van O', N'Nam', N'Y tá', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0022', N'Hoang Thi P', N'Nữ', N'Sinh viên', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0023', N'Doan Van Q', N'Nam', N'Bác sĩ', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0024', N'Nguyen Thi R', N'Nữ', N'Giáo viên', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0025', N'Tran Van S', N'Nam', N'Giao viên', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0026', N'Le Thi T', N'Nữ', N'Nhân viên văn phòng', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0027', N'Pham Van U', N'Nam', N'Kỹ sư', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0028', N'Hoang Thi V', N'Nữ', N'Công nhân', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0029', N'Nguyen Van X', N'Nam', N'Sinh viên', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0030', N'Tran Thi Y', N'Nữ', N'Nữ', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0031', N'Le Van Z', N'Nam', N'Nhan vien van phong', N'Kinh', N'Hoi giao', N'Còn sống'),
('CD0032', N'Pham Thi A', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0033', N'Hoang Van B', N'Nam', N'Ky su', N'Kinh', N'Cong giao', N'Còn sống'),
('CD0034', N'Doan Thi C', N'Nữ', N'Nhan vien van phong', N'Kinh', N'Khong', N'Còn sống'),
('CD0035', N'Nguyen Van D', N'Nam', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0036', N'Tran Thi E', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0037', N'Le Van F', N'Nam', N'Bac si', N'Kinh', N'Khong', N'Còn sống'),
('CD0038', N'Pham Thi G', N'Nữ', N'Du hoc sinh', N'Kinh', N'Khong', N'Còn sống'),
('CD0039', N'Hoang Van H', N'Nam', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0040', N'Doan Thi I', N'Nữ', N'Nhan vien van phong', N'Kinh', N'Khong', N'Còn sống'),
('CD0041', N'Nguyen Van J', N'Nam', N'Bac si', N'Kinh', N'Khong', N'Còn sống'),
('CD0042', N'Tran Thi K', N'Nữ', N'Cong nhan', N'Kinh', N'Khong', N'Còn sống'),
('CD0043', N'Le Van L', N'Nam', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0044', N'Pham Thi M', N'Nữ', N'Ky su', N'Kinh', N'Cong giao', N'Còn sống'),
('CD0045', N'Hoang Van N', N'Nam', N'Nhan vien van phong', N'Kinh', N'Khong', N'Còn sống'),
('CD0046', N'Doan Thi O', N'Nữ', N'Cong nhan', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0047', N'Nguyen Van P', N'Nam', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0048', N'Tran Thi Q', N'Nữ', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống'),
('CD0049', N'Le Van R', N'Nam', N'Cong nhan', N'Kinh', N'Khong', N'Còn sống'),
('CD0050', N'Pham Thi S', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống'),
('CD0051', N'Truong Van A', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0052', N'Doan Thi B', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0053', N'Bui Van C', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0054', N'Ho Thi D', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0055', N'Nguyen Van E', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0056', N'Tran Thi F', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống'),
('CD0057', N'Le Van G', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống'),
('CD0058', N'Pham Thi H', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống'),
('CD0059', N'Hoang Van I', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống'),
('CD0060', N'Vo Thi K', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống');

INSERT INTO Citizens (MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang)
VALUES
	('QLHH', N'', N'Nam', N'', N'', N'', N''),
	('QLB', N'', N'Nam', N'', N'', N'', N''),
	('QLM', N'', N'Nam', N'', N'', N'', N''),
	('QLPM', N'', N'Nam', N'', N'', N'', N''),
	('QLTM', N'', N'Nam', N'', N'', N'', N''),
	('QLP', N'', N'Nam', N'', N'', N'', N'');
INSERT INTO Accounts (MaCD, MatKhau, PhanQuyen)
VALUES 
	('QLHH', 'manager', 1),
	('QLB', 'manager', 1),
	('QLM', 'manager', 1),
	('QLPM', 'manager', 1),
	('QLTM', 'manager', 1),
	('QLP', 'manager', 1);
INSERT INTO Accounts (MaCD, MatKhau, PhanQuyen)
VALUES 
('CD0001', '12345', 0),
('CD0002', '12345', 0),
('CD0003', '12345', 0),
('CD0004', '12345', 0),
('CD0005', '12345', 0),
('CD0006', '12345', 0),
('CD0007', '12345', 0),
('CD0008', '12345', 0),
('CD0009', '12345', 0),
('CD0010', '12345', 0),
('CD0011', '12345', 0),
('CD0012', '12345', 0),
('CD0013', '12345', 0),
('CD0014', '12345', 0),
('CD0015', '12345', 0),
('CD0016', '12345', 0),
('CD0017', '12345', 0),
('CD0018', '12345', 0),
('CD0019', '12345', 0),
('CD0020', '12345', 0),
('CD0021', '12345', 0),
('CD0022', '12345', 0),
('CD0023', '12345', 0),
('CD0024', '12345', 0),
('CD0025', '12345', 0),
('CD0026', '12345', 0),
('CD0027', '12345', 0),
('CD0028', '12345', 0),
('CD0029', '12345', 0),
('CD0030', '12345', 0),
('CD0031', '12345', 0),
('CD0032', '12345', 0),
('CD0033', '12345', 0),
('CD0034', '12345', 0),
('CD0035', '12345', 0),
('CD0036', '12345', 0),
('CD0037', '12345', 0),
('CD0038', '12345', 0),
('CD0039', '12345', 0),
('CD0040', '12345', 0),
('CD0041', '12345', 0),
('CD0042', '12345', 0),
('CD0043', '12345', 0),
('CD0044', '12345', 0),
('CD0045', '12345', 0),
('CD0046', '12345', 0),
('CD0047', '12345', 0),
('CD0048', '12345', 0),
('CD0049', '12345', 0),
('CD0050', '12345', 0),
('CD0051', '12345', 0),
('CD0052', '12345', 0),
('CD0053', '12345', 0),
('CD0054', '12345', 0),
('CD0055', '12345', 0),
('CD0056', '12345', 0),
('CD0057', '12345', 0),
('CD0058', '12345', 0),
('CD0059', '12345', 0),
('CD0060', '12345', 0);


INSERT INTO Births (MaCD, NgaySinh, NoiSinh, MaCD_Cha, MaCD_Me, NgayKhai)
VALUES
('CD0001', '2000-01-01', 'Ha Noi', 'CD0001', 'CD0001', '2023-04-10'),
('CD0002', '2002-05-15', 'Hai Phong', 'CD0002', 'CD0002', '2023-04-10'),
('CD0003', '1995-12-31', 'TP HCM', 'CD0001', 'CD0002', '2023-04-10'),
('CD0004', '1980-07-21', 'Da Nang', 'CD0001', 'CD0002', '2023-04-10'),
('CD0005', '1985-03-11', 'Hue', 'CD0001', 'CD0002', '2023-04-10'),
('CD0006', '1990-11-30', 'Quang Ngai','CD0006', 'CD0006', '2023-04-10'),
('CD0007', '1988-04-05', 'Ninh Binh','CD0007', 'CD0007', '2023-04-10'),
('CD0008', '1982-12-25', 'Thai Nguyen', 'CD0006', 'CD0007', '2023-04-10'),
('CD0009', '1983-06-17', 'Bac Ninh', 'CD0006', 'CD0007', '2023-04-10'),
('CD0010', '2001-09-03', 'Can Tho', 'CD0006', 'CD0007', '2023-04-10'),
('CD0011', '1998-11-20', N'Hà Nội', 'CD0011', 'CD0011', '2023-04-10'),
('CD0012', '2005-07-08', N'Hải Phòng', 'CD0012', 'CD0012', '2023-04-10'),
('CD0013', '1993-03-17', N'TP Hồ Chí Minh', 'CD0012', 'CD0013', '2023-04-10'),
('CD0014', '1982-09-05', N'Đà Nẵng', 'CD0012', 'CD0013', '2023-04-10'),
('CD0015', '1991-01-25', N'Huế', 'CD0012', 'CD0013', '2023-04-10'),
('CD0016', '1996-12-02', N'Quảng Ngãi', 'CD0016', 'CD0016', '2023-04-10'),
('CD0017', '1994-05-28', N'Ninh Bình', 'CD0017', 'CD0017', '2023-04-10'),
('CD0018', '1988-10-15', N'Thái Nguyên', 'CD0016', 'CD0017', '2023-04-10'),
('CD0019', '1990-06-12', N'Bắc Ninh', 'CD0016', 'CD0017', '2023-04-10'),
('CD0020', '2004-04-30', N'Cần Thơ', 'CD0016', 'CD0017', '2023-04-10'),
('CD0021', '1997-08-18', N'Hà Nội', 'CD0021', 'CD0021', '2023-04-10'),
('CD0022', '2003-03-11', N'Hải Phòng', 'CD0022', 'CD0022', '2023-04-10'),
('CD0023', '1992-01-05', N'TP Hồ Chí Minh', 'CD0022', 'CD0023', '2023-04-10'),
('CD0024', '1985-09-27', N'Đà Nẵng', 'CD0022', 'CD0023',  '2023-04-10'),
('CD0025', '1993-04-15', N'Huế', 'CD0022', 'CD0023',  '2023-04-10'),
('CD0026', '1999-12-12', N'Quảng Ngãi', 'CD0026', 'CD0026',  '2023-04-10'),
('CD0027', '1998-06-07', N'Ninh Bình', 'CD0027', 'CD0027',  '2023-04-10'),
('CD0028', '2002-02-28', N'Thái Nguyên', 'CD0026', 'CD0027',  '2023-04-10'),
('CD0029', '2003-07-15', N'Bắc Ninh', 'CD0026', 'CD0027', '2023-04-10'),
('CD0030', '1999-11-05', N'Thái Bình', 'CD0026', 'CD0027', '2023-04-10'),
('CD0031', '2001-03-12', N'Nam Định', 'CD0031', 'CD0031', '2023-04-10'),
('CD0032', '1997-09-21', N'Hà Nam', 'CD0032', 'CD0032', '2023-04-10'),
('CD0033', '1992-12-30', N'Nghệ An', 'CD0031', 'CD0032', '2023-04-10'),
('CD0034', '1994-08-08', N'Hà Tĩnh', 'CD0031', 'CD0032', '2023-04-10'),
('CD0035', '2004-01-10', N'Quảng Bình', 'CD0031', 'CD0032', '2023-04-10'),
('CD0036', '2000-06-18', N'Quảng Trị', 'CD0036', 'CD0036', '2023-04-10'),
('CD0037', '1998-02-25', N'Thừa Thiên Huế', 'CD0037', 'CD0037', '2023-04-10'),
('CD0038', '2005-04-05', N'Đà Nẵng', 'CD0036', 'CD0037', '2023-04-10'),
('CD0039', '1996-10-22', N'Quảng Nam', 'CD0036', 'CD0037', '2023-04-10'),
('CD0040', '1993-05-07', N'Quảng Ngãi', 'CD0036', 'CD0037', '2023-04-10'),
('CD0041', '1991-01-15', N'Bình Định', 'CD0041', 'CD0041', '2023-04-10'),
('CD0042', '1990-07-29', N'Phú Yên', 'CD0042', 'CD0042', '2023-04-10'),
('CD0043', '1997-08-08', N'Khánh Hòa', 'CD0041', 'CD0042', '2023-04-10'),
('CD0044', '2003-01-15', N'Lâm Đồng', 'CD0041', 'CD0042', '2023-04-10'),
('CD0045', '2005-05-20', N'Bình Thuận', 'CD0041', 'CD0042', '2023-04-10'),
('CD0046', '1999-10-03', N'Ninh Thuận', 'CD0046', 'CD0046', '2023-04-10'),
('CD0047', '1996-06-12', N'Tây Ninh', 'CD0047', 'CD0047', '2023-04-10'),
('CD0048', '1994-03-18', N'Bình Dương', 'CD0046', 'CD0047', '2023-04-10'),
('CD0049', '2002-12-25', N'Bình Phước','CD0046', 'CD0047', '2023-04-10'),
('CD0050', '2001-07-01', N'Đồng Nai', 'CD0046', 'CD0047', '2023-04-10');
--('CD0051', '1993-09-05', N'Long An', 'CD0051', 'CD0051', '2023-04-10'),
--('CD0052', '1991-11-10', N'Tiền Giang', 'CD0001', 'CD0002', '2023-04-10'),
--('CD0053', '2000-02-17', N'Vĩnh Long', 'CD0006', 'CD0007', '2023-04-10'),
--('CD0054', '1998-04-23', N'Đồng Tháp', 'CD00011', 'CD0012', '2023-04-10'),
--('CD0055', '1995-12-30', N'An Giang', 'CD0016', 'CD0017', '2023-04-10'),
--('CD0056', '1992-10-07', N'Kiên Giang', 'CD0021', 'CD0022', '2023-04-10'),
--('CD0057', '2004-06-25', N'Cần Thơ', 'CD0026', 'CD0027', '2023-04-10');


INSERT INTO Users_Deleted (MaCD, NguoiKhai, NguyenNhan, NgayTu, NgayKhai, NgayDuyet)
VALUES
('CD0023', 'CD0021', N'Đột quỵ', '2023-01-01', '2023-05-12', NULL),
('CD0025', 'CD0021', N'Tai nạn', '2023-02-01', '2023-05-12', NULL),
('CD0027', 'CD0026', N'Tự tử', '2023-03-01', '2023-05-12', NULL),
('CD0045', 'CD0041', N'Bệnh hiểm nghèo', '2023-04-01', '2023-05-12', NULL),
('CD0012', 'CD0011', N'Ung thư', '2023-05-01', '2023-05-12', NULL),
('CD0024', 'CD0021', N'Tự tử', '2023-05-01', '2023-05-12', NULL),
('CD0007', 'CD0006', N'Ung thư', '2023-05-01', '2023-05-12', NULL),
('CD0008', 'CD0006', N'Tai nạn giao thông', '2023-05-01', '2023-05-12', NULL),
('CD0015', 'CD0011', N'Uống lộn thuốc', '2023-05-01', '2023-05-12', NULL),
('CD0003', 'CD0001', N'Ung thư', '2022-03-15', GETDATE(), NULL),
('CD0005', 'CD0001', N'Tai nạn giao thông', '2022-04-20', GETDATE(), NULL);

INSERT INTO Households
VALUES
('HO0001','CD0001', N'Hà Nội', N'Ba Đình', N'Trúc Bạch', '2023-04-10', N'Chưa duyệt'),
('HO0002','CD0006', N'Hà Nội', N'Cầu Giấy', N'Quan Hoa', '2023-04-10', N'Chưa duyệt'),
('HO0003','CD0011', N'Hà Nội', N'Hoàng Mai', N'Vĩnh Tuy', '2023-04-10', N'Chưa duyệt'),
('HO0004','CD0016', N'Hồ Chí Minh', N'Quận 1', N'Bến Nghé', '2023-04-10', N'Chưa duyệt'),
('HO0005','CD0021', N'Hồ Chí Minh', N'Quận 2', N'An Phú', '2023-04-10', N'Chưa duyệt'),
('HO0006','CD0026', N'Hồ Chí Minh', N'Quận 3', N'Phường 7', '2023-04-10', N'Chưa duyệt'),
('HO0007','CD0031', N'Da Nang', N'Quận Sơn Trà', N'Phường Mỹ An', '2023-04-10', N'Chưa duyệt'),
('HO0008','CD0036', N'Da Nang', N'Quận Hải Châu', N'Phường Thanh Bình', '2023-04-10', N'Chưa duyệt'),
('HO0009','CD0041', N'Nghệ An', N'Huyện Quỳnh Lưu', N'Xã Quỳnh Đôi', '2023-04-10', N'Chưa duyệt'),
('HO0010','CD0046', N'Bình Dương', N'Thủ Dầu Một', N'Phường Phú Hòa', '2023-04-10', N'Chưa duyệt');

INSERT INTO Detail_Households (MaHo, MaCD, TinhTrangCuTru, QuanHeVoiChuHo, NgayDangKy, TrangThai)
VALUES
    ('HO0001', 'CD0001', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0001', 'CD0002', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0001', 'CD0003', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0001', 'CD0004', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0001', 'CD0005', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    
    ('HO0002', 'CD0006', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0002', 'CD0007', N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    ('HO0002', 'CD0008', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0002', 'CD0009', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0002', 'CD0010', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    ('HO0003', 'CD0011', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0003', 'CD0012', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0003', 'CD0013', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0003', 'CD0014', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0003', 'CD0015', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    ('HO0004', 'CD0016', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0004', 'CD0017', N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    ('HO0004', 'CD0018', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0004', 'CD0019', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0004', 'CD0020', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0005', 'CD0021', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0005', 'CD0022', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0005', 'CD0023', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0005', 'CD0024', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0005', 'CD0025', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0006', 'CD0026', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0006', 'CD0027', N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    ('HO0006', 'CD0028', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0006', 'CD0029', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0006', 'CD0030', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    ('HO0007', 'CD0031', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0007', 'CD0032', N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    ('HO0007', 'CD0033', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0007', 'CD0034', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0007', 'CD0035', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0008', 'CD0036', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
	('HO0008', 'CD0037', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0008', 'CD0038', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0008', 'CD0039', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0008', 'CD0040', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0009', 'CD0041', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0009', 'CD0042', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0009', 'CD0043', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0009', 'CD0044', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0009', 'CD0045', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0010', 'CD0046', N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    ('HO0010', 'CD0047', N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    ('HO0010', 'CD0048', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0010', 'CD0049', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0010', 'CD0050', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	('HO0001', 'CD0051', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0002', 'CD0052', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0003', 'CD0053', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0004', 'CD0054', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0005', 'CD0055', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
	('HO0006', 'CD0056', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0007', 'CD0057', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0008', 'CD0058', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0009', 'CD0059', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    ('HO0010', 'CD0060', N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt');

INSERT INTO People_Marriage
VALUES
('HN0001', 'CD0001', 'CD0002', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0002', 'CD0007', 'CD0006', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0003', 'CD0011', 'CD0012', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0004', 'CD0017', 'CD0016', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0005', 'CD0021', 'CD0022', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0006', 'CD0027', 'CD0026', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0007', 'CD0032', 'CD0031', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0008', 'CD0036', 'CD0037', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0009', 'CD0042', 'CD0041', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
('HN0010', 'CD0047', 'CD0046', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt');

--certificates mails temporary-absent temporary-staying

INSERT INTO Certificates (MaCD, QuocTich, QueQuan, NoiThuongTru, HanSuDung, DacDiemNhanDang, Avatar)
VALUES
    ('CD0001', N'Việt Nam', N'Kon Tum', N'Đắk Hà', N'2033-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0002', N'Việt Nam', N'Đà Nẵng', N'Hải Châu', N'2034-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0003', N'Việt Nam', N'Hà Nội', N'Cầu Giấy', N'2035-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0004', N'Việt Nam', N'Hồ Chí Minh', N'Quận 1', N'2036-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0005', N'Việt Nam', N'Đồng Nai', N'Biên Hòa', N'2037-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0006', N'Việt Nam', N'Bình Dương', N'Thủ Dầu Một', N'2038-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0007', N'Việt Nam', N'Nghệ An', N'Vinh', N'2039-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0008', N'Việt Nam', N'Hải Phòng', N'Hồng Bàng', N'2040-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0009', N'Việt Nam', N'Khánh Hòa', N'Nha Trang', N'2041-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0010', N'Việt Nam', N'Bà Rịa - Vũng Tàu', N'Vũng Tàu', N'2042-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0011', N'Việt Nam', N'Quảng Ngãi', N'Quảng Ngãi', N'2043-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0012', N'Việt Nam', N'Đắk Lắk', N'Buôn Ma Thuột', N'2044-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0013', N'Việt Nam', N'Lâm Đồng', N'Đà Lạt', N'2045-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0014', N'Việt Nam', N'Thừa Thiên Huế', N'Huế', N'2046-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0015', N'Việt Nam', N'Hà Tĩnh', N'Hà Tĩnh', N'2047-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0016', N'Việt Nam', N'Thanh Hóa', N'Thanh Hóa', N'2048-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0017', N'Việt Nam', N'Nam Định', N'Nam Định', N'2049-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0018', N'Việt Nam', N'Bắc Ninh', N'Bắc Ninh', N'2050-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0019', N'Việt Nam', N'Phú Thọ', N'Việt Trì', N'2051-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0020', N'Việt Nam', N'Bắc Giang', N'Bắc Giang', N'2052-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0021', N'Việt Nam', N'Hòa Bình', N'Hòa Bình', N'2053-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0022', N'Việt Nam', N'Hưng Yên', N'Hưng Yên', N'2054-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0023', N'Việt Nam', N'Hà Nam', N'Phủ Lý', N'2055-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0024', N'Việt Nam', N'Thái Bình', N'Thái Bình', N'2056-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0025', N'Việt Nam', N'Hải Dương', N'Hải Dương', N'2057-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0026', N'Việt Nam', N'Hải Dương', N'Chí Linh', N'2058-01-01', N'Không', 'D:\meo.jpg'),
    ('CD0027', N'Việt Nam', N'Quảng Ninh', N'Hạ Long', N'2059-01-01', N'Không', 'D:\meo.jpg');






INSERT INTO Temporarily_Absent (ID,MaCD, MaCCCD, Tinh, Huyen, Xa, LyDo, thoi_gian_bat_dau, thoi_gian_ket_thuc)
VALUES
  ('TA0001','CD0001', 'CCCD001', N'Kon Tum', N'Đắk Hà', N'Hà Mòn', N'Học', '2023-05-01', '2023-05-07'),
  ('TA0002','CD0002', 'CCCD002', N'Bình Thuận', N'Hàm Thuận Bắc', N'Phước Bình', N'Công tác', '2023-05-02', '2023-05-08'),
  ('TA0003','CD0003', 'CCCD003', N'Tiền Giang', N'Cái Bè', N'Mỹ Thanh', N'Đi công việc', '2023-05-03', '2023-05-09'),
  ('TA0004','CD0004', 'CCCD004', N'Quảng Bình', N'Đồng Hới', N'Đức Ninh', N'Du lịch', '2023-05-04', '2023-05-10'),
  ('TA0005','CD0005', 'CCCD005', N'Hải Phòng', N'Hồng Bàng', N'Hà Khẩu', N'Công tác', '2023-05-05', '2023-05-11'),
  ('TA0006','CD0006', 'CCCD006', N'Đồng Nai', N'Tân Phú', N'Tân Hòa', N'Học', '2023-05-06', '2023-05-12'),
  ('TA0007','CD0007', 'CCCD007', N'Lâm Đồng', N'Đà Lạt', N'Liên Nghĩa', N'Du lịch', '2023-05-07', '2023-05-13'),
  ('TA0008','CD0008', 'CCCD008', N'Ninh Bình', N'Tam Điệp', N'Yên Mạc', N'Đi công việc', '2023-05-08', '2023-05-14'),
  ('TA0009','CD0009', 'CCCD009', N'Hà Tĩnh', N'Kỳ Anh', N'Kỳ Long', N'Du lịch', '2023-05-09', '2023-05-15'),
  ('TA0010','CD0010', 'CCCD010', N'Đắk Lắk', N'Buôn Ma Thuột', N'Ea Kao', N'Công tác', '2023-05-10', '2023-05-16');


INSERT INTO Temporarily_Staying (ID,MaCD, MaCCCD, Tinh, Huyen, Xa, LyDo, thoi_gian_bat_dau)
VALUES
  ('TS0001', 'CD0011', 'CCCD011', N'Kon Tum', N'Đắk Hà', N'Hà Mòn', N'Học', '2023-05-01'),
  ('TS0002','CD0012', 'CCCD012', N'Bình Thuận', N'Hàm Thuận Bắc', N'Phước Bình', N'Công tác', '2023-05-02'),
  ('TS0003','CD0013', 'CCCD013', N'Tiền Giang', N'Cái Bè', N'Mỹ Thanh', N'Đi công việc', '2023-05-03'),
  ('TS0004','CD0014', 'CCCD014', N'Quảng Bình', N'Đồng Hới', N'Đức Ninh', N'Du lịch', '2023-05-04'),
  ('TS0005','CD0015', 'CCCD015', N'Hải Phòng', N'Hồng Bàng', N'Hà Khẩu', N'Công tác', '2023-05-05'),
  ('TS0006','CD0016', 'CCCD016', N'Đồng Nai', N'Tân Phú', N'Tân Hòa', N'Học', '2023-05-06'),
  ('TS0007','CD0017', 'CCCD017', N'Lâm Đồng', N'Đà Lạt', N'Liên Nghĩa', N'Du lịch', '2023-05-07'),
  ('TS0008','CD0018', 'CCCD018', N'Ninh Bình', N'Tam Điệp', N'Yên Mạc', N'Đi công việc', '2023-05-08'),
  ('TS0009','CD0019', 'CCCD019', N'Hà Tĩnh', N'Kỳ Anh', N'Kỳ Long', N'Du lịch', '2023-05-09'),
  ('TS0010','CD0020', 'CCCD020', N'Đắk Lắk', N'Buôn Ma Thuột', N'Ea Kao', N'Công tác', '2023-05-10');

  INSERT INTO Mails (MaMail,TieuDe, Ngay, NguoiGui, NguoiNhan, NoiDung)
VALUES
    ('Mail0001',N'Mail 1', '2022-01-01', 'CD0001', 'CD0002', N'Nội dung mail 1'),
    ('Mail0002',N'Mail 2', '2022-02-05', 'CD0001', 'CD0004', N'Nội dung mail 2'),
    ('Mail0003',N'Mail 3', '2022-03-10', 'CD0001', 'CD0006', N'Nội dung mail 3'),
    ('Mail0004',N'Mail 4', '2022-04-15', 'CD0001', 'CD0008', N'Nội dung mail 4'),
    ('Mail0005',N'Mail 5', '2022-05-20', 'CD0001', 'CD0010', N'Nội dung mail 5'),
    ('Mail0006',N'Mail 6', '2022-06-25', 'CD0001', 'CD0012', N'Nội dung mail 6'),
    ('Mail0007',N'Mail 7', '2022-07-30', 'CD0001', 'CD0014', N'Nội dung mail 7'),
    ('Mail0008',N'Mail 8', '2022-08-04', 'CD0001', 'CD0016', N'Nội dung mail 8'),
    ('Mail0009',N'Mail 9', '2022-09-09', 'CD0001', 'CD0018', N'Nội dung mail 9'),
    ('Mail0010',N'Mail 10', '2022-10-14', 'CD0001', 'CD0020', N'Nội dung mail 10'),
    ('Mail0011',N'Mail 11', '2022-11-19', 'CD0001', 'CD0022', N'Nội dung mail 11'),
    ('Mail0012',N'Mail 12', '2022-12-24', 'CD0001', 'CD0024', N'Nội dung mail 12'),
    ('Mail0013',N'Mail 13', '2023-01-29', 'CD0001', 'CD0026', N'Nội dung mail 13'),
    ('Mail0014',N'Mail 14', '2023-03-05', 'CD0001', 'CD0028', N'Nội dung mail 14'),
    ('Mail0015',N'Mail 15', '2023-04-10', 'CD0001', 'CD0030', N'Nội dung mail 15'),
    ('Mail0016',N'Mail 16', '2023-05-15', 'CD0001', 'CD0032', N'Nội dung mail 16'),
    ('Mail0017',N'Mail 17', '2023-06-20', 'CD0001', 'CD0034', N'Nội dung mail 17'),
    ('Mail0018',N'Mail 18', '2023-07-25', 'CD0001', 'CD0036', N'Nội dung mail 18'),
    ('Mail0019',N'Mail 19', '2023-08-30', 'CD0001', 'CD0038', N'Nội dung mail 19'),
    ('Mail0020',N'Mail 20', '2023-10-04', 'CD0001', 'CD0040', N'Nội dung mail 20'),
    ('Mail0021',N'Mail 21', '2023-10-09', 'CD0002', 'CD0001', N'Nội dung mail 21'),
    ('Mail0022',N'Mail 22', '2023-09-04', 'CD0004', 'CD0001', N'Nội dung mail 22'),
    ('Mail0023',N'Mail 23', '2023-08-01', 'CD0006', 'CD0001', N'Nội dung mail 23'),
    ('Mail0024',N'Mail 24', '2023-07-01', 'CD0008', 'CD0001', N'Nội dung mail 24'),
    ('Mail0025',N'Mail 25', '2023-06-05', 'CD0010', 'CD0001', N'Nội dung mail 25'),
    ('Mail0026',N'Mail 26', '2023-05-08', 'CD0012', 'CD0001', N'Nội dung mail 26'),
    ('Mail0027',N'Mail 27', '2023-04-02', 'CD0014', 'CD0001', N'Nội dung mail 27'),
    ('Mail0028',N'Mail 28', '2023-03-01', 'CD0016', 'CD0001', N'Nội dung mail 28'),
    ('Mail0029',N'Mail 29', '2023-02-02', 'CD0018', 'CD0001', N'Nội dung mail 29'),
    ('Mail0030',N'Mail 30', '2023-01-06', 'CD0020', 'CD0001', N'Nội dung mail 30'),
    ('Mail0031',N'Mail 31', '2022-12-10', 'CD0022', 'CD0001', N'Nội dung mail 31'),
    ('Mail0032',N'Mail 32', '2022-11-14', 'CD0024', 'CD0001', N'Nội dung mail 32'),
    ('Mail0033',N'Mail 33', '2022-10-19', 'CD0026', 'CD0001', N'Nội dung mail 33'),
    ('Mail0034',N'Mail 34', '2022-09-23', 'CD0028', 'CD0001', N'Nội dung mail 34'),
    ('Mail0035',N'Mail 35', '2022-08-27', 'CD0030', 'CD0001', N'Nội dung mail 35'),
    ('Mail0036',N'Mail 36', '2022-07-31', 'CD0032', 'CD0001', N'Nội dung mail 36'),
    ('Mail0037',N'Mail 37', '2022-07-03', 'CD0034', 'CD0001', N'Nội dung mail 37'),
    ('Mail0038',N'Mail 38', '2022-06-05', 'CD0036', 'CD0001', N'Nội dung mail 38'),
    ('Mail0039',N'Mail 39', '2022-05-09', 'CD0038', 'CD0001', N'Nội dung mail 39'),
    ('Mail0040',N'Mail 40', '2022-04-13', 'CD0040', 'CD0001', N'Nội dung mail 40');
  /*

DROP TABLE Accounts
DROP TABLE Births
DROP TABLE Certificates
DROP TABLE Citizens
DROP TABLE Detail_Households
DROP TABLE Households
DROP TABLE Mails
DROP TABLE People_Marriage
DROP TABLE Temporarily_Absent
DROP TABLE Temporarily_Staying
DROP TABLE Users_Deleted
DROP VIEW Citizens_Without_Certificates
DROP VIEW MAILBOX
DROP VIEW PERSONAL_INFORMATION
DROP VIEW V_GetCertificates
DROP FUNCTION fn_DSCDTamVangTheoHuyen
DROP FUNCTION fn_DSCDTamVangTheoTinh
DROP FUNCTION fn_DSCDTamVangTheoXa
DROP FUNCTION GetCitizensByProvince
DROP FUNCTION GetHouseholdsByLocation
DROP DATABASE CityzenManagement
*/