-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2023 11:58:28
-- Generated © Hanlaroğlu
-- --------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
USE [Barcodedb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Company_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_IslemOzet_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IslemOzet] DROP CONSTRAINT [FK_IslemOzet_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Mehsul_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Mehsul_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Mehsul_Tax]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Mehsul_Tax];
GO
IF OBJECT_ID(N'[dbo].[FK_Mehsul_Unit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Mehsul_Unit];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Product_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Barkod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Barkod];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Islem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Islem];
GO
IF OBJECT_ID(N'[dbo].[IslemOzet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IslemOzet];
GO
IF OBJECT_ID(N'[dbo].[Kullanici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kullanici];
GO
IF OBJECT_ID(N'[dbo].[MehsulQrup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MehsulQrup];
GO
IF OBJECT_ID(N'[dbo].[Procces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Procces];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Satis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Satis];
GO
IF OBJECT_ID(N'[dbo].[Security]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Security];
GO
IF OBJECT_ID(N'[dbo].[Seller]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seller];
GO
IF OBJECT_ID(N'[dbo].[SoftSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoftSettings];
GO
IF OBJECT_ID(N'[dbo].[StokHareket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StokHareket];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TaxType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaxType];
GO
IF OBJECT_ID(N'[dbo].[Terazi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terazi];
GO
IF OBJECT_ID(N'[dbo].[UnitType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitType];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Terazi'
CREATE TABLE [dbo].[Terazi] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeraziOnEk] int  NULL
);
GO

-- Creating table 'Islem'
CREATE TABLE [dbo].[Islem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IslemNo] int  NULL
);
GO

-- Creating table 'Barkod'
CREATE TABLE [dbo].[Barkod] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BarkodNo] int  NULL
);
GO

-- Creating table 'StokHareket'
CREATE TABLE [dbo].[StokHareket] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Barkod] nvarchar(50)  NULL,
    [UrunAd] nvarchar(50)  NULL,
    [Birim] nvarchar(50)  NULL,
    [Miktar] float  NULL,
    [UrunGrup] nvarchar(50)  NULL,
    [Kullanici] nvarchar(50)  NULL,
    [Tarih] datetime  NULL
);
GO

-- Creating table 'Security'
CREATE TABLE [dbo].[Security] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [start] nvarchar(10)  NULL,
    [finis] nvarchar(10)  NULL,
    [Type] nvarchar(15)  NULL,
    [ProductId] uniqueidentifier  NULL
);
GO

-- Creating table 'Seller'
CREATE TABLE [dbo].[Seller] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name_Surname] nvarchar(50)  NULL,
    [Password] nvarchar(20)  NULL,
    [Balance] decimal(18,0)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'MehsulQrup'
CREATE TABLE [dbo].[MehsulQrup] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MehsulGrupAd] nvarchar(100)  NULL
);
GO

-- Creating table 'Satis'
CREATE TABLE [dbo].[Satis] (
    [Satisid] int IDENTITY(1,1) NOT NULL,
    [IslemNo] nvarchar(50)  NULL,
    [MehsulAd] nvarchar(50)  NULL,
    [Barkod] nvarchar(50)  NULL,
    [MehsulQrup] nvarchar(50)  NULL,
    [Vahid] nvarchar(50)  NULL,
    [AlisQiymet] float  NULL,
    [SatisQiymet] float  NULL,
    [Miqdar] float  NULL,
    [Toplam] float  NULL,
    [OdemeSekli] nvarchar(50)  NULL,
    [Comment] nvarchar(500)  NULL,
    [Tarix] datetime  NULL,
    [AdditionType] int  NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Yazici] bit  NULL,
    [AdSoyad] nvarchar(50)  NULL,
    [Unvan] nvarchar(100)  NULL,
    [Adres] nvarchar(500)  NULL,
    [Telefon] nvarchar(50)  NULL,
    [Eposta] nchar(50)  NULL,
    [RegisterDate] datetime  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'TaxType'
CREATE TABLE [dbo].[TaxType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EDV_Name] nvarchar(50)  NULL
);
GO

-- Creating table 'UnitType'
CREATE TABLE [dbo].[UnitType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Unit_Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Mehsulid] int IDENTITY(1,1) NOT NULL,
    [Barkod] nvarchar(50)  NULL,
    [ProductCode] nvarchar(50)  NULL,
    [CategoryID] int  NULL,
    [MehsulAdi] nvarchar(50)  NULL,
    [Amount] float  NULL,
    [AlisQiymet] float  NULL,
    [SatisQiymet] float  NULL,
    [UnitID] int  NULL,
    [TaxID] int  NULL,
    [Date] datetime  NULL,
    [UserID] int  NULL,
    [Aciqlama] nvarchar(200)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NULL,
    [NameSurname] nvarchar(100)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [Status] bit  NULL,
    [Type] bit  NULL,
    [Balance] float  NULL
);
GO

-- Creating table 'SoftSettings'
CREATE TABLE [dbo].[SoftSettings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RemoteServerConnection] bit  NULL
);
GO

-- Creating table 'IslemOzet'
CREATE TABLE [dbo].[IslemOzet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IslemNo] nvarchar(30)  NULL,
    [Iade] bit  NULL,
    [OdemeSekli] nvarchar(50)  NULL,
    [Nakit] float  NULL,
    [Kart] float  NULL,
    [Gelir] bit  NULL,
    [Gider] bit  NULL,
    [AlisFiyatToplam] float  NULL,
    [Tarix] datetime  NULL,
    [Odenen] float  NULL,
    [Qaliq] float  NULL,
    [ProccesNo] nvarchar(50)  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'Kullanici'
CREATE TABLE [dbo].[Kullanici] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdSoyad] nvarchar(100)  NULL,
    [Telefon] nvarchar(50)  NULL,
    [EPosta] nvarchar(50)  NULL,
    [KullaniciAd] nvarchar(50)  NULL,
    [Sifre] nvarchar(50)  NULL,
    [Satis] bit  NULL,
    [Rapor] bit  NULL,
    [Stok] bit  NULL,
    [UrunGiris] bit  NULL,
    [Ayarlar] bit  NULL,
    [FiyatGuncelle] bit  NULL,
    [Yedekleme] bit  NULL,
    [Balance] decimal(18,0)  NULL,
    [UserType] nvarchar(15)  NULL
);
GO

-- Creating table 'Procces'
CREATE TABLE [dbo].[Procces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SalesNo] int  NULL,
    [CancelNo] int  NULL,
    [SaveProccesNo] int  NULL,
    [Barcode] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Terazi'
ALTER TABLE [dbo].[Terazi]
ADD CONSTRAINT [PK_Terazi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Islem'
ALTER TABLE [dbo].[Islem]
ADD CONSTRAINT [PK_Islem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Barkod'
ALTER TABLE [dbo].[Barkod]
ADD CONSTRAINT [PK_Barkod]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StokHareket'
ALTER TABLE [dbo].[StokHareket]
ADD CONSTRAINT [PK_StokHareket]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Security'
ALTER TABLE [dbo].[Security]
ADD CONSTRAINT [PK_Security]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Seller'
ALTER TABLE [dbo].[Seller]
ADD CONSTRAINT [PK_Seller]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'MehsulQrup'
ALTER TABLE [dbo].[MehsulQrup]
ADD CONSTRAINT [PK_MehsulQrup]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Satisid] in table 'Satis'
ALTER TABLE [dbo].[Satis]
ADD CONSTRAINT [PK_Satis]
    PRIMARY KEY CLUSTERED ([Satisid] ASC);
GO

-- Creating primary key on [Id] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaxType'
ALTER TABLE [dbo].[TaxType]
ADD CONSTRAINT [PK_TaxType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnitType'
ALTER TABLE [dbo].[UnitType]
ADD CONSTRAINT [PK_UnitType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Mehsulid] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Mehsulid] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SoftSettings'
ALTER TABLE [dbo].[SoftSettings]
ADD CONSTRAINT [PK_SoftSettings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IslemOzet'
ALTER TABLE [dbo].[IslemOzet]
ADD CONSTRAINT [PK_IslemOzet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kullanici'
ALTER TABLE [dbo].[Kullanici]
ADD CONSTRAINT [PK_Kullanici]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Procces'
ALTER TABLE [dbo].[Procces]
ADD CONSTRAINT [PK_Procces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Mehsul_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mehsul_Category'
CREATE INDEX [IX_FK_Mehsul_Category]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [TaxID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Mehsul_Tax]
    FOREIGN KEY ([TaxID])
    REFERENCES [dbo].[TaxType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mehsul_Tax'
CREATE INDEX [IX_FK_Mehsul_Tax]
ON [dbo].[Products]
    ([TaxID]);
GO

-- Creating foreign key on [UnitID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Mehsul_Unit]
    FOREIGN KEY ([UnitID])
    REFERENCES [dbo].[UnitType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mehsul_Unit'
CREATE INDEX [IX_FK_Mehsul_Unit]
ON [dbo].[Products]
    ([UnitID]);
GO

-- Creating foreign key on [UserID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Users'
CREATE INDEX [IX_FK_Product_Users]
ON [dbo].[Products]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'IslemOzet'
ALTER TABLE [dbo].[IslemOzet]
ADD CONSTRAINT [FK_IslemOzet_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IslemOzet_Users'
CREATE INDEX [IX_FK_IslemOzet_Users]
ON [dbo].[IslemOzet]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK_Company_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Kullanici]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Company_Users'
CREATE INDEX [IX_FK_Company_Users]
ON [dbo].[Company]
    ([UserID]);
GO

-- --------------------------------------------------
-- Stored Procedures
-- --------------------------------------------------


USE [Barcodedb]
GO
/****** Object:  StoredProcedure [dbo].[BarcodeNo]    Script Date: 28.02.2023 02:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BarcodeNo]

as
begin
DECLARE @COUNT INT =(SELECT COUNT (*) FROM Procces)
   IF @COUNT=0 
   BEGIN 
   SELECT '1' as col1
   END
   ELSE 
   BEGIN
   SELECT (RTRIM( LTRIM(CAST(MAX(CAST(REPLACE(Barcode,'1','')  
   AS INT)+1) AS NCHAR(10)))) ) as col1 FROM Procces
   end
end
GO
/****** Object:  StoredProcedure [dbo].[CancelProccessNo]    Script Date: 28.02.2023 02:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CancelProccessNo]

as
begin
DECLARE @COUNT INT =(SELECT COUNT (*) FROM Procces)
   IF @COUNT=0 
   BEGIN 
   SELECT 'CS-1' as col1
   END
   ELSE 
   BEGIN
   SELECT ('CS-'+ RTRIM( LTRIM(CAST(MAX(CAST(REPLACE(CancelNo,'CS-','')  
   AS INT)+1) AS NCHAR(10)))) ) as col1 FROM Procces
   end
end
GO
/****** Object:  StoredProcedure [dbo].[SalesProccessNo]    Script Date: 28.02.2023 02:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SalesProccessNo]

as
begin
DECLARE @COUNT INT =(SELECT COUNT (*) FROM Procces)
   IF @COUNT=0 
   BEGIN 
   SELECT 'PS-1' as col1
   END
   ELSE 
   BEGIN
   SELECT ('PS-'+ RTRIM( LTRIM(CAST(MAX(CAST(REPLACE(SalesNo,'PS-','')  
   AS INT)+1) AS NCHAR(10)))) ) as col1 FROM Procces
   end
end
GO