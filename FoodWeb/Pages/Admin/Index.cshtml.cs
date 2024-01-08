using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class IndexModel : PageModel
    {
        AppDbContext db;
        public List<Orders> order { get; set; }
        public List<ContactInfo> messages { get; set; }
        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            order = db.tbl_orders.ToList();
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
