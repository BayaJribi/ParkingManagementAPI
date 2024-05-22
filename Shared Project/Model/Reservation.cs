using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ReservationDate { get; set; }
        public int ParkingId { get; set; }
        public int ParkingPlacementId { get; set; }
        public Reservation(int reservationId, string reservationDate, int parkingId, int parkingPlacementId)
        {
            ReservationId = reservationId;
            ReservationDate = reservationDate;
            ParkingId = parkingId;
            ParkingPlacementId = parkingPlacementId;
        }
        public Reservation()
        {

        }
    }
}
