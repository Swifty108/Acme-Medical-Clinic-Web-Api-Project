using AcmeMedicalClinicWebApi.DAL.Models;
using System.Threading.Tasks;

namespace AcmeApartments.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<LabOrder> LabOrderRepository { get; }
        IRepository<Record> RecordRepository { get; }
        IRepository<Appointment> AppointmentRepository { get; }
        Task Save();
    }
}