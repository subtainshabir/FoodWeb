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


        public IndexModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
            contactinfo=db.tbl_contact.FirstOrDefault();
            breakfast=db.tbl_breakfast.ToList();
            
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
