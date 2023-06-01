CREATE OR ALTER FUNCTION [dbo].[Fn_CongDanHetHanSuDung]()
RETURNS @SapHetHan TABLE (ID int,MaCCCD nvarchar(12),MaCD varchar(10),QuocTich nvarchar(max),QueQuan nvarchar(max),NoiThuongTru nvarchar(max),HanSuDung nvarchar(max),DacDiemNhanDang nvarchar(max))
AS
BEGIN
	INSERT INTO @SapHetHan(ID,MaCCCD,MaCD,QuocTich,QueQuan,NoiThuongTru,HanSuDung,DacDiemNhanDang)
	SELECT ID,MaCCCD,MaCD,QuocTich,QueQuan,NoiThuongTru,HanSuDung,DacDiemNhanDang
	FROM Certificates
	WHERE HanSuDung <= GETDATE();
	return 
END