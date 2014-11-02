USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[Payment]    脚本日期: 10/21/2013 22:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[Code] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Payment] [varchar](25) COLLATE Chinese_PRC_CI_AS NULL,
	[FreeFlag] [bit] NULL CONSTRAINT [DF_Payment_FreeFlag]  DEFAULT (0),
	[AddUpFlag] [bit] NULL CONSTRAINT [DF_Payment_AddUpFlag]  DEFAULT (1),
	[Disable] [bit] NULL CONSTRAINT [DF_Payment_Active]  DEFAULT (0),
	[ClientAccountFlag] [bit] NULL CONSTRAINT [DF_Payment_ClientAccountFlag]  DEFAULT (0),
	[CardTypeFlag] [bit] NULL CONSTRAINT [DF_Payment_ICCardFlag]  DEFAULT (0),
	[GroupBuyFlag] [bit] NULL CONSTRAINT [DF_Payment_GroupBuyFlag]  DEFAULT (0),
	[IniValue] [money] NULL CONSTRAINT [DF_Payment_IniValue]  DEFAULT (0),
	[Price] [money] NULL CONSTRAINT [DF_Payment_Price]  DEFAULT (0),
	[MaxNumber] [int] NULL CONSTRAINT [DF_Payment_MaxNumber]  DEFAULT (1),
	[CouponFlag] [bit] NULL CONSTRAINT [DF_Payment_CouponFlag]  DEFAULT (0),
	[PaidInFlag] [bit] NULL CONSTRAINT [DF_Payment_PaidInFlag]  DEFAULT (0),
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF