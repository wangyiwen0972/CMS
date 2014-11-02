USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[Shophours]    脚本日期: 10/21/2013 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shophours](
	[Code] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Shophours] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[BeginTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Disable] [bit] NULL CONSTRAINT [DF_Shophours_Disable]  DEFAULT (0),
	[BookShowTime] [datetime] NULL,
 CONSTRAINT [PK_Shophours] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF