﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreP.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookStore.Models.Author", b =>
                {
                    b.Property<int>("authourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("authorName")
                        .HasColumnType("longtext");

                    b.HasKey("authourId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AuthorauthourId")
                        .HasColumnType("int");

                    b.Property<string>("bookDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("bookName")
                        .HasColumnType("longtext");

                    b.Property<string>("imgURL")
                        .HasColumnType("longtext");

                    b.HasKey("bookId");

                    b.HasIndex("AuthorauthourId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.HasOne("BookStore.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorauthourId");

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}
