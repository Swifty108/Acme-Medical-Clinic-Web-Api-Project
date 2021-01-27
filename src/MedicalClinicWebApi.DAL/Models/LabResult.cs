using System;

namespace MedicalClinicWebApi.DAL.Models
{
    public class LabResult
    {
        public int LabResultId { get; set; }
        public string Notes { get; set; }
        public DateTime ResultsDate { get; set; }
        public int LabOrderId { get; set; }
        public LabOrder LabOrder { get; set; }

    }
}