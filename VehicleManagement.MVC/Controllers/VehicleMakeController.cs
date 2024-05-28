using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagement.Shared.ViewModels;
using VehicleManagement.Service.Interfaces;
using VehicleManagement.Service.Models;

namespace VehicleManagement.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _makeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService makeService, IMapper mapper)
        {
            _makeService = makeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var paginatedMakes = await _makeService.GetMakesAsync(sortOrder, searchString, pageNumber ?? 1, 10);

            return View(paginatedMakes);
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
            await _makeService.CreateMakeAsync(make);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var make = await _makeService.GetMakeAsync(id);
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
            await _makeService.UpdateMakeAsync(make);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var make = await _makeService.GetMakeAsync(id);
            if (make == null) return NotFound();
            var makeViewModel = _mapper.Map<VehicleMakeViewModel>(make);
            return View(makeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _makeService.DeleteMakeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
