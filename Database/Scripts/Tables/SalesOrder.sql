USE [CMS]
GO

/****** Object:  Table [dbo].[SalesOrder]    Script Date: 01/23/2014 22:48:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesOrder](
	[GUID] [uniqueidentifier] NOT NULL,
	[SalesNo] [nvarchar](50) NULL,
	[CardID] [uniqueidentifier] NULL,
	[EntranceID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL
) ON [PRIMARY]

GO

