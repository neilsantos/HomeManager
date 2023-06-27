﻿// <auto-generated />
using System;
using Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230627212020_terceira")]
    partial class terceira
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Dominio.Entidades.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Dominio.Entidades.NotaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RefNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NotaFiscalId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoPaiId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("NotaFiscalId")
                        .IsUnique()
                        .HasFilter("[NotaFiscalId] IS NOT NULL");

                    b.HasIndex("ProdutoPaiId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.NotaFiscal", "NotaFiscal")
                        .WithOne("Produto")
                        .HasForeignKey("Dominio.Entidades.Produto", "NotaFiscalId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Dominio.Entidades.Produto", "ProdutoPai")
                        .WithMany("Acessorios")
                        .HasForeignKey("ProdutoPaiId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Marca");

                    b.Navigation("NotaFiscal");

                    b.Navigation("ProdutoPai");
                });

            modelBuilder.Entity("Dominio.Entidades.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Dominio.Entidades.Marca", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Dominio.Entidades.NotaFiscal", b =>
                {
                    b.Navigation("Produto")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.Navigation("Acessorios");
                });
#pragma warning restore 612, 618
        }
    }
}
