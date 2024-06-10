using System.ComponentModel.DataAnnotations;

namespace apbd10_ef_code_first.DTOs;

public class PatientInfo
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    public List<PrescriptionInfo>? Prescriptions { get; set; }
    
}