using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EatMeApp.Models;

namespace EatMeApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20161112225900_StartEndEvent")]
    partial class StartEndEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("EatMeApp.Models.Commensal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("IdentityCard");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Preferences");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Commnesals");
                });

            modelBuilder.Entity("EatMeApp.Models.Cooker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Bio");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("IdentityCard");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cookers");
                });

            modelBuilder.Entity("EatMeApp.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CookerId");

                    b.Property<string>("Description");

                    b.Property<int>("FoodType");

                    b.Property<double>("LocationX");

                    b.Property<double>("LocationY");

                    b.Property<int>("SoldTickets");

                    b.Property<double>("TicketPrice");

                    b.Property<string>("Title");

                    b.Property<int>("TotalTickets");

                    b.Property<DateTime>("endTime");

                    b.Property<DateTime>("startTime");

                    b.HasKey("Id");

                    b.HasIndex("CookerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EatMeApp.Models.EventCommensal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommensalId");

                    b.Property<int>("EventId");

                    b.HasKey("Id");

                    b.ToTable("EventCommnesals");
                });

            modelBuilder.Entity("EatMeApp.Models.Event", b =>
                {
                    b.HasOne("EatMeApp.Models.Cooker", "Cooker")
                        .WithMany()
                        .HasForeignKey("CookerId");
                });
        }
    }
}
