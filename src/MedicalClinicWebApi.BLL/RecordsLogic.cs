using Apartments.DAL.Interfaces;
using MedicalClinicWebApi.BLLDTOs;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.DAL.Identity;
using MedicalClinicWebApi.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MedicalClinicWebApi.BLL
{
    public class RecordsLogic : IRecordsLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecordsLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Record>> GetAllRecords(string patientId)
        {
            var records = await _unitOfWork.RecordRepository.Get(filter: u => u.PatientId == patientId, includeProperties: "Patient").ToListAsync();

            return records.Count == 0 ? null : records;
        }

        public async Task<Record> GetRecordByID(int recordId)
        {
            var record = await _unitOfWork.RecordRepository.GetByID(recordId);
            return record;
        }

        public async Task<RecordDto> CreateRecord(RecordDto record)
        {
            //var apptDateTime = Convert.ToDateTime(appointmentDto.AppointmentDateTime);
            //appointmentDto.AppointmentDateTime = apptDateTime;

            var recordEntity = _mapper.Map<Record>(record);

            await _unitOfWork.RecordRepository.Insert(recordEntity);
            await _unitOfWork.Save();

            var createdRecord = _mapper.Map<RecordDto>(recordEntity);

            return createdRecord;
        }

        public async Task UpdateRecord(RecordDto record)
        {
            var recordEntity = _mapper.Map<Record>(record);

            _unitOfWork.RecordRepository.Update(recordEntity);
            await _unitOfWork.Save();
        }

        public async Task DeleteRecord(int recordId)
        {
            await _unitOfWork.AppointmentRepository.Delete(recordId);
            await _unitOfWork.Save();
        }
    }
}