using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateStarterModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Starter starter { get; set; }
        public UpdateStarterModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public void OnGet(int id)
        {
            starter = db.tbl_starter.Find(id);
        }
        public IActionResult OnPost(Starter starter)
        {
            if (starter.Photo != null)
            {
                var FileName = starter.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "menu_images", "starter");
                var FilePath = Path.Combine(env.WebRootPath, FolderPath, FileName);

                FileStream fs = new FileStream(FilePath, FileMode.Create);
                starter.Photo.CopyTo(fs);
                fs.Close();

                starter.Image = FileName;
                db.tbl_starter.Update(starter);
                db.SaveChanges();
                return Redirect($"UpdateStarter?id={starter.id}");
            }
            else
            {
                db.tbl_starter.Update(starter);
                db.SaveChanges();
                return Redirect($"UpdateStarter?id={starter.id}");
            }
            
        }
    }
}
