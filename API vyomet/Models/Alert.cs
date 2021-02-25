using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_vyomet.Models
{
    public class Alert
    {
        public int alertid { get; set;}
        public string playerid { get; set;}
        [DataType(DataType.Date)]
        public DateTime alertadded { get; set;}
        public DateTime pushsent { get; set;}
        public int usercount { get; set;}
        public string weatheralertid { get; set;}


    }
}
