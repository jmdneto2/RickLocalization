IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Dimensao] (
    [DimensaoId] int NOT NULL IDENTITY,
    [DimensaoNome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Dimensao] PRIMARY KEY ([DimensaoId])
);
GO

CREATE TABLE [Personagem] (
    [PersonagemId] int NOT NULL IDENTITY,
    [PersonagemNome] nvarchar(max) NOT NULL,
    [PersonagemDimensaoDimensaoId] int NULL,
    [ImagemPersonagem] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Personagem] PRIMARY KEY ([PersonagemId]),
    CONSTRAINT [FK_Personagem_Dimensao_PersonagemDimensaoDimensaoId] FOREIGN KEY ([PersonagemDimensaoDimensaoId]) REFERENCES [Dimensao] ([DimensaoId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Viagem] (
    [ViagemId] int NOT NULL IDENTITY,
    [PersonagemId] int NULL,
    [OrigemDimensaoId] int NULL,
    [DestinoDimensaoId] int NULL,
    [Data] datetime2 NOT NULL,
    CONSTRAINT [PK_Viagem] PRIMARY KEY ([ViagemId]),
    CONSTRAINT [FK_Viagem_Dimensao_DestinoDimensaoId] FOREIGN KEY ([DestinoDimensaoId]) REFERENCES [Dimensao] ([DimensaoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Viagem_Dimensao_OrigemDimensaoId] FOREIGN KEY ([OrigemDimensaoId]) REFERENCES [Dimensao] ([DimensaoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Viagem_Personagem_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagem] ([PersonagemId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Personagem_PersonagemDimensaoDimensaoId] ON [Personagem] ([PersonagemDimensaoDimensaoId]);
GO

CREATE INDEX [IX_Viagem_DestinoDimensaoId] ON [Viagem] ([DestinoDimensaoId]);
GO

CREATE INDEX [IX_Viagem_OrigemDimensaoId] ON [Viagem] ([OrigemDimensaoId]);
GO

CREATE INDEX [IX_Viagem_PersonagemId] ON [Viagem] ([PersonagemId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210126104647_Initial', N'5.0.0');
GO

COMMIT;
GO
