using System;
using System.IO;
using System.Web.Mvc;
using MetroAPP.Models.Picture;

namespace MetroAPP.Controllers
{
    public class KorisnikController : Controller
    {
        //
        // GET: /Korisnik/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddItem(Picture picture)
        {
            var pic = Path.GetFileName(picture.File.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/Korisnik/"), pic);
            // file is uploaded               
            picture.File.SaveAs(path);

            using (var db = new MainDatabaseEntities())
            {
                var korisnik = new Korisnik();
                korisnik.KorisnikIme = Request.Form["korisnikIme"];
                korisnik.KorisnikPrezime = Request.Form["korisnikPrezime"];
                korisnik.KorisnikRegistracija = DateTime.Now;
                korisnik.KorisnikPassword = Request.Form["korisnikPassword"];
                korisnik.KorisnikUsername = Request.Form["korisnikUsername"];
                db.Korisnik.Add(korisnik);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Korisnik");
        }
        public ActionResult RemoveItem(int korisnikId, string korisnikSlika)
        {
            string fullPath = Request.MapPath("~/Images/Korisnik/" + korisnikSlika);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            using (var db = new MainDatabaseEntities())
            {
                var findKorisnik = db.Korisnik.Find(korisnikId);
                db.Korisnik.Remove(findKorisnik);
                db.SaveChanges();
            }  

            return RedirectToAction("Index", "Korisnik");
        }

    }
}
