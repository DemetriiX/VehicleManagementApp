using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Service.Models;

namespace VehicleManagement.Service.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleMake>> GetAllMakesAsync();
        Task<VehicleMake> GetMakeAsync(int id);
        Task CreateMakeAsync(VehicleMake make);
        Task UpdateMakeAsync(VehicleMake make);
        Task DeleteMakeAsync(int id);

        Task<IEnumerable<VehicleModel>> GetAllModelsAsync();
        Task<VehicleModel> GetModelAsync(int id);
        Task CreateModelAsync(VehicleModel model);
        Task UpdateModelAsync(VehicleModel model);
        Task DeleteModelAsync(int id);
    }
}
