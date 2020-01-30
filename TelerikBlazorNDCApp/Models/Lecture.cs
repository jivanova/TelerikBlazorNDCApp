using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikBlazorNDCApp.Models
{
    public class Lecture
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public bool IsAllDay { get; set; }

        public Lecture()
        {
            Id = Guid.NewGuid();
        }
    }
}
