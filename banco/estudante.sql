USE [cubm]
GO

/****** Object:  Table [dbo].[estudante]    Script Date: 21/11/2023 12:50:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[estudante](
	[Id] [uniqueidentifier] NOT NULL,
	[NomeCompleto] [varchar](100) NULL,
	[DataNascimento] [date] NULL,
 CONSTRAINT [PK_estudante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

