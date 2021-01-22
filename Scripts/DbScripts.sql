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

CREATE TABLE [Produto] (
    [ProdutoId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Preco] decimal(18,2) NOT NULL,
    [QtdMaxPorCliente] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([ProdutoId])
);
GO

CREATE TABLE [Venda] (
    [VendaID] int NOT NULL IDENTITY,
    [ValorTotal] decimal(18,2) NOT NULL,
    [ValorTotalDescontos] decimal(18,2) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Venda] PRIMARY KEY ([VendaID])
);
GO

CREATE TABLE [Promocao] (
    [PromocaoID] int NOT NULL IDENTITY,
    [Produto1Id] int NULL,
    [Produto2Id] int NULL,
    [Produto3Id] int NULL,
    [Produto1Qtd] int NULL,
    [Produto2Qtd] int NULL,
    [Produto3Qtd] int NULL,
    [ValorDescP1] int NULL,
    [ValorDescP2] int NULL,
    [ValorDescP3] int NULL,
    CONSTRAINT [PK_Promocao] PRIMARY KEY ([PromocaoID]),
    CONSTRAINT [FK_Promocao_Produto_Produto1Id] FOREIGN KEY ([Produto1Id]) REFERENCES [Produto] ([ProdutoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Promocao_Produto_Produto2Id] FOREIGN KEY ([Produto2Id]) REFERENCES [Produto] ([ProdutoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Promocao_Produto_Produto3Id] FOREIGN KEY ([Produto3Id]) REFERENCES [Produto] ([ProdutoId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pedido] (
    [PedidoId] int NOT NULL IDENTITY,
    [ValorTotal] decimal(18,2) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [VendaID] int NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([PedidoId]),
    CONSTRAINT [FK_Pedido_Venda_VendaID] FOREIGN KEY ([VendaID]) REFERENCES [Venda] ([VendaID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Item] (
    [ItemId] int NOT NULL IDENTITY,
    [PedidoId] int NULL,
    [ProdutoId] int NOT NULL,
    [Quantidade] int NOT NULL,
    [ValorTotal] decimal(18,2) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([ItemId]),
    CONSTRAINT [FK_Item_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([PedidoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Item_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([ProdutoId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Item_PedidoId] ON [Item] ([PedidoId]);
GO

CREATE INDEX [IX_Item_ProdutoId] ON [Item] ([ProdutoId]);
GO

CREATE INDEX [IX_Pedido_VendaID] ON [Pedido] ([VendaID]);
GO

CREATE INDEX [IX_Promocao_Produto1Id] ON [Promocao] ([Produto1Id]);
GO

CREATE INDEX [IX_Promocao_Produto2Id] ON [Promocao] ([Produto2Id]);
GO

CREATE INDEX [IX_Promocao_Produto3Id] ON [Promocao] ([Produto3Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201127133858_init', N'5.0.0');
GO

COMMIT;
GO

--drop table Promocao
--drop table Item

--select * from Produto;
insert into Produto values ('Arroz', 25,5);
GO
insert into Produto values ('Feijão', 9,10);
GO
insert into Produto values ('Macarrão', 5,20);
GO
insert into Produto values ('Farinha', 3,20);
GO
insert into Produto values ('Sabão', 2,100);
GO

--select * from Promocao;

insert into Promocao values (1, 2, null, 1, 1, null, 3, null, null);
GO
insert into Promocao values (1, 3, 5, 2, 3, null, null, null, 2);
GO


--select * from Item;
insert into Item values (null, 1, 1,5.00,getdate());
GO
insert into Item values (null, 2, 10,90.00,getdate());
GO
insert into Item values (null, 3, 10,100.00,getdate());
GO
insert into Item values (null, 4, 6,24.00,getdate());
GO
insert into Item values (null, 5, 20,100.00,getdate());
GO
insert into Item values (null, 1, 4,8.00,getdate());
GO


--select * from Pedido;
insert into Pedido values ( 327, getdate(),null);
GO

update Item set PedidoId = (select top 1 PedidoId from Pedido) ;
GO

--select * from Venda;
insert into Venda values (327,327,getdate());
GO

update Pedido set VendaId = (select top 1 VendaID from Venda) ;
GO
