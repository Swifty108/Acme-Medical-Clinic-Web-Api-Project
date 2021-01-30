using MedicalClinicWebApi.BLL.DTOs;
using MedicalClinicWebApi.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IRecordsLogic
    {
        Task<IEnumerable<Record>> GetAllRecords(string patientId);
        Task<Record> GetRecordByID(int recordId);
        Task<RecordDTO> CreateRecord(RecordDTO recordDTO);
        Task UpdateRecord(RecordDTO record);
        Task DeleteRecord(int recordId);

    }
}
