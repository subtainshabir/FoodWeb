using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateAboutModel : PageModel
    {
        public AboutUs about { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public UpdateAboutModel(IWebHostEnvironment env, AppDbContext db)
        {

            this.env = env;
            this.db = db;

        }
        public void OnGet(int id)
        {
            about = db.tbl_about.Find(id);
        }
        public IActionResult OnPost(AboutUs about)
        {
            if (about.Photo != null)
            {
                var Imagename = about.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "about_us");
                var ImagePath = Path.Combine(FolderPath, Imagename);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                about.Photo.CopyTo(fs);
                fs.Dispose();

                about.Image = Imagename;
                db.tbl_about.Update(about);
                db.SaveChanges();
                return Redirect($"UpdateAbout?id={about.id}");
            }
            else
            {
                db.tbl_about.Update(about);
                db.SaveChanges();
                return Redirect($"UpdateAbout?id={about.id}");
            }
        }
    }
}
