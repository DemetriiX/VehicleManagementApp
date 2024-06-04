using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Shared.ViewModels;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;
using VehicleManagement.Service;

namespace VehicleManagement.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _modelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber)
        {
            var sortingParameters = new SortingParameters { SortOrder = sortOrder };
            var filteringParameters = new FilteringParameters { SearchString = searchString };
            var pagingParameters = new PagingParameters { PageNumber = pageNumber ?? 1 };

            var paginatedModels = await _modelService.GetModelsAsync(sortingParameters, filteringParameters, pagingParameters);

            return View(paginatedModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleModelViewModel modelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var model = _mapper.Map<VehicleModel>(modelViewModel);
            await _modelService.CreateModelAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _modelService.GetModelAsync(id);
            if (model == null) return NotFound();
            var modelViewModel = _mapper.Map<VehicleModelViewModel>(model);
            return View(modelViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleModelViewModel modelViewModel)
        {
            if (id != modelViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var model = _mapper.Map<VehicleModel>(modelViewModel);
            await _modelService.UpdateModelAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _modelService.GetModelAsync(id);
            if (model == null) return NotFound();
            var modelViewModel = _mapper.Map<VehicleModelViewModel>(model);
            return View(modelViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _modelService.DeleteModelAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
