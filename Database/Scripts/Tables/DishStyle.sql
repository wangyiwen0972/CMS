USE [CMS]
GO

/****** Object:  Table [dbo].[DishStyle]    Script Date: 2013/10/21 17:35:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DishStyle](
	[GUID] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Introduction] [nvarchar](50) NULL,
 CONSTRAINT [PK_DishStyle] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

