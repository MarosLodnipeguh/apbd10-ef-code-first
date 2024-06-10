using apbd10_ef_code_first.DTOs;
using apbd10_ef_code_first.Models;
using apbd10_ef_code_first.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd10_ef_code_first.Controllers;

[ApiController]
[Route("api/prescriptions")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _service;

    public PrescriptionsController(IDbService dbService)
    {
        _service = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDto request)
    {
        
        // czy pacjent istnieje, jesli nie to dodaj
        if (!await _service.DoesPatientExist(request.Patient.IdPatient))
        {
            await _service.AddPatient(request.Patient);
        }
        
        // czy podane leki istnieją
        foreach (var medicament in request.Medicaments)
        {
            if (!await _service.DoesMedicamentExist(medicament.IdMedicament))
            {
                return BadRequest("Medicament does not exist");
            }
        }
        
        // czy nie za dużo leków
        if (request.Medicaments.Count > 10)
        {
            return BadRequest("Too many medicaments");
        }

        // czy data waznosci jest pozniej niz data wypisania
        if (request.DueDate < request.Date)
        {
            return BadRequest("Due date is earlier than prescription date");
        }

        // czy lekarz istnieje
        if (!await _service.DoesDoctorExist(request.IdDoctor))
        {
            return BadRequest("Doctor does not exist");
        }

        var prescriptionId = await _service.AddPrescription(request);

        foreach (var medicament in request.Medicaments)
        {
            PrescribedMedicamentDto med = new PrescribedMedicamentDto
            {
                IdMedicament = medicament.IdMedicament,
                Dose = medicament.Dose,
                Details = medicament.Details,
            };
            await _service.AddPrescriptionMedicament(med, prescriptionId);
        }

        return Ok("Prescription added");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPatientInfo(int patientId)
    {
        if (!await _service.DoesPatientExist(patientId))
        {
            return BadRequest("Patient does not exist");
        }

        var patientInfo = await _service.GetPatientInfo(patientId);
        return Ok(patientInfo);
    }

    
    
}