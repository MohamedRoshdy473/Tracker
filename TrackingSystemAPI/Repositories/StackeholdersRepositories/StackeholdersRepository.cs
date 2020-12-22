using Microsoft.EntityFrameworkCore;
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
        public void Add(StackeholdersDTO stackeholdersDTO)
        {
            Stackeholders stackeholders = new Stackeholders();
            //stackeholders.Id = stackeholdersDTO.Id;
            stackeholders.StackeholderName = stackeholdersDTO.StackeholderName;
            stackeholders.Mobile = stackeholdersDTO.Mobile;
            stackeholders.Rank = stackeholdersDTO.Rank;
            stackeholders.Description = stackeholdersDTO.Description;
            stackeholders.ProjectId = stackeholdersDTO.ProjectId;
            _context.stackeholders.Add(stackeholders);
        }
        public void Delete(int id)
        {
            Stackeholders stackeholders = Find(id);
            _context.stackeholders.Remove(stackeholders);
        }
        public Stackeholders Find(int id)
        {
           return _context.stackeholders.Find(id);
        }
        public IEnumerable<StackeholdersDTO> GetAll()
        {

            var stackeholders = _context.stackeholders.Select(stack => new StackeholdersDTO
            {
                Id = stack.Id,
                StackeholderName = stack.StackeholderName,
                ProjectId = stack.ProjectId,
                ProjectName = stack.Project.ProjectName,
                Mobile = stack.Mobile,
                Rank = stack.Rank,
                Description = stack.Description
            }).ToList() ;
            return stackeholders;
        }
        public StackeholdersDTO GetById(int id)
        {
            var stack = _context.stackeholders.Include(p => p.Project).FirstOrDefault(e => e.Id == id);
            StackeholdersDTO stackeholdersDTO = new StackeholdersDTO
            {
                Id = stack.Id,
                StackeholderName = stack.StackeholderName,
                ProjectId = stack.ProjectId,
                ProjectName = stack.Project.ProjectName,
                Mobile = stack.Mobile,
                Rank = stack.Rank,
                Description = stack.Description
            };
            return stackeholdersDTO;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(StackeholdersDTO stackeholdersDTO)
        {
            Stackeholders stackeholders = new Stackeholders();
            stackeholders.Id = stackeholdersDTO.Id;
            stackeholders.StackeholderName = stackeholdersDTO.StackeholderName;
            stackeholders.Mobile = stackeholdersDTO.Mobile;
            stackeholders.Rank = stackeholdersDTO.Rank;
            stackeholders.Description = stackeholdersDTO.Description;
            stackeholders.ProjectId = stackeholdersDTO.ProjectId;
            _context.Entry(stackeholders).State = EntityState.Modified;
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
