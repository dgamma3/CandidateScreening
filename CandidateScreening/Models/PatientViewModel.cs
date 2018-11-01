using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CandidateScreening.Models
{
	public class PatientViewModel
	{        
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
    }
}