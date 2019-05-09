using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Entities
{
    [Table("tblBrokers")]
    public class Broker
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string FirstName { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string LastName { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Email { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Password { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Broker()
        {
            Cars = new List<Car>();
        }
    }
}
