USE master
GO

DECLARE @CUR CURSOR SET @CUR = CURSOR FOR 
	SELECT [spid] FROM master.dbo.sysprocesses
	 WHERE [dbid] = 
			 (SELECT [dbid] FROM master.dbo.sysdatabases
			   WHERE [name] = 'SparkServer')
OPEN @CUR
DECLARE @spid INT
FETCH @CUR INTO @spid
WHILE (@@FETCH_STATUS = 0)
BEGIN 
	DECLARE @SQL NVARCHAR(50) 
	SET @SQL = N'KILL ' + CAST(@spid AS NVARCHAR(16))
	PRINT 'Killing Process #' + CAST(@spid AS NVARCHAR(16))
	EXEC sp_executesql @SQL
	FETCH @CUR INTO @spid
END
CLOSE @CUR


IF DB_ID('SparkServer') IS NOT NULL
DROP DATABASE [SparkServer]
GO

CREATE DATABASE [SparkServer]
GO
