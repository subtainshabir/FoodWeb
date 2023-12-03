using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class GallaryModel : PageModel
    {
        AppDbContext db;
        public Pictures pictures { get; set; }
        IWebHostEnvironment env;

        public GallaryModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.env=env;
            this.db = db;
            
        }

        public void OnGet()
        {
        }
        public void OnPost(Pictures pictures)
        {
            var ImageName = pictures.Photo.FileName.ToString();
            var FolderPath = Path.Combine(env.WebRootPath, "Gallary");
            var ImagePath=Path.Combine(FolderPath, ImageName);

            FileStream fs=new FileStream(ImagePath, FileMode.Create);
            pictures.Photo.CopyTo(fs);
            fs.Dispose();

            pictures.Image = ImageName;
            db.tbl_gallay.Add(pictures);
            db.SaveChanges();
        }
    }
}
