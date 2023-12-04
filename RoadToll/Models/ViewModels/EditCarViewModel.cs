using Microsoft.AspNetCore.Mvc.Rendering;
using RoadToll.Models;

namespace RoadToll.Models.ViewModels
{
    public class EditCarViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        public List<SelectListItem> YearOptions { get; set; } = new List<SelectListItem>();
    }
}
