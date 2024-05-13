USE [fruitable_store]
GO
/****** Object:  Table [dbo].[products]    Script Date: 5/13/2024 10:32:54 AM ******/
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
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (1, N'Grapes', N'fruite-item-5.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 4.9900)
INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (2, N'Raspberries', N'fruite-item-2.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 4.9900)
INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (3, N'Apricots', N'fruite-item-4.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.2600)
INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (4, N'Banana', N'fruite-item-3.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 5.9900)
INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (5, N'Oranges', N'fruite-item-1.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.9900)
INSERT [dbo].[products] ([id], [name], [img], [description], [price]) VALUES (6, N'Apple', N'fruite-item-6.jpg', N'Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod te incididunt

', 3.9900)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
