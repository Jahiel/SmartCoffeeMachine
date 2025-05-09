USE [CoffeeMachineDb]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 29/04/2025 11:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[Action] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[ParametersJson] [nvarchar](max) NULL,
	[ResultsJson] [nvarchar](max) NULL,
	[ErrorMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
