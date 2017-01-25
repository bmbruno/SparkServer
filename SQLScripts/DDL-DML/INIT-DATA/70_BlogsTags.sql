USE [SparkServer]
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (1, 1, 1, GETDATE())
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (1, 2, 1, GETDATE())
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (1, 3, 1, GETDATE())
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (2, 6, 1, GETDATE())
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (3, 5, 1, GETDATE())
GO

INSERT INTO [dbo].[BlogsTags] ([BlogID], [TagID], [Active] ,[CreateDate])
VALUES (3, 2, 1, GETDATE())
GO
