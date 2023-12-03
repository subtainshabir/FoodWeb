using System.ComponentModel.DataAnnotations;

namespace FoodWeb.Model
{
    public class ContactInfo
    {
        public int id { get; set; }
        public string Address { get; set; }
        public string OpeningDays { get; set; }
        public string OpeningTimings { get; set; }
        public string? ClosedDays { get; set; }
        public string  Email { get; set; }
        public string Phone { get; set; }
    }
}
