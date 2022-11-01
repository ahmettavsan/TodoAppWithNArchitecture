﻿// <auto-generated />
using ABC.TODOAPP.DATAACCESS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABC.TODOAPP.DATAACCESS.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20221028194322_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABC.TODOAPP.ENTITIES.Domains.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComplated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Work");
                });
#pragma warning restore 612, 618
        }
    }
}