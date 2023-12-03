using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class AddOffersModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Offers offer { get; set; }
        public AddOffersModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
            
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Offers offer)
        {
            var ImageName = offer.Photo.FileName.ToString();
            var FolderName = Path.Combine(env.WebRootPath, "offers");
            var ImageFolder=Path.Combine(FolderName, ImageName);

            FileStream fs=new FileStream(ImageFolder, FileMode.Create);
            offer.Photo.CopyTo(fs);
            fs.Dispose();

            offer.Image = ImageName;
            db.tbl_offers.Add(offer);
            db.SaveChanges();
            return RedirectToPage("ShowOffer");
        }
    }
}
