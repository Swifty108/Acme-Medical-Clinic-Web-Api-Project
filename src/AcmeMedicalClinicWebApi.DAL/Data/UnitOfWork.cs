using AcmeApartments.DAL.Interfaces;
using AcmeMedicalClinicWebApi.DAL.Data;
using AcmeMedicalClinicWebApi.DAL.Models;
using System;
using System.Threading.Tasks;

namespace AcmeApartments.DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _dbContext;
        private GenericRepository<LabOrder> _labOrders;
        private GenericRepository<Record> _records;
        private GenericRepository<Appointment> _appointments;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<LabOrder> LabOrderRepository
        {
            get
            {
                return _labOrders ??
                    (_labOrders = new GenericRepository<LabOrder>(_dbContext));
            }
        }

        public IRepository<Record> RecordRepository
        {
            get
            {
                return _records ??
                    (_records = new GenericRepository<Record>(_dbContext));
            }
        }

        public IRepository<Appointment> AppointmentRepository
        {
            get
            {
                return _appointments ??
                    (_appointments = new GenericRepository<Appointment>(_dbContext));
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}