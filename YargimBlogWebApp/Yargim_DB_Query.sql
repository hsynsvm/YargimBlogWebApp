CREATE DATABASE Yargim_DB
GO
USE Yargim_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(75) not null,
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Moderator')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(75) not null,
	Soyisim nvarchar(75) not null,
	KullaniciAdi nvarchar(50) not null,
	Mail nvarchar(130) not null,
	Sifre nvarchar(20) not null,
	Durum bit,
	Silinmis bit,
	CONSTRAINT pk_yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyisim,KullaniciAdi,Mail,Sifre,Durum,Silinmis)
VALUES(1, 'Hüseyin', 'Sevim','Admin','hsynsvm@hotmail.com','12345',1,0)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) not null,
	Aciklama nvarchar(500) not null,
	Durum bit,
	Silinmis bit,
	CONSTRAINT pk_Kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(100,1),
	KategoriID int,
	YazarID int,
	Baslik nvarchar(250),
	Ozet nvarchar(500),
	Icerik ntext,
	EklemeTarihi Datetime,
	DuzenlemeTarihi Datetime,
	GoruntulemeSayisi bigint,
	KapakResim nvarchar(50),
	Durum bit,
	CONSTRAINT pk_makale PRIMARY KEY(ID),
	CONSTRAINT fk_makaleKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_makaleYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1000,1),
	Isim nvarchar(75) not null,
	Soyisim nvarchar(75) not null,
	KullaniciAdi nvarchar(50) not null,
	Mail nvarchar(120) not null,
	Sifre nvarchar(20) not null,
	UyelikTarihi datetime,
	Durum bit,
	Silinmis bit,
	CONSTRAINT pk_Uye PRIMARY KEY(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	MakaleID int,
	UyeID int,
	Icerik nvarchar(500),
	EklemeTarihi datetime,
	Durum bit,
	UyeAdi nvarchar(25),
	CONSTRAINT pk_Yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(MakaleID) REFERENCES Makaleler(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)
)


