﻿// <auto-generated />
using System;
using BolsaFamilia.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BolsaFamilia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BolsaFamilia.Modelos.AliquotaTipoBeneficio", b =>
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

            modelBuilder.Entity("BolsaFamilia.Modelos.Beneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int>("MotivoRejeicao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaId")
                        .IsUnique();

                    b.ToTable("Beneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Modelos.Familia", b =>
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

            modelBuilder.Entity("BolsaFamilia.Modelos.HistoricoBeneficio", b =>
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

            modelBuilder.Entity("BolsaFamilia.Modelos.Pessoa", b =>
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

            modelBuilder.Entity("BolsaFamilia.Modelos.PessoaFamilia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDesvinculo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVinculo")
                        .HasColumnType("datetime2");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int>("MotivoDesvinculo")
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

            modelBuilder.Entity("BolsaFamilia.Modelos.RendaPessoa", b =>
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

            modelBuilder.Entity("BolsaFamilia.Modelos.Beneficio", b =>
                {
                    b.HasOne("BolsaFamilia.Modelos.Familia", "Familia")
                        .WithOne("Beneficio")
                        .HasForeignKey("BolsaFamilia.Modelos.Beneficio", "FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");
                });

            modelBuilder.Entity("BolsaFamilia.Modelos.HistoricoBeneficio", b =>
                {
                    b.HasOne("BolsaFamilia.Modelos.Beneficio", "Beneficio")
                        .WithMany()
                        .HasForeignKey("BeneficioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficio");
                });

            modelBuilder.Entity("BolsaFamilia.Modelos.PessoaFamilia", b =>
                {
                    b.HasOne("BolsaFamilia.Modelos.Familia", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaFamilia.Modelos.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Modelos.RendaPessoa", b =>
                {
                    b.HasOne("BolsaFamilia.Modelos.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BolsaFamilia.Modelos.Familia", b =>
                {
                    b.Navigation("Beneficio")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}