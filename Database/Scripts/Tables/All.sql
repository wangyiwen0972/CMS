USE [CMS]
GO
/****** 对象:  Table [dbo].[Area]    脚本日期: 10/27/2013 13:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[GUID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](25) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Floor] [smallint] NULL,
	[MaxTableCount] [int] NOT NULL,
	[Manager] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Area_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_Area_ChangedDate]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Attribute]    脚本日期: 10/27/2013 13:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[AttributeGuid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Attribute_AttributeGuid]  DEFAULT (newid()),
	[AttributeEName] [nvarchar](25) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[AttributeCName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[AttributeGuid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[AttributeEnum]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeEnum](
	[Guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_AttributeEnum_Guid]  DEFAULT (newid()),
	[AttributeGuid] [uniqueidentifier] NULL,
	[EnumValue] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL,
	[Remark] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreateDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_AttributeEnum] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[CookTypes]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CookTypes](
	[Guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_CookTypes_Guid]  DEFAULT (newid()),
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Code] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Introduction] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_CookTypes_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_CookTypes_ChangedDate]  DEFAULT (getdate()),
	[StatusID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CookTypes_1] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC,
	[Code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Customer]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [uniqueidentifier] NOT NULL,
	[Login] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CardGuid] [uniqueidentifier] NULL,
	[FullName] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Sex] [real] NULL,
	[Telephone] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Age] [int] NULL,
	[Points] [int] NULL,
	[StatusID] [uniqueidentifier] NULL,
	[LastPayDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Customer_CreateDate]  DEFAULT (getdate()),
	[ChangedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_Customer_ChangedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Department]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Department_GUID]  DEFAULT (newid()),
	[DepartmentName] [nvarchar](25) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Dish]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Dish_GUID]  DEFAULT (newid()),
	[ShortID] [nvarchar](8) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ShopHoursID] [uniqueidentifier] NOT NULL,
	[Discount] [tinyint] NOT NULL CONSTRAINT [DF_Dish_Discount]  DEFAULT ((100)),
	[Code] [nvarchar](12) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Price] [money] NOT NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Title] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Introduction] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[ImageUrl] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[UnitGUID] [uniqueidentifier] NOT NULL,
	[StyleGUID] [uniqueidentifier] NOT NULL,
	[TypeGUID] [uniqueidentifier] NOT NULL,
	[StatusGUID] [uniqueidentifier] NOT NULL,
	[CreatedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Dish_CreateDate]  DEFAULT (getdate()),
	[ChangedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ChangeDate] [datetime] NOT NULL CONSTRAINT [DF_Dish_ChangeDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Dish] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC,
	[ShortID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[DishStyle]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishStyle](
	[GUID] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Introduction] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DishStyle_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_DishStyle_ChangedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_DishStyle] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[DishTable]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishTable](
	[GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_DishTable_GUID]  DEFAULT (newid()),
	[Name] [nvarchar](25) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[AreaID] [uniqueidentifier] NULL,
	[StatusID] [uniqueidentifier] NOT NULL,
	[MaxPerson] [smallint] NOT NULL CONSTRAINT [DF_DishTable_MaxPerson]  DEFAULT ((1)),
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[DishType]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishType](
	[GUID] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Introduction] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DishType_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_DishType_ChangedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_DishType] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Employee]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Employee_GUID]  DEFAULT (newid()),
	[Login] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[FullName] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Sex] [real] NULL,
	[Telephone] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Age] [int] NULL,
	[DepartmentID] [uniqueidentifier] NOT NULL,
	[StatusID] [uniqueidentifier] NOT NULL,
	[PositionID] [uniqueidentifier] NOT NULL,
	[CreatedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Employee_CreateDate]  DEFAULT (getdate()),
	[ChangedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_Employee_ChangedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Invoice]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Invoice_GUID]  DEFAULT (newid()),
	[InvoiceNo] [nvarchar](15) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OrderNo] [nvarchar](15) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Invoice_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_Invoice_ChangedDate]  DEFAULT (getdate()),
	[StatusID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC,
	[InvoiceNo] ASC,
	[OrderNo] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Order]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[GUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Order_GUID]  DEFAULT (newid()),
	[PreOrderNo] [nvarchar](12) COLLATE Chinese_PRC_CI_AS NULL,
	[OrderNo] [nvarchar](15) COLLATE Chinese_PRC_CI_AS NULL,
	[InvoiceID] [uniqueidentifier] NULL,
	[TableID] [uniqueidentifier] NOT NULL,
	[ShopTypeID] [uniqueidentifier] NOT NULL,
	[PersonCount] [int] NOT NULL CONSTRAINT [DF_Order_PersonCount]  DEFAULT ((0)),
	[Amount] [money] NULL,
	[PayAmount] [money] NULL,
	[IsUseCard] [bit] NOT NULL CONSTRAINT [DF_Order_IsUseCard]  DEFAULT ((0)),
	[CustomerID] [uniqueidentifier] NULL,
	[Status] [uniqueidentifier] NOT NULL,
	[PrintFlag] [bit] NOT NULL CONSTRAINT [DF_Order_PrintFlag]  DEFAULT ((0)),
	[MachineID] [uniqueidentifier] NOT NULL,
	[Operator] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Order_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_Order_ChangedDate]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[OrderDetail]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderNo] [nvarchar](15) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[DishOrder] [int] NOT NULL,
	[DishID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL CONSTRAINT [DF_OrderDetail_Discount]  DEFAULT ((100)),
	[Operator] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_OrderDetail_CreatedDate]  DEFAULT (getdate()),
	[ChangedBy] [uniqueidentifier] NOT NULL,
	[ChangedDate] [datetime] NOT NULL CONSTRAINT [DF_OrderDetail_ChangedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC,
	[DishOrder] ASC,
	[DishID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Position]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[GUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Position_GUID]  DEFAULT (newid()),
	[EName] [nvarchar](25) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[CName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Rights] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[RestInfo]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestInfo](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_RestInfo_ID_1]  DEFAULT (newid()),
	[RestName] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Telphone] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Addr] [nvarchar](1000) COLLATE Chinese_PRC_CI_AS NULL,
	[TaxNo] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[RestDBIP] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[VPNName] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[ManageBranch] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_RestInfo_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** 对象:  Table [dbo].[Shophours]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shophours](
	[Code] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Shophours] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[BeginTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Disable] [bit] NULL CONSTRAINT [DF_Shophours_Disable]  DEFAULT ((0)),
	[BookShowTime] [datetime] NULL,
 CONSTRAINT [PK_Shophours] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** 对象:  Table [dbo].[Unit]    脚本日期: 10/27/2013 13:27:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[GUID] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](12) COLLATE Chinese_PRC_CI_AS NULL,
	[Name] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[UnitTypeID] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[ChangedBy] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
