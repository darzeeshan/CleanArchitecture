USE [master]
GO
/****** Object:  Database [dbCone.InventoryManagement]    Script Date: 11/7/2022 2:15:40 PM ******/
CREATE DATABASE [dbCone.InventoryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbCone.InventoryManagement', FILENAME = N'e:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\dbCone.InventoryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbCone.InventoryManagement_log', FILENAME = N'e:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\dbCone.InventoryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbCone.InventoryManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbCone.InventoryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbCone.InventoryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbCone.InventoryManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbCone.InventoryManagement', N'ON'
GO
ALTER DATABASE [dbCone.InventoryManagement] SET QUERY_STORE = OFF
GO
USE [dbCone.InventoryManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/7/2022 2:15:41 PM ******/
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
/****** Object:  Table [dbo].[tblMapClientConnection]    Script Date: 11/7/2022 2:15:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMapClientConnection](
	[intClientConnectionId] [int] IDENTITY(1,1) NOT NULL,
	[intClientSetupId] [int] NOT NULL,
	[bytConnectionType] [tinyint] NOT NULL,
	[txtKey] [varchar](100) NULL,
	[txtUsername] [varchar](20) NULL,
	[txtPassword] [varchar](20) NULL,
	[txtPort] [varchar](5) NULL,
	[dtDateTime] [datetime2](7) NOT NULL,
	[dtLastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblMapClientConnection] PRIMARY KEY CLUSTERED 
(
	[intClientConnectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMapClientFile]    Script Date: 11/7/2022 2:15:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMapClientFile](
	[intClientFileId] [int] IDENTITY(1,1) NOT NULL,
	[intClientSetupId] [int] NOT NULL,
	[bytFileType] [tinyint] NOT NULL,
	[blnFileColumnRequired] [bit] NOT NULL,
	[blnReferenceNumber] [bit] NOT NULL,
	[txtFileColumn] [varchar](35) NULL,
	[txtMapWithNode] [varchar](35) NULL,
	[dtDateTime] [datetime2](7) NOT NULL,
	[dtLastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblMapClientFile] PRIMARY KEY CLUSTERED 
(
	[intClientFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMapClientSetup]    Script Date: 11/7/2022 2:15:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMapClientSetup](
	[intClientSetupId] [int] IDENTITY(1,1) NOT NULL,
	[bytStatus] [tinyint] NOT NULL,
	[txtClientName] [varchar](100) NOT NULL,
	[txtClientId] [varchar](15) NOT NULL,
	[txtFolderLocation] [varchar](250) NOT NULL,
	[txtProcessedFolderLocation] [varchar](250) NOT NULL,
	[dtDateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblMapClientSetup] PRIMARY KEY CLUSTERED 
(
	[intClientSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblMapClientConnection] ADD  DEFAULT ((0)) FOR [intClientSetupId]
GO
ALTER TABLE [dbo].[tblMapClientConnection] ADD  DEFAULT ((0)) FOR [bytConnectionType]
GO
ALTER TABLE [dbo].[tblMapClientConnection] ADD  DEFAULT (getdate()) FOR [dtDateTime]
GO
ALTER TABLE [dbo].[tblMapClientConnection] ADD  DEFAULT (getdate()) FOR [dtLastUpdated]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT ((0)) FOR [intClientSetupId]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT ((0)) FOR [bytFileType]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT ((0)) FOR [blnFileColumnRequired]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT ((0)) FOR [blnReferenceNumber]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT (getdate()) FOR [dtDateTime]
GO
ALTER TABLE [dbo].[tblMapClientFile] ADD  DEFAULT (getdate()) FOR [dtLastUpdated]
GO
ALTER TABLE [dbo].[tblMapClientSetup] ADD  DEFAULT ((0)) FOR [bytStatus]
GO
ALTER TABLE [dbo].[tblMapClientSetup] ADD  DEFAULT (getdate()) FOR [dtDateTime]
GO
ALTER TABLE [dbo].[tblMapClientConnection]  WITH CHECK ADD  CONSTRAINT [FK_tblMapClientConnection_tblMapClientSetup] FOREIGN KEY([intClientSetupId])
REFERENCES [dbo].[tblMapClientSetup] ([intClientSetupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMapClientConnection] CHECK CONSTRAINT [FK_tblMapClientConnection_tblMapClientSetup]
GO
ALTER TABLE [dbo].[tblMapClientFile]  WITH CHECK ADD  CONSTRAINT [FK_tblMapClientFile_tblMapClientSetup] FOREIGN KEY([intClientSetupId])
REFERENCES [dbo].[tblMapClientSetup] ([intClientSetupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMapClientFile] CHECK CONSTRAINT [FK_tblMapClientFile_tblMapClientSetup]
GO
USE [master]
GO
ALTER DATABASE [dbCone.InventoryManagement] SET  READ_WRITE 
GO
