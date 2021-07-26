CREATE TABLE [dbo].[TBCOMPROMISSO] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Local]       VARCHAR (300)  NULL,
    [Data]        DATETIME       NOT NULL,
    [HoraInicio]  BIGINT         NOT NULL,
    [HoraTermino] BIGINT         NOT NULL,
    [Link]        VARCHAR (1000) NULL,
    [Assunto]     VARCHAR (300)  NULL,
    [Id_Contato]  INT            NULL,
    CONSTRAINT [PK__TBCOMPRO__3214EC074FE80D80] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCOMPROMISSO_TBCONTATO] FOREIGN KEY ([Id_Contato]) REFERENCES [dbo].[TBCONTATO] ([Id])
);

