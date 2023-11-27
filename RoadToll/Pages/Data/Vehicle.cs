using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public interface Vehicle
    {
        String GetVehicleType();
        //string GetVehicleName();
    }
    public enum VehicleType
    {
        Motorbike = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5,
        Car = 6,
        Truck = 7
    }
}