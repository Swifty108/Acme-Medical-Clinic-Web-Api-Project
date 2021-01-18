using AcmeMedicalClinicWebApi.BLL;
using AcmeMedicalClinicWebApi.DAL.Models;
using AutoMapper;

namespace AcmeApartments.BLL.HelperClasses
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //Appointemnt Logic Class in BLL

            CreateMap<AppointmentDto, Appointment>();

        }
    }
}