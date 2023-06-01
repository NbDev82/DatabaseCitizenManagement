-- Addition

-- Citizens vs People_Marriage

-- View

-- View People_Marriage
go
CREATE VIEW [dbo].[V_GetPeopleMarriage]
AS
Select *
from People_Marriage

--select * from V_GetPeopleMarriage
go
-- View Citizen Nam mà chưa kết hôn
CREATE VIEW [dbo].[V_MaleNotFamily]
AS
SELECT *
FROM Citizens ci
WHERE ci.GioiTinh=N'Nam' AND ci.MaCD NOT IN(SELECT MaCDChong
					 FROM People_Marriage);
--select * from V_MaleNotFamily
-- View Citizen nữ mà chưa kết hôn
CREATE VIEW [dbo].[V_FemaleNotFamily]
AS
Select *
from Citizens ci
Where ci.GioiTinh=N'Nữ' AND ci.MaCD NOT IN (Select MaCDVo
											FROM People_Marriage);
--select * from [V_FemaleNotFamily]

-- VIEW danh sách các gia đình chưa duyệt
go
CREATE VIEW [dbo].[V_DataFmailyNotBrowse]
AS
	SELECT *
	FROM People_Marriage 
	WHERE TrangThai= N'Chưa duyệt'
--Select * from V_DataFmailyNotBrowse

-- View danh sách các cặp đôi đăng ký kết hôn nhưng chưa xác nhận 
go
CREATE VIEW [dbo].[V_DataFmailyNotConfirm]
AS
SELECT *
FROM People_Marriage pm
WHERE (pm.XacNhanLan1 IS NULL OR pm.XacNhanLan2 IS NULL) OR (pm.XacNhanLan1 IS NULL AND pm.XacNhanLan2 IS NULL)
--select * from dbo.V_DataFmailyNotConfirm

--- Function ---
-- 
go
-- Hàm trả về ngay sinh cua 1 nguoi thong qua ID
CREATE OR ALTER FUNCTION [dbo].[FN_DataBirthByID](@macd varchar(10))
RETURNS TABLE
AS
	RETURN( SELECT *
			FROM Births
			WHERE MaCD=@macd
	);
--select * from FN_DataBirthByID('CD0002')
-- Hàm  tìm kiếm 1 gia đình thông qua mã hôn nhân 
CREATE OR ALTER FUNCTION [dbo].[FN_DataFindFamily](@mahn varchar(10))
RETURNS TABLE 
AS 
	RETURN (SELECT *
			FROM People_Marriage pm
			WHERE pm.MaHN=@mahn);


--Hàm trả về danh sách các cặp đôi trong khoảng thời gian
go 
Create OR ALTER FUNCTION [dbo].[FN_DataFmailyInTime](@months_to_substract INT)
RETURNS TABLE
AS
	RETURN( SELECT *
			FROM People_Marriage pm
			WHERE pm.NgayDangKy>=DATEADD(MONTH,-@months_to_substract,GETDATE())
	);
--select * from dbo.FN_DataFmailyInTime(2)
go 

--- PROCEDURE ---
-- xay dung 1 gia dinh 
go
CREATE OR ALTER PROCEDURE [dbo].[PROC_RegisterMarriage](@mahn varchar(10),@macdchong varchar(10),@macdvo varchar(10),@loai nvarchar(255),@ngaydangnhap date,@xacnhan1 varchar(10),@xacnhan2 varchar(10),@trangthai nvarchar(255))
AS
BEGIN
	INSERT INTO People_Marriage(MaHN,MaCDChong,MaCDVo,Loai,NgayDangKy,XacNhanLan1,XacNhanLan2,TrangThai)
	VALUES(@mahn,@macdchong,@macdvo,@loai,@ngaydangnhap,@xacnhan1,@xacnhan2,@trangthai)
END
--EXEC PROC_RegisterMarriage 'HN0001', 'CD0001', 'CD0002', N'Kết hôn', '2023-04-10', NULL, NULL, N'Chưa duyệt'
--EXEC PROC_RegisterMarriage 'HN0011', 'CD0003', 'CD0004', N'Kết hôn', '6/1/2023 8:10:02 AM', '', '', N'Chưa duyệt'
select * from V_GetPeopleMarriage

--DROP PROCEDURE PROC_RegisterMarriage
go
-- Ly hon
CREATE OR ALTER PROCEDURE [dbo].[PROC_DivorceMarriage](@mahn varchar(10))
AS
BEGIN
	DELETE FROM People_Marriage WHERE MaHN=@mahn 
END
--EXEC PROC_DivorceMarriage 'HN0001'
--DROP PROC PROC_DivorceMarriage

-- Thu tục Update Xac nhan 2 vo chong
go
CREATE OR ALTER PROCEDURE [dbo].[PROC_UPDATEMarriage](@mahn varchar(10),@xacnhan1 varchar(10), @xacnhan2 varchar(10))
AS
BEGIN
	UPDATE People_Marriage SET XacNhanLan1=@xacnhan1,XacNhanLan2=@xacnhan2 WHERE MaHN=@mahn
END
--EXEC PROC_UPDATEMarriage 'HN0001','CD0001', 'CD0002'

--DROP PROC PROC_UPDATEMarriage
--SS

-- Thủ tục xác duyệt gia đình 
go
CREATE OR ALTER PROCEDURE [dbo].[PROC_BROWSEMarriage](@mahn varchar(10),@Trangthai nvarchar(255))
AS
BEGIN
	UPDATE People_Marriage SET TrangThai=@Trangthai WHERE MaHN=@mahn
END
--EXEC PROC_BROWSEMarriage 'HN0003',N'Duyệt'


-- Briths and Users_Deleted

--VIEW
go
CREATE VIEW [dbo].[V_GetBriths]
AS 
SELECT *
FROM Births
--select * from V_GetBriths
-- 
go
CREATE VIEW [dbo].[V_UserDeleted]
AS 
SELECT *
FROM Users_Deleted
--select * from V_UserDeleted
-- Function

CREATE FUNCTION dbo.Fn_CountBirthsInYear(@year int)
RETURNS TABLE
AS
    return (SELECT *
    FROM Births
    WHERE YEAR(NgaySinh) = @year);













