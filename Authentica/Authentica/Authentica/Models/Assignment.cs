using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authentica.Models
{
    public class Assignment
    {

        [Required]
        public string AssignmentName { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public DateTime? CompletionDate { get; set; }

        [Required]
        public float MaxScore { get; set; }

        [Required]
        public float ScoreEarned { get; set; }
    }
}