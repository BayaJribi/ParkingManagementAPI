using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Project.Model
{
    public class ParkingOwner
    {
        public int ParkingOwnerId { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }
        public ParkingOwner(int parkingOwnerId, string username,string password )
        {
            ParkingOwnerId = parkingOwnerId;
            Username = username;
            Password = password;
        }

                
    }
}
