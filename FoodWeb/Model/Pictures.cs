using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb.Model
{
    public class Pictures
    {
        public int id { get; set; }
        public string  Image { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
