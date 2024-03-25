﻿// <auto-generated />
using System;
using BolsaFamilia.Shared.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BolsaFamilia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240325141708_DataRejeicaoBeneficio")]
    partial class DataRejeicaoBeneficio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.AliquotaTipoBeneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoBeneficio")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("AliquotaTipoBeneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.Beneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataBloqueio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCalculoRejeicao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int?>("MotivoBloqueio")
                        .HasColumnType("int");

                    b.Property<int?>("MotivoRejeicao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaId")
                        .IsUnique();

                    b.ToTable("Beneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Familia");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.HistoricoBeneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BeneficioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BeneficioId");

                    b.ToTable("HistoricoBeneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.PessoaFamilia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataDesvinculo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVinculo")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int?>("MotivoDesvinculo")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoVinculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("PessoaFamilia");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.RendaPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("RendaPessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.Beneficio", b =>
                {
                    b.HasOne("BolsaFamilia.Shared.Entity.Entity.Familia", "Familia")
                        .WithOne("Beneficio")
                        .HasForeignKey("BolsaFamilia.Shared.Entity.Entity.Beneficio", "FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.HistoricoBeneficio", b =>
                {
                    b.HasOne("BolsaFamilia.Shared.Entity.Entity.Beneficio", "Beneficio")
                        .WithMany()
                        .HasForeignKey("BeneficioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.PessoaFamilia", b =>
                {
                    b.HasOne("BolsaFamilia.Shared.Entity.Entity.Familia", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaFamilia.Shared.Entity.Entity.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.RendaPessoa", b =>
                {
                    b.HasOne("BolsaFamilia.Shared.Entity.Entity.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Shared.Entity.Entity.Familia", b =>
                {
                    b.Navigation("Beneficio")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
