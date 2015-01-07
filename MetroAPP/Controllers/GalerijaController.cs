using System.IO;
using System.Web.Mvc;
using MetroAPP.Models.Picture;

namespace MetroAPP.Controllers
{
    public class GalerijaController : Controller
    {
        //
        // GET: /Galerija/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RemoveItem(int pictureId, string pictureSrc)
        {
            string fullPath = Request.MapPath("~/Images/Gallery/" + pictureSrc);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            using (var db = new MainDatabaseEntities())
            {
                var itemGallery = db.GalleryAndSliderAndNaslovnica.Find(pictureId);
                db.GalleryAndSliderAndNaslovnica.Remove(itemGallery);
                db.SaveChanges();
            }            
            return RedirectToAction("Index", "Galerija");
        }

        public ActionResult AddItem(Picture picture)
        {
            string picturePage = Request.Form["picturePage"];
            var pic = Path.GetFileName(picture.File.FileName);

            var directory = Server.MapPath("~/Images/Gallery/" + Request.Form["picturePage"]);
            if(!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var path = Path.Combine(Server.MapPath("~/Images/Gallery/" + picturePage), pic);
            // file is uploaded               
            picture.File.SaveAs(path);

            using (var db = new MainDatabaseEntities())
            {
                var itemGallery = new GalleryAndSliderAndNaslovnica();
                itemGallery.PictureSrc = Request.Form["picturePage"] + "/" + picture.File.FileName;
                itemGallery.PicturePage = Request.Form["picturePage"];
                itemGallery.ItemHTMLplace = "Gallery";
                db.GalleryAndSliderAndNaslovnica.Add(itemGallery);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Galerija");
        }
    }
}
