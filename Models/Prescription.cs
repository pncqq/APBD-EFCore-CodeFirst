namespace CW9.Models;

public class Prescription
{
    //Pola
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    //FK
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

    //Relacje
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicament { get; set; }
}