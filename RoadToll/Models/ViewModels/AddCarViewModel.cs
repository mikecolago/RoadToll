using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace RoadToll.Models.ViewModels
{
    public class AddCarViewModel
    {
        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Color")]
        public string Color { get; set; }
        [DisplayName("Year")]
        public int Year { get; set; }
        [DisplayName("Vehicle Type")]
        public VehicleType VehicleType { get; set; }
        public List<SelectListItem> YearOptions { get; set; } = new List<SelectListItem>();
    }
}
