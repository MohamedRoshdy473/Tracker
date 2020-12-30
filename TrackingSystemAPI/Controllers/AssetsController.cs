using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.AssetRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepository _assetRepository;

        public AssetsController(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        // GET: api/Assets
        [HttpGet]
        public IEnumerable<Asset> Getassets()
        {
            return _assetRepository.GetAll();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public ActionResult<Asset> GetAsset(int id)
        {
            var asset = _assetRepository.GetById(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAsset(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            _assetRepository.Update(asset);

            try
            {
                _assetRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Assets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Asset> PostAsset(Asset asset)
        {
            _assetRepository.Add(asset);
            _assetRepository.Save();

            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public ActionResult<Asset> DeleteAsset(int id)
        {
            var asset = _assetRepository.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            _assetRepository.Delete(id);
            _assetRepository.Save();

            return asset;
        }
    }
}
