CREATE OR ALTER FUNCTION [dbo].[Fn_CongDanHetHanSuDung]()
RETURNS @SapHetHan TABLE (ID int,MaCCCD nvarchar(12),MaCD varchar(10),QuocTich nvarchar(max),QueQuan nvarchar(max),NoiThuongTru nvarchar(max),HanSuDung nvarchar(max),DacDiemNhanDang nvarchar(max),Anh image)
AS
BEGIN
	INSERT INTO @SapHetHan(ID,MaCCCD,MaCD,QuocTich,QueQuan,NoiThuongTru,HanSuDung,DacDiemNhanDang,Anh)
	SELECT *
	FROM Certificates
	WHERE HanSuDung <= GETDATE();
	return 
END