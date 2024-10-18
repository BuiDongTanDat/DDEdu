USE [master]
GO
/****** Object:  Database [DDEdu]    Script Date: 10/18/2024 10:16:00 PM ******/
CREATE DATABASE [DDEdu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DDEdu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TANDAT\MSSQL\DATA\DDEdu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DDEdu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TANDAT\MSSQL\DATA\DDEdu_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DDEdu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DDEdu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DDEdu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DDEdu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DDEdu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DDEdu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DDEdu] SET ARITHABORT OFF 
GO
ALTER DATABASE [DDEdu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DDEdu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DDEdu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DDEdu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DDEdu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DDEdu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DDEdu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DDEdu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DDEdu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DDEdu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DDEdu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DDEdu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DDEdu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DDEdu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DDEdu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DDEdu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DDEdu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DDEdu] SET RECOVERY FULL 
GO
ALTER DATABASE [DDEdu] SET  MULTI_USER 
GO
ALTER DATABASE [DDEdu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DDEdu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DDEdu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DDEdu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DDEdu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DDEdu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DDEdu', N'ON'
GO
ALTER DATABASE [DDEdu] SET QUERY_STORE = ON
GO
ALTER DATABASE [DDEdu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DDEdu]
GO
/****** Object:  Table [dbo].[aboutus]    Script Date: 10/18/2024 10:16:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aboutus](
	[id] [int] NOT NULL,
	[title] [nvarchar](255) NULL,
	[desc] [nvarchar](max) NULL,
	[icon] [nvarchar](255) NULL,
	[isquestion] [bit] NULL,
	[img] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
 CONSTRAINT [PK_aboutus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] NOT NULL,
	[name] [varchar](255) NULL,
	[link] [varchar](255) NULL,
	[meta] [varchar](255) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[idMenu] [int] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact](
	[id] [int] NOT NULL,
	[email] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[addressGPS] [nvarchar](max) NULL,
	[hotline] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[name] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[course]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[desc] [nvarchar](max) NULL,
	[detail] [nvarchar](max) NULL,
	[startOn] [date] NULL,
	[endDate] [date] NULL,
	[maxStudent] [int] NULL,
	[currrStudent] [int] NULL,
	[tuition] [int] NULL,
	[idCategory] [int] NULL,
	[meta] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[image] [nvarchar](255) NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logo]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logo](
	[id] [int] NOT NULL,
	[logoImage] [nvarchar](255) NULL,
	[logoName] [nvarchar](255) NULL,
	[meta] [nvarchar](255) NULL,
	[link] [nvarchar](255) NULL,
	[hide] [bit] NULL,
	[text] [nvarchar](255) NULL,
	[desc] [nvarchar](255) NULL,
	[hotline] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[link] [nvarchar](max) NULL,
	[meta] [nvarchar](max) NULL,
	[hide] [bit] NULL,
	[order] [int] NULL,
	[datebegin] [smalldatetime] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newPost]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newPost](
	[id] [int] NOT NULL,
	[title] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[detail] [nvarchar](max) NULL,
	[image] [nvarchar](255) NULL,
	[postDate] [date] NULL,
	[hide] [bit] NULL,
	[meta] [nvarchar](50) NULL,
	[type] [nvarchar](255) NULL,
	[author] [nvarchar](255) NULL,
 CONSTRAINT [PK_newPost] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[slide]    Script Date: 10/18/2024 10:16:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[slide](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[hide] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 10/18/2024 10:16:01 PM ******/
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
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usercourse]    Script Date: 10/18/2024 10:16:01 PM ******/
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
 CONSTRAINT [PK_usercourse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DDEdu] SET  READ_WRITE 
GO
