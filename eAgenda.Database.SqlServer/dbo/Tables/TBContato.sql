CREATE TABLE [dbo].[TBCONTATO] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (100) NOT NULL,
    [Email]    VARCHAR (100) NOT NULL,
    [Telefone] VARCHAR (20)  NOT NULL,
    [Cargo]    VARCHAR (100) NULL,
    [Empresa]  VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
