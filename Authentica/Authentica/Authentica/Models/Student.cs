using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentica.Models
{
    public class Student : Person
    {
        [Required]
        public string Grade { get; set; }

        [Required]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

    }

    public class common
    {

    }
}