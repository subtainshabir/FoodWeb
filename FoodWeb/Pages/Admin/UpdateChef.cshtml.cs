using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateChefModel : PageModel
    {
        public Chefs chef { get; set; }
        AppDbContext db;
        IWebHostEnvironment env;
        public UpdateChefModel(AppDbContext db, IWebHostEnvironment env)
        {
            
            this.db = db;
            this.env = env;
        }
        public IActionResult OnGet(int id)
        {
            var itemtoupdate = db.tbl_chefs.Find(id);
            chef = itemtoupdate;
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
        public IActionResult OnPost(Chefs chef)
        { 
            if (chef.Photo != null)
            {
                string ImageName = chef.Photo.FileName.ToString();
                var Folderpath = Path.Combine(env.WebRootPath,"chefs");
                var ImagePath = Path.Combine(Folderpath, ImageName);

                var fs = new FileStream(ImagePath, FileMode.Create);
                chef.Photo.CopyTo(fs);

                chef.Image = ImageName;
                db.tbl_chefs.Update(chef);
                db.SaveChanges();
                return Redirect($"updatechef?id={chef.id}");
            }
            else
            {
                db.tbl_chefs.Update(chef);
                db.SaveChanges();
                return Redirect($"updateChef?id={chef.id}");
            }
        }
    }
}
