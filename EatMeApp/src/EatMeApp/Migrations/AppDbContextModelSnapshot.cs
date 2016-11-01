using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EatMeApp.Models;

namespace EatMeApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("EatMeApp.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("FoodType");

                    b.Property<double>("LocationX");

                    b.Property<double>("LocationY");

                    b.Property<int>("SoldTickets");

                    b.Property<double>("TicketPrice");

                    b.Property<string>("Title");

                    b.Property<int>("TotalTickets");

                    b.HasKey("EventId");

                    b.ToTable("Eventos");
                });
        }
    }
}
