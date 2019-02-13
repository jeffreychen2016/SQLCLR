-- ==========================CREATING CLR============================ --

-- Tutorial: https://www.youtube.com/watch?v=Am1_AIX5XNk --
-- Doc: https://www.sqlshack.com/impact-clr-strict-security-configuration-setting-sql-server-2017/ --

-- enabled CLR
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
-- turned off security in order to create CLR (BAD)
EXEC sp_configure 'show advanced options',1;
GO
RECONFIGURE;
GO
EXEC sp_configure 'clr strict security',0;
GO
RECONFIGURE;
GO
RECONFIGURE
GO

-- ==========================IN VS============================ --
-- 1. Create new project
-- 2. Select SQL Server
-- 3. Right click on project, added new item
-- 4. Select SQL CLR C#
-- 5. Select SQL CLR C# Stored Procedure
-- =========================================================== --

-- Create Assembly reference to assembly created in VS
CREATE ASSEMBLY MyCLR
FROM 'C:\Users\ysong\source\repos\CLR\CLR\bin\Debug\CLR.dll'
WITH PERMISSION_SET = SAFE;
GO 

-- Create SP
-- Assembly.ClassName.MethodName
CREATE PROCEDURE spMyCLR
AS 
EXTERNAL NAME MyCLR.StoredProcedures.MyCLR
GO

EXEC spMyCLR
