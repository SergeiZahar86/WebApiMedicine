using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiMedicine.Models
{
    public class Visits
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Diagnosis { get; set; }

        public int PatientsInfoKey { get; set; }
        public Patients Patients { get; set; }
    }
}
