using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EatMeApp.Models;

namespace EatMeApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20161101230556_CocineroAdded")]
    partial class CocineroAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("EatMeApp.Models.Cooker", b =>
                {
                    b.Property<int>("CocineroId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<string>("Cedula");

                    b.Property<int>("Codigo_Postal");

                    b.Property<string>("Contraseña");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Direccion");

                    b.Property<string>("Mail");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.Property<string>("Usuario");

                    b.HasKey("CocineroId");

                    b.ToTable("Cocineros");
                });

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
