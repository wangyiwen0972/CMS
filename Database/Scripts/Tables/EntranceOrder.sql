USE [CMS]
GO

/****** Object:  Table [dbo].[EntranceOrder]    Script Date: 01/23/2014 22:47:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntranceOrder](
	[GUID] [uniqueidentifier] NOT NULL,
	[SalesID] [uniqueidentifier] NULL,
	[Amount] [money] NULL,
	[PayAmount] [money] NULL,
	[IsUseCard] [bit] NULL,
	[CardID] [uniqueidentifier] NULL,
	[EntranceID] [uniqueidentifier] NULL,
	[Status] [uniqueidentifier] NULL,
	[PrintFlag] [bit] NULL,
	[Machine] [nvarchar](50) NULL,
	[Operator] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[changedDate] [datetime] NULL
) ON [PRIMARY]

GO

