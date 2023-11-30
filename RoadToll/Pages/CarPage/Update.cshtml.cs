using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using RoadToll.Services;
using System.Runtime.CompilerServices;

namespace RoadToll.Pages.CarPage
{
    public class UpdateModel : PageModel
    {
        private readonly CarService _carService;

        [BindProperty]
        public EditCarViewModel CarViewModel { get; set; }        
        public UpdateModel(CarService carService)
        {
            _carService = carService;
        }
        public async Task OnGetAsync(int id)
        {
            CarViewModel = new EditCarViewModel();
            var currentYear = DateTime.Now.Year;
            for (var i = 0; i < 100; i++)
            {
                CarViewModel.YearOptions.Add(new SelectListItem((currentYear - i).ToString(), (currentYear - i).ToString()));
            }                        
            var currentCar = await _carService.GetCarByIdAsync(id);
            CarViewModel.Id = currentCar.Id;
            CarViewModel.RegistrationNumber = currentCar.RegistrationNumber;
            CarViewModel.Color = currentCar.Color;
            CarViewModel.Model = currentCar.Model;
            CarViewModel.VehicleType = currentCar.VehicleType;
            //CarViewModel.Passages = currentCar.Passages;            
        }
        public IActionResult OnPost()
        {
            var carModel = new CarViewModel
            {
                Id = CarViewModel.Id,
                RegistrationNumber = CarViewModel.RegistrationNumber,
                VehicleType = CarViewModel.VehicleType,
                Color = CarViewModel.Color,
                Model = CarViewModel.Model,
                Year = CarViewModel.Year,
            };
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<CarViewModel> jsonCars = JsonConvert.DeserializeObject<List<CarViewModel>>(jsonCarsData);
            var currentCar = jsonCars.FindIndex(x => x.Id == CarViewModel.Id);
            if (currentCar == -1)
            {
                ViewData["Message"] = "save error, object not found";                
                return RedirectToPage();
            }
            else { 
                jsonCars[currentCar] = carModel;            
                string jsonString = JsonConvert.SerializeObject(jsonCars);
                System.IO.File.WriteAllText("./Data/Cars.json", jsonString);
                ViewData["Message"] = "Saved";
                return RedirectToPage();
            }

        }
    }
}
