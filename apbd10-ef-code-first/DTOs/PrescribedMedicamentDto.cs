using System.ComponentModel.DataAnnotations;

namespace apbd10_ef_code_first.DTOs;

public class PrescribedMedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }
    [Required]
    public int Dose { get; set; }
    [MaxLength(1000)]
    public string Details { get; set; }
}