using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMedicine.Models
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Middle_name { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }

        public DateTime Birth { get; set; }

        [MaxLength(150)]
        public string Adress { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public int Age { get; set; }
        public List<Visits> Visits { get; set; }
    }
}
