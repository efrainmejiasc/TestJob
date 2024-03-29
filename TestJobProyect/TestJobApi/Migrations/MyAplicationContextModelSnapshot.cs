﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestJobApi.DataModels;

namespace TestJobApi.Migrations
{
    [DbContext(typeof(MyAplicationContext))]
    partial class MyAplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestJobApi.DataModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("CveProducto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TestJobApi.DataModels.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("UserApp");
                });
#pragma warning restore 612, 618
        }
    }
}
