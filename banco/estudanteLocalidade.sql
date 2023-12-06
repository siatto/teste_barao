USE [cubm]
GO

/****** Object:  Table [dbo].[estudanteLocalidade]    Script Date: 21/11/2023 12:50:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[estudanteLocalidade](
	[Id] [uniqueidentifier] NOT NULL,
	[EstudanteId] [uniqueidentifier] NOT NULL,
	[LocalidadeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_estudante_localidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[estudanteLocalidade]  WITH CHECK ADD  CONSTRAINT [FK_estudante_localidade_estudante] FOREIGN KEY([EstudanteId])
REFERENCES [dbo].[estudante] ([Id])
GO

ALTER TABLE [dbo].[estudanteLocalidade] CHECK CONSTRAINT [FK_estudante_localidade_estudante]
GO

ALTER TABLE [dbo].[estudanteLocalidade]  WITH CHECK ADD  CONSTRAINT [FK_estudante_localidade_localidade] FOREIGN KEY([LocalidadeId])
REFERENCES [dbo].[localidade] ([Id])
GO

ALTER TABLE [dbo].[estudanteLocalidade] CHECK CONSTRAINT [FK_estudante_localidade_localidade]
GO

