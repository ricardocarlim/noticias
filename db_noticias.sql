USE [master]
GO
/****** Object:  Database [Noticias]    Script Date: 11/5/2024 10:41:52 AM ******/
CREATE DATABASE [Noticias]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Noticias', FILENAME = N'/var/opt/mssql/data/Noticias.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Noticias_log', FILENAME = N'/var/opt/mssql/data/Noticias_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Noticias] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Noticias].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Noticias] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Noticias] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Noticias] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Noticias] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Noticias] SET ARITHABORT OFF 
GO
ALTER DATABASE [Noticias] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Noticias] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Noticias] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Noticias] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Noticias] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Noticias] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Noticias] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Noticias] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Noticias] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Noticias] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Noticias] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Noticias] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Noticias] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Noticias] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Noticias] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Noticias] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Noticias] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Noticias] SET RECOVERY FULL 
GO
ALTER DATABASE [Noticias] SET  MULTI_USER 
GO
ALTER DATABASE [Noticias] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Noticias] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Noticias] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Noticias] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Noticias] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Noticias] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Noticias', N'ON'
GO
ALTER DATABASE [Noticias] SET QUERY_STORE = ON
GO
ALTER DATABASE [Noticias] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Noticias]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/5/2024 10:41:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticia]    Script Date: 11/5/2024 10:41:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Noticia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoticiaTag]    Script Date: 11/5/2024 10:41:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoticiaTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoticiaId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_NoticiaTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 11/5/2024 10:41:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/5/2024 10:41:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Senha] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Noticia_UsuarioId]    Script Date: 11/5/2024 10:41:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_Noticia_UsuarioId] ON [dbo].[Noticia]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NoticiaTag_NoticiaId]    Script Date: 11/5/2024 10:41:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_NoticiaTag_NoticiaId] ON [dbo].[NoticiaTag]
(
	[NoticiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NoticiaTag_TagId]    Script Date: 11/5/2024 10:41:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_NoticiaTag_TagId] ON [dbo].[NoticiaTag]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Noticia]  WITH CHECK ADD  CONSTRAINT [FK_Noticia_Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Noticia] CHECK CONSTRAINT [FK_Noticia_Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[NoticiaTag]  WITH CHECK ADD  CONSTRAINT [FK_NoticiaTag_Noticia_NoticiaId] FOREIGN KEY([NoticiaId])
REFERENCES [dbo].[Noticia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NoticiaTag] CHECK CONSTRAINT [FK_NoticiaTag_Noticia_NoticiaId]
GO
ALTER TABLE [dbo].[NoticiaTag]  WITH CHECK ADD  CONSTRAINT [FK_NoticiaTag_Tag_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NoticiaTag] CHECK CONSTRAINT [FK_NoticiaTag_Tag_TagId]
GO
USE [master]
GO
ALTER DATABASE [Noticias] SET  READ_WRITE 
GO
