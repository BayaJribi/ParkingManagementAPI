using Shared_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.IDAO
{
    public interface ParkingOwnerIDAO
    {
        List<ParkingOwner> GetParkingOwners();
        ParkingOwner GetParkingOwnersbyID(int id);
        int GetParkingOwnerbyUsername(string username);
        bool AddParkingOwner(ParkingOwner parkingOwner);
        bool RemoveParkingOwner(int id); 
        bool UpdateParkingOwner(int id,string password);

    }
}
