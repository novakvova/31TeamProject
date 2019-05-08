using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string GraduationYear { get; set; }
        public string VIN { get; set; }
        public string StateNumber { get; set; }
        public int ClientID { get; set; }
    }
}
