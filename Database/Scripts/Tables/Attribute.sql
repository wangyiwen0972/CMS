USE [CMS]
GO

/****** Object:  Table [dbo].[Attribute]    Script Date: 2013/10/21 17:34:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Attribute](
	[AttributeGuid] [uniqueidentifier] NOT NULL,
	[AttributeName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[AttributeGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

