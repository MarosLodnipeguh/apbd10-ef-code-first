using apbd10_ef_code_first.Data;
using apbd10_ef_code_first.DTOs;
using apbd10_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd10_ef_code_first.Services;

public class DbService : IDbService
{
    
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    
    public async Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        var NewPrescription = new Prescription
        {
            Date = newPrescriptionDto.Date,
            DueDate = newPrescriptionDto.DueDate,
            IdPatient = newPrescriptionDto.Patient.IdPatient,
            IdDoctor = newPrescriptionDto.IdDoctor
        };
        
        await _context.Prescriptions.AddAsync(NewPrescription);
        await _context.SaveChangesAsync();
        
        return await Task.FromResult(NewPrescription.IdPrescription);
    }
    
    public async Task<int> AddPrescriptionMedicament (PrescribedMedicamentDto prescribedMedicamentDto, int prescriptionId)
    {
        var newPrescriptionMedicament = new PrescriptionMedicament
        {
            IdMedicament = prescribedMedicamentDto.IdMedicament,
            IdPrescription = prescriptionId,
            Dose = prescribedMedicamentDto.Dose,
            Details = prescribedMedicamentDto.Details
        };
        
        await _context.PrescriptionMedicaments.AddAsync(newPrescriptionMedicament);
        await _context.SaveChangesAsync();
        return await Task.FromResult(newPrescriptionMedicament.IdMedicament);
    }

    public async Task<bool> DoesPatientExist(int id)
    {
        var exists = await _context.Patients.AnyAsync(p => p.IdPatient == id);
        return exists;
    }

    public async Task<int> AddPatient(PatientDto patientDto)
    {
        var newPatient = new Patient
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            BirthDate = patientDto.BirthDate
        };
        
        await _context.Patients.AddAsync(newPatient);
        await _context.SaveChangesAsync();
        return await Task.FromResult(newPatient.IdPatient);
    }

    public async Task<bool> DoesMedicamentExist(int id)
    {
        var exists = await _context.Medicaments.AnyAsync(m => m.IdMedicament == id);
        return exists;
    }

    public async Task<bool> DoesDoctorExist(int id)
    {
        var exists = await _context.Doctors.AnyAsync(d => d.IdDoctor == id);
        return exists;
    }
    
    // =========================== Patient info ===========================
    
    public async Task<PatientInfo> GetPatientInfo(int patientId)
    {
        var patient = await GetPatient(patientId);
        var prescriptions = await GetPrescriptionsInfo(patientId);
        
        var patientInfo = new PatientInfo
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = prescriptions.ToList()
            // Prescriptions = null
        };
        
        return patientInfo;
    }
    
    // for getting Patient info
    private async Task<PatientDto> GetPatient(int patientId)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
        var patientInfo = new PatientDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate
        };
        return patientInfo;
    }
    
    // for getting Prescriptions list
    private async Task<IEnumerable<PrescriptionInfo>> GetPrescriptionsInfo(int patientId)
    {
        var prescriptions = await _context.Prescriptions.Where(p => p.IdPatient == patientId).ToListAsync();
        var prescriptionInfos = new List<PrescriptionInfo>();
        
        foreach (var prescription in prescriptions)
        {
            var prescriptionInfo = new PrescriptionInfo
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Medicaments = GetMedicamentsInfo(prescription.IdPrescription).Result.ToList(),
                Doctor = GetDoctor(prescription.IdDoctor).Result
            };
            prescriptionInfos.Add(prescriptionInfo);
        }
        
        return prescriptionInfos;
    }
    
    
    
    // for getting Medicaments list
    private async Task<IEnumerable<MedicamentInfo>> GetMedicamentsInfo(int prescriptionId)
    {
        var presMedicaments = await _context.PrescriptionMedicaments.Where(pm => pm.IdPrescription == prescriptionId).ToListAsync();
        
        var medicamentInfos = new List<MedicamentInfo>();
        
        foreach (var m in presMedicaments)
        {
            var medicamentInfo = new MedicamentInfo
            {
                IdMedicament = m.IdMedicament,
                Name = GetMedicamentName(m.IdMedicament).Result,
                Dose = m.Dose,
                Details = m.Details
            };
            medicamentInfos.Add(medicamentInfo);
        }

        return medicamentInfos;
    }
    
    // for getting Medicament name
    private async Task<string> GetMedicamentName(int medicamentId)
    {
        var medicament = await _context.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == medicamentId);
        string medicamentName = medicament.Name;
        return medicamentName;
    }
    
    // for getting Doctor name
    private async Task<DoctorInfo> GetDoctor(int doctorId)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == doctorId);
        var doctorInfo = new DoctorInfo
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName
        };
        return doctorInfo;
    }

}