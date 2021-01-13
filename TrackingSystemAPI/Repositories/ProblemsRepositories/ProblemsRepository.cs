using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProblemsRepositories
{
    public class ProblemsRepository : IProblemsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProblemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Problems problems)
        {
            _context.problems.Add(problems);
        }

        public void Delete(int id)
        {
            var problem = Find(id);
            _context.problems.Remove(problem);
        }

        public Problems Find(int id)
        {
            return _context.problems.Find(id);
        }

        public IEnumerable<Problems> GetAll()
        {
            return _context.problems.ToList();
        }

        public Problems GetById(int id)
        {
            var problem=_context.problems.Where(p => p.Id == id).FirstOrDefault();
            return problem;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Problems problems)
        {
            _context.Entry(problems).State = EntityState.Modified;
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
