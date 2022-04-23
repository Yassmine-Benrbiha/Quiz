Drop Table if exists [Quiz]
Go

CREATE TABLE [Quiz](
	[QUI_Id] [uniqueidentifier] NOT NULL,
	[QUI_Title] [nvarchar](250) NOT NULL,
	[QUI_CreatedDate] [datetime] NOT NULL,
	[QUI_CreatedBy] [nvarchar](250) NULL,
	[QUI_LastModifiedDate] [datetime] NOT NULL,
	[QUI_LastModifiedBy] [nvarchar](250) NULL,
	
PRIMARY KEY CLUSTERED 
( [QUI_Id] ASC ))
GO

ALTER TABLE [Quiz]  ADD  CONSTRAINT [QUI_QUIZ_Id]  DEFAULT (newid()) FOR [QUI_Id]
GO

ALTER TABLE [Quiz]  ADD  CONSTRAINT [QUI_QUIZ_CreatedDate]  DEFAULT (getdate()) FOR [QUI_CreatedDate]
GO

ALTER TABLE [Quiz]  ADD  CONSTRAINT [QUI_QUIZ_LastModifiedDate]  DEFAULT (getdate()) FOR [QUI_LastModifiedDate]
GO