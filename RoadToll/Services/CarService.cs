using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RoadToll.Models;
using System.Collections.Generic;

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
            //TODO get car
            Car car = new Car();
            string jsonCarsData = System.IO.File.ReadAllText("./Data/Cars.json");
            List<Car> carsList = JsonConvert.DeserializeObject<List<Car>>(jsonCarsData);
            var currentCar = carsList.FirstOrDefault(x => x.Id == id);            
            return currentCar;
        }
    }
}
