USE [CMS]
GO

/****** Object:  Table [dbo].[DishPrice]    Script Date: 01/23/2014 22:47:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DishPrice](
	[GUID] [uniqueidentifier] NOT NULL,
	[DishID] [uniqueidentifier] NOT NULL,
	[UnitID] [uniqueidentifier] NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO

