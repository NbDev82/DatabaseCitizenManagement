CREATE DATABASE CityzenManagement
GO

USE CityzenManagement
GO

CREATE table [Citizens](
	MaCD int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
	HoTen NVARCHAR(max) NOT NULL,
	GioiTinh NVARCHAR(max) NOT NULL, -- Nam | Nữ
	NgheNghiep NVARCHAR(max) NOT NULL DEFAULT N'NONE',
	DanToc NVARCHAR(max) NOT NULL,
	TonGiao NVARCHAR(max) NOT NULL DEFAULT N'NONE',
	TinhTrang NVARCHAR(max) DEFAULT N'Còn sống' NOT NULL, -- Đã chết | Còn sống
	MaHN int NOT NULL DEFAULT -1, -- -1: Độc thân
)
/*
drop table [Citizens]
*/
CREATE TABLE [Accounts](
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD),
	matkhau nvarchar(max)  NOT NULL,
	phanquyen bit /*chỉ nhận 2 giá trị 0 hoặc 1*/
)
/*
drop table [Accounts]
*/
CREATE TABLE [Births] (
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    NgaySinh DATE  NOT NULL,
	NoiSinh NVARCHAR(255) NOT NULL,
    MaCD_Cha int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    MaCD_Me int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
    NgayKhai DATE NOT NULL DEFAULT GETDATE(),
	NgayDuyet DATE NULL
);
GO
/*
drop table [Births]
*/


CREATE TABLE [Users_Deleted](
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL UNIQUE,
	NguoiKhai int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
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
	MaHo INT IDENTITY(1,1) PRIMARY KEY,
	ChuHo int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
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
ADD MaHoKhau INT FOREIGN KEY REFERENCES [Households](MaHo) NULL;

CREATE TABLE [Detail_Households](
	MaHo int FOREIGN KEY REFERENCES [Households](MaHo) NOT NULL,
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
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
	MaHN INT IDENTITY PRIMARY KEY,
	MaCDChong int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
	MaCDVo int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
	Loai NVARCHAR(255) NOT NULL DEFAULT N'Kết hôn', -- 1: Kết hôn | 0: Ly hôn
	NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
	XacNhanLan1 int REFERENCES [Citizens](MaCD) DEFAULT NULL,
	XacNhanLan2 int REFERENCES [Citizens](MaCD) DEFAULT NULL,
	TrangThai NVARCHAR(255) NOT NULL DEFAULT N'Chưa duyệt'-- 1: Đã duyệt | 0: Chưa duyệt
)
GO
/*
drop table [People_Marriage]
*/
CREATE TABLE [Mails](
	MaMail INT IDENTITY PRIMARY KEY,
	TieuDe NVARCHAR(MAX) NOT NULL DEFAULT N'NONE',
	Ngay DATE NOT NULL DEFAULT GETDATE(),
	NguoiGui int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
	NguoiNhan int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
	NoiDung NVARCHAR(MAX) NOT NULL
)
GO
/*
drop table [Mails]
*/
CREATE TABLE Temporarily_Absent (
	ID int PRIMARY KEY IDENTITY(1,1),
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
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
	ID int PRIMARY KEY IDENTITY(1,1),
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) NOT NULL,
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
	MaCD int FOREIGN KEY REFERENCES [Citizens](MaCD) UNIQUE NOT NULL,
	MaCCCD VARCHAR(max) NOT NULL,
	QuocTich NVARCHAR(max) NOT NULL,
	QueQuan NVARCHAR(max) NOT NULL,
	NoiThuongTru NVARCHAR(max) NOT NULL,
	HanSuDung Date NOT NULL,
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


/*--TRIGGER
-- Trigger cho việc thêm mới công dân vào [Detail_Households]
CREATE TRIGGER [dbo].[trg_AddCitizenToHousehold]
ON [dbo].[Detail_Households]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
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
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
    SELECT @MaHo = deleted.MaHo, @MaCD = deleted.MaCD FROM deleted;
    
    -- Cập nhật trạng thái hộ khẩu của công dân
    UPDATE [Citizens] SET MaHoKhau = NULL WHERE MaCD = @MaCD;
END
GO

-- Trigger cho việc thêm công dân đã chết vào [Users_Deleted]
CREATE or ALTER TRIGGER [trg_Citizen_Delete] ON [Users_Deleted] 
AFTER INSERT
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @MaCD INT;
  DECLARE @CheckMaCD INT;

  SELECT @MaCD = MaCD FROM inserted;

  -- Kiểm tra xem công dân đã chết hay chưa
  SELECT @CheckMaCD = COUNT(*) FROM [Citizens] WHERE MaCD = @MaCD AND TinhTrang = N'Đã chết';

  IF @CheckMaCD > 0
  BEGIN
    RAISERROR('Không thể thêm công dân đã chết vào bảng Users_Deleted!', 16, 1);
    ROLLBACK TRANSACTION;
  END

  UPDATE [Citizens]
  SET TinhTrang = N'Đã chết'
  WHERE MaCD = @MaCD
END
go
-- Trigger cho việc kiểm tra xem người khai có phải chủ hộ không trong [Users_Deleted] 
CREATE TRIGGER [Check_Death_NguoiKhai] 
ON [Users_Deleted]
FOR INSERT
AS
BEGIN
    DECLARE @MaCD INT, @NguoiKhai INT, @ChuHo INT, @MaHoKhau INT
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
*/

--KHOA----------------------------------------------------------------------------------------------------------------------

/* 
CREATE DATABASE CityzenManagement
GO 
*/

ALTER TABLE [Births]
ADD CONSTRAINT CHK_Births_NgKhaiNgDuyet CHECK (NgayDuyet is null OR NgayDuyet >= NgayKhai)


ALTER TABLE [People_Marriage]
ADD CONSTRAINT CHK_People_Marriage_Loai CHECK (Loai = 'Kết hôn' OR Loai ='Ly hôn')

GO


--TRIGGER
-- Trigger cho việc thêm mới công dân vào [Detail_Households]
CREATE TRIGGER [trg_AddCitizenToHousehold]
ON [dbo].[Detail_Households]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
    SELECT @MaHo = inserted.MaHo, @MaCD = inserted.MaCD FROM inserted;
    
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
CREATE TRIGGER [trg_RemoveCitizenFromHousehold]
ON [dbo].[Detail_Households]
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
    SELECT @MaHo = deleted.MaHo, @MaCD = deleted.MaCD FROM deleted;
    
    -- Cập nhật trạng thái hộ khẩu của công dân
    UPDATE [Citizens] SET MaHoKhau = NULL WHERE MaCD = @MaCD;
END
GO

-- Trigger cho việc thêm công dân đã chết vào [Users_Deleted]
CREATE or ALTER TRIGGER [trg_Citizen_Delete] ON [Users_Deleted] 
AFTER INSERT
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @MaCD INT;
  DECLARE @CheckMaCD INT;

  SELECT @MaCD = MaCD FROM inserted;

  -- Kiểm tra xem công dân đã chết hay chưa
  SELECT @CheckMaCD = COUNT(*) FROM [Citizens] WHERE MaCD = @MaCD AND TinhTrang = N'Đã chết';

  IF @CheckMaCD > 0
  BEGIN
    RAISERROR('Không thể thêm công dân đã chết vào bảng Users_Deleted!', 16, 1);
    ROLLBACK TRANSACTION;
  END

  UPDATE [Citizens]
  SET TinhTrang = N'Đã chết'
  WHERE MaCD = @MaCD
END
go
-- Trigger cho việc kiểm tra xem người khai có phải chủ hộ không trong [Users_Deleted] 
CREATE TRIGGER [Check_Death_NguoiKhai] 
ON [Users_Deleted]
FOR INSERT
AS
BEGIN
    DECLARE @MaCD INT, @NguoiKhai INT, @ChuHo INT, @MaHoKhau INT
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
	DECLARE @MaCDChong int, @MaCDVo int, 
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

	if(@SoHo > 0)
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
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Huyen = @Huyen )

--Theo xã
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoXa(@Xa nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Xa = @Xa )
--Theo tỉnh
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoTinh(@Tinh nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN
	FROM Citizens cti, Temporarily_Absent ta
	WHERE cti.MaCD = ta.MaCD
	AND ta.Tinh = @Tinh )

--Function lấy danh sách CD có cùng chủ hộ
GO
CREATE or ALTER FUNCTION fn_DSCDTamVangTheoTinh(@ChuHo nvarchar(max))
RETURNS TABLE
AS
RETURN(
	SELECT cti.MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN
	FROM Citizens cti
	WHERE cti.MaCD IN (SELECT MaCD FROM Detail_Households WHERE MaHo = @ChuHo))
--Khoa----------------------------------------------------------------------------------------------------------------------







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
-- Hàm đếm số lượng người tạm chú tại 1 khu vực (tham số: thành phố, huyện, xã)
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
SELECT MaCD, HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN
FROM Citizens
WHERE MaCD NOT IN (SELECT MaCD FROM Certificates);
SELECT * FROM Citizens_Without_Certificates;

GO
-- 
CREATE FUNCTION Fn_CountHouseholdsInArea
(
    @tinhThanh NVARCHAR(max),
    @quanHuyen NVARCHAR(max),
    @phuongXa NVARCHAR(max)
)
RETURNS INT
AS
BEGIN
    DECLARE @soLuongHo INT;

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

-- chuyển

ALTER TABLE [Users_Deleted]
ADD CONSTRAINT CK_Users_Deleted_NgayDuyet CHECK (NgayDuyet > NgayKhai);
GO
--TRIGGER

--ngày duyệt phải lớn hơn ngày khai(Hoàng)(Users_Deleted)
CREATE TRIGGER trg_CheckNgayDuyet_Update
ON [Users_Deleted]
FOR UPDATE, INSERT
AS
BEGIN
    -- Kiểm tra ngày duyệt phải lớn hơn ngày khai trong hoạt động UPDATE
    IF EXISTS (
        SELECT 1
        FROM [Users_Deleted] AS UD
        INNER JOIN inserted AS I ON UD.MaCD = I.MaCD
        WHERE I.NgayDuyet IS NOT NULL AND I.NgayDuyet < I.NgayKhai
    )
    BEGIN
        RAISERROR ('Ngày duyệt phải lớn hơn ngày khai.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END
GO
--Quản lý phải là người gửi hoặc người nhận(Hoàng)(Mails)
CREATE or ALTER TRIGGER TR_Mails_CheckQuanLy
ON [Mails]
AFTER INSERT
AS
BEGIN
    
    -- Check if the sender or recipient is a manager
    IF EXISTS (
        SELECT 1
        FROM [Mails] AS M
        INNER JOIN [Accounts] AS A ON M.NguoiGui = A.MaCD OR M.NguoiNhan = A.MaCD
        WHERE M.MaMail IN (SELECT MaMail FROM inserted)
        AND A.phanquyen = 1
    )
    BEGIN
        -- Allow the insert operation
        PRINT 'Insert operation allowed.';
    END
    ELSE
    BEGIN
        -- Rollback the insert operation
        PRINT 'Insert operation denied. Manager must be the sender or recipient.';
        ROLLBACK TRANSACTION;
    END
END;
GO

--Cập nhật trạng thái hộ khẩu của công dân khi thêm, xóa công dân ra khỏi [Detail_Households](Hoàng)(Detail_Households)

-- Trigger cho việc thêm mới công dân vào [Detail_Households]
CREATE TRIGGER [trg_AddCitizenToHousehold]
ON [Detail_Households]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
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
    SET NOCOUNT ON;
    
    DECLARE @MaHo INT, @MaCD INT;
    SELECT @MaHo = deleted.MaHo, @MaCD = deleted.MaCD FROM deleted;
    
    -- Cập nhật trạng thái hộ khẩu của công dân
    UPDATE [Citizens] SET MaHoKhau = NULL WHERE MaCD = @MaCD;
END
GO

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

    -- Update household status after deleting citizen
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE [Citizens]
        SET MaHoKhau = NULL
        FROM [Citizens] AS C
        INNER JOIN deleted AS D ON C.MaCD = D.MaCD;
    END
END;

--kiểm tra xem người khai có phải chủ hộ không khi thêm  trong [Users_Deleted](Hoàng)(Users_Deleted)
CREATE TRIGGER [Check_Death_NguoiKhai] 
ON [Users_Deleted]
FOR INSERT
AS
BEGIN
    DECLARE @MaCD INT, @NguoiKhai INT, @ChuHo INT, @MaHoKhau INT
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

--FUNCTION
GO
--Liệt kê các công dân có quên quán ở 1 tỉnh (truyền vào tên tỉnh ), ( truyền ra danh sách công dân )(Hoàng)(Certificates)
CREATE FUNCTION dbo.GetCitizensByProvince( @Province NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN
(
    SELECT C.MaCD, C.HoTen, C.GioiTinh, C.NgheNghiep, C.DanToc, C.TonGiao, C.TinhTrang, C.MaHN
    FROM [Citizens] AS C
    INNER JOIN [Certificates] AS Certi ON C.MaCD = Certi.MaCD
    WHERE Certi.QueQuan LIKE '%' + @Province + '%'
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
--Khoa
--Tạo view thông tin cá nhân
GO
CREATE OR ALTER VIEW PERSONAL_INFORMATION
AS
SELECT *
FROM [Citizens]
--Tạo view hòm thư
GO
CREATE OR ALTER VIEW MAILBOX
AS
SELECT MaMail, TieuDe, Ngay, ctz1.HoTen AS TenNguoiGui,ctz2.HoTen AS TenNguoiNhan, NoiDung
FROM 
	Mails m
	INNER JOIN [Citizens] ctz1 ON m.NguoiGui = ctz1.MaCD
	INNER JOIN [Citizens] ctz2 ON m.NguoiNhan = ctz2.MaCD
GO
--DATA
/*USE CityzenManagement
GO*/

INSERT INTO Citizens (HoTen, GioiTinh, NgheNghiep, DanToc, TonGiao, TinhTrang, MaHN)
VALUES
(N'Nguyen Van A', N'Nam', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống', -1),--1
(N'Tran Thi B', N'Nữ', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống', -1),
(N'Le Van C', N'Nam', N'Cong nhan', N'Kinh', N'Khong', N'Còn sống', -1),
(N'Hoang Thi D', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống', -1),
(N'Pham Van E', N'Nam', N'Ky su', N'Kinh', N'Cong giao', N'Còn sống', -1),
(N'Doan Thi F', N'Nữ', N'Nhan vien van phong', N'Kinh', N'Khong', N'Còn sống', -1),--6
(N'Nguyen Van G', N'Nam', N'Giao vien', N'Kinh', N'Phat giao', N'Còn sống', -1),
(N'Tran Thi H', N'Nữ', N'Sinh vien', N'Kinh', N'Khong', N'Còn sống', -1),
(N'Le Van I', N'Nam', N'Bac si', N'Kinh', N'Khong', N'Còn sống', -1),
(N'Hoang Thi K', N'Nữ', N'Du hoc sinh', N'Kinh', N'Khong', N'Còn sống', -1),
(N'Nguyen Van D', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Hồi giáo', N'Còn sống', -1),--11
(N'Tran Thi E', N'Nữ', N'Kỹ sư', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Le Van F', N'Nam', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Pham Thi G', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Hoang Van H', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Vo Thi I', N'Nữ', N'Bác sĩ', N'Kinh', N'Phật giáo', N'Còn sống', -1),--16
(N'Truong Van K', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Doan Thi L', N'Nữ', N'Nhân viên kế toán', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Bui Van M', N'Nam', N'Công nhân', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Ho Thi N', N'Nữ', N'Bác sĩ', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Nguyen Van O', N'Nam', N'Giáo viên', N'Kinh', N'Hồi giáo', N'Còn sống', -1),--
(N'Tran Thi P', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Le Van Q', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Pham Thi R', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Hoang Van S', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Vo Thi T', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1),--
(N'Truong Van U', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Doan Thi V', N'Nữ', N'Y tá', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Vo Thi T', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Truong Van U', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Doan Thi V', N'Nữ', N'Y tá', N'Kinh', N'Phật giáo', N'Còn sống', -1),--31
(N'Bui Van X', N'Nam', N'Công nhân', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Ho Thi Y', N'Nữ', N'Bác sĩ', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Nguyen Van Z', N'Nam', N'Giáo viên', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Tran Thi AA', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Le Van BB', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),--
(N'Hoang Van DD', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Vo Thi EE', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Truong Van FF', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Doan Thi GG', N'Nữ', N'Y tá', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Bui Van HH', N'Nam', N'Công nhân', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),--41
(N'Ho Thi II', N'Nữ', N'Bác sĩ', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Tran Thi KK', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Le Van LL', N'Nam', N'Kỹ sư', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Pham Thi MM', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Hoang Van NN', N'Nam', N'Giáo viên', N'Kinh', N'Hồi giáo', N'Còn sống', -1),--46
(N'Vo Thi OO', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Truong Van PP', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Doan Thi QQ', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Bui Van RR', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Ho Thi SS', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1),--
(N'Nguyen Van TT', N'Nam', N'Giáo viên', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Tran Thi UU', N'Nữ', N'Y tá', N'Kinh', N'Công giáo', N'Còn sống', -1),
(N'Le Van VV', N'Nam', N'Nhân viên văn phòng', N'Kinh', N'Không tôn giáo', N'Còn sống', -1),
(N'Pham Thi WW', N'Nữ', N'Công nhân', N'Kinh', N'Phật giáo', N'Còn sống', -1),
(N'Hoang Van XX', N'Nam', N'Kỹ sư', N'Kinh', N'Hồi giáo', N'Còn sống', -1),
(N'Vo Thi YY', N'Nữ', N'Bác sĩ', N'Kinh', N'Công giáo', N'Còn sống', -1);


INSERT INTO Accounts (MaCD, MatKhau, PhanQuyen)
VALUES 
(1, '12345', 1), 
(2, '12345', 0),
(3, '12345', 0),
(4, '12345', 0),
(5, '12345', 0),
(6, '12345', 0),
(7, '12345', 0),
(8, '12345', 0),
(9, '12345', 0),
(10, '12345', 0),
(11, '12345', 1), 
(12, '12345', 0),
(13, '12345', 0),
(14, '12345', 0),
(15, '12345', 0),
(16, '12345', 0),
(17, '12345', 0),
(18, '12345', 0),
(19, '12345', 0),
(20, '12345', 0),
(21, '12345', 1), 
(22, '12345', 0),
(23, '12345', 0),
(24, '12345', 0),
(25, '12345', 0),
(26, '12345', 0),
(27, '12345', 0),
(28, '12345', 0),
(29, '12345', 0),
(30, '12345', 0),
(31, '12345', 1), 
(32, '12345', 0),
(33, '12345', 0),
(34, '12345', 0),
(35, '12345', 0),
(36, '12345', 0),
(37, '12345', 0),
(38, '12345', 0),
(39, '12345', 0),
(40, '12345', 0),
(41, '12345', 1), 
(42, '12345', 0),
(43, '12345', 0),
(44, '12345', 0),
(45, '12345', 0),
(46, '12345', 0),
(47, '12345', 0),
(48, '12345', 0),
(49, '12345', 0),
(50, '12345', 0),
(51, '12345', 1), 
(52, '12345', 0),
(53, '12345', 0),
(54, '12345', 0),
(55, '12345', 0),
(56, '12345', 0),
(57, '12345', 0);




INSERT INTO Births (MaCD, NgaySinh, NoiSinh, MaCD_Cha, MaCD_Me, NgayKhai)
VALUES
(1, '2000-01-01', 'Ha Noi', 1, 1, '2023-04-10'),
(2, '2002-05-15', 'Hai Phong', 2, 2, '2023-04-10'),
(3, '1995-12-31', 'TP HCM', 1, 2, '2023-04-10'),
(4, '1980-07-21', 'Da Nang', 1, 2, '2023-04-10'),
(5, '1985-03-11', 'Hue', 1, 2, '2023-04-10'),
(6, '1990-11-30', 'Quang Ngai', 6,6, '2023-04-10'),
(7, '1988-04-05', 'Ninh Binh', 7, 7, '2023-04-10'),
(8, '1982-12-25', 'Thai Nguyen', 6, 7, '2023-04-10'),
(9, '1983-06-17', 'Bac Ninh', 6, 7, '2023-04-10'),
(10, '2001-09-03', 'Can Tho', 6, 7, '2023-04-10'),
(11, '1998-11-20', N'Hà Nội', 6, 7, '2023-04-10'),
(12, '2005-07-08', N'Hải Phòng', 11, 11, '2023-04-10'),
(13, '1993-03-17', N'TP Hồ Chí Minh', 12, 13, '2023-04-10'),
(14, '1982-09-05', N'Đà Nẵng', 14, 15, '2023-04-10'),
(15, '1991-01-25', N'Huế', 15, 16, '2023-04-10'),
(16, '1996-12-02', N'Quảng Ngãi', 17, 18, '2023-04-10'),
(17, '1994-05-28', N'Ninh Bình', 19, 19, '2023-04-10'),
(18, '1988-10-15', N'Thái Nguyên', 20, 21, '2023-04-10'),
(19, '1990-06-12', N'Bắc Ninh', 21, 21, '2023-04-10'),
(20, '2004-04-30', N'Cần Thơ', 22, 23, '2023-04-10'),
(21, '1997-08-18', N'Hà Nội', 24, 24, '2023-04-10'),
(22, '2003-03-11', N'Hải Phòng', 25, 25, '2023-04-10'),
(23, '1992-01-05', N'TP Hồ Chí Minh', 26, 27, '2023-04-10'),
(24, '1985-09-27', N'Đà Nẵng', 28, 29, '2023-04-10'),
(25, '1993-04-15', N'Huế', 29, 30, '2023-04-10'),
(26, '1999-12-12', N'Quảng Ngãi', 31, 32, '2023-04-10'),
(27, '1998-06-07', N'Ninh Bình', 33, 33, '2023-04-10'),
(28, '2002-02-28', N'Thái Nguyên', 34, 35, '2023-04-10'),
(29, '2003-07-15', N'Bắc Ninh', 36, 36, '2023-04-10'),
(30, '1999-11-05', N'Thái Bình', 37, 38, '2023-04-10'),
(31, '2001-03-12', N'Nam Định', 39, 39, '2023-04-10'),
(32, '1997-09-21', N'Hà Nam', 40, 41, '2023-04-10'),
(33, '1992-12-30', N'Nghệ An', 42, 43, '2023-04-10'),
(34, '1994-08-08', N'Hà Tĩnh', 44, 44, '2023-04-10'),
(35, '2004-01-10', N'Quảng Bình', 45, 46, '2023-04-10'),
(36, '2000-06-18', N'Quảng Trị', 47, 47, '2023-04-10'),
(37, '1998-02-25', N'Thừa Thiên Huế', 48, 49, '2023-04-10'),
(38, '2005-04-05', N'Đà Nẵng', 50, 51, '2023-04-10'),
(39, '1996-10-22', N'Quảng Nam', 52, 52, '2023-04-10'),
(40, '1993-05-07', N'Quảng Ngãi', 53, 54, '2023-04-10'),
(41, '1991-01-15', N'Bình Định', 41, 41, '2023-04-10'),
(42, '1990-07-29', N'Phú Yên', 42, 42, '2023-04-10'),
(43, '1997-08-08', N'Khánh Hòa', 41, 42, '2023-04-10'),
(44, '2003-01-15', N'Lâm Đồng', 41, 42, '2023-04-10'),
(45, '2005-05-20', N'Bình Thuận', 41, 42, '2023-04-10'),
(46, '1999-10-03', N'Ninh Thuận', 46, 46, '2023-04-10'),
(47, '1996-06-12', N'Tây Ninh', 47, 47, '2023-04-10'),
(48, '1994-03-18', N'Bình Dương', 46, 47, '2023-04-10'),
(49, '2002-12-25', N'Bình Phước', 46, 47, '2023-04-10'),
(50, '2001-07-01', N'Đồng Nai', 46, 47, '2023-04-10'),
(51, '1993-09-05', N'Long An', 51, 51, '2023-04-10'),
(52, '1991-11-10', N'Tiền Giang', 52, 52, '2023-04-10'),
(53, '2000-02-17', N'Vĩnh Long', 51, 52, '2023-04-10'),
(54, '1998-04-23', N'Đồng Tháp', 51, 52, '2023-04-10'),
(55, '1995-12-30', N'An Giang', 51, 52, '2023-04-10'),
(56, '1992-10-07', N'Kiên Giang', 51, 52, '2023-04-10'),
(57, '2004-06-25', N'Cần Thơ', 51, 52, '2023-04-10');



INSERT INTO Users_Deleted (MaCD, NguoiKhai, NguyenNhan, NgayTu, NgayKhai, NgayDuyet)
VALUES
(23, 23, N'Đột quỵ', '2023-01-01', '2023-05-12', NULL),
(25, 25, N'Tai nạn', '2023-02-01', '2023-05-12', NULL),
(27, 25, N'Tự tử', '2023-03-01', '2023-05-12', NULL),
(45, 45, N'Bệnh hiểm nghèo', '2023-04-01', '2023-05-12', NULL),
(12, 12, N'Ung thư', '2023-05-01', '2023-05-12', NULL),
(6, 6, N'Tai nạn giao thông', '2023-05-01', '2023-05-12', NULL),
(24, 24, N'Tự tử', '2023-05-01', '2023-05-12', NULL),
(7, 7, N'Ung thư', '2023-05-01', '2023-05-12', NULL),
(8, 8, N'Tai nạn giao thông', '2023-05-01', '2023-05-12', NULL),
(15, 15, N'Uống lộn thuốc', '2023-05-01', '2023-05-12', NULL),
(3, 3, N'Ung thư', '2022-03-15', GETDATE(), '2022-05-12'),
(5, 5, N'Tai nạn giao thông', '2022-04-20', GETDATE(), '2022-05-12');

INSERT INTO Households (ChuHo, TinhThanh, QuanHuyen, PhuongXa, NgayDangKy, TrangThai)
VALUES
(1, N'Hà Nội', N'Ba Đình', N'Trúc Bạch', '2023-04-10', N'Chưa duyệt'),
(6, N'Hà Nội', N'Cầu Giấy', N'Quan Hoa', '2023-04-10', N'Chưa duyệt'),
(11, N'Hà Nội', N'Hoàng Mai', N'Vĩnh Tuy', '2023-04-10', N'Chưa duyệt'),
(16, N'Hồ Chí Minh', N'Quận 1', N'Bến Nghé', '2023-04-10', N'Chưa duyệt'),
(21, N'Hồ Chí Minh', N'Quận 2', N'An Phú', '2023-04-10', N'Chưa duyệt'),
(26, N'Hồ Chí Minh', N'Quận 3', N'Phường 7', '2023-04-10', N'Chưa duyệt'),
(31, N'Da Nang', N'Quận Sơn Trà', N'Phường Mỹ An', '2023-04-10', N'Chưa duyệt'),
(36, N'Da Nang', N'Quận Hải Châu', N'Phường Thanh Bình', '2023-04-10', N'Chưa duyệt'),
(41, N'Nghệ An', N'Huyện Quỳnh Lưu', N'Xã Quỳnh Đôi', '2023-04-10', N'Chưa duyệt'),
(46, N'Bình Dương', N'Thủ Dầu Một', N'Phường Phú Hòa', '2023-04-10', N'Chưa duyệt');

INSERT INTO Detail_Households (MaHo, MaCD, TinhTrangCuTru, QuanHeVoiChuHo, NgayDangKy, TrangThai)
VALUES
    (1, 1, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (1, 2, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (1, 3, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (1, 4, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (1, 5, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    
    (2, 6, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (2, 7, N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    (2, 8, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (2, 9, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (2, 10, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    (3, 11, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (3, 12, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (3, 13, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (3, 14, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (3, 15, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    (4, 16, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (4, 17, N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    (4, 18, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (4, 19, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (4, 20, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(5, 21, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (5, 22, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (5, 23, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (5, 24, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (5, 25, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(6, 26, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (6, 27, N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    (6, 28, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (6, 29, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (6, 30, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

    (7, 31, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (7, 32, N'Thường trú', N'Chồng', '2023-04-10', N'Chưa duyệt'),
    (7, 33, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (7, 34, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (7, 35, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(8, 36, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
	(8, 37, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (8, 38, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (8, 39, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (8, 40, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(9, 41, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (9, 42, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (9, 43, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (9, 44, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (9, 45, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(10, 46, N'Thường trú', N'Chủ hộ', '2023-04-10', N'Chưa duyệt'),
    (10, 47, N'Thường trú', N'Vợ', '2023-04-10', N'Chưa duyệt'),
    (10, 48, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (10, 49, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (10, 50, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),

	(1, 51, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (2, 52, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (3, 53, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (4, 54, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (5, 55, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
	(6, 56, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt'),
    (7, 57, N'Thường trú', N'Con', '2023-04-10', N'Chưa duyệt');

INSERT INTO People_Marriage (MaCDChong, MaCDVo, Loai, NgayDangKy, XacNhanLan1, XacNhanLan2, TrangThai)
VALUES
(1, 2, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(7, 6, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(11, 12, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(17, 16, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(21, 22, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(27, 26, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(32, 31, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(36, 37, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(42, 41, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'),
(47, 46, N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt');

--certificates mails temporary-absent temporary-staying

INSERT INTO Certificates (MaCD, MaCCCD, QuocTich, QueQuan, NoiThuongTru, HanSuDung, DacDiemNhanDang, Avatar)
VALUES
    (1, 'CCCD001', N'Việt Nam', N'Kon Tum', N'Đắk Hà', N'2033-01-01', N'Không', 'image1.jpg'),
	(2, 'CCCD002', N'Việt Nam', N'Đà Nẵng', N'Hải Châu', N'2034-01-01', N'Không', 'image2.jpg'),
    (3, 'CCCD003', N'Việt Nam', N'Hà Nội', N'Cầu Giấy', N'2035-01-01', N'Không', 'image3.jpg'),
    (4, 'CCCD004', N'Việt Nam', N'Hồ Chí Minh', N'Quận 1', N'2036-01-01', N'Không', 'image4.jpg'),
    (5, 'CCCD005', N'Việt Nam', N'Đồng Nai', N'Biên Hòa', N'2037-01-01', N'Không', 'image5.jpg'),
    (6, 'CCCD006', N'Việt Nam', N'Bình Dương', N'Thủ Dầu Một', N'2038-01-01', N'Không', 'image6.jpg'),
    (7, 'CCCD007', N'Việt Nam', N'Nghệ An', N'Vinh', N'2039-01-01', N'Không', 'image7.jpg'),
    (8, 'CCCD008', N'Việt Nam', N'Hải Phòng', N'Hồng Bàng', N'2040-01-01', N'Không', 'image8.jpg'),
    (9, 'CCCD009', N'Việt Nam', N'Khánh Hòa', N'Nha Trang', N'2041-01-01', N'Không', 'image9.jpg'),
    (10, 'CCCD010', N'Việt Nam', N'Bà Rịa - Vũng Tàu', N'Vũng Tàu', N'2042-01-01', N'Không', 'image10.jpg'),
    (11, 'CCCD011', N'Việt Nam', N'Quảng Ngãi', N'Quảng Ngãi', N'2043-01-01', N'Không', 'image11.jpg'),
    (12, 'CCCD012', N'Việt Nam', N'Đắk Lắk', N'Buôn Ma Thuột', N'2044-01-01', N'Không', 'image12.jpg'),
    (13, 'CCCD013', N'Việt Nam', N'Lâm Đồng', N'Đà Lạt', N'2045-01-01', N'Không', 'image13.jpg').
	(14, 'CCCD014', N'Việt Nam', N'Thừa Thiên Huế', N'Huế', N'2046-01-01', N'Không', 'image14.jpg'),
    (15, 'CCCD015', N'Việt Nam', N'Hà Tĩnh', N'Hà Tĩnh', N'2047-01-01', N'Không', 'image15.jpg'),
    (16, 'CCCD016', N'Việt Nam', N'Thanh Hóa', N'Thanh Hóa', N'2048-01-01', N'Không', 'image16.jpg'),
    (17, 'CCCD017', N'Việt Nam', N'Nam Định', N'Nam Định', N'2049-01-01', N'Không', 'image17.jpg'),
    (18, 'CCCD018', N'Việt Nam', N'Bắc Ninh', N'Bắc Ninh', N'2050-01-01', N'Không', 'image18.jpg'),
    (19, 'CCCD019', N'Việt Nam', N'Phú Thọ', N'Việt Trì', N'2051-01-01', N'Không', 'image19.jpg'),
    (20, 'CCCD020', N'Việt Nam', N'Bắc Giang', N'Bắc Giang', N'2052-01-01', N'Không', 'image20.jpg'),
    (21, 'CCCD021', N'Việt Nam', N'Hòa Bình', N'Hòa Bình', N'2053-01-01', N'Không', 'image21.jpg'),
    (22, 'CCCD022', N'Việt Nam', N'Hưng Yên', N'Hưng Yên', N'2054-01-01', N'Không', 'image22.jpg'),
    (23, 'CCCD023', N'Việt Nam', N'Hà Nam', N'Phủ Lý', N'2055-01-01', N'Không', 'image23.jpg'),
    (24, 'CCCD024', N'Việt Nam', N'Thái Bình', N'Thái Bình', N'2056-01-01', N'Không', 'image24.jpg'),
    (25, 'CCCD025', N'Việt Nam', N'Hải Dương', N'Hải Dương', N'2057-01-01', N'Không', 'image25.jpg'),
    (26, 'CCCD026', N'Việt Nam', N'Hải Dương', N'Chí Linh', N'2058-01-01', N'Không', 'image26.jpg'),
    (27, 'CCCD027', N'Việt Nam', N'Quảng Ninh', N'Hạ Long', N'2059-01-01', N'Không', 'image27.jpg');


INSERT INTO Mails (TieuDe, Ngay, NguoiGui, NguoiNhan, NoiDung)
VALUES
    (N'Mail 1', '2022-01-01', 1, 2, N'Nội dung mail 1'),
    (N'Mail 2', '2022-02-05', 1, 4, N'Nội dung mail 2'),
    (N'Mail 3', '2022-03-10', 1, 6, N'Nội dung mail 3'),
    (N'Mail 4', '2022-04-15', 1, 8, N'Nội dung mail 4'),
    (N'Mail 5', '2022-05-20', 1, 10, N'Nội dung mail 5'),
    (N'Mail 6', '2022-06-25', 1, 12, N'Nội dung mail 6'),
    (N'Mail 7', '2022-07-30', 1, 14, N'Nội dung mail 7'),
    (N'Mail 8', '2022-08-04', 1, 16, N'Nội dung mail 8'),
    (N'Mail 9', '2022-09-09', 1, 18, N'Nội dung mail 9'),
    (N'Mail 10', '2022-10-14', 1, 20, N'Nội dung mail 10'),
    (N'Mail 11', '2022-11-19', 1, 22, N'Nội dung mail 11'),
    (N'Mail 12', '2022-12-24', 1, 24, N'Nội dung mail 12'),
    (N'Mail 13', '2023-01-29', 1, 26, N'Nội dung mail 13'),
    (N'Mail 14', '2023-03-05', 1, 28, N'Nội dung mail 14'),
    (N'Mail 15', '2023-04-10', 1, 30, N'Nội dung mail 15'),
    (N'Mail 16', '2023-05-15', 1, 32, N'Nội dung mail 16'),
    (N'Mail 17', '2023-06-20', 1, 34, N'Nội dung mail 17'),
    (N'Mail 18', '2023-07-25', 1, 36, N'Nội dung mail 18'),
    (N'Mail 19', '2023-08-30', 1, 38, N'Nội dung mail 19'),
    (N'Mail 20', '2023-10-04', 1, 40, N'Nội dung mail 20'),
	(N'Mail 21', '2023-10-09', 2, 1, N'Nội dung mail 21'),
    (N'Mail 22', '2023-09-04', 4, 1, N'Nội dung mail 22'),
    (N'Mail 23', '2023-08-01', 6, 1, N'Nội dung mail 23'),
    (N'Mail 24', '2023-07-01', 8, 1, N'Nội dung mail 24'),
    (N'Mail 25', '2023-06-05', 10, 1, N'Nội dung mail 25'),
    (N'Mail 26', '2023-05-08', 12, 1, N'Nội dung mail 26'),
    (N'Mail 27', '2023-04-02', 14, 1, N'Nội dung mail 27'),
    (N'Mail 28', '2023-03-01', 16, 1, N'Nội dung mail 28'),
    (N'Mail 29', '2023-02-02', 18, 1, N'Nội dung mail 29'),
    (N'Mail 30', '2023-01-06', 20, 1, N'Nội dung mail 30'),
    (N'Mail 31', '2022-12-10', 22, 1, N'Nội dung mail 31'),
    (N'Mail 32', '2022-11-14', 24, 1, N'Nội dung mail 32'),
    (N'Mail 33', '2022-10-19', 26, 1, N'Nội dung mail 33'),
    (N'Mail 34', '2022-09-23', 28, 1, N'Nội dung mail 34'),
    (N'Mail 35', '2022-08-27', 30, 1, N'Nội dung mail 35'),
    (N'Mail 36', '2022-07-31', 32, 1, N'Nội dung mail 36'),
    (N'Mail 37', '2022-07-03', 34, 1, N'Nội dung mail 37'),
    (N'Mail 38', '2022-06-05', 36, 1, N'Nội dung mail 38'),
    (N'Mail 39', '2022-05-09', 38, 1, N'Nội dung mail 39'),
    (N'Mail 40', '2022-04-13', 40, 1, N'Nội dung mail 40');

INSERT INTO Temporarily_Absent (MaCD, MaCCCD, Tinh, Huyen, Xa, LyDo, thoi_gian_bat_dau, thoi_gian_ket_thuc)
VALUES
  (1, 'CCCD001', N'Kon Tum', N'Đắk Hà', N'Hà Mòn', N'Học', '2023-05-01', '2023-05-07'),
  (2, 'CCCD002', N'Bình Thuận', N'Hàm Thuận Bắc', N'Phước Bình', N'Công tác', '2023-05-02', '2023-05-08'),
  (3, 'CCCD003', N'Tiền Giang', N'Cái Bè', N'Mỹ Thanh', N'Đi công việc', '2023-05-03', '2023-05-09'),
  (4, 'CCCD004', N'Quảng Bình', N'Đồng Hới', N'Đức Ninh', N'Du lịch', '2023-05-04', '2023-05-10'),
  (5, 'CCCD005', N'Hải Phòng', N'Hồng Bàng', N'Hà Khẩu', N'Công tác', '2023-05-05', '2023-05-11'),
  (6, 'CCCD006', N'Đồng Nai', N'Tân Phú', N'Tân Hòa', N'Học', '2023-05-06', '2023-05-12'),
  (7, 'CCCD007', N'Lâm Đồng', N'Đà Lạt', N'Liên Nghĩa', N'Du lịch', '2023-05-07', '2023-05-13'),
  (8, 'CCCD008', N'Ninh Bình', N'Tam Điệp', N'Yên Mạc', N'Đi công việc', '2023-05-08', '2023-05-14'),
  (9, 'CCCD009', N'Hà Tĩnh', N'Kỳ Anh', N'Kỳ Long', N'Du lịch', '2023-05-09', '2023-05-15'),
  (10, 'CCCD010', N'Đắk Lắk', N'Buôn Ma Thuột', N'Ea Kao', N'Công tác', '2023-05-10', '2023-05-16');

INSERT INTO Temporarily_Staying (MaCD, MaCCCD, Tinh, Huyen, Xa, LyDo, thoi_gian_bat_dau)
VALUES
  (11, 'CCCD011', N'Kon Tum', N'Đắk Hà', N'Hà Mòn', N'Học', '2023-05-01'),
  (12, 'CCCD012', N'Bình Thuận', N'Hàm Thuận Bắc', N'Phước Bình', N'Công tác', '2023-05-02'),
  (13, 'CCCD013', N'Tiền Giang', N'Cái Bè', N'Mỹ Thanh', N'Đi công việc', '2023-05-03'),
  (14, 'CCCD014', N'Quảng Bình', N'Đồng Hới', N'Đức Ninh', N'Du lịch', '2023-05-04'),
  (15, 'CCCD015', N'Hải Phòng', N'Hồng Bàng', N'Hà Khẩu', N'Công tác', '2023-05-05'),
  (16, 'CCCD016', N'Đồng Nai', N'Tân Phú', N'Tân Hòa', N'Học', '2023-05-06'),
  (17, 'CCCD017', N'Lâm Đồng', N'Đà Lạt', N'Liên Nghĩa', N'Du lịch', '2023-05-07'),
  (18, 'CCCD018', N'Ninh Bình', N'Tam Điệp', N'Yên Mạc', N'Đi công việc', '2023-05-08'),
  (19, 'CCCD019', N'Hà Tĩnh', N'Kỳ Anh', N'Kỳ Long', N'Du lịch', '2023-05-09'),
  (20, 'CCCD020', N'Đắk Lắk', N'Buôn Ma Thuột', N'Ea Kao', N'Công tác', '2023-05-10');

SELECT *
FROM MAILBOX