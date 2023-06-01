USE CityzenManagement

/*CREATE LOGIN manager WITH PASSWORD = 'manager';
CREATE USER manager FOR LOGIN manager;*/

ALTER AUTHORIZATION ON DATABASE::CityzenManagement TO manager;


CREATE LOGIN households_manager WITH PASSWORD = 'manager';
CREATE USER households_manager FOR LOGIN households_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Households to households_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON Detail_Households to households_manager
GRANT SELECT ON view_HouseholdMembersInfo to households_manager
GRANT SELECT ON View_HouseholdsByMaHo to households_manager
GRANT SELECT ON View_Citizens to households_manager
GRANT SELECT ON View_Births to households_manager
GRANT EXECUTE ON func_GenerateMaHo to households_manager
GRANT EXECUTE ON proc_InsertDetailHousehold to households_manager
GRANT EXECUTE ON proc_DeleteDetailHousehold to households_manager
GRANT EXECUTE ON proc_InsertHousehold to households_manager
GRANT EXECUTE ON proc_InsertDetailHousehold to households_manager









CREATE LOGIN users WITH PASSWORD = 'user';
CREATE USER users FOR LOGIN users;





CREATE LOGIN certificates_manager WITH PASSWORD = 'manager';
CREATE USER certificates_manager FOR LOGIN certificates_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Certificates to certificates_manager
GRANT SELECT ON V_GetCertificates to certificates_manager
GRANT SELECT ON FN_GetCertificates to certificates_manager
GRANT SELECT ON FN_GetDataUser to certificates_manager
GRANT SELECT ON dbo.GetCitizensByProvince to certificates_manager
GRANT SELECT ON Citizens_Without_Certificates to certificates_manager
GRANT EXECUTE ON PROC_RegisterCertificate to certificates_manager
GRANT SELECT ON [Fn_CongDanHetHanSuDung] to certificates_manager
GRANT SELECT ON [Fn_CongDanSapHetHanSuDung] to certificates_manager





CREATE LOGIN births_manager WITH PASSWORD = 'manager';
CREATE USER births_manager FOR LOGIN births_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Births to births_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON Users_Deleted to births_manager


CREATE LOGIN people_marriage_manager WITH PASSWORD = 'manager';
CREATE USER people_marriage_manager FOR LOGIN people_marriage_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON People_Marriage to people_marriage_manager
GRANT SELECT ON [V_GetPeopleMarriage] to people_marriage_manager
GRANT SELECT ON [V_MaleNotFamily] to people_marriage_manager
GRANT SELECT ON [V_FemaleNotFamily] to people_marriage_manager
GRANT SELECT ON [V_DataFmailyNotBrowse] to people_marriage_manager
GRANT SELECT ON [V_DataFmailyNotConfirm] to people_marriage_manager
GRANT SELECT ON [FN_DataBirthByID] to people_marriage_manager
GRANT SELECT ON [FN_DataFindFamily] to people_marriage_manager
GRANT SELECT ON [FN_DataFmailyInTime] to people_marriage_manager
GRANT EXECUTE ON [PROC_RegisterMarriage] to people_marriage_manager
GRANT EXECUTE ON [PROC_DivorceMarriage] to people_marriage_manager
GRANT EXECUTE ON [PROC_UPDATEMarriage] to people_marriage_manager
GRANT EXECUTE ON [PROC_BROWSEMarriage] to people_marriage_manager
GRANT SELECT ON [V_GetBriths] to people_marriage_manager
GRANT SELECT ON [V_UserDeleted] to people_marriage_manager
GRANT SELECT ON Fn_CountBirthsInYear to people_marriage_manager
GRANT SELECT ON PERSONAL_INFORMATION to people_marriage_manager

CREATE LOGIN temporarily_manager WITH PASSWORD = 'manager';
CREATE USER temporarily_manager FOR LOGIN temporarily_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Temporarily_Absent to temporarily_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON Temporarily_Staying to temporarily_manager
GRANT EXECUTE ON proc_DeleteTemporarilyStayingData to temporarily_manager
GRANT EXECUTE ON proc_UpdateTemporarilyStayingStatus to temporarily_manager
GRANT EXECUTE ON proc_UpdateTemporarilyAbsentStatus to temporarily_manager
GRANT EXECUTE ON proc_DeleteTemporarilyAbsentData to temporarily_manager
GRANT EXECUTE ON proc_InsertTemporarilyAbsent to temporarily_manager
GRANT EXECUTE ON proc_InsertTemporarilyStaying to temporarily_manager
GRANT SELECT ON View_Temporarily_Absent to temporarily_manager
GRANT SELECT ON view_TemporarilyStaying to temporarily_manager
GRANT SELECT ON View_ListExpiredPermission to temporarily_manager
GRANT SELECT ON View_ListExpired to temporarily_manager
GRANT EXECUTE ON func_GenerateMaTamVang to temporarily_manager
GRANT EXECUTE ON func_GenerateMaTamTru to temporarily_manager


CREATE LOGIN personal_data_manager WITH PASSWORD = 'manager';
CREATE USER personal_data_manager FOR LOGIN personal_data_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Citizens to personal_data_manager
GRANT SELECT, INSERT ON Births to personal_data_manager
GRANT SELECT ON fn_TimTheoNgheNghiep to personal_data_manager
GRANT SELECT ON fn_TimCongDanTheoMaCd to personal_data_manager
GRANT SELECT ON fn_TimTheoDanToc to personal_data_manager
GRANT SELECT ON fn_TimTheoTen to personal_data_manager
GRANT SELECT ON PERSONAL_INFORMATION to personal_data_manager
