using System.ComponentModel.DataAnnotations;

namespace apbd10_ef_code_first.DTOs;

public class DoctorInfo
{
    [Required]
    public int IdDoctor { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
}