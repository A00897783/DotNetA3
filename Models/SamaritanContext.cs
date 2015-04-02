using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class SamaritanContext : DbContext
    {

        public SamaritanContext()
            : base("GoodSamaritanConnection")
        {
        }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<AbuserRelationship> AbuserRelationships { get; set; }

        public DbSet<Age> Ages { get; set; }

        public DbSet<AssignedWorker> AssignedWorkers { get; set; }

        public DbSet<Crisis> Crises { get; set; }

        public DbSet<DuplicateFile> DuplicateFiles { get; set; }

        public DbSet<Ethnicity> Ethnicities { get; set; }

        public DbSet<FamilyViolenceFile> FamilyViolenceFiles { get; set; }

        public DbSet<FiscalYear> FiscalYears { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ReferralContact> ReferralContacts { get; set; }

        public DbSet<ReferralSource> ReferralSources { get; set; }

        public DbSet<RepeatClient> RepeatClients { get; set; }

        public DbSet<RiskLevel> RiskLevels { get; set; }

        public DbSet<RiskStatus> RiskStatus { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<StatusOfFile> StatusOfFiles { get; set; }

        public DbSet<VictimOfIncident> VictimOfIncidents { get; set; }

        public DbSet<Smart> Smarts { get; set; }

        public DbSet<BadDateReport> BadDateReports { get; set; }

        public DbSet<CityOfAssault> CityOfAssaults { get; set; }

        public DbSet<CityOfResidence> CityOfResidences { get; set; }

        public DbSet<DrugFacilitatedAssault> DrugFacilitatedAssaults { get; set; }

        public DbSet<EvidenceStored> EvidenceStoreds { get; set; }

        public DbSet<HIVMeds> HIVMeds { get; set; }

        public DbSet<HospitalAttended> HospitalAttendeds { get; set; }

        public DbSet<MedicalOnly> MedicalOnlies { get; set; }

        public DbSet<MultiplePerpetrators> MultiplePerpetrators { get; set; }

        public DbSet<PoliceAttendance> PoliceAttendances { get; set; }

        public DbSet<PoliceReported> PoliceReporteds { get; set; }

        public DbSet<ReferredToCBVS> ReferredToCBVS { get; set; }

        public DbSet<ReferringHospital> ReferringHospitals { get; set; }

        public DbSet<SexWorkExploitation> SexWorkExploitations { get; set; }

        public DbSet<SocialWorkAttendance> SocialWorkAttendances { get; set; }

        public DbSet<ThirdPartyReport> ThirdPartyReports { get; set; }

        public DbSet<VictimServicesAttendance> VictimServicesAttendances { get; set; }
    
    }
}
