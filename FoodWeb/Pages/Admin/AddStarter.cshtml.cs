using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddStarterModel : PageModel
    {
        public Starter starter { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public AddStarterModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db= db;
            this.env = env;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Starter starter)
        {
            string ImageName = starter.Photo.FileName.ToString();
            var Folderpath = Path.Combine(env.WebRootPath, "menu_images", "starter");
            var ImagePath = Path.Combine(Folderpath, ImageName);

            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            starter.Photo.CopyTo(fs);
            fs.Dispose();

            starter.Image = ImageName;
            db.tbl_starter.Add(starter);
            db.SaveChanges();
            return RedirectToPage("ShowStarter");
        }
    }
}
