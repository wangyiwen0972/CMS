USE [CMS]
GO

/****** Object:  Table [dbo].[Entrance]    Script Date: 01/23/2014 22:47:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Entrance](
	[GUID] [uniqueidentifier] NOT NULL,
	[EnterName] [nvarchar](25) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL
) ON [PRIMARY]

GO

