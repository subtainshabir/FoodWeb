using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages
{
    public class IndexModel : PageModel
    {
        AppDbContext db;
        public Orders order { get; set; }
        public List<BreakFast> breakfast { get; set; }
        public ContactInfo contactinfo { get; set; }
        public Introduction intro { get; set; }
        public Question question { get; set; }

        public List<Pictures> gallary { get; set; }
        public List<Offers> offer { get; set; }
        public List<Chefs> chef { get; set; }
        public List<Testimonial> testimonial { get; set; }
        public List<Starter> starter { get; set; }
        public List<Launch> lunch { get; set; }

        public IndexModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            contactinfo=db.tbl_contact.FirstOrDefault();
            breakfast=db.tbl_breakfast.ToList();
            intro = db.tbl_intro.FirstOrDefault();
            question = db.tbl_question.FirstOrDefault();
            gallary=db.tbl_gallay.ToList();
            offer = db.tbl_offers.ToList();
            chef = db.tbl_chefs.ToList();
            testimonial = db.tbl_testimonial.ToList();
            starter = db.tbl_starter.ToList();
            lunch = db.tbl_launch.ToList();
            
        }
        public IActionResult OnPost(Orders order)
        {
            if (ModelState.IsValid)
            {
                db.tbl_orders.Add(order);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToPage("index");

            }


            else
            {
                return Page();

            }
           
        }

    }
}
