using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb.Model
{
    public class Launch
    {
        public int id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
        public string DishName { get; set; }
        public string Ingredients { get; set; }
        public string Price { get; set; }
    }
}
