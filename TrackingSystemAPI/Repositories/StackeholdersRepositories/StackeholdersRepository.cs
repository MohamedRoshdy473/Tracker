using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.StackeholdersRepositories
{
    public class StackeholdersRepository : IStackeholdersRepository
    {
        private readonly ApplicationDbContext _context;
        public StackeholdersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Stackeholders stackeholders)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Stackeholders Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StackeholdersDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public StackeholdersDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Stackeholders stackeholders)
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
