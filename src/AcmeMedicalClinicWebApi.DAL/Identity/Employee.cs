using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeMedicalClinicWebApi.DAL.Identity
{
    public class Employee : AppUser
    {
        public string Department { get; set; }
    }
}
