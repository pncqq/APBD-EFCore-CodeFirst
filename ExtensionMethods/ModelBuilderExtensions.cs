using CW9.Controllers;
using CW9.Models;
using CW9.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace CW9.ExtensionMethods;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //Doctor
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Filip", LastName = "Michalski", Email = "test@.pl" }
        );
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 2, FirstName = "Michal", LastName = "Filipski", Email = "test1@.pl" }
        );

        //Patient
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Adam", LastName = "Mickiewicz", Email = "test3@.pl" }
        );
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 2, FirstName = "Adam", LastName = "Małysz", Email = "test4@.pl" }
        );

        //Medicament
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Depralin", Description = "Lek 1", Type = "Tabs" }
        );
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 2, Name = "Xanax", Description = "Lek 2", Type = "Tabs" }
        );

        //Prescription
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdDoctor = 1, IdPatient = 2, IdPrescription = 1,
                Date = DateTime.Now, DueDate = new DateTime(2025, 5, 1)
            }
        );

        //Prescription_meds
        modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Prescription_Medicament
            {
                IdPrescription = 1, IdMedicament = 2, Details = "Pacjent niestabilny psychicznie", Dose = 100
            }
        );
        //
        // //users
        // modelBuilder.Entity<User>().HasData(
        //     new User
        //     {
        //         Id = 1, Login = "admin", Password = "admin", RefreshToken = TokenService.GenerateRefreshToken(),
        //         RefreshTokenExp = DateTime.Now.AddDays(10)
        //     });
    }
}