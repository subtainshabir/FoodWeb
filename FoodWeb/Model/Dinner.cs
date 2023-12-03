using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb.Model
{
    public class Dinner
    {
        public int id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? Phote { get; set; }
        public string DishName { get; set; }
        public string Ingredients { get; set; }
        public string Price { get; set; }
    }
}
