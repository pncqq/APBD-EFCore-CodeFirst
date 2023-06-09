namespace CW9.Models;

public class Prescription_Medicament
{
    //PK FK
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    
    public int? Dose { get; set; }
    public string Details { get; set; }
    
    //Relacje
    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}