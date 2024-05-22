using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.IDAO
{
    public interface ParkingPlacementIDAO
    {
        List<ParkingPlacement> GetParkingPlacements();
        ParkingPlacement GetParkingPlacementByID(int Id);
        string GetSumParkingPlacementbyState(string state,int parkingId);
        bool AddParkingPlacement(ParkingPlacement parkingLocation);
        bool RemoveParkingPlacement(int id);
        bool UpdateParkingPlacement(int id, string state);  

    }
}
