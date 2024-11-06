﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Orders.Persistence;

#nullable disable

namespace Orders.Persistence.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Orders.Persistence.DbEntities.OrderDb", b =>
                {
                    b.Property<Guid>("SystemId")
                        .HasColumnType("uuid");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("integer");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PublicUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("SystemUserId")
                        .HasColumnType("uuid");

                    b.HasKey("SystemId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Orders.Persistence.DbEntities.ProductDb", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "SystemId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Orders.Persistence.DbEntities.ProductDb", b =>
                {
                    b.HasOne("Orders.Persistence.DbEntities.OrderDb", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Orders.Persistence.DbEntities.OrderDb", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
