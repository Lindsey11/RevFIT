USE [master]
GO
/****** Object:  Database [Bearfitness]    Script Date: 2023/06/14 15:39:33 ******/
CREATE DATABASE [Bearfitness]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hlrvvniw_bearfitness', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Bearfitness.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hlrvvniw_bearfitness_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Bearfitness_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Bearfitness] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bearfitness].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bearfitness] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bearfitness] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bearfitness] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bearfitness] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bearfitness] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bearfitness] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bearfitness] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bearfitness] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bearfitness] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bearfitness] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bearfitness] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bearfitness] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bearfitness] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bearfitness] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bearfitness] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bearfitness] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bearfitness] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bearfitness] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bearfitness] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bearfitness] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bearfitness] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bearfitness] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bearfitness] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bearfitness] SET  MULTI_USER 
GO
ALTER DATABASE [Bearfitness] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bearfitness] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bearfitness] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bearfitness] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bearfitness] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bearfitness] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bearfitness', N'ON'
GO
ALTER DATABASE [Bearfitness] SET QUERY_STORE = OFF
GO
USE [Bearfitness]
GO
/****** Object:  User [sqladmin]    Script Date: 2023/06/14 15:39:33 ******/
CREATE USER [sqladmin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [hostking]    Script Date: 2023/06/14 15:39:33 ******/
CREATE USER [hostking] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [hlrvvniw_lindsey]    Script Date: 2023/06/14 15:39:33 ******/
CREATE USER [hlrvvniw_lindsey] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[hlrvvniw_lindsey]
GO
/****** Object:  User [hlrvvniw_bear]    Script Date: 2023/06/14 15:39:33 ******/
CREATE USER [hlrvvniw_bear] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[hlrvvniw_bear]
GO
ALTER ROLE [db_owner] ADD MEMBER [sqladmin]
GO
ALTER ROLE [db_owner] ADD MEMBER [hostking]
GO
ALTER ROLE [db_owner] ADD MEMBER [hlrvvniw_lindsey]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [hlrvvniw_lindsey]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [hlrvvniw_lindsey]
GO
ALTER ROLE [db_datareader] ADD MEMBER [hlrvvniw_lindsey]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [hlrvvniw_lindsey]
GO
ALTER ROLE [db_owner] ADD MEMBER [hlrvvniw_bear]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [hlrvvniw_bear]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [hlrvvniw_bear]
GO
ALTER ROLE [db_datareader] ADD MEMBER [hlrvvniw_bear]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [hlrvvniw_bear]
GO
/****** Object:  Schema [hlrvvniw_bear]    Script Date: 2023/06/14 15:39:33 ******/
CREATE SCHEMA [hlrvvniw_bear]
GO
/****** Object:  Schema [hlrvvniw_lindsey]    Script Date: 2023/06/14 15:39:33 ******/
CREATE SCHEMA [hlrvvniw_lindsey]
GO
/****** Object:  Table [dbo].[ExcerciseDifficulty]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcerciseDifficulty](
	[ExcerciseDifficultyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_ExcerciseDifficulty] PRIMARY KEY CLUSTERED 
(
	[ExcerciseDifficultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcerciseProgram]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcerciseProgram](
	[ProgramID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramName] [varchar](max) NULL,
	[ProgramTypeID] [int] NOT NULL,
	[ProgramDurationWeeks] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_ExcerciseProgram] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Excercises]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Excercises](
	[ExcerciseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Type] [varchar](max) NULL,
	[Muscle] [varchar](max) NULL,
	[Equipment] [varchar](max) NULL,
	[Difficulty] [varchar](max) NULL,
	[Instructions] [varchar](max) NULL,
	[ProgramID] [int] NULL,
 CONSTRAINT [PK_Excercises] PRIMARY KEY CLUSTERED 
(
	[ExcerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcerciseType]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcerciseType](
	[ExcerciseTypID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_ExcerciseType] PRIMARY KEY CLUSTERED 
(
	[ExcerciseTypID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcersiceMuscleGroup]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcersiceMuscleGroup](
	[MuscleGroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_ExcersiceMuscleGroup] PRIMARY KEY CLUSTERED 
(
	[MuscleGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramType]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramType](
	[ProgramTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Value] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ProgramType] PRIMARY KEY CLUSTERED 
(
	[ProgramTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[PassworkEcyp] [varbinary](max) NOT NULL,
	[SaltEcyp] [varbinary](max) NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutCircuitChild]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutCircuitChild](
	[WorkoutCircuitChild] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NULL,
	[Day] [int] NULL,
	[Year] [int] NULL,
	[WorkoutDate] [datetime] NULL,
	[Excercise] [varchar](max) NULL,
	[Reps] [int] NULL,
	[Time] [varchar](max) NULL,
	[RestPeriod] [int] NULL,
	[Notes] [int] NULL,
	[WorkoutCircuitParentID] [int] NOT NULL,
 CONSTRAINT [PK_WorkoutCircuitChild] PRIMARY KEY CLUSTERED 
(
	[WorkoutCircuitChild] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutCircuitParent]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutCircuitParent](
	[WorkoutCircutParent] [int] IDENTITY(1,1) NOT NULL,
	[Rounds] [int] NULL,
	[Time] [varchar](max) NULL,
	[TimeCap] [int] NOT NULL,
	[WorkoutID] [int] NOT NULL,
	[WokoutDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WorkoutCircutParent] PRIMARY KEY CLUSTERED 
(
	[WorkoutCircutParent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutRegular]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutRegular](
	[WorkoutRegularID] [int] IDENTITY(1,1) NOT NULL,
	[ExcerciseName] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[MuscleGroupFocus] [varchar](max) NULL,
	[Notes] [varchar](max) NULL,
	[WorkoutID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_WorkoutRegular] PRIMARY KEY CLUSTERED 
(
	[WorkoutRegularID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutRegularChild]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutRegularChild](
	[WorkoutRegularChildrenID] [int] IDENTITY(1,1) NOT NULL,
	[Reps] [int] NULL,
	[Sets] [int] NULL,
	[Time] [int] NULL,
	[Weight] [int] NULL,
	[RestPeriod] [int] NULL,
	[Notes] [varchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[WorkoutRegularParentID] [int] NOT NULL,
 CONSTRAINT [PK_WorkoutRegularChild] PRIMARY KEY CLUSTERED 
(
	[WorkoutRegularChildrenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workouts]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workouts](
	[WorkoutID] [int] IDENTITY(1,1) NOT NULL,
	[WarmUP] [varchar](max) NULL,
	[WorkoutName] [varchar](max) NOT NULL,
	[Description] [varchar](max) NULL,
	[WorkoutTypeID] [int] NOT NULL,
	[ProgramID] [int] NOT NULL,
	[CoolDown] [varchar](max) NULL,
	[WokoutDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Workouts] PRIMARY KEY CLUSTERED 
(
	[WorkoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutScoringType]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutScoringType](
	[ScoringTypeID] [int] NOT NULL,
	[ScoringType] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_WorkoutScoringType] PRIMARY KEY CLUSTERED 
(
	[ScoringTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkoutType]    Script Date: 2023/06/14 15:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutType](
	[WorkoutTypeID] [int] IDENTITY(1,1) NOT NULL,
	[WorkoutType] [varchar](max) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_WorkoutType] PRIMARY KEY CLUSTERED 
(
	[WorkoutTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExcerciseProgram] ADD  CONSTRAINT [DEFAULT_ExcerciseProgram_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Excercises] ADD  CONSTRAINT [DEFAULT_Excercises_ProgramID]  DEFAULT (NULL) FOR [ProgramID]
GO
ALTER TABLE [dbo].[WorkoutRegular] ADD  CONSTRAINT [DF_WorkoutRegular_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[WorkoutRegularChild] ADD  CONSTRAINT [DF_WorkoutRegularChild_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Workouts] ADD  CONSTRAINT [DEFAULT_Workouts_WokoutDate]  DEFAULT (getdate()) FOR [WokoutDate]
GO
ALTER TABLE [dbo].[ExcerciseProgram]  WITH CHECK ADD  CONSTRAINT [FK_ExcerciseProgram_ProgramType] FOREIGN KEY([ProgramTypeID])
REFERENCES [dbo].[ProgramType] ([ProgramTypeID])
GO
ALTER TABLE [dbo].[ExcerciseProgram] CHECK CONSTRAINT [FK_ExcerciseProgram_ProgramType]
GO
ALTER TABLE [dbo].[WorkoutCircuitChild]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutCircuitChild_WorkoutCircuitParent] FOREIGN KEY([WorkoutCircuitParentID])
REFERENCES [dbo].[WorkoutCircuitParent] ([WorkoutCircutParent])
GO
ALTER TABLE [dbo].[WorkoutCircuitChild] CHECK CONSTRAINT [FK_WorkoutCircuitChild_WorkoutCircuitParent]
GO
ALTER TABLE [dbo].[WorkoutCircuitParent]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutCircuitParent_Workouts] FOREIGN KEY([WorkoutID])
REFERENCES [dbo].[Workouts] ([WorkoutID])
GO
ALTER TABLE [dbo].[WorkoutCircuitParent] CHECK CONSTRAINT [FK_WorkoutCircuitParent_Workouts]
GO
ALTER TABLE [dbo].[WorkoutRegular]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutRegular_Workouts] FOREIGN KEY([WorkoutID])
REFERENCES [dbo].[Workouts] ([WorkoutID])
GO
ALTER TABLE [dbo].[WorkoutRegular] CHECK CONSTRAINT [FK_WorkoutRegular_Workouts]
GO
ALTER TABLE [dbo].[WorkoutRegularChild]  WITH CHECK ADD  CONSTRAINT [FK_WorkoutRegularChild_WorkoutRegular] FOREIGN KEY([WorkoutRegularParentID])
REFERENCES [dbo].[WorkoutRegular] ([WorkoutRegularID])
GO
ALTER TABLE [dbo].[WorkoutRegularChild] CHECK CONSTRAINT [FK_WorkoutRegularChild_WorkoutRegular]
GO
ALTER TABLE [dbo].[Workouts]  WITH CHECK ADD  CONSTRAINT [FK_Workouts_ExcerciseProgram] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[ExcerciseProgram] ([ProgramID])
GO
ALTER TABLE [dbo].[Workouts] CHECK CONSTRAINT [FK_Workouts_ExcerciseProgram]
GO
USE [master]
GO
ALTER DATABASE [Bearfitness] SET  READ_WRITE 
GO
