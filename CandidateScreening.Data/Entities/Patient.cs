using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateScreening.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter a date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a gender")]
        public string Gender { get; set; } //M or F

        [Required(ErrorMessage = "Please enter a email")]
        public string Email { get; set; }

        public DateTime Created { get; set; }

        public int Index { get; set; } //this is only used to make sure we just seed 1000 patients
    }
}
