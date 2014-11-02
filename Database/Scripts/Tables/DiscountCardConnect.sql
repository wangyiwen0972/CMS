USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[DiscountCardConnect]    脚本日期: 10/21/2013 22:25:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscountCardConnect](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[DiscountCard] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Category] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Flag] [bit] NULL CONSTRAINT [DF_DiscountCardConnect_Flag]  DEFAULT (0),
	[DiscountRate] [float] NULL CONSTRAINT [DF_DiscountCardConnect_DiscountRate]  DEFAULT (0),
	[Notes] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_DiscountCardConnect] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF