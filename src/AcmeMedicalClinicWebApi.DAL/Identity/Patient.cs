using AcmeMedicalClinicWebApi.DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AcmeMedicalClinicWebApi.DAL.Models
{
    public class Patient : AppUser
    {
        public string InsuranceName { get; set; }
        public string InsuranceNumber { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<LabOrder> LabOrders { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}