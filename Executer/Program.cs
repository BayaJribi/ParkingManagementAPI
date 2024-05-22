using System;
using Shared_Project.Model;
using DataAccessProject.Connection;
using Shared_Project.IDAO;
using DataAccessProject.DAO;

public class Program
{
    public static void Main(string[] args)
    {

        DAOParkingOwner Owner =new DAOParkingOwner();
        DAOParkingLocation location= new DAOParkingLocation();
        DAOParking parking = new DAOParking();
        parking.AddParking(new Parking(43, "Promogros", 20));
        //Console.WriteLine(location.AddParkingLocation(new ParkingLocation(11, 0.5, 0.3)));
        //Console.WriteLine(Owner.AddParkingOwner(new ParkingOwner(12, "Baya Jribi")));
        Console.WriteLine(parking.AddParking(new Parking(43, "Promogros", 20)));
        Console.WriteLine(parking.GetParkings()[0].Name);


        //Console.WriteLine(location.RemoveParkingLocation(11));

        //Console.WriteLine(Owner.RemoveParkingOwner(12));
    }
}