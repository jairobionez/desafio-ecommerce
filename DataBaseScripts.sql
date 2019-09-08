create database ecommerce

USE [ecommerce]
GO

/****** Object: Table [dbo].[PAGAMENTO] Script Date: 08/09/2019 18:52:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PAGAMENTO] (
    [NROPAGAMENTO]  INT             IDENTITY (1, 1) NOT NULL,
    [NOME]          VARCHAR (30)    NOT NULL,
    [SOBRENOME]     VARCHAR (70)    NOT NULL,
    [RUA]           VARCHAR (60)    NOT NULL,
    [NUMERO]        VARCHAR (6)     NOT NULL,
    [CEP]           VARCHAR (8)     NOT NULL,
    [DTAPAGAMENTO]  DATETIME        NOT NULL,
    [CIDADE]        VARCHAR (30)    NOT NULL,
    [ESTADO]        VARCHAR (20)    NOT NULL,
    [BAIRRO]        VARCHAR (20)    NULL,
    [EMAIL]         VARCHAR (50)    NULL,
    [TOTAL]         DECIMAL (15, 3) NOT NULL,
    [TOTALPAGO]     DECIMAL (15, 3) NOT NULL,
    [DOCUMENTO]     VARCHAR (14)    NOT NULL,
    [TIPODOCUMENTO] VARCHAR (4)     NOT NULL
);


USE [ecommerce]
GO

/****** Object: Table [dbo].[PRODUTO] Script Date: 08/09/2019 18:52:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRODUTO] (
    [SKU]        INT             IDENTITY (1, 1) NOT NULL,
    [DESCRICAO]  VARCHAR (50)    NOT NULL,
    [IMAGEM]     IMAGE           NOT NULL,
    [VALOR]      DECIMAL (15, 3) NOT NULL,
    [PESO]       DECIMAL (15, 3) NOT NULL,
    [QUANTIDADE] INT             NOT NULL,
    [CODEAN]     VARCHAR (13)    NOT NULL
);


USE [ecommerce]
GO

/****** Object: Table [dbo].[PEDIDOITEM] Script Date: 08/09/2019 18:52:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDOITEM] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [QUANTIDADE]   INT             NOT NULL,
    [VLRUNITARIO]  DECIMAL (15, 3) NULL,
    [DESCRICAO]    VARCHAR (100)   NOT NULL,
    [NROPAGAMENTO] INT             NOT NULL
);


