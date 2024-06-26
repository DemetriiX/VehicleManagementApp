﻿namespace VehicleManagement.MVC.ViewModels
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
        public VehicleMakeViewModel Make { get; set; }
    }
}
