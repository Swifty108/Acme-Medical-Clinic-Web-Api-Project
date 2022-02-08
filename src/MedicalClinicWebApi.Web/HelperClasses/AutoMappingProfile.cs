using AutoMapper;
using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.DAL.Models;

namespace Apartments.BLL.HelperClasses
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //Appointemnt Logic Class in BLL

            CreateMap<AppointmentDto, Appointment>().ReverseMap();
            CreateMap<RecordDto, Record>().ReverseMap();
            CreateMap<LabOrderDto, LabOrder>().ReverseMap();
            CreateMap<LabResultDto, LabResult>().ReverseMap();
        }
    }
}