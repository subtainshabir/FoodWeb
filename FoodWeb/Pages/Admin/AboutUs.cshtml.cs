using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace FoodWeb.Pages.Admin
{
    public class AboutUsModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public AboutUs about { get; set; }
        public AboutUsModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env=env;
            
        }
        public IActionResult OnGet()
        {
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
        public IActionResult OnPost(AboutUs about)
        {
            var ImageName = about.Photo.FileName.ToString();
            var FolderPath = Path.Combine(env.WebRootPath, "about_us");
            var ImagePath = Path.Combine(FolderPath, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            about.Photo.CopyTo(fs);
            fs.Dispose();

            about.Image = ImageName;
            db.tbl_about.Add(about);
            db.SaveChanges();
            return RedirectToPage("ShowAbout");
        }
    }
}
