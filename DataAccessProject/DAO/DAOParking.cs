using Shared_Project.IDAO;
using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessProject.Connection;
using System.Runtime.Remoting.Messaging;

namespace DataAccessProject.DAO
{
    public class DAOParking : IDAOParking
    {
        private SqlDataReader reader;
        private SqlConnection _con;
        private SqlCommand _command;
        private DAOParkingPlacement _Parkingplacement;
        public DAOParking(DAOParkingPlacement parkingPlacement)
        {
            _con = DBConnection.getInstance()._sqlConnection;
            _Parkingplacement = parkingPlacement;
        }
        public bool AddParking(Parking parking)
        {
            bool Response = true;
            try
            {
                string request = "INSERT INTO dbo.Parking (ParkingId,parkingOwnerId,Location,Capacity) VALUES ((select ISNULL(MAX(ParkingId)+1,1)From Parking),'" + parking.ParkingOwnerId + "','" + parking.Location + "','" + parking.Capacity + "' );";
                _command = new SqlCommand(request, _con);
                _con.Open();
                _command.ExecuteNonQuery();

            }
            catch { Response = false; }
            finally
            {
                _con.Close();
                for (int i = 0; i < 20; i++)
                {

                    _Parkingplacement.AddParkingPlacement(new ParkingPlacement(0, parking.ParkingId+1, "Empty"));
                }
            }

            return Response;
        }

        public Parking GetParkingbyID(int Id)
        {
            Parking parking = null;
            string request = "SELECT * FROM dbo.Parking where ParkingId=" + Id + " ;";
            _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                parking = new Parking(reader.GetInt32(0),reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));
            }
            _con.Close();
            return parking;
        }

        public List<Parking> GetParkings()
        {
            List<Parking> parkings = new List<Parking>();
            string request = "SELECT * FROM dbo.Parking ;";
            _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                Parking ValueFromDB = new Parking(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));

                parkings.Add(ValueFromDB);
            }
            _con.Close();
            return parkings;
        }

        public List<Parking> GetParkingsByOwnerID(int ownerid)
        {
            List<Parking> parkings = new List<Parking>();
            string request = "SELECT * FROM dbo.Parking where ParkingOwnerId=" + ownerid + " ;";
            _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                Parking ValueFromDB = new Parking(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));
                parkings.Add(ValueFromDB);
            }
            _con.Close();
            return parkings;
        }

        public bool RemoveParking(int id)
        {
            bool Response = true;
            try
            {
                string request = "DELETE FROM dbo.Parking WHERE ParkingId =" + id + ";";
                _command = new SqlCommand(request, _con);
                _con.Open();
                _command.ExecuteNonQuery();
            }
            catch { Response = false; }
            finally
            {
                _con.Close();
            }
            return Response;
        }

        public bool UpdateParking(int Id, Parking parking)
        {
            bool Response = true;
            try
            {
                string request = "Update Parking Set ParkingOwnerId='" + parking.ParkingOwnerId +"'where ParkingId=" + Id + ";";
                _command = new SqlCommand(request, _con);
                _con.Open();
                _command.ExecuteNonQuery();
            }
            catch { Response = false; }
            finally
            {
                _con.Close();
            }
            return Response;
        }
    }
}
