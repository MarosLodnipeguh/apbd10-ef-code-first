using apbd10_ef_code_first.DTOs;

namespace apbd10_ef_code_first.Services;

public interface IDbService
{

    Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto);
    Task<int> AddPrescriptionMedicament(PrescribedMedicamentDto prescribedMedicamentDto, int prescriptionId);
    Task<bool> DoesPatientExist(int id);
    Task<int> AddPatient(PatientDto patientDto);
    Task<bool> DoesMedicamentExist(int id);
    Task<bool> DoesDoctorExist(int id);
    
    // 
    Task<PatientInfo> GetPatientInfo(int patientId);
    
}