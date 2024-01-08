using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class LoginModel : PageModel
    {
        AppDbContext db;
        public User user { get; set; }
        public LoginModel(AppDbContext db)
        {
            this.db = db;
            
        }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost(User user)
        {
            if (ModelState.IsValid)
            {
                var result = db.tbl_user.Where(opt => opt.UserName.Equals(user.UserName) && opt.PassKey.Equals(user.PassKey)).FirstOrDefault();
                if (result is not null)
                {
                    HttpContext.Session.SetString("flag", "true");
                    return RedirectToPage("index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }

    }
}
