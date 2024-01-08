using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowFactsModel : PageModel
    {
        AppDbContext db;
        public Facts fact { get; set; }
        public ShowFactsModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public IActionResult OnGet()
        {
            fact = db.tbl_facts.FirstOrDefault();
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
    }
}
