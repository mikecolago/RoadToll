using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;
using TollFeeCalculator;
using RoadToll.Models;
//using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using RoadToll.Services;

namespace RoadToll.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CarService _carService;

        public IndexModel(ILogger<IndexModel> logger, CarService carService)
        {
            _logger = logger;
            _carService = carService;
        }        

        public void OnGet()
        {
            Car car = new Car() { RegistrationNumber = "ABC123"};            
            TollCalculator tollCalculator = new TollCalculator();
            Vehicle vehicle = new Car();
            bool isFree = tollCalculator.IsTollFreeVehicle(vehicle);
            DateTime dateNow = DateTime.Now.AddHours(-6);
            var result = tollCalculator.GetTollFee(dateNow, car);
            var list2 = tollCalculator.ListCost();
            var currentCar = list2.SingleOrDefault(x => x.RegistrationNumber == "ABC 123");
            currentCar.Passages.AddRange(new List<DateTime>() {
                new DateTime (2021, 11, 15, 8, 30, 0), // 15 November 2021, 8:30
                new DateTime(2021, 11, 16, 9, 15, 0), // 16 November 2021, 9:15
                new DateTime(2021, 11, 17, 10, 0, 0),  // 17 November 2021, 10:00
                new DateTime(2021, 11, 17, 15, 15, 0),  // 17 November 2021, 10:00
                new DateTime(2021, 11, 17, 15, 20, 0) //17 November 2021, 15:15
            });
            //vehicle.Passages.AddRange(morePassages.Where(passage => passage.Hour >= 9));
            var totalPrice = 0;
            foreach (var item in currentCar.Passages)
            {
                totalPrice += tollCalculator.GetTollFee(item, car); 
            }
            string jsonString = JsonConvert.SerializeObject(car);
            Car jsonCar = JsonConvert.DeserializeObject<Car>(jsonString);
            //File.WriteAllText("Cars.json", jsonString);
        }
        
        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carService.GetAllCars();            
        }
        public void SaveCar()
        {
            Car car = new Car() { RegistrationNumber = "ABC123" };
            string jsonString = JsonConvert.SerializeObject(car);
        }
    }
}
