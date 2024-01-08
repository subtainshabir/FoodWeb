using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace FoodWeb.Pages.Admin
{
    public class UpdateLunchModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;

        public Launch launch { get; set; }
        public UpdateLunchModel( AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;

        }
        public IActionResult OnGet(int id)
        {
            launch = db.tbl_launch.Find(id);
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
        public IActionResult OnPost(Launch launch)
        {
            if (launch.Photo != null)
            {
                var Imagename = launch.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "menu_images", "Lunch");
                var ImagePath = Path.Combine(FolderPath, Imagename);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                launch.Photo.CopyTo(fs);
                fs.Dispose();

                launch.Image = Imagename;
                db.tbl_launch.Update(launch);
                db.SaveChanges();
                return Redirect($"UpdateLunch?id={launch.id}");
            }
            else
            {
                db.tbl_launch.Update(launch);
                db.SaveChanges();
                return Redirect($"UpdateLunch?id={launch.id}");
            }
        }
    }
}
