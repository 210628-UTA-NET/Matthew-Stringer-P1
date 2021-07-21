﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreDL;

namespace StoreDL.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20210721200604_Annotations2")]
    partial class Annotations2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("StoreClasslib.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("StoreClasslib.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ProdId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("StoreFrontId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProdId");

                    b.HasIndex("StoreFrontId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("StoreClasslib.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProdId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Order");

                    b.HasIndex("ProdId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("StoreClasslib.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("StoreFrontId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreFrontId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StoreClasslib.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreClasslib.StoreFront", b =>
                {
                    b.Property<int>("StoreFrontId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("StoreFrontId");

                    b.ToTable("StoreFronts");
                });

            modelBuilder.Entity("StoreClasslib.InventoryItem", b =>
                {
                    b.HasOne("StoreClasslib.Product", "Prod")
                        .WithMany()
                        .HasForeignKey("ProdId");

                    b.HasOne("StoreClasslib.StoreFront", null)
                        .WithMany("Inventory")
                        .HasForeignKey("StoreFrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("StoreClasslib.LineItem", b =>
                {
                    b.HasOne("StoreClasslib.Order", "OrderObj")
                        .WithMany("LineItems")
                        .HasForeignKey("Order");

                    b.HasOne("StoreClasslib.Product", "Prod")
                        .WithMany()
                        .HasForeignKey("ProdId");

                    b.Navigation("OrderObj");

                    b.Navigation("Prod");
                });

            modelBuilder.Entity("StoreClasslib.Order", b =>
                {
                    b.HasOne("StoreClasslib.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreClasslib.StoreFront", null)
                        .WithMany("Orders")
                        .HasForeignKey("StoreFrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreClasslib.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("StoreClasslib.Order", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("StoreClasslib.StoreFront", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
