USE [CMS]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 2013/10/21 17:35:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [uniqueidentifier] NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](20) NULL,
	[Sex] [bit] NULL,
	[Telephone] [nvarchar](20) NULL,
	[Address] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[DepartmentID] [uniqueidentifier] NULL,
	[StatusID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

