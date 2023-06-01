
CREATE INDEX idx_MaCD
ON Accounts (MaCD);

CREATE INDEX idx_Birth
ON Births (MaCD,MaCD_Cha,MaCD_Me);


CREATE INDEX idx_MaCD_Citizens
ON Citizens (MaCD);

CREATE INDEX idx_MaCD_MaHo_Detail_Households
ON Detail_Households (MaHo,MaCD);

CREATE INDEX idx_MaHo
ON Households (MaHo);

CREATE INDEX idx_ChuHo
ON Households (ChuHo);

CREATE INDEX idx_MaMail
ON Mails (MaMail);

CREATE INDEX idx_NguoiGui
ON Mails (NguoiGui);

CREATE INDEX idx_Ngay
ON Mails (Ngay);

CREATE UNIQUE INDEX idx_MaCDChong_MaCDVo
ON People_Marriage (MaCDChong, MaCDVo);

CREATE INDEX idx_MaHN
ON People_Marriage (MaHN);

CREATE INDEX idx_MaCD_Temporarily_Absent
ON Temporarily_Absent (MaCD);

CREATE INDEX idx_MaCD_Temporarily_Staying
ON Temporarily_Staying (MaCD);

CREATE INDEX idx_MaCD_Users_Deleted
ON Users_Deleted (MaCD); 

CREATE INDEX idx_MaCCCD_Certificates
ON Certificates (MaCCCD); 

CREATE INDEX idx_MaCD_Certificates
ON Certificates (MaCD); 
