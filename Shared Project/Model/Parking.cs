using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.Model
{
    public class Parking
    {
        public Parking(int parkingId,int parkingOwnerId, string location, int capacity)
        {
            ParkingId = parkingId;
            ParkingOwnerId = parkingOwnerId;
            Location = location;
            Capacity = capacity;
        }

        public int ParkingId { get; set; }
        public int ParkingOwnerId { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

    }
}
