using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.IDAO
{
    public interface IDAOParking
    {
        List<Parking> GetParkings() ;
        List<Parking> GetParkingsByOwnerID(int ownerid);
        Parking GetParkingbyID(int id);
        bool AddParking(Parking parking) ;
        bool RemoveParking(int Id) ;
        bool UpdateParking(int Id , Parking parking) ;

    }
}
