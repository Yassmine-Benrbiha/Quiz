Drop Table if exists [Option]
Go

CREATE TABLE [Option](
	[OPT_Id] [uniqueidentifier] NOT NULL,
	[OPT_Text] [nvarchar](500)NOT NULL,
    [OPT_Value] Bit NOT NULL,
	[OPT_CreatedDate] [datetime] NOT NULL,
	[OPT_CreatedBy] [nvarchar](250) NULL,
	[OPT_LastModifiedDate] [datetime] NOT NULL,
	[OPT_LastModifiedBy] [nvarchar](250) NULL,
	
PRIMARY KEY CLUSTERED 
( [OPT_Id] ASC ))
GO

ALTER TABLE [Option]  ADD  CONSTRAINT [OPT_Option_Id]  DEFAULT (newid()) FOR [OPT_Id]
GO

ALTER TABLE [Option]  ADD  CONSTRAINT [OPT_Option_CreatedDate]  DEFAULT (getdate()) FOR [OPT_CreatedDate]
GO