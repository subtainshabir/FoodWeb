using FoodWeb.Data;
using FoodWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodWeb.Pages.Admin
{
    public class UpdateOffersModel : PageModel
    {
        AppDbContext db;
        public Offers offer { get; set; }
        IWebHostEnvironment env;
        public UpdateOffersModel(AppDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet(int id)
        {
            offer = db.tbl_offers.Find(id);
            
        }
        public IActionResult OnPost(Offers offer)
        {
            if (offer.Photo != null)
            {
                var Imagename = offer.Photo.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "offers");
                var ImagePath = Path.Combine(FolderPath, Imagename);

                FileStream fs = new FileStream(ImagePath, FileMode.Create);
                offer.Photo.CopyTo(fs);
                fs.Dispose();

                offer.Image = Imagename;
                db.tbl_offers.Update(offer);
                db.SaveChanges();
                return Redirect($"UpdateOffers?id={offer.id}");
            }
            else
            {
                db.tbl_offers.Update(offer);
                db.SaveChanges();
                return Redirect($"Updateoffers?id={offer.id}");
            }

        }
    }
}
