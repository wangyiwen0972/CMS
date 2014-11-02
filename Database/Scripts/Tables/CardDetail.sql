USE [CMS]
GO

/****** Object:  Table [dbo].[CardDetail]    Script Date: 01/23/2014 22:46:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardDetail](
	[GUID] [uniqueidentifier] NOT NULL,
	[SeriesNumber] [nvarchar](25) NULL,
	[Balance] [decimal](18, 0) NULL,
	[CardStatusID] [uniqueidentifier] NULL,
	[CardTypeID] [uniqueidentifier] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Points] [decimal](18, 0) NULL,
	[Remark] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CardDetail] ADD  CONSTRAINT [DF_CardDetail_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

