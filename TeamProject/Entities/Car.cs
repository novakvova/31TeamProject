using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Entities
{
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Brand { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string GraduationYear { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string VIN { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string StateNumber { get; set; }

        public int? BrokerId { get; set; }
        public Broker Broker { get; set; }

        public int? UserId { get; set; }
        public Broker User { get; set; }
    }
}