using MedicalClinicWebApi.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicWebApi.BLL.DTOs
{
    public class RecordDto
    {
        public int RecordId { get; set; }
        public string Notes { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime DateCreated { get; set; }

        public string PatientId { get; set; }
    }
}
