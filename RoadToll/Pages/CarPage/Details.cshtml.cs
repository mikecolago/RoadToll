using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using System;

namespace RoadToll.Pages.CarPage
{
    public class DetailsModel : PageModel
    {        
        public CarViewModel CarViewModel { get; set; } = new CarViewModel();
        public void OnGet(int id)
        {
            string jsonString2 = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> jsonCars = JsonConvert.DeserializeObject<List<Car>>(jsonString2);
            var currentCar = jsonCars.FirstOrDefault(x => x.Id == id);
            CarViewModel.Id = currentCar.Id;
            CarViewModel.RegistrationNumber = currentCar.RegistrationNumber;
            CarViewModel.Color = currentCar.Color;
            CarViewModel.Model = currentCar.Model;
            CarViewModel.VehicleType = currentCar.VehicleType;
            CarViewModel.Passages = currentCar.Passages;

        }

        //public async Task<IActionResult> OnGetAsync(int id)
        //{
        //    //Car = await _context.Cars.FindAsync(id);

        //    //if (Car == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return Page();
        //}
    }
}
