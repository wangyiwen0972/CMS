USE [NHRBMSX]
GO
/****** 对象:  Table [dbo].[RestInfo]    脚本日期: 10/21/2013 22:31:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestInfo](
	[Serial] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_RestInfo_Serial_1]  DEFAULT (newid()),
	[RestID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RestName] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Telphone] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Addr] [nvarchar](1000) COLLATE Chinese_PRC_CI_AS NULL,
	[TaxNo] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[RestDBIP] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[VPNName] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[ManageBranch] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_RestInfo_1] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
