using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessProject.DAO;
using Shared_Project.Model;
namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {

            DAOParkingOwner Owner = new DAOParkingOwner();
            DAOParkingPlacement placement = new DAOParkingPlacement();
            DAOParking parking = new DAOParking(placement);
            DAOReservation reservation = new DAOReservation();

            Console.WriteLine(placement.GetSumParkingPlacementbyState("Empty",2));
            //reservation.AddReservation(new Reservation(1, "13/12/2022", 1, 1));
            //Console.WriteLine(Owner.GetParkingbyUsername("madiha"));
            //parking.AddParking(new Parking(0, 1,"Sfax Mall", 20));

            //Owner.AddParkingOwner(new ParkingOwner(1, "Baya", "Baya"));
            //Owner.UpdateParkingOwner(1, new ParkingOwner(1, "madiha", "madiha"));

            //parking.AddParking(new Parking(43, "Promogros", 20));
            ////Console.WriteLine(location.AddParkingLocation(new ParkingLocation(11, 0.5, 0.3)));
            ////Console.WriteLine(Owner.AddParkingOwner(new ParkingOwner(12, "Baya Jribi")));
            //Console.WriteLine(parking.AddParking(new Parking(43, "Promogros", 20)));
            //Console.WriteLine(parking.GetParkings()[0].Name);


            //Console.WriteLine(location.RemoveParkingLocation(11));

            //Console.WriteLine(Owner.RemoveParkingOwner(12));

        }
        }
    }
