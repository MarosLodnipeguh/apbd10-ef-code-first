using System.ComponentModel.DataAnnotations;
using apbd10_ef_code_first.Models;

namespace apbd10_ef_code_first.DTOs;

public class NewPrescriptionDto
{
    [Required]
    public PatientDto Patient { get; set; }
    
    [Required]
    public List<PrescribedMedicamentDto> Medicaments { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
}