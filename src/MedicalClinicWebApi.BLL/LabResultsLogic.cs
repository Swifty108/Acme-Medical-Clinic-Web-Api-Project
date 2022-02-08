using Apartments.DAL.Interfaces;
using AutoMapper;
using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL
{
    public class LabResultsLogic : ILabResultsLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LabResultsLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LabResult> GetLabResult(int labOrderId)
        {
            var labResult = await _unitOfWork.LabResultRepository.Get(filter: u => u.LabOrderId == labOrderId, includeProperties: "LabOrder").FirstOrDefaultAsync();

            return labResult;
        }

        public async Task<LabResult> GetLabResultByID(int labResultId)
        {
            var labResult = await _unitOfWork.LabResultRepository.Get(filter: u => u.LabResultId == labResultId, includeProperties: "LabOrder").FirstOrDefaultAsync();

            return labResult;
        }

        public async Task<LabResultDto> CreateLabResult(LabResultDto labResultDto)
        {
            var resultEntity = _mapper.Map<LabResult>(labResultDto);

            await _unitOfWork.LabResultRepository.Insert(resultEntity);
            await _unitOfWork.Save();

            var resultDto = _mapper.Map<LabResultDto>(resultEntity);

            return resultDto;
        }

        public async Task UpdateLabResult(LabResultDto labResultDto)
        {
            var labResultEntity = _mapper.Map<LabResult>(labResultDto);

            _unitOfWork.LabResultRepository.Update(labResultEntity);
            await _unitOfWork.Save();
        }

        public async Task DeleteLabResult(int labResultId)
        {
            await _unitOfWork.LabResultRepository.Delete(labResultId);
            await _unitOfWork.Save();
        }
    }
}