USE [cubm]
GO

/****** Object:  Table [dbo].[localidade]    Script Date: 21/11/2023 12:51:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[localidade](
	[Id] [uniqueidentifier] NOT NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [char](2) NULL,
	[Logradouro] [varchar](100) NULL,
	[CEP] [varchar](8) NULL,
 CONSTRAINT [PK_localidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

