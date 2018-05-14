using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authentica.Models
{
    public class Enrollment
    {
        [Required]
        public string ExitReason { get; set; }

        [Required]
        public DateTime? EntryDate { get; set; }

        [Required]
        public DateTime? ExitDate { get; set; }
    }
}