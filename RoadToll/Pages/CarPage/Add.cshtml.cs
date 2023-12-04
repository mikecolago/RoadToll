using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using RoadToll.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoadToll.Pages.CarPage
{
    public class AddModel : PageModel
    {
        private readonly CarService _carService;
        public AddModel(CarService carService)
        {
            _carService = carService;
        }
        [BindProperty]
        public AddCarViewModel CarViewModel { get; set; } = new AddCarViewModel();
        public void OnGet()
        {
            var currentYear = DateTime.Now.Year;            
            for (var i = 0; i < 100; i++)
            {                
                CarViewModel.YearOptions.Add(new SelectListItem((currentYear-i).ToString(), (currentYear-i).ToString()));
            }
        }
        public IActionResult OnPost()
        {
            var carModel = new CarViewModel
            {
                RegistrationNumber = CarViewModel.RegistrationNumber,
                VehicleType = CarViewModel.VehicleType,
                Color = CarViewModel.Color,
                Model = CarViewModel.Model,
                Year = CarViewModel.Year,                
            };
            var car = _carService.AddCarAsync(carModel);
            //todo return to detail car /Details/1
            return Redirect("/Index");
        }
    }
}
