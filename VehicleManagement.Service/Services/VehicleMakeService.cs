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
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleContext _context;

        public VehicleMakeService(VehicleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleMake>> GetAllMakesAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        public async Task<VehicleMake> GetMakeAsync(int id)
        {
            return await _context.VehicleMakes.FindAsync(id);
        }

        public async Task<PaginatedList<VehicleMake>> GetMakesAsync(SortingParameters sortingParameters, FilteringParameters filteringParameters, PagingParameters pagingParameters)
        {
            var query = _context.VehicleMakes.AsQueryable();

            query = query.ApplyFiltering(filteringParameters);
            query = query.ApplySorting(sortingParameters);

            return await PagingHelper.CreateAsync(query, pagingParameters);
        }

        public async Task CreateMakeAsync(VehicleMake make)
        {
            _context.VehicleMakes.Add(make);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMakeAsync(VehicleMake make)
        {
            _context.Entry(make).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMakeAsync(int id)
        {
            var make = await _context.VehicleMakes.FindAsync(id);
            if (make != null)
            {
                _context.VehicleMakes.Remove(make);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
