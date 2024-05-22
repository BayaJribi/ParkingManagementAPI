using DataAccessProject.Connection;
using Shared_Project.IDAO;
using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessProject.DAO
{
    public class DAOParkingOwner : ParkingOwnerIDAO
    {
        private SqlDataReader reader;
        private SqlConnection _con;
        public DAOParkingOwner()
        {
            _con = DBConnection.getInstance()._sqlConnection;
        }
        public bool AddParkingOwner(ParkingOwner parkingOwner)
        {
            bool Response = true;
            try
            {
                string request = "INSERT INTO dbo.ParkingOwner (ParkingOwnerId,Username,Password) VALUES ((select ISNULL(MAX(ParkingOwnerId)+1,1)From ParkingOwner),'" + parkingOwner.Username + "','" + parkingOwner.Password + "' );";
                SqlCommand _command = new SqlCommand(request, _con);
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

        public int GetParkingOwnerbyUsername(string username)
        {
            //ParkingOwner parkingOwner = null;
            int OwnerId=0;
            string request = "SELECT * FROM dbo.ParkingOwner where Username='" + username + "' ;";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                OwnerId = reader.GetInt32(0);
                //parkingOwner = new ParkingOwner(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            _con.Close();
            return OwnerId;
        }

        public List<ParkingOwner> GetParkingOwners()
        {
            List<ParkingOwner> parkingOwners = new List<ParkingOwner>();
            string request = "SELECT * FROM dbo.ParkingOwner ;";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                ParkingOwner ValueFromDB = new ParkingOwner(reader.GetInt32(0), reader.GetString(1),reader.GetString(2));

                parkingOwners.Add(ValueFromDB);
            }
            _con.Close();
            return parkingOwners;
        }
        public ParkingOwner GetParkingOwnersbyID(int Id)
        {
            ParkingOwner parkingOwner = null;
            string request = "SELECT * FROM dbo.ParkingOwner where ParkingOwnerId=" + Id + " ;";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                parkingOwner = new ParkingOwner(reader.GetInt32(0), reader.GetString(1),reader.GetString(2));
            }
            _con.Close();
            return parkingOwner;
        }

        public bool RemoveParkingOwner(int id)
        {
            bool Response = true;
            try
            {
                string request = "DELETE FROM dbo.ParkingOwner WHERE ParkingOwnerId =" + id + ";";
                SqlCommand _command = new SqlCommand(request, _con);
                _con.Open();
                _command.ExecuteNonQuery();
            }
            catch { Response = false; }
            finally
            {
                _con.Close();            }
            return Response;
        }

        public bool UpdateParkingOwner(int id, string parkingOwnerpassword)
        {
            bool Response = true;
            try
            {
                string request = "Update ParkingOwner Set Password='"+ parkingOwnerpassword + "' where ParkingOwnerId=" + id + ";";
                SqlCommand _command = new SqlCommand(request, _con);
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
