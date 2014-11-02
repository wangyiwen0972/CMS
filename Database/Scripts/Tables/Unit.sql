USE [CMS]
GO

/****** Object:  Table [dbo].[Unit]    Script Date: 2013/10/21 17:36:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Unit](
	[GUID] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](12) NULL,
	[Name] [nvarchar](50) NULL,
	[UnitTypeID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

