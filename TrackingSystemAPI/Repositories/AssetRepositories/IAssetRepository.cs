using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.AssetRepositories
{
   public interface IAssetRepository : IDisposable
    {
        IEnumerable<Asset> GetAll();
        Asset GetById(int id);
        Asset Find(int id);
        void Add(Asset asset);
        void Update(Asset asset);
        void Delete(int id);
        void Save();
    }
}
