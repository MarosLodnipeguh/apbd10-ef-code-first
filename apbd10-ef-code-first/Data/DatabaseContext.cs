using apbd10_ef_code_first.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd10_ef_code_first.Data
{
    public class DatabaseContext : DbContext
    {
        protected DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@hospital.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@hospital.com"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Alice",
                    LastName = "Brown",
                    Email = "alice.brown@hospital.com"
                }
            });

            modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    BirthDate = DateTime.Parse("1985-06-15")
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Emily",
                    LastName = "Davis",
                    BirthDate = DateTime.Parse("1992-04-12")
                },
                new Patient
                {
                    IdPatient = 3,
                    FirstName = "Daniel",
                    LastName = "Wilson",
                    BirthDate = DateTime.Parse("2000-11-25")
                }
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Parse("2023-05-01"),
                    DueDate = DateTime.Parse("2023-05-15"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Parse("2023-06-01"),
                    DueDate = DateTime.Parse("2023-06-15"),
                    IdPatient = 2,
                    IdDoctor = 2
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = DateTime.Parse("2023-07-01"),
                    DueDate = DateTime.Parse("2023-07-15"),
                    IdPatient = 3,
                    IdDoctor = 3
                }
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Paracetamol",
                    Description = "Painkiller",
                    Type = "Tablet"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Ibuprofen",
                    Description = "Anti-inflammatory",
                    Type = "Tablet"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Amoxicillin",
                    Description = "Antibiotic",
                    Type = "Capsule"
                }
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 1,
                    Dose = 2,
                    Details = "Twice a day after meals"
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 2,
                    IdMedicament = 2,
                    Dose = 1,
                    Details = "Once a day before bed"
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 3,
                    IdMedicament = 3,
                    Dose = 3,
                    Details = "Three times a day before meals"
                }
            });
        }
    }
}
