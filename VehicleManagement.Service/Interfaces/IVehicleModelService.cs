using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Service.Models;

namespace VehicleManagement.Service.Interfaces
{
    public interface IVehicleModelService
    {        
        Task<IEnumerable<VehicleModel>> GetAllModelsAsync();
        Task<VehicleModel> GetModelAsync(int id);
        Task<PaginatedList<VehicleModel>> GetModelsAsync(SortingParameters sortingParameters, FilteringParameters filteringParameters, PagingParameters pagingParameters);
        Task CreateModelAsync(VehicleModel model);
        Task UpdateModelAsync(VehicleModel model);
        Task DeleteModelAsync(int id);
    }
}
