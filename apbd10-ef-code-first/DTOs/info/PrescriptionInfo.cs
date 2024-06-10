using System.ComponentModel.DataAnnotations;

namespace apbd10_ef_code_first.DTOs;

public class PrescriptionInfo
{
    [Required]
    public int IdPrescription { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public List<MedicamentInfo> Medicaments { get; set; }
    [Required]
    public DoctorInfo Doctor { get; set; }
}