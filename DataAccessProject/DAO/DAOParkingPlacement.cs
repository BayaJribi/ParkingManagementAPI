using DataAccessProject.Connection;
using Shared_Project.IDAO;
using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessProject.DAO
{
    public class DAOParkingPlacement : ParkingPlacementIDAO
    {
        SqlDataReader reader;
        private SqlConnection _con;
        public DAOParkingPlacement()
        {
            _con = DBConnection.getInstance()._sqlConnection;
        }
        public bool AddParkingPlacement(ParkingPlacement parkingPlacement)
        {
            bool Response = true;
            try
            {
                string request = "INSERT INTO dbo.ParkingPlacement (ParkingPlacementId,ParkingId,State) VALUES ((select ISNULL(MAX(ParkingPlacementId)+1,1)From ParkingPlacement),(select ISNULL(MAX(ParkingId),1)From Parking),'" + parkingPlacement.State+"');";
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


        public ParkingPlacement GetParkingPlacementByID(int Id)
        {
            ParkingPlacement parkingPlacement=null;
            string request = "SELECT * FROM dbo.ParkingPlacement where ParkingPlacementId="+Id+" ;";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader=_command.ExecuteReader();
            while (reader.Read())
            {
                parkingPlacement = new ParkingPlacement(reader.GetInt32(0),reader.GetInt32(1), reader.GetString(2));
            }
            _con.Close();
            return parkingPlacement;
        }

        public List<ParkingPlacement> GetParkingPlacements()
        {
            List<ParkingPlacement> parkingPlacements = new List<ParkingPlacement>();
            string request = "SELECT * FROM dbo.ParkingPlacement ;";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                ParkingPlacement ValueFromDB = new ParkingPlacement(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));

                parkingPlacements.Add(ValueFromDB);
            }
            _con.Close();
            return parkingPlacements;
        }

        public string GetSumParkingPlacementbyState(string state,int parkingid)
        {
            int sum = 0;
            string request = "SELECT Count(State) FROM dbo.ParkingPlacement  where State='" + state + " ' and ParkingId=" + parkingid + ";";
            SqlCommand _command = new SqlCommand(request, _con);
            _con.Open();
            _command.ExecuteNonQuery();
            reader = _command.ExecuteReader();
            while (reader.Read())
            {
                sum=reader.GetInt32(0);

            }
            _con.Close();
            return sum.ToString();
        }

        public bool RemoveParkingPlacement(int id)
        {
            bool Response = true;
            try
            {
                string request = "DELETE FROM dbo.ParkingPlacement WHERE ParkingPlacementId =" + id+";";
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

        public bool UpdateParkingPlacement(int id, string state)
        {

                bool Response = true;
                try
                {
                    string request = "Update ParkingPlacement Set State='" + state  + "'where ParkingPlacementId=" + id + ";";
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
