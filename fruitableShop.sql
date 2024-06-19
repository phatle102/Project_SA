USE [fruitable_store]
GO
/****** Object:  Table [dbo].[products]    Script Date: 6/19/2024 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[img] [varchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[price] [money] NULL,
	[SaleRate] [int] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/19/2024 11:01:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[address] [nvarchar](max) NULL,
	[phone] [varchar](11) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (1, N'Grapes', N'fruite-item-5.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 4.9900, 800)
INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (2, N'Raspberries', N'fruite-item-2.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 4.9900, 264)
INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (3, N'Apricots', N'fruite-item-4.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.2600, 499)
INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (4, N'Banana', N'fruite-item-3.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 5.9900, 652)
INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (5, N'Oranges', N'fruite-item-1.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.9900, 115)
INSERT [dbo].[products] ([id], [name], [img], [description], [price], [SaleRate]) VALUES (6, N'Apple', N'fruite-item-6.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.9900, 344)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username], [email], [address], [phone], [password]) VALUES (1, N'Nguyễn Quốc Duy', N'nqd@gmail.com', N'HCM', N'0123456789', N'123456')
INSERT [dbo].[User] ([id], [username], [email], [address], [phone], [password]) VALUES (2, N'Đõ Thanh Hùng', N'hung.dt@gmail.com', N'HCM', N'0123789465', N'123456')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
