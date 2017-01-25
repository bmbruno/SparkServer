USE [SparkServer]
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Introduction to Sitecore', 1 , 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Content Management', 2 , 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Building Components', 3, 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Experience Platform', 4, 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Configuration', 5, 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Tooling', 5, 1, GETDATE())
GO

INSERT INTO [dbo].[Category] ([Name] ,[SortOrder] ,[Active] ,[CreateDate])
VALUES ('Documentation &amp Community', 6, 1, GETDATE())
GO
