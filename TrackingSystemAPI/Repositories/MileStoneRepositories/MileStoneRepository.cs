using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.MileStoneRepositories
{
    public class MileStoneRepository : IMileStoneRepository
    {
        private readonly ApplicationDbContext _context;
        public MileStoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(MileStone mileStone)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MileStone Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MileStoneDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public MileStoneDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(MileStone mileStone)
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
