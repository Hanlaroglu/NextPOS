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
--/****** Object:  StoredProcedure [dbo].[SaveProccessNo]    Script Date: 28.02.2023 02:15:19 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE proc [dbo].[SaveProccessNo]

--as
--begin
--DECLARE @COUNT INT =(SELECT COUNT (*) FROM Procces)
--   IF @COUNT=0 
--   BEGIN 
--   SELECT 'SP-1' as col1
--   END
--   ELSE 
--   BEGIN
--   SELECT ('SP-'+ RTRIM( LTRIM(CAST(MAX(CAST(REPLACE(SaveProccesNo,'SP-','')  
--   AS INT)+1) AS NCHAR(10)))) ) as col1 FROM Procces
--   end
--end
--GO