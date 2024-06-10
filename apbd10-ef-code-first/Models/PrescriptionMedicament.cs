﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd10_ef_code_first.Models;

// asocjacja wiele do wielu, z dwoma kluczami obcymi, które są kluczami głównymi
[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; } // nullable
    [MaxLength(100)]
    public string Details { get; set; } = string.Empty;

    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
}