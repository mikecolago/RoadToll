using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RoadToll.Models;
using RoadToll.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using TollFeeCalculator;

namespace RoadToll.Services
{
    public class CarService
    {
        public CarService()
        {
        }
        public async Task<List<Car>> GetAllCars()
        {
            // Create a list of car objects            
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> carsList = JsonConvert.DeserializeObject<List<Car>>(jsonCarsData);
            return carsList;
        }

        public async Task<Car> GetCarById(int id)
        {
            Car car = new Car();
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> carsList = JsonConvert.DeserializeObject<List<Car>>(jsonCarsData);
            var currentCar = carsList.FirstOrDefault(x => x.Id == id);
            return currentCar;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {            
            Car car = new Car();
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> carsList = JsonConvert.DeserializeObject<List<Car>>(jsonCarsData);
            var currentCar = carsList.FirstOrDefault(x => x.Id == id);            
            return currentCar;
        }
        public async Task<CarViewModel> AddCarAsync(CarViewModel car)
        {
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<CarViewModel> jsonCars = JsonConvert.DeserializeObject<List<CarViewModel>>(jsonCarsData);
            jsonCars.Add(car);
            string jsonString = JsonConvert.SerializeObject(jsonCars);
            System.IO.File.WriteAllText("./Data/Cars.json", jsonString);
            return car;
        }
        public int GetPrice(Car car)
        {
            TollCalculator tollCalculator = new TollCalculator();
            var totalPrice = 0;
            var free = tollCalculator.IsTollFreeVehicle(car);
            if (!free)
            {
                foreach (var item in car.Passages)
                {
                    totalPrice += tollCalculator.GetTollFee(item.Time, car);
                }
            }
            return totalPrice;
        }
    }
}
