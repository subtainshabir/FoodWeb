using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowTestimonialModel : PageModel
    {
        public List<Testimonial> testimonial { get; set; }
        AppDbContext db;
        public ShowTestimonialModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            testimonial = db.tbl_testimonial.ToList();
        }
    }
}
