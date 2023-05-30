﻿-- Contraint

--  Ngày sinh không được lớn hơn ngày hiện tại(Công)(Births)

ALTER TABLE Births 
ADD CONSTRAINT check_ngaysinhhople CHECK(NgaySinh<GETDATE())

-- Trạng thái chỉ có 2 trạng thái “duyet” và “chua duyet” (Công)(Households)
--USE Backup_CityzenManagement
GO
ALTER TABLE Households 
ADD CONSTRAINT check_trangthai_Households CHECK(TrangThai IN('duyet', 'chua duyet'))

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
		print 'tuoi cua cong dan phai du 16'
	end
END

GO
-- Giới tính của vợ phải là nữ, giới tính của chồng phải là nam(insert,update)(Công)(People_Marriage)
CREATE TRIGGER [dbo].[trg_CheckGenderVoChong]
ON People_Marriage
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @GIOTINHCHONG NVARCHAR(MAX)
	DECLARE @GIOITINHVO NVARCHAR(MAX)
	SELECT @GIOTINHCHONG=CH.GioiTinh,@GIOITINHVO=CH.GioiTinh	 
	FROM Citizens CH,Citizens VO, People_Marriage HN
	WHERE HN.MaCDChong=CH.MaCD AND HN.MaCDVo=VO.MaCD
	IF (@GIOITINHVO !='Nữ' OR  @GIOTINHCHONG !='Nam')
	BEGIN
	ROLLBACK TRAN 
	PRINT'gioi tinh chong phai la nam, gioi tinh vo la nu'
	END
END
 



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


GO
CREATE TRIGGER [dbo].[trg_CheckAlive]
ON Users_Deleted
after INSERT 
AS 
BEGIN
	IF( (SELECT COUNT(*) AS RESULTCOUNT 
	FROM Users_Deleted ud,Citizens ci 
	where ud.MaCD=ci.MaCD)=0) 
	begin
		rollback tran
		print ' cong dan phai co trong Cirizens moi them vao User_deleted '
	end
END; 

-- Procedure 

--Đưa ra thông tin chi tiết của công dân ở bảng Citizens, Houserholds, Births(Công)(citizens)


GO
CREATE OR ALTER PROC [dbo].[spud_thongtinCongDan]
AS
BEGIN
	SELECT ci.MaCD,ci.HoTen,ci.GioiTinh,ci.NgheNghiep,ci.DanToc,ci.TonGiao,ci.TinhTrang,ci.TinhTrang, ci.MaHN,ci.MaHoKhau,
	bi.NgaySinh,bi.NgaySinh,bi.NoiSinh,bi.MaCD_Cha,bi.MaCD_Me,bi.MaCD_Cha,bi.MaCD_Me,bi.NgayKhai,bi.NgayDuyet,
	ho.ChuHo,ho.TinhThanh,ho.QuanHuyen,ho.PhuongXa,ho.NgayDangKy,ho.TrangThai
	FROM Citizens ci,Households ho,Births bi
	WHERE ci.MaCD=bi.MaCD AND ho.MaHo=ci.MaHoKhau
END

-- Thủ tục xuất ra danh sách công dân tạm chú ở khu vực (tham số:thành phố, huyện, xã )
-- mà chưa được duyệt(Công)(Temporarily_Staying)
GO
CREATE OR ALTER PROC [dbo].[spud_CongDanTamChu_ChuaDuyet](@Tinh nvarchar(max),@huyen nvarchar(max),@xa nvarchar(max))
AS
BEGIN
	SELECT *
	FROM Temporarily_Staying
	WHERE TrangThai='chua duyet'
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

-- Liệt kê những công dân có hạn sử dụng năm nay, 
-- hoặc năm sau đi thay thế cccd.(Công)(Certificates)
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