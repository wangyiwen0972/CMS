USE [CMS]
GO

/****** Object:  Table [dbo].[EntranceDishDetail]    Script Date: 01/23/2014 22:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EntranceDishDetail](
	[SalesID] [uniqueidentifier] NOT NULL,
	[DishID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL
) ON [PRIMARY]

GO

