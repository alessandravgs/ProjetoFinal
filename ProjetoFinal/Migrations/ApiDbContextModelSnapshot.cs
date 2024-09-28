﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.Data;

#nullable disable

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlergiaPaciente", b =>
                {
                    b.Property<int>("AlergiasId")
                        .HasColumnType("int");

                    b.Property<int>("PacientesId")
                        .HasColumnType("int");

                    b.HasKey("AlergiasId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("AlergiaPaciente");
                });

            modelBuilder.Entity("CoberturaCurativo", b =>
                {
                    b.Property<int>("CoberturasId")
                        .HasColumnType("int");

                    b.Property<int>("CurativosId")
                        .HasColumnType("int");

                    b.HasKey("CoberturasId", "CurativosId");

                    b.HasIndex("CurativosId");

                    b.ToTable("CoberturaCurativo");
                });

            modelBuilder.Entity("ComorbidadePaciente", b =>
                {
                    b.Property<int>("ComorbidadesId")
                        .HasColumnType("int");

                    b.Property<int>("PacientesId")
                        .HasColumnType("int");

                    b.HasKey("ComorbidadesId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("ComorbidadePaciente");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Alergia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alergias");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Cobertura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coberturas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Comorbidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comorbidades");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Curativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("LesaoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orientacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LesaoId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Curativos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.EvolucaoLesao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<int?>("CurativoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<double>("Largura")
                        .HasColumnType("float");

                    b.Property<int>("LesaoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<double>("Profundidade")
                        .HasColumnType("float");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurativoId")
                        .IsUnique()
                        .HasFilter("[CurativoId] IS NOT NULL");

                    b.HasIndex("LesaoId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("EvolucaoLesao");
                });

            modelBuilder.Entity("ProjetoFinal.Models.ImagemCurativo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CurativoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CurativoId");

                    b.ToTable("ImagensCurativos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Lesao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Amputacao")
                        .HasColumnType("bit");

                    b.Property<bool>("Cirurgica")
                        .HasColumnType("bit");

                    b.Property<bool>("DeiscenciaCirurgica")
                        .HasColumnType("bit");

                    b.Property<bool>("Desbridamento")
                        .HasColumnType("bit");

                    b.Property<string>("Detalhes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hanseniase")
                        .HasColumnType("bit");

                    b.Property<bool>("Infectada")
                        .HasColumnType("bit");

                    b.Property<int>("LadoRegiao")
                        .HasColumnType("int");

                    b.Property<int>("Membro")
                        .HasColumnType("int");

                    b.Property<bool>("Miiase")
                        .HasColumnType("bit");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("Regiao")
                        .HasColumnType("int");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<bool>("Traumatica")
                        .HasColumnType("bit");

                    b.Property<int>("UlceraVenosa")
                        .HasColumnType("int");

                    b.Property<int>("UltimaEvolucaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Lesoes");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("AlergiaPaciente", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Alergia", null)
                        .WithMany()
                        .HasForeignKey("AlergiasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoberturaCurativo", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Cobertura", null)
                        .WithMany()
                        .HasForeignKey("CoberturasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Curativo", null)
                        .WithMany()
                        .HasForeignKey("CurativosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComorbidadePaciente", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Comorbidade", null)
                        .WithMany()
                        .HasForeignKey("ComorbidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoFinal.Models.Curativo", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Lesao", "Lesao")
                        .WithMany("Curativos")
                        .HasForeignKey("LesaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Lesao");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("ProjetoFinal.Models.EvolucaoLesao", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Curativo", "Curativo")
                        .WithOne("EvolucaoLesao")
                        .HasForeignKey("ProjetoFinal.Models.EvolucaoLesao", "CurativoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjetoFinal.Models.Lesao", "Lesao")
                        .WithMany("Evolucoes")
                        .HasForeignKey("LesaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Curativo");

                    b.Navigation("Lesao");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("ProjetoFinal.Models.ImagemCurativo", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Curativo", "Curativo")
                        .WithMany("Imagens")
                        .HasForeignKey("CurativoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curativo");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Lesao", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Paciente", "Paciente")
                        .WithMany("Lesoes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Curativo", b =>
                {
                    b.Navigation("EvolucaoLesao")
                        .IsRequired();

                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Lesao", b =>
                {
                    b.Navigation("Curativos");

                    b.Navigation("Evolucoes");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Paciente", b =>
                {
                    b.Navigation("Lesoes");
                });
#pragma warning restore 612, 618
        }
    }
}
