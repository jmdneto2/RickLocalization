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
    [Migration("20210126104647_Initial")]
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

            modelBuilder.Entity("RickLocalization.Domain.Personagem", b =>
                {
                    b.HasOne("RickLocalization.Domain.Dimensao", "PersonagemDimensao")
                        .WithMany()
                        .HasForeignKey("PersonagemDimensaoDimensaoId");

                    b.Navigation("PersonagemDimensao");
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
#pragma warning restore 612, 618
        }
    }
}
