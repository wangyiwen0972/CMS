USE [CMS]
GO

/****** Object:  Table [dbo].[AttributeEnum]    Script Date: 2013/10/21 17:34:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AttributeEnum](
	[EnumGuid] [uniqueidentifier] NOT NULL,
	[AttributeGuid] [uniqueidentifier] NULL,
	[EnumValue] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_AttributeEnum] PRIMARY KEY CLUSTERED 
(
	[EnumGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

