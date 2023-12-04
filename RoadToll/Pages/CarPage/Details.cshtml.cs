using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using RoadToll.Services;
using System;

namespace RoadToll.Pages.CarPage
{
    public class DetailsModel : PageModel
    {
        private readonly CarService _carService;
        public DetailsModel(CarService carService)
        {
            _carService = carService;
        }
        public CarViewModel CarViewModel { get; set; }
        public async Task OnGetAsync(int id)
        {
            CarViewModel = new CarViewModel();                        
            var currentCar = await _carService.GetCarByIdAsync(id);
            CarViewModel.Id = currentCar.Id;
            CarViewModel.RegistrationNumber = currentCar.RegistrationNumber;
            CarViewModel.Color = currentCar.Color;
            CarViewModel.Model = currentCar.Model;
            CarViewModel.VehicleType = currentCar.VehicleType;
            CarViewModel.Passages = currentCar.Passages;
            CarViewModel.TotalToll = _carService.GetPrice(currentCar);
        }

        public IActionResult OnPostDelete(int id)
        {            
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> jsonCars = JsonConvert.DeserializeObject<List<Car>>(jsonCarsData);
            var currentCar = jsonCars.FirstOrDefault(x => x.Id == id);
            jsonCars.Remove(currentCar);
            string jsonString = JsonConvert.SerializeObject(jsonCars);
            System.IO.File.WriteAllText("./Data/Cars.json", jsonString);
            return Redirect("/Index");
        }        
    }
}
