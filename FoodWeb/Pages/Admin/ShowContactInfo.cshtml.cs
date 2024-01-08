using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class ShowContactInfoModel : PageModel
    {
        AppDbContext db;
        public ContactInfo contact { get; set; }
        public ShowContactInfoModel(AppDbContext db)
        {
            this.db=db;
        }
        public IActionResult OnGet()
        {
            contact = db.tbl_contact.FirstOrDefault();
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
