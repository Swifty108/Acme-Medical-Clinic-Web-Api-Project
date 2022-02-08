using MedicalClinicWebApi.DAL.Models;
using System.Threading.Tasks;

namespace Apartments.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<LabOrder> LabOrderRepository { get; }
        IRepository<Record> RecordRepository { get; }
        IRepository<Appointment> AppointmentRepository { get; }

        Task Save();
    }
}