USE [CMS]
GO

/****** Object:  Table [dbo].[CookTypes]    Script Date: 2013/10/21 17:34:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CookTypes](
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Introduction] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL,
	[StatusID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CookTypes_1] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC,
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

