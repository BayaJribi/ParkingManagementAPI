using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.Model
{
    public class ParkingPlacement
    {
        public int ParkingPlacementId { get; set; }
        public int ParkingId { get; set; }
        public String State { get; set; }
        public ParkingPlacement(int parkingPlacementId,int parkingId, String state)
        {
            ParkingPlacementId = parkingPlacementId;
            ParkingId = parkingId;
            State = state;
        }


    }
}
