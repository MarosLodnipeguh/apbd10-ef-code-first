using System.ComponentModel.DataAnnotations;

namespace apbd10_ef_code_first.DTOs;

public class PatientDto
{
    // [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
}