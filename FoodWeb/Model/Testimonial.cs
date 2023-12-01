using System.Reflection.Metadata.Ecma335;

namespace FoodWeb.Model
{
    public class Testimonial
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public string Image { get; set; }
        public string Designation { get; set; }
    }
}
