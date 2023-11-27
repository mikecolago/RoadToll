using TollFeeCalculator;

namespace RoadToll.Models.ViewModels
{
    public class CarViewModel
    {
        public string GetVehicleType()
        {
            return "Car";
        }
        public string GetVehicleName()
        {
            return "ABC123";
        }
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; } = "N/A";
        public string Color { get; set; } = "N/A";
        public int Year { get; set; }
        public List<DateTime> Passages { get; set; }
        public VehicleType VehicleType { get; set; } = VehicleType.Unknown;
        
    }
}
