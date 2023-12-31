﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoadToll.Models.ViewModels
{
    public class AddCarViewModel
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        public List<SelectListItem> YearOptions { get; set; } = new List<SelectListItem>();
    }
}
