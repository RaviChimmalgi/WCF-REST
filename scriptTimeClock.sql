USE [master]
GO
/****** Object:  Database [timeClock]    Script Date: 11/02/2012 17:08:55 ******/
CREATE DATABASE [timeClock] ON  PRIMARY 
( NAME = N'timeClock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\timeClock.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'timeClock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\timeClock_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [timeClock] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [timeClock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [timeClock] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [timeClock] SET ANSI_NULLS OFF
GO
ALTER DATABASE [timeClock] SET ANSI_PADDING OFF
GO
ALTER DATABASE [timeClock] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [timeClock] SET ARITHABORT OFF
GO
ALTER DATABASE [timeClock] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [timeClock] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [timeClock] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [timeClock] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [timeClock] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [timeClock] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [timeClock] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [timeClock] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [timeClock] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [timeClock] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [timeClock] SET  ENABLE_BROKER
GO
ALTER DATABASE [timeClock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [timeClock] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [timeClock] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [timeClock] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [timeClock] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [timeClock] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [timeClock] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [timeClock] SET  READ_WRITE
GO
ALTER DATABASE [timeClock] SET RECOVERY FULL
GO
ALTER DATABASE [timeClock] SET  MULTI_USER
GO
ALTER DATABASE [timeClock] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [timeClock] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'timeClock', N'ON'
GO
USE [timeClock]
GO
/****** Object:  Table [dbo].[users]    Script Date: 11/02/2012 17:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[username] [varchar](50) NULL,
	[timein] [smalldatetime] NULL,
	[timeou] [smalldatetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spUpdateLog]    Script Date: 11/02/2012 17:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateLog] @timeou datetime, @username varchar(20)
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
Update users set timeou = @timeou where username = @username and timeou is NULL

	/* SET NOCOUNT ON */
	RETURN
GO
/****** Object:  StoredProcedure [dbo].[spInsertLog]    Script Date: 11/02/2012 17:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertLog] @username varchar(20), @timein datetime, @timeou datetime
as
Insert into users (username, timein, timeou) values (@username, @timein, @timeou)

return
GO
/****** Object:  StoredProcedure [dbo].[spGetCount]    Script Date: 11/02/2012 17:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCount] @username varchar(20)
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select Count(username) From users where username = @username and timeou is NULL
	/* SET NOCOUNT ON */
	RETURN
GO
