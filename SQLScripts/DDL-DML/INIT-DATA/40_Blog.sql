USE [SparkServer]
GO

INSERT INTO [dbo].[Blog]
           ([Title]
           ,[Subtitle]
           ,[Body]
           ,[UniqueURL]
           ,[PublishDate]
           ,[AuthorID]
           ,[Active]
           ,[CreateDate])
     VALUES
           ('Blog Article #1'
           ,'Subtitle Test'
           ,'<p>body!</p>'
           ,'blog-article-one'
           ,'2017-01-15'
           ,1
           ,1
           ,'2017-01-14')
GO


