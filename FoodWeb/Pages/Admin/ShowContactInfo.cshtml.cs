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
        public void OnGet()
        {
            contact = db.tbl_contact.FirstOrDefault();
        }
    }
}
