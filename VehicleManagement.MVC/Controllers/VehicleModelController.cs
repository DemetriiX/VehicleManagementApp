using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Shared.ViewModels;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;

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
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }

            var models = await _modelService.GetAllModelsAsync();

            // Filtering
            if (!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(s => s.Name.Contains(searchString));
            }

            // Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    models = models.OrderByDescending(s => s.Name);
                    break;

                default:
                    models = models.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            var paginatedMakes = await PagingHelper.CreateAsync(models.AsQueryable(), pageNumber ?? 1, pageSize);
            return View(paginatedMakes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _modelService.GetModelAsync(id);
            if (model == null) return NotFound();
            var modelViewModel = _mapper.Map<VehicleModelViewModel>(model);
            return View(modelViewModel);
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
