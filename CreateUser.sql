USE CityzenManagement

/*CREATE LOGIN manager WITH PASSWORD = 'manager';
CREATE USER manager FOR LOGIN manager;*/

ALTER AUTHORIZATION ON DATABASE::CityzenManagement TO manager;


CREATE LOGIN households_manager WITH PASSWORD = 'manager';
CREATE USER households_manager FOR LOGIN households_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Households to households_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON Detail_Households to households_manager


CREATE LOGIN certificates_manager WITH PASSWORD = 'manager';
CREATE USER certificates_manager FOR LOGIN certificates_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Certificates to certificates_manager

CREATE LOGIN births_manager WITH PASSWORD = 'manager';
CREATE USER births_manager FOR LOGIN births_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Births to births_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON People_Marriage to births_manager

CREATE LOGIN mails_manager WITH PASSWORD = 'manager';
CREATE USER mails_manager FOR LOGIN mails_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Mails to mails_manager

CREATE LOGIN people_marriage_manager WITH PASSWORD = 'manager';
CREATE USER people_marriage_manager FOR LOGIN people_marriage_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON People_Marriage to people_marriage_manager

CREATE LOGIN temporarily_manager WITH PASSWORD = 'manager';
CREATE USER temporarily_manager FOR LOGIN temporarily_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Temporarily_Absent to temporarily_manager
GRANT SELECT, DELETE, UPDATE, INSERT ON Temporarily_Staying to temporarily_manager

CREATE LOGIN personal_data_manager WITH PASSWORD = 'manager';
CREATE USER personal_data_manager FOR LOGIN personal_data_manager;
GRANT SELECT, DELETE, UPDATE, INSERT ON Citizens to personal_data_manager
GRANT SELECT, INSERT ON Births to personal_data_manager
