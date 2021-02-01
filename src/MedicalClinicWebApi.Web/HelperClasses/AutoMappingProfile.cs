using AutoMapper;
using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;

namespace Apartments.BLL.HelperClasses
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //Appointemnt Logic Class in BLL

            CreateMap<AppointmentDTO, Appointment>().ReverseMap();
            CreateMap<RecordDTO, Record>().ReverseMap();
            CreateMap<LabOrderDTO, LabOrder>().ReverseMap();
            CreateMap<LabResultDTO, LabResult>().ReverseMap();
        }
    }
}