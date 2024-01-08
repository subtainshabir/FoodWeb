using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowOfferModel : PageModel
    {
        AppDbContext db;
        public List<Offers> offer { get; set; }
        public ShowOfferModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            offer=db.tbl_offers.ToList();
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
