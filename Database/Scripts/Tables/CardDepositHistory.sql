USE [CMS]
GO

/****** Object:  Table [dbo].[CardDepositHistory]    Script Date: 01/23/2014 22:46:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardDepositHistory](
	[GUID] [uniqueidentifier] NOT NULL,
	[CardID] [uniqueidentifier] NOT NULL,
	[AdjustedAmount] [decimal](18, 0) NOT NULL,
	[ActualAmount] [decimal](18, 0) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Remark] [nvarchar](250) NULL
) ON [PRIMARY]

GO

