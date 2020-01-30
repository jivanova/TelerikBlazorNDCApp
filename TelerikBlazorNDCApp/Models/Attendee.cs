using System.Collections.Generic;

namespace TelerikBlazorNDCApp.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
        public List<Lecture> Lectures { get; set; }
    }
}
