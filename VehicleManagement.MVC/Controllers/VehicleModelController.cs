using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.Service.ViewModels;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;

namespace VehicleManagement.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _vehicleService.GetAllModelsAsync();
            var modelViewModels = _mapper.Map<IEnumerable<VehicleModelViewModel>>(models);
            return View(modelViewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _vehicleService.GetModelAsync(id);
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
            await _vehicleService.CreateModelAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _vehicleService.GetModelAsync(id);
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
            await _vehicleService.UpdateModelAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _vehicleService.GetModelAsync(id);
            if (model == null) return NotFound();
            var modelViewModel = _mapper.Map<VehicleModelViewModel>(model);
            return View(modelViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehicleService.DeleteModelAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
