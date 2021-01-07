using System;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class LabOrder
    {
        public int Id { get; set; }
        public string LabName { get; set; }
        public DateTime OrderDate { get; set; }
        public LabResult Result { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}