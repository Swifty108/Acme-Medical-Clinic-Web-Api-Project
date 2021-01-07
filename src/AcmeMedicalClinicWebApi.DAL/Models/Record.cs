using System;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}