USE [DDEdu]
GO
/****** Object:  Table [dbo].[aboutus]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aboutus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[desc] [nvarchar](255) NULL,
	[icon] [nvarchar](255) NULL,
	[isquestion] [bit] NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_aboutus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[link] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[idMenu] [int] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](255) NULL,
	[address] [nvarchar](max) NULL,
	[addressGPS] [nvarchar](max) NULL,
	[hotline] [nvarchar](50) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[name] [nvarchar](255) NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[desc] [nvarchar](max) NULL,
	[detail] [nvarchar](max) NULL,
	[startOn] [date] NULL,
	[endDate] [date] NULL,
	[maxStudent] [int] NULL,
	[currStudent] [int] NULL,
	[tuition] [int] NULL,
	[idCategory] [int] NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[image] [nvarchar](255) NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[imageaboutus]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[imageaboutus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](255) NULL,
	[role] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_imageaboutus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logo]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logoImage] [nvarchar](255) NULL,
	[logoName] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[link] [nvarchar](max) NULL,
	[hide] [bit] NULL,
	[text] [nvarchar](255) NULL,
	[desc] [nvarchar](255) NULL,
	[dateBegin] [date] NULL,
 CONSTRAINT [PK_logo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[link] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newPost]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newPost](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[detail] [nvarchar](max) NULL,
	[image] [nvarchar](255) NULL,
	[postDate] [date] NULL,
	[hide] [bit] NULL,
	[meta] [nvarchar](255) NULL,
	[author] [nvarchar](255) NULL,
	[type] [int] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_newPost] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[datebegin] [date] NULL,
	[nameI] [nvarchar](255) NULL,
 CONSTRAINT [PK_slide] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[typePost]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typePost](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameType] [nvarchar](255) NULL,
	[link] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[datebegin] [date] NULL,
 CONSTRAINT [PK_typePost] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[fullname] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[birth] [date] NULL,
	[meta] [nvarchar](255) NULL,
	[isAdmin] [bit] NULL,
	[dateBegin] [date] NULL,
	[isActive] [bit] NULL,
	[hide] [bit] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usercourse]    Script Date: 12/06/2024 1:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usercourse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[idCourse] [int] NULL,
	[dateBegin] [date] NULL,
	[meta] [nvarchar](50) NULL,
	[ispaid] [bit] NULL,
	[dateedit] [date] NULL,
 CONSTRAINT [PK_usercourse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[aboutus] ON 

INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (1, N'Diverse types of international certificates', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-bookmark', 0, N'about', 1, 1, NULL)
INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (2, N'Search your courses', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-search', 0, N'about', 1, 2, NULL)
INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (3, N'We have professional teachers', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-book', 0, N'about', 1, 3, NULL)
INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (4, N'How can I sign up for a course?', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-book', 1, NULL, 1, 1, NULL)
INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (5, N'How can I contact for customer service?', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-search', 1, N'about', 1, 2, NULL)
INSERT [dbo].[aboutus] ([id], [title], [desc], [icon], [isquestion], [meta], [hide], [order], [datebegin]) VALUES (6, N'How to search for a course?', N'Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis, cumque magnam? Sequi, cupiditate quibusdam alias illum sed esse ad dignissimos libero sunt, quisquam numquam aliquam? Voluptas, accusamus omnis?', N'bi-search', 1, NULL, 1, 3, NULL)
SET IDENTITY_INSERT [dbo].[aboutus] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name], [link], [meta], [hide], [order], [idMenu], [datebegin]) VALUES (1, N'IELTS', N'#', N'ielts', 1, 1, 2, CAST(N'2024-10-28' AS Date))
INSERT [dbo].[category] ([id], [name], [link], [meta], [hide], [order], [idMenu], [datebegin]) VALUES (2, N'TOEIC', N'#', N'toeic', 1, 2, 2, CAST(N'2024-10-29' AS Date))
INSERT [dbo].[category] ([id], [name], [link], [meta], [hide], [order], [idMenu], [datebegin]) VALUES (3, N'PET', N'#', N'pet', 1, 3, 2, CAST(N'2024-11-25' AS Date))
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[contact] ON 

INSERT [dbo].[contact] ([id], [email], [address], [addressGPS], [hotline], [meta], [hide], [name], [datebegin]) VALUES (1, N'bdtd1ad@gmail.com', N'19 Nguyen Huu Tho Street,
Tan Phong Ward, District 7,
Ho Chi Minh City, Vietnam', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.0239008081553!2d106.6971889748043!3d10.7326398894135!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752fbd7d343a57%3A0xb5ca26918dff0578!2zMTkgxJAuIE5ndXnhu4VuIEjhu691IFRo4buNLCBUw6JuIEjGsG5nLCBRdeG6rW4gNywgSOG7kyBDaMOtIE1pbmgsIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1728986153480!5m2!1svi!2s', N'000 000 000', N'contact', 1, N'DDEdu English Center', CAST(N'2024-11-23' AS Date))
SET IDENTITY_INSERT [dbo].[contact] OFF
GO
SET IDENTITY_INSERT [dbo].[course] ON 

INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (1, N'IELTS For Beginer', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 1, N'ielts', 1, N'faq_graphic.jpg', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (2, N'IELTS Advance', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. ', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 2, 200000, 1, N'ielts', 1, N'undraw_Educator_re_ju47.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (3, N'IELTS For Kid', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites   Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.  Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.  Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.. ', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 1, 200000, 1, N'ielts', 1, N'undraw_Graduation_re_gthn.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (4, N'TOEIC For Beginer', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 2, 200000, 2, N'toeic', 1, N'undraw_Group_video_re_btu7.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (5, N'TOEIC Advance', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 2, N'toeic', 1, N'undraw_Podcast_audience_re_4i5q.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (6, N'TOEIC For Kid', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 2, N'toeic', 1, N'colleagues-working-cozy-office-medium-shot.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (7, N'PET For Beginer', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 3, N'pet', 1, N'undraw_Remote_design_team_re_urdx.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (8, N'PET Advance', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 1, 200000, 3, N'pet', 1, N'undraw_Finance_re_gnv2.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (9, N'PET For Kid', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 3, N'pet', 1, N'undraw_viral_tweet_gndb.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (10, N'IELTS 8.0', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 1, 200000, 1, N'ielts', 1, N'undraw_viral_tweet_gndb.png', NULL)
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (11, N'PET Friendly Academic', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'<p>Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.</p>
', CAST(N'2024-12-20' AS Date), CAST(N'2025-01-20' AS Date), 20, 0, 200000, 3, N'pet', 1, N'undraw_viral_tweet_gndb.png', CAST(N'2024-11-21' AS Date))
INSERT [dbo].[course] ([id], [name], [desc], [detail], [startOn], [endDate], [maxStudent], [currStudent], [tuition], [idCategory], [meta], [hide], [image], [datebegin]) VALUES (12, N'IELTS not show', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', CAST(N'2024-11-01' AS Date), CAST(N'2024-11-20' AS Date), 20, 0, 200000, 1, N'ielts', 1, N'undraw_viral_tweet_gndb.png', NULL)
SET IDENTITY_INSERT [dbo].[course] OFF
GO
SET IDENTITY_INSERT [dbo].[imageaboutus] ON 

INSERT [dbo].[imageaboutus] ([id], [image], [role], [meta], [hide], [datebegin]) VALUES (1, N'colleagues-working-cozy-office-medium-shot.jpg', N'background', N'aboutus', 1, NULL)
INSERT [dbo].[imageaboutus] ([id], [image], [role], [meta], [hide], [datebegin]) VALUES (2, N'faq_graphic.jpg', N'question', N'aboutus', 1, NULL)
SET IDENTITY_INSERT [dbo].[imageaboutus] OFF
GO
SET IDENTITY_INSERT [dbo].[logo] ON 

INSERT [dbo].[logo] ([id], [logoImage], [logoName], [meta], [link], [hide], [text], [desc], [dateBegin]) VALUES (1, N'21-11-24-20-51-10-logo-icon.png', N'DDEdu', N'default', N'#', 1, N'Welcom to DDEDu Center', N'Discover . Learn . Enjoy', CAST(N'2024-11-25' AS Date))
SET IDENTITY_INSERT [dbo].[logo] OFF
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (1, N'HOME', N'#', N'default', 1, 1, CAST(N'2024-11-04' AS Date))
INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (2, N'COURSES', N'#', N'courses', 1, 2, CAST(N'2024-11-04' AS Date))
INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (3, N'NEWS', N'#', N'news', 1, 3, CAST(N'2024-10-29' AS Date))
INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (4, N'CONTACT', N'#', N'contact', 1, 5, CAST(N'2024-11-04' AS Date))
INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (5, N'MY COURSES', N'#', N'my-courses', 1, 6, CAST(N'2024-11-04' AS Date))
INSERT [dbo].[menu] ([id], [name], [link], [meta], [hide], [order], [datebegin]) VALUES (6, N'ABOUT US', N'#', N'about-us', 1, 4, CAST(N'2024-11-04' AS Date))
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[newPost] ON 

INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (2, N'Update new course today', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-02' AS Date), 1, N'update-new-course-today', N'authorA', 2, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (3, N'Update new course today', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-03' AS Date), 1, N'update-new-course-today', N'authorA', 2, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (4, N'Update new course today', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-04' AS Date), 1, N'update-new-course-today', N'authorA', 2, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (5, N'Update new course today', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-05' AS Date), 1, N'update-new-course-today', N'authorA', 2, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (6, N'New English Zone welcome to you', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites. Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-06' AS Date), 1, N'new-english-zone-welcome-to-you', N'authorA', 1, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (7, N'Begin new journey', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-07' AS Date), 1, N'begin-new-journey', N'authorA', 1, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (8, N'Animal Topic weekend', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-08' AS Date), 1, N'animal-topic-weekend', N'authorA', 1, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (9, N'Open Space - Nature and Human', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-09' AS Date), 1, N'open-space-nature-and-human', N'authorA', 1, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (10, N'Super sale for first course', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'<p>#</p>
', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-10' AS Date), 1, N'super-sale-for-first-course', N'authorA', 3, CAST(N'2024-11-23' AS Date))
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (11, N'Free Trip For Kid', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-11' AS Date), 1, N'free-trip-for-kid', N'authorA', 3, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (12, N'Super Double Discount', N'Topic Listing includes home, listing, detail and contact pages. Feel free to modify this template for your custom websites.', N'#', N'businesswoman-using-tablet-analysis.jpg', CAST(N'2024-11-12' AS Date), 1, N'super-double-discount', N'authorA', 3, NULL)
INSERT [dbo].[newPost] ([id], [title], [desc], [detail], [image], [postDate], [hide], [meta], [author], [type], [datebegin]) VALUES (35, N'cggfdg', N'idCategoryidCategory', N'<p><img alt="" src="/Content/upload/img/news/03b7d458-a289-48c9-97f6-ad2c6b604cce.png" style="height:1047px; width:1424px" /></p>
', N'407ca9ce-9e0b-4188-b2cb-6e602ed3636b.jpg', CAST(N'2024-11-26' AS Date), 1, N'cggfdg', N'pepe', 2, CAST(N'2024-11-26' AS Date))
SET IDENTITY_INSERT [dbo].[newPost] OFF
GO
SET IDENTITY_INSERT [dbo].[slide] ON 

INSERT [dbo].[slide] ([id], [name], [hide], [order], [datebegin], [nameI]) VALUES (1, N'img-screen.jpg', 1, 1, CAST(N'2024-11-21' AS Date), N'slide1')
INSERT [dbo].[slide] ([id], [name], [hide], [order], [datebegin], [nameI]) VALUES (2, N'businesswoman-using-tablet-analysis.jpg', 1, 2, CAST(N'2024-11-21' AS Date), N'slide2')
INSERT [dbo].[slide] ([id], [name], [hide], [order], [datebegin], [nameI]) VALUES (3, N'colleagues-working-cozy-office-medium-shot.jpg', 1, 3, CAST(N'2024-11-25' AS Date), N'slide3')
SET IDENTITY_INSERT [dbo].[slide] OFF
GO
SET IDENTITY_INSERT [dbo].[typePost] ON 

INSERT [dbo].[typePost] ([id], [nameType], [link], [meta], [hide], [order], [datebegin]) VALUES (1, N'EVENT', NULL, N'event', 1, 1, CAST(N'2024-11-21' AS Date))
INSERT [dbo].[typePost] ([id], [nameType], [link], [meta], [hide], [order], [datebegin]) VALUES (2, N'SCHEDULE', NULL, N'schedule', 1, 2, CAST(N'2024-11-21' AS Date))
INSERT [dbo].[typePost] ([id], [nameType], [link], [meta], [hide], [order], [datebegin]) VALUES (3, N'BENEFIT', NULL, N'benefit', 1, 3, CAST(N'2024-11-21' AS Date))
SET IDENTITY_INSERT [dbo].[typePost] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (17, N'tester', N'E10ADC3949BA59ABBE56E057F20F883E', N'Bui Dong Tan Dat', N'bdtd1ad@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 0, CAST(N'2024-11-25' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (21, N'haha', N'e10adc3949ba59abbe56e057f20f883e', N'Bui Dong Tan AAAA', N'hehe@gmail.com', CAST(N'2004-10-02' AS Date), N'user', 0, CAST(N'2024-10-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1014, N'lolo', N'e10adc3949ba59abbe56e057f20f883e', N'Tester Student', N'haha@gmail.com', CAST(N'2004-10-02' AS Date), N'user', 0, CAST(N'2024-10-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1015, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'Admin Nè', N'buidongtandat@gmail.com', CAST(N'2004-03-15' AS Date), N'user', 1, CAST(N'2024-11-20' AS Date), 1, 0)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1020, N'manager', N'e10adc3949ba59abbe56e057f20f883e', N'Mangaer Tester', N'manager@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 1, CAST(N'2024-11-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1021, N'employee', N'e10adc3949ba59abbe56e057f20f883e', N'Employee1', N'employee1@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 1, CAST(N'2024-11-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1022, N'student1', N'e10adc3949ba59abbe56e057f20f883e', N'Student1', N'st1@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 0, CAST(N'2024-11-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1023, N'student2', N'e10adc3949ba59abbe56e057f20f883e', N'Student2', N'st2@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 0, CAST(N'2024-11-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1024, N'student3', N'e10adc3949ba59abbe56e057f20f883e', N'Student3', N'st3@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 0, CAST(N'2024-11-20' AS Date), 1, 1)
INSERT [dbo].[user] ([id], [username], [password], [fullname], [email], [birth], [meta], [isAdmin], [dateBegin], [isActive], [hide]) VALUES (1025, N'student4', N'e10adc3949ba59abbe56e057f20f883e', N'Student4', N'st4@gmail.com', CAST(N'2001-11-14' AS Date), N'user', 0, CAST(N'2024-11-20' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET IDENTITY_INSERT [dbo].[usercourse] ON 

INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (16, 21, 3, CAST(N'2024-10-20' AS Date), N'my-course', 0, NULL)
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1011, 17, 10, CAST(N'2024-11-17' AS Date), N'my-course', 1, CAST(N'2024-11-24' AS Date))
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1012, 17, 2, CAST(N'2024-11-17' AS Date), N'my-course', 1, CAST(N'2024-11-26' AS Date))
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1013, 17, 8, CAST(N'2024-11-17' AS Date), N'my-course', 0, NULL)
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1014, 17, 4, CAST(N'2024-11-17' AS Date), N'my-course', 0, NULL)
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1015, 21, 4, CAST(N'2024-11-17' AS Date), N'my-course', 0, NULL)
INSERT [dbo].[usercourse] ([id], [idUser], [idCourse], [dateBegin], [meta], [ispaid], [dateedit]) VALUES (1016, 21, 2, CAST(N'2024-11-17' AS Date), N'my-course', 0, NULL)
SET IDENTITY_INSERT [dbo].[usercourse] OFF
GO
