using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateContactInfoModel : PageModel
    {
        public ContactInfo contactinfo { get; set; }
        AppDbContext db;
        public UpdateContactInfoModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet(int id)
        {
            contactinfo = db.tbl_contact.Find(id);
        }
        public IActionResult OnPost(ContactInfo contactinfo)
        {
            db.tbl_contact.Update(contactinfo);
            db.SaveChanges();
            return RedirectToPage("ShowContactInfo");
        }
    }
}
