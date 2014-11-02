USE [CMS]
GO

/****** Object:  Table [dbo].[Dish]    Script Date: 2013/10/21 17:35:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dish](
	[GUID] [uniqueidentifier] NOT NULL,
	[Discount] [tinyint] NULL,
	[Code] [nvarchar](12) NULL,
	[Price] [money] NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Introduction] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](50) NULL,
	[Unit] [uniqueidentifier] NULL,
	[StyleGUID] [uniqueidentifier] NULL,
	[TypeGUID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_Dish] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

