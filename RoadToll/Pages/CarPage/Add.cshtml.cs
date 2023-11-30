using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoadToll.Pages.CarPage
{
    public class AddModel : PageModel
    {
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
        public void OnPost()
        {
            var carModel = new CarViewModel
            {
                RegistrationNumber = CarViewModel.RegistrationNumber,
                VehicleType = CarViewModel.VehicleType,
                Color = CarViewModel.Color,
                Model = CarViewModel.Model,
                Year = CarViewModel.Year,                
            };
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<CarViewModel> jsonCars = JsonConvert.DeserializeObject<List<CarViewModel>>(jsonCarsData);            
            jsonCars.Add(carModel);
            string jsonString = JsonConvert.SerializeObject(jsonCars);
            System.IO.File.WriteAllText("./Data/Cars.json", jsonString);
        }
    }
}
