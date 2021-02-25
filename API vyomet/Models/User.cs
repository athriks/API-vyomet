using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_vyomet.Models
{
    public class User
    {
        public int Id { get; set; }
        public int  MobileNumber { get; set; }
        public bool PrimeMember { get; set;}
        //public int Otp { get; set;}
    }
}
