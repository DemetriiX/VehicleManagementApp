using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagement.Service.ViewModels;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;

namespace VehicleManagement.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var makes = await _vehicleService.GetAllMakesAsync();
            var makeViewModels = _mapper.Map<IEnumerable<VehicleMakeViewModel>>(makes);
            return View(makeViewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var make = await _vehicleService.GetMakeAsync(id);
            if (make == null) return NotFound();
            var makeViewModel = _mapper.Map<VehicleMakeViewModel>(make);
            return View(makeViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleMakeViewModel makeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var make = _mapper.Map<VehicleMake>(makeViewModel);
            await _vehicleService.CreateMakeAsync(make);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var make = await _vehicleService.GetMakeAsync(id);
            if (make == null) return NotFound();
            var makeViewModel = _mapper.Map<VehicleMakeViewModel>(make);
            return View(makeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleMakeViewModel makeViewModel)
        {
            if (id != makeViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var make = _mapper.Map<VehicleMake>(makeViewModel);
            await _vehicleService.UpdateMakeAsync(make);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var make = await _vehicleService.GetMakeAsync(id);
            if (make == null) return NotFound();
            var makeViewModel = _mapper.Map<VehicleMakeViewModel>(make);
            return View(makeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehicleService.DeleteMakeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
