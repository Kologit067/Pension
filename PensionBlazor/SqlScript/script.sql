USE [master]
GO
/****** Object:  Database [Pension]    Script Date: 7/3/2025 1:38:46 PM ******/
CREATE DATABASE [Pension]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pension', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pension.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pension_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pension_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pension] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pension].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pension] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pension] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pension] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pension] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pension] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pension] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pension] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pension] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pension] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pension] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pension] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pension] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pension] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pension] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pension] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pension] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pension] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pension] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pension] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pension] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pension] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pension] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pension] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pension] SET  MULTI_USER 
GO
ALTER DATABASE [Pension] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pension] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pension] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pension] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pension] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pension] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pension] SET QUERY_STORE = OFF
GO
USE [Pension]
GO
/****** Object:  UserDefinedTableType [dbo].[PersonSalaryType]    Script Date: 7/3/2025 1:38:46 PM ******/
CREATE TYPE [dbo].[PersonSalaryType] AS TABLE(
	[SalaryYear] [int] NOT NULL,
	[SalaryMonth] [int] NOT NULL,
	[SalaryForPens] [numeric](19, 2) NULL,
	[IsSelected] [bit] NOT NULL
)
GO
/****** Object:  Table [dbo].[AverageSalary]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AverageSalary](
	[AverageSalaryId] [int] IDENTITY(1,1) NOT NULL,
	[SalaryYear] [int] NOT NULL,
	[SalaryMonth] [int] NOT NULL,
	[Salary] [numeric](19, 2) NULL,
 CONSTRAINT [PK_AverageSalary] PRIMARY KEY CLUSTERED 
(
	[AverageSalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomPersonSalary]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPersonSalary](
	[CustomPersonSalaryId] [int] IDENTITY(1,1) NOT NULL,
	[SalaryYear] [int] NOT NULL,
	[SalaryMonth] [int] NOT NULL,
	[SalaryForPens] [numeric](19, 2) NULL,
	[UserLoginId] [int] NULL,
	[IsSelected] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_CustomPersonSalary] PRIMARY KEY CLUSTERED 
(
	[CustomPersonSalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonSalary]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSalary](
	[PersonSalaryId] [int] IDENTITY(1,1) NOT NULL,
	[SalaryYear] [int] NOT NULL,
	[SalaryMonth] [int] NOT NULL,
	[SalaryForPens] [numeric](19, 2) NULL,
	[UserLoginId] [int] NULL,
	[IsSelected] [bit] NOT NULL,
 CONSTRAINT [PK_PersonSalary] PRIMARY KEY CLUSTERED 
(
	[PersonSalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserLoginId] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](500) NULL,
	[password] [varchar](500) NULL,
	[token] [varchar](max) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserLoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomPersonSalary] ADD  DEFAULT ((1)) FOR [IsSelected]
GO
ALTER TABLE [dbo].[PersonSalary] ADD  DEFAULT ((1)) FOR [IsSelected]
GO
ALTER TABLE [dbo].[CustomPersonSalary]  WITH CHECK ADD  CONSTRAINT [FK_CustomPersonSalary_UserLogin_UserLoginId] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[UserLogin] ([UserLoginId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CustomPersonSalary] CHECK CONSTRAINT [FK_CustomPersonSalary_UserLogin_UserLoginId]
GO
ALTER TABLE [dbo].[PersonSalary]  WITH CHECK ADD  CONSTRAINT [FK_PersonSalary_UserLogin_UserLoginId] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[UserLogin] ([UserLoginId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PersonSalary] CHECK CONSTRAINT [FK_PersonSalary_UserLogin_UserLoginId]
GO
/****** Object:  StoredProcedure [dbo].[addCustomSalary]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[addCustomSalary]
    @UserLoginId INT,
    @PersonSalaries dbo.[PersonSalaryType] READONLY
AS    
BEGIN
	
	MERGE INTO [dbo].[PersonSalary] AS TRG
	USING @PersonSalaries AS SRC
	ON (
			SRC.SalaryYear = TRG.SalaryYear AND	
			SRC.SalaryMonth = TRG.SalaryMonth AND	
			@UserLoginId = TRG.UserLoginId )
	WHEN MATCHED THEN UPDATE
		SET
			TRG.[SalaryForPens] = SRC.[SalaryForPens],
			TRG.[IsSelected] = SRC.[IsSelected]
	WHEN NOT MATCHED BY TARGET THEN INSERT
		VALUES (SRC.[SalaryYear], SRC.[SalaryMonth], SRC.[SalaryForPens], @UserLoginId, SRC.[IsSelected])
	WHEN NOT MATCHED BY SOURCE AND TRG.UserLoginId = @UserLoginId THEN 
		DELETE;
	
END
GO
/****** Object:  StoredProcedure [dbo].[addPersonSalary]    Script Date: 7/3/2025 1:38:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[addPersonSalary]
    @UserLoginId INT,
    @PersonSalaries dbo.[PersonSalaryType] READONLY
AS    
BEGIN
	
	MERGE INTO [dbo].[PersonSalary] AS TRG
	USING @PersonSalaries AS SRC
	ON (
			SRC.SalaryYear = TRG.SalaryYear AND	
			SRC.SalaryMonth = TRG.SalaryMonth AND	
			@UserLoginId = TRG.UserLoginId )
	WHEN MATCHED THEN UPDATE
		SET
			TRG.[IsSelected] = SRC.[IsSelected]
	WHEN NOT MATCHED BY TARGET THEN INSERT
		VALUES (SRC.[SalaryYear], SRC.[SalaryMonth], SRC.[SalaryForPens], @UserLoginId, SRC.[IsSelected])
	WHEN NOT MATCHED BY SOURCE AND TRG.UserLoginId = @UserLoginId THEN 
		DELETE;
	
END
GO
USE [master]
GO
ALTER DATABASE [Pension] SET  READ_WRITE 
GO
