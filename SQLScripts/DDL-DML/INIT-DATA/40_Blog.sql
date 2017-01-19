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
           ('Blog Article #1' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-one' ,'2017-01-15' , 1 ,1 ,'2017-01-14')
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
           ('Blog Article #2' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-two' ,'2017-01-16' , 1 ,1 ,'2017-01-14')
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
           ('Blog Article #3' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-three' ,'2017-02-03' , 1 ,1 ,'2017-01-14')
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
           ('Blog Article #4' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-four' ,'2017-02-04' , 1 ,1 ,'2017-01-14')
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
           ('Blog Article #5' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-five' ,'2017-02-28' , 1 ,1 ,'2017-01-14')
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
           ('Blog Article #6' ,'Subtitle Test' ,'<p>body!</p>', 'blog-article-six' ,'2017-03-17' , 1 ,1 ,'2017-01-14')
GO