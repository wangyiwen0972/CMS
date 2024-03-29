USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[CategoryShophoursConnect]    脚本日期: 10/21/2013 22:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoryShophoursConnect](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](3) COLLATE Chinese_PRC_CI_AS NULL,
	[Category] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Shophours] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_CategoryShophoursConnect] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF