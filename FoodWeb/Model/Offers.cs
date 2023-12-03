using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWeb.Model
{
    public class Offers
    {
        public int id { get; set; }
        public string OfferName { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
    }

}
