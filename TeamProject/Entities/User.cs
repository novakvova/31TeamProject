using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Entities
{
    [Table("tblUsers")]
    public class User
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
        public string Status { get; set; }
    }
}
