using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Service.Data;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;

namespace VehicleManagement.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext _context;

        public VehicleModelService(VehicleContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<VehicleModel>> GetAllModelsAsync()
        {
            return await _context.VehicleModels.Include(m => m.Make).ToListAsync();
        }

        public async Task<VehicleModel> GetModelAsync(int id)
        {
            return await _context.VehicleModels.Include(m => m.Make).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<PaginatedList<VehicleModel>> GetModelsAsync(SortingParameters sortingParameters, FilteringParameters filteringParameters, PagingParameters pagingParameters)
        {
            var query = _context.VehicleModels.AsQueryable();

            query = query.ApplyFiltering(filteringParameters);
            query = query.ApplySorting(sortingParameters);

            return await PagingHelper.CreateAsync(query, pagingParameters);
        }

        public async Task CreateModelAsync(VehicleModel model)
        {
            _context.VehicleModels.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateModelAsync(VehicleModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(int id)
        {
            var model = await _context.VehicleModels.FindAsync(id);
            if (model != null)
            {
                _context.VehicleModels.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
