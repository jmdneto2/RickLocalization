﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RickLocalization.Repository.Data;

namespace RickLocalization.Repository.Migrations
{
    [DbContext(typeof(RickLocalizationContext))]
    [Migration("20210124163508_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RickLocalization.Domain.Dimensao", b =>
                {
                    b.Property<int>("DimensaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DimensaoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DimensaoId");

                    b.ToTable("Dimensao");
                });

            modelBuilder.Entity("RickLocalization.Domain.Item", b =>
                {
                    b.Property<int?>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("RickLocalization.Domain.Pedido", b =>
                {
                    b.Property<int?>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VendaID")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("VendaID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("RickLocalization.Domain.Personagem", b =>
                {
                    b.Property<int>("PersonagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImagemPersonagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonagemDimensaoDimensaoId")
                        .HasColumnType("int");

                    b.Property<string>("PersonagemNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonagemId");

                    b.HasIndex("PersonagemDimensaoDimensaoId");

                    b.ToTable("Personagem");
                });

            modelBuilder.Entity("RickLocalization.Domain.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QtdMaxPorCliente")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("RickLocalization.Domain.Promocao", b =>
                {
                    b.Property<int>("PromocaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Produto1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Produto1Qtd")
                        .HasColumnType("int");

                    b.Property<int?>("Produto2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Produto2Qtd")
                        .HasColumnType("int");

                    b.Property<int?>("Produto3Id")
                        .HasColumnType("int");

                    b.Property<int?>("Produto3Qtd")
                        .HasColumnType("int");

                    b.Property<int?>("ValorDescP1")
                        .HasColumnType("int");

                    b.Property<int?>("ValorDescP2")
                        .HasColumnType("int");

                    b.Property<int?>("ValorDescP3")
                        .HasColumnType("int");

                    b.HasKey("PromocaoID");

                    b.HasIndex("Produto1Id");

                    b.HasIndex("Produto2Id");

                    b.HasIndex("Produto3Id");

                    b.ToTable("Promocao");
                });

            modelBuilder.Entity("RickLocalization.Domain.Venda", b =>
                {
                    b.Property<int?>("VendaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotalDescontos")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("VendaID");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("RickLocalization.Domain.Viagem", b =>
                {
                    b.Property<int?>("ViagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DestinoDimensaoId")
                        .HasColumnType("int");

                    b.Property<int?>("OrigemDimensaoId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonagemId")
                        .HasColumnType("int");

                    b.HasKey("ViagemId");

                    b.HasIndex("DestinoDimensaoId");

                    b.HasIndex("OrigemDimensaoId");

                    b.HasIndex("PersonagemId");

                    b.ToTable("Viagem");
                });

            modelBuilder.Entity("RickLocalization.Domain.Item", b =>
                {
                    b.HasOne("RickLocalization.Domain.Pedido", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId");

                    b.HasOne("RickLocalization.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("RickLocalization.Domain.Pedido", b =>
                {
                    b.HasOne("RickLocalization.Domain.Venda", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("VendaID");
                });

            modelBuilder.Entity("RickLocalization.Domain.Personagem", b =>
                {
                    b.HasOne("RickLocalization.Domain.Dimensao", "PersonagemDimensao")
                        .WithMany()
                        .HasForeignKey("PersonagemDimensaoDimensaoId");

                    b.Navigation("PersonagemDimensao");
                });

            modelBuilder.Entity("RickLocalization.Domain.Promocao", b =>
                {
                    b.HasOne("RickLocalization.Domain.Produto", "Produto1")
                        .WithMany()
                        .HasForeignKey("Produto1Id");

                    b.HasOne("RickLocalization.Domain.Produto", "Produto2")
                        .WithMany()
                        .HasForeignKey("Produto2Id");

                    b.HasOne("RickLocalization.Domain.Produto", "Produto3")
                        .WithMany()
                        .HasForeignKey("Produto3Id");

                    b.Navigation("Produto1");

                    b.Navigation("Produto2");

                    b.Navigation("Produto3");
                });

            modelBuilder.Entity("RickLocalization.Domain.Viagem", b =>
                {
                    b.HasOne("RickLocalization.Domain.Dimensao", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoDimensaoId");

                    b.HasOne("RickLocalization.Domain.Dimensao", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemDimensaoId");

                    b.HasOne("RickLocalization.Domain.Personagem", "Personagem")
                        .WithMany()
                        .HasForeignKey("PersonagemId");

                    b.Navigation("Destino");

                    b.Navigation("Origem");

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("RickLocalization.Domain.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("RickLocalization.Domain.Venda", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
