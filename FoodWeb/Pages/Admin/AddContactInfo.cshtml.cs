using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddContactInfoModel : PageModel
    {
        AppDbContext db;
        public ContactInfo contactinfo { get; set; }
        public AddContactInfoModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(ContactInfo contactinfo)
        {
            db.tbl_contact.Add(contactinfo);
            db.SaveChanges();
            return RedirectToPage("ShowContactInfo");
        }
    }
}
