USE [CMS]
GO
/****** 对象:  Table [dbo].[OOSDishes]    脚本日期: 03/29/2014 21:09:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OOSDishes](
	[DishID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[MachineID] [uniqueidentifier] NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OOSDishes] PRIMARY KEY CLUSTERED 
(
	[DishID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
