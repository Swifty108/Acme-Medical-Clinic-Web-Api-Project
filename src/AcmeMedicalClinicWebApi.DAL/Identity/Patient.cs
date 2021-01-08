using AcmeMedicalClinicWebApi.DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class Patient : AppUser
    {
        public string InsuranceName { get; set; }
        public string InsuranceNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<LabOrder> LabOrders { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}