USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[Category]    脚本日期: 10/21/2013 22:33:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Code] [varchar](3) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Category] [varchar](25) COLLATE Chinese_PRC_CI_AS NULL,
	[ButtonColor] [int] NULL,
	[FontName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FontColor] [int] NULL,
	[FontSize] [int] NULL,
	[FontBold] [bit] NULL,
	[FontItalic] [bit] NULL,
	[FontUnderline] [bit] NULL,
	[FontStrikeout] [bit] NULL,
	[Class] [varchar](25) COLLATE Chinese_PRC_CI_AS NULL,
	[JobListFlag] [bit] NULL CONSTRAINT [DF_Category_JobListFlag]  DEFAULT (1),
	[JobListFlag2] [bit] NOT NULL CONSTRAINT [DF_Category_JobListFlag2]  DEFAULT (1),
	[JobListFlag3] [bit] NULL CONSTRAINT [DF_Category_JobListFlag21]  DEFAULT (1),
	[CategoryListFlag] [bit] NULL CONSTRAINT [DF_Category_CategoryListFlag]  DEFAULT (0),
	[MenuListFlag] [bit] NULL CONSTRAINT [DF_Category_MenuListFlag]  DEFAULT (0),
	[DiscountFlag] [bit] NULL CONSTRAINT [DF_Category_DiscountFlag]  DEFAULT (1),
	[MenuPrinterPort] [smallint] NULL,
	[MenuPrinterPort1] [smallint] NULL,
	[MenuPrinterPort2] [smallint] NULL,
	[MenuPrinterPort3] [smallint] NULL,
	[DepartName] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Category2] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[ButtonColor1] [int] NULL,
	[FontName1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[FontColor1] [int] NULL,
	[FontSize1] [int] NULL,
	[FontBold1] [bit] NULL,
	[FontItalic1] [bit] NULL,
	[FontUnderline1] [bit] NULL,
	[FontStrikeout1] [bit] NULL,
	[ShowOnMainMenu] [bit] NULL,
	[ShowOnPOSMenu] [bit] NULL,
	[ShowOnPhoneOrderMenu] [bit] NULL,
	[ShowOnIPadMenu] [bit] NULL,
	[HideFlag] [bit] NULL CONSTRAINT [DF_Category_HideFlag_1]  DEFAULT (0),
	[ActiveM] [bit] NULL CONSTRAINT [DF_Category_Active]  DEFAULT (1),
	[SendToKitchenScreenM] [bit] NULL CONSTRAINT [DF_Category_SendToKitchenScreen]  DEFAULT (0),
	[StockControlM] [bit] NULL CONSTRAINT [DF_Category_StockControl]  DEFAULT (0),
	[BarFlagM] [bit] NULL CONSTRAINT [DF_Category_BarFlag]  DEFAULT (0),
	[FishBowlFlagM] [bit] NULL CONSTRAINT [DF_Category_FishBowlFlag]  DEFAULT (0),
	[SeafoodAddOrMinusM] [bit] NULL CONSTRAINT [DF_Category_SeafoodAddOrMinus]  DEFAULT (0),
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF