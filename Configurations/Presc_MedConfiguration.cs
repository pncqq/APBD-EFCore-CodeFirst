using CW9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW9.Configurations;

public class Presc_MedConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
{
    public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
    {
        //PK
        builder.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        //Props
        builder.Property(pm => pm.Dose).IsRequired(false);
        builder.Property(pm => pm.Details).HasMaxLength(100).IsRequired();

        //Relacje
        builder
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicament)
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}