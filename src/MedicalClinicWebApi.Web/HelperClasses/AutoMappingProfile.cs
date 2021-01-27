using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using AutoMapper;

namespace Apartments.BLL.HelperClasses
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //Appointemnt Logic Class in BLL

            CreateMap<AppointmentDTO, Appointment>();

        }
    }
}