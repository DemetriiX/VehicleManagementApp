using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Service.Models;

namespace VehicleManagement.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetAllMakesAsync();
        Task<VehicleMake> GetMakeAsync(int id);
        Task<PaginatedList<VehicleMake>> GetMakesAsync(string sortOrder, string searchString, int pageNumber, int pageSize);
        Task CreateMakeAsync(VehicleMake make);
        Task UpdateMakeAsync(VehicleMake make);
        Task DeleteMakeAsync(int id);
        
    }
}
