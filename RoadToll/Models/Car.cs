using RoadToll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculator;

namespace RoadToll.Models
{
    public class Car : Vehicle
    {
        public string GetVehicleType()
        {
            return VehicleType.ToString();
        }
        public string GetVehicleName()
        {
            return "ABC123";
        }
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model {  get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public List<Passage> Passages { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}