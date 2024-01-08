using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateFactsModel : PageModel
    {
        public Facts fact { get; set; }
        AppDbContext db;
        public UpdateFactsModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int id)
        {
            fact = db.tbl_facts.Find(id);
            var flag = HttpContext.Session.GetString("flag");
            if (flag != "true")
            {
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Facts fact)
        {
            db.tbl_facts.Update(fact);
            db.SaveChanges();
            return RedirectToPage("ShowFacts");
        }
    }
}
