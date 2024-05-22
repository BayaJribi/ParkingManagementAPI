using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.IDAO
{
    public interface ReservationIDAO
    {
        List<Reservation> GetReservations();
        Reservation GetReservationbyID(int id);
        bool AddReservation(Reservation reservation);
    }
}
