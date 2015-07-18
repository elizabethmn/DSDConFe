USE [BDDOCUMENTUM]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 14/07/2015 06:42:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[codigoExpediente] [int] NULL,
	[FechaEmision] [datetime] NULL,
	[Recepcionista] [nvarchar](200) NULL,
	[Solicitante] [nvarchar](200) NULL,
	[Estado] [nvarchar](200) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expediente]    Script Date: 14/07/2015 06:42:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expediente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[codigoSolicitante] [int] NULL,
	[codigoTramite] [int] NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Expediente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitante]    Script Date: 14/07/2015 06:42:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Solicitante](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NULL,
	[apellido] [varchar](200) NULL,
	[dni] [varchar](8) NULL,
	[telefono] [varchar](15) NULL,
	[correo] [varchar](200) NULL,
	[direccion] [varchar](200) NULL,
 CONSTRAINT [PK_Solicitante] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tramite]    Script Date: 14/07/2015 06:42:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tramite](
	[codigo] [int] NOT NULL,
	[nombre] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tramite] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tupa]    Script Date: 14/07/2015 06:42:43 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tupa](
	[codigo] [int] NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[codigoTramite] [int] NULL,
 CONSTRAINT [PK_Tupa] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Expediente] FOREIGN KEY([codigoExpediente])
REFERENCES [dbo].[Expediente] ([codigo])
GO
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Expediente]
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD  CONSTRAINT [FK_Expediente_Solicitante] FOREIGN KEY([codigoSolicitante])
REFERENCES [dbo].[Solicitante] ([codigo])
GO
ALTER TABLE [dbo].[Expediente] CHECK CONSTRAINT [FK_Expediente_Solicitante]
GO
ALTER TABLE [dbo].[Expediente]  WITH CHECK ADD  CONSTRAINT [FK_Expediente_Tramite] FOREIGN KEY([codigoTramite])
REFERENCES [dbo].[Tramite] ([codigo])
GO
ALTER TABLE [dbo].[Expediente] CHECK CONSTRAINT [FK_Expediente_Tramite]
GO
ALTER TABLE [dbo].[Tupa]  WITH CHECK ADD  CONSTRAINT [FK_Tupa_Tramite] FOREIGN KEY([codigoTramite])
REFERENCES [dbo].[Tramite] ([codigo])
GO
ALTER TABLE [dbo].[Tupa] CHECK CONSTRAINT [FK_Tupa_Tramite]
GO
