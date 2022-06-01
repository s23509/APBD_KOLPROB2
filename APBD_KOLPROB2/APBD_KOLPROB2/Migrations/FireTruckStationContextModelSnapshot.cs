﻿// <auto-generated />
using System;
using APBD_KOLPROB2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APBD_KOLPROB2.Migrations
{
    [DbContext(typeof(FireTruckStationContext))]
    partial class FireTruckStationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD_KOLPROB2.Entities.Action", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NeedSpecialEquipment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAction")
                        .HasName("Action_pk");

                    b.ToTable("Action");

                    b.HasData(
                        new
                        {
                            IdAction = 1,
                            EndTime = new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            NeedSpecialEquipment = false,
                            StartTime = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdAction = 2,
                            EndTime = new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            NeedSpecialEquipment = true,
                            StartTime = new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdAction = 3,
                            NeedSpecialEquipment = true,
                            StartTime = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("APBD_KOLPROB2.Entities.FireTruck", b =>
                {
                    b.Property<int>("IdFireTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OperationNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("SpecialEquipment")
                        .HasColumnType("bit");

                    b.HasKey("IdFireTruck")
                        .HasName("FireTruck_pk");

                    b.ToTable("FireTruck");

                    b.HasData(
                        new
                        {
                            IdFireTruck = 1,
                            OperationNumber = "1",
                            SpecialEquipment = true
                        },
                        new
                        {
                            IdFireTruck = 2,
                            OperationNumber = "11",
                            SpecialEquipment = false
                        },
                        new
                        {
                            IdFireTruck = 3,
                            OperationNumber = "113",
                            SpecialEquipment = false
                        },
                        new
                        {
                            IdFireTruck = 4,
                            OperationNumber = "2137",
                            SpecialEquipment = true
                        });
                });

            modelBuilder.Entity("APBD_KOLPROB2.Entities.FireTruckAction", b =>
                {
                    b.Property<int>("IdFireTruck")
                        .HasColumnType("int");

                    b.Property<int>("IdAction")
                        .HasColumnType("int");

                    b.Property<DateTime>("AssignmentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 6, 1, 17, 44, 52, 319, DateTimeKind.Local).AddTicks(7006));

                    b.HasKey("IdFireTruck", "IdAction")
                        .HasName("FireTruckAction.pk");

                    b.HasIndex("IdAction");

                    b.ToTable("FireTruck_Action");

                    b.HasData(
                        new
                        {
                            IdFireTruck = 1,
                            IdAction = 2,
                            AssignmentDate = new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdFireTruck = 4,
                            IdAction = 2,
                            AssignmentDate = new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdFireTruck = 2,
                            IdAction = 1,
                            AssignmentDate = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdFireTruck = 4,
                            IdAction = 3,
                            AssignmentDate = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            IdFireTruck = 3,
                            IdAction = 2,
                            AssignmentDate = new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("APBD_KOLPROB2.Entities.FireTruckAction", b =>
                {
                    b.HasOne("APBD_KOLPROB2.Entities.Action", "IdActionNavigation")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdAction")
                        .HasConstraintName("FireTruckAction_Action")
                        .IsRequired();

                    b.HasOne("APBD_KOLPROB2.Entities.FireTruck", "IdFireTruckNavigation")
                        .WithMany("FireTruckActions")
                        .HasForeignKey("IdFireTruck")
                        .HasConstraintName("FireTruckAction_FireTruck")
                        .IsRequired();

                    b.Navigation("IdActionNavigation");

                    b.Navigation("IdFireTruckNavigation");
                });

            modelBuilder.Entity("APBD_KOLPROB2.Entities.Action", b =>
                {
                    b.Navigation("FireTruckActions");
                });

            modelBuilder.Entity("APBD_KOLPROB2.Entities.FireTruck", b =>
                {
                    b.Navigation("FireTruckActions");
                });
#pragma warning restore 612, 618
        }
    }
}
