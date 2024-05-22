using DataAccessProject.Connection;
using Shared_Project.IDAO;
using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessProject.DAO
{
    public class DAOReservation : ReservationIDAO
    {
        private SqlDataReader reader;
        private SqlConnection _con;
        private SqlCommand _command;
        public DAOReservation()
        {
            _con = DBConnection.getInstance()._sqlConnection;

        }
        public bool AddReservation(Reservation reservation)
        {
            bool Response = true;
            try
            {
                string request = "INSERT INTO dbo.Reservation (ReservationId,ReservationDate,ParkingId,ParkingPlacementId) VALUES ((select ISNULL(MAX(ReservationId)+1,1)From Reservation),'" + reservation.ReservationDate + "','" + reservation.ParkingId + "','" + reservation.ParkingPlacementId + "' );";
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

        public Reservation GetReservationbyID(int id)
        {
            Reservation reservation = null;
            string request = "SELECT * FROM dbo.Reservation where ReservationId=" + id + " ;";
            _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                reservation = new Reservation(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
            }
            _con.Close();
            return reservation;
        }

        public List<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            string request = "SELECT * FROM dbo.Reservation ;";
            _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                Reservation ValueFromDB = new Reservation(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));

                reservations.Add(ValueFromDB);
            }
            _con.Close();
            return reservations;
        }
    }
}
