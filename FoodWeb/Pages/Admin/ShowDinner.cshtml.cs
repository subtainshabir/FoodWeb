using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowDinnerModel : PageModel
    {
        AppDbContext db;
        public List<Dinner> dinner { get; set; }
        public ShowDinnerModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public IActionResult OnGet()
        {
            dinner=db.tbl_dinner.ToList();
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
