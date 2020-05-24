﻿using System;
using APBD11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APBD11.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD11.Models.Doctor", b =>
            {
                b.Property<int>("IdDoctor")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdDoctor")
                    .HasName("Doctor_pk");

                b.ToTable("Doctors");
            });

            modelBuilder.Entity("APBD11.Models.Medicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdMedicament")
                    .HasName("Medicament_pk");

                b.ToTable("Medicaments");
            });

            modelBuilder.Entity("APBD11.Models.Patient", b =>
            {
                b.Property<int>("IdPatient")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Birthdate")
                    .HasColumnType("date");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdPatient")
                    .HasName("Patient_pk");

                b.ToTable("Patients");
            });

            modelBuilder.Entity("APBD11.Models.Prescription", b =>
            {
                b.Property<int>("IdPrescription")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("Date")
                    .HasColumnType("date");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("date");

                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.HasKey("IdPrescription")
                    .HasName("Prescription_pk");

                b.HasIndex("IdDoctor");

                b.HasIndex("IdPatient");

                b.ToTable("Prescriptions");
            });

            modelBuilder.Entity("APBD11.Models.PrescriptionMedicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<string>("Details")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<int>("Dose")
                    .HasColumnType("int");

                b.HasKey("IdMedicament", "IdPrescription")
                    .HasName("Prescription_Medicament_pk");

                b.HasIndex("IdPrescription");

                b.ToTable("Prescription_Medicament");
            });

            modelBuilder.Entity("APBD11.Models.Prescription", b =>
            {
                b.HasOne("APBD11.Models.Doctor", "IdDoctorNavigation")
                    .WithMany("Prescription")
                    .HasForeignKey("IdDoctor")
                    .HasConstraintName("Prescription_Doctor")
                    .IsRequired();

                b.HasOne("APBD11.Models.Patient", "IdPatientNavigation")
                    .WithMany("Prescription")
                    .HasForeignKey("IdPatient")
                    .HasConstraintName("Prescription_Patient")
                    .IsRequired();
            });

            modelBuilder.Entity("APBD11.Models.PrescriptionMedicament", b =>
            {
                b.HasOne("APBD11.Models.Medicament", "IdMedicamentNavigation")
                    .WithMany("PrescriptionMedicament")
                    .HasForeignKey("IdMedicament")
                    .HasConstraintName("Prescription_Medicament_Medicament")
                    .IsRequired();

                b.HasOne("APBD11.Models.Prescription", "IdPrescriptionNavigation")
                    .WithMany("PrescriptionMedicament")
                    .HasForeignKey("IdPrescription")
                    .HasConstraintName("Prescription_Medicament_Prescription")
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}

