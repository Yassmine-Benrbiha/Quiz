
Drop Table if exists [Question]
Go
CREATE TABLE [Question](
	[QUE_Id] [uniqueidentifier] NOT NULL,
	[QUE_Text] [nvarchar](500) NOT NULL,
	[QUE_Type] [varchar(20)]  not null,
	[QUE_CreatedDate] [datetime] NOT NULL,
	[QUE_CreatedBy] [nvarchar](250) NULL,
	[QUE_LastModifiedDate] [datetime] NOT NULL,
	[QUE_LastModifiedBy] [nvarchar](250) NULL,
	
PRIMARY KEY CLUSTERED 
( [QUE_Id] ASC ))
GO

ALTER TABLE [Question]  ADD  CONSTRAINT [QUE_Question_Id]  DEFAULT (newid()) FOR [QUE_Id]
GO

ALTER TABLE [Question]  ADD  CONSTRAINT [QUE_Question_CreatedDate]  DEFAULT (getdate()) FOR [QUE_CreatedDate]
GO

ALTER TABLE [Question]  ADD  CONSTRAINT [QUE_Question_LastModifiedDate]  DEFAULT (getdate()) FOR [QUE_LastModifiedDate]
GO