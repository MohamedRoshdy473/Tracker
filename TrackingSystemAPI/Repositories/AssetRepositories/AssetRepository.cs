using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.AssetRepositories
{
    public class AssetRepository:IAssetRepository
    { 
    private readonly ApplicationDbContext _context;
    public AssetRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Add(Asset Asset)
    {
        _context.assets.Add(Asset);
    }

    public void Delete(int id)
    {
        Asset Asset = Find(id);
        _context.assets.Remove(Asset);
    }
    public Asset Find(int id)
    {
        return _context.assets.Find(id);
    }

    public IEnumerable<Asset> GetAll()
    {
        return _context.assets.ToList();
    }

    public Asset GetById(int id)
    {
        return _context.assets.Where(d => d.Id == id).FirstOrDefault();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Asset Asset)
    {
        _context.Entry(Asset).State = EntityState.Modified;
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
