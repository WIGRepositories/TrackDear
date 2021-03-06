USE [TrackDear]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[AppUsers]
GO
/****** Object:  Table [dbo].[GroupMembers]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[GroupMembers]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[Groups]
GO
/****** Object:  Table [dbo].[MemberLocation]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[MemberLocation]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[Members]
GO
/****** Object:  Table [dbo].[TypeGroups]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[TypeGroups]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 12/18/2017 10:24:54 ******/
DROP TABLE [dbo].[Types]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Active] [int] NULL,
	[TypeGroupId] [int] NULL,
	[ListKey] [varchar](20) NULL,
	[ListValue] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeGroups]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Members]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Members](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[MobileNo] [varchar](10) NULL,
	[Mobileotp] [varchar](10) NULL,
	[Address] [varchar](500) NULL,
	[Photo] [varchar](max) NULL,
	[Ownerid] [int] NULL,
	[FCMID] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [int] NULL,
	[statusId] [int] NULL,
	[Accepted] [int] NULL,
	[Acceptedotp] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberLocation]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberLocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [varchar](50) NULL,
	[Longitude] [varchar](50) NULL,
	[FCMID] [varchar](50) NULL,
	[PlaceId] [varchar](50) NULL,
	[LocationDesc] [varchar](150) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Place] [varchar](50) NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Title] [varchar](50) NULL,
	[Photo] [varchar](max) NULL,
	[Active] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupMembers]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupMembers](
	[GroupId] [int] NULL,
	[OwnerId] [int] NULL,
	[MemberId] [int] NULL,
	[FCMID] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AcceptRejectRequest] [int] NULL,
	[RequestNo] [varchar](10) NULL,
	[StartTracking] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 12/18/2017 10:24:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppUsers](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[MobileNo] [varchar](10) NOT NULL,
	[EmailOtp] [varchar](10) NULL,
	[Address] [varchar](500) NULL,
	[Photo] [varchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobileOtp] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
