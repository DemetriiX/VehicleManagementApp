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

        public async Task<IEnumerable<VehicleMake>> GetAllMakesAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        public async Task<VehicleMake> GetMakeAsync(int id)
        {
            return await _context.VehicleMakes.FindAsync(id);
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

        public async Task<IEnumerable<VehicleModel>> GetAllModelsAsync()
        {
            return await _context.VehicleModels.Include(m => m.Make).ToListAsync();
        }

        public async Task<VehicleModel> GetModelAsync(int id)
        {
            return await _context.VehicleModels.Include(m => m.Make).FirstOrDefaultAsync(m => m.Id == id);
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
