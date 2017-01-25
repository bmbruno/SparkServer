USE [SparkServer]
GO

INSERT INTO [dbo].[Article] ([Title],[CategoryID],[Body],[SitecoreVersionID],[PublishDate],[UniqueURL],[AuthorID],[Active],[CreateDate])
VALUES('Article Test #1',1,'<p>Article Test #1 body goes here.</p>',1,'2017-01-17','article-number-one',1,1,'2017-01-15')
GO

INSERT INTO [dbo].[Article] ([Title],[CategoryID],[Body],[SitecoreVersionID],[PublishDate],[UniqueURL],[AuthorID],[Active],[CreateDate])
VALUES('Article Test #2',1,'<p>Article Test #2 body goes here.</p>',1,'2017-01-24','article-number-two',1,1,'2017-01-15')
GO

INSERT INTO [dbo].[Article] ([Title],[CategoryID],[Body],[SitecoreVersionID],[PublishDate],[UniqueURL],[AuthorID],[Active],[CreateDate])
VALUES('Article Test #3',2,'<p>Article Test #3 body goes here.</p>',1,'2017-02-03','article-number-three',1,1,'2017-01-15')
GO

INSERT INTO [dbo].[Article] ([Title],[CategoryID],[Body],[SitecoreVersionID],[PublishDate],[UniqueURL],[AuthorID],[Active],[CreateDate])
VALUES('Article Test #4',2,'<p>Article Test #4 body goes here.</p>',1,'2017-02-25','article-number-four',1,1,'2017-01-15')
GO

INSERT INTO [dbo].[Article] ([Title],[CategoryID],[Body],[SitecoreVersionID],[PublishDate],[UniqueURL],[AuthorID],[Active],[CreateDate])
VALUES('Article Test #5',3,'<p>Article Test #5 body goes here.</p>',1,'2017-03-13','article-number-five',1,1,'2017-01-15')
GO

