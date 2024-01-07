using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb.Model
{
    public class AboutUs
    {
        public int id { get; set; }
        public string desc1 { get; set; }
        public string Point1 { get; set; }
        public string Point2 { get; set; }
        public string Point3 { get; set; }
        public string desc2 { get; set; }
        public string contact { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }

    }
}
