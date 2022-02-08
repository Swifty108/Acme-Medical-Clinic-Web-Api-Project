using MedicalClinicWebApi.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.BLLDTOs
{
    public class LabOrderDto
    {
        public int LabOrderId { get; set; }
        public string LabName { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime OrderDate { get; set; }

        public LabResult Result { get; set; }
        public string PatientId { get; set; }
    }
}