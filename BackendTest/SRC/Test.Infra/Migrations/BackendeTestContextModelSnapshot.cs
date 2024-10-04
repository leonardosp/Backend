﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Test.Infra;

#nullable disable

namespace Test.Infra.Migrations
{
    [DbContext(typeof(BackendeTestContext))]
    partial class BackendeTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Test.Domain.Alugueis.Aluguel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevisaoFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EntregadorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MotoId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("ValorPrevisto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EntregadorId");

                    b.HasIndex("MotoId");

                    b.ToTable("Alugueis");
                });

            modelBuilder.Entity("Test.Domain.Entregadores.Entregador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<string>("ImagemCNH")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroCnh")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCnh")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Entregadores");
                });

            modelBuilder.Entity("Test.Domain.Motos.Moto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ano")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Motos");
                });

            modelBuilder.Entity("Test.Domain.Alugueis.Aluguel", b =>
                {
                    b.HasOne("Test.Domain.Entregadores.Entregador", "Entregador")
                        .WithMany("Alugueis")
                        .HasForeignKey("EntregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Domain.Motos.Moto", "Moto")
                        .WithMany("Alugueis")
                        .HasForeignKey("MotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entregador");

                    b.Navigation("Moto");
                });

            modelBuilder.Entity("Test.Domain.Entregadores.Entregador", b =>
                {
                    b.Navigation("Alugueis");
                });

            modelBuilder.Entity("Test.Domain.Motos.Moto", b =>
                {
                    b.Navigation("Alugueis");
                });
#pragma warning restore 612, 618
        }
    }
}
