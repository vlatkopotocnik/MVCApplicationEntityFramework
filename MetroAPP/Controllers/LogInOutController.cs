using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using MetroAPP.Models.Picture;

namespace MetroAPP.Controllers
{
    public class LogInOutController : Controller
    {
        //
        // GET: /LogInOut/

        public ActionResult Index(Boolean logOut = false)
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            if (username == null || password == null)
            {
                return View();
            }
            using (var db = new MainDatabaseEntities())
            {
                try
                {
                    var korisnici = db.Korisnik.Where(un=>un.KorisnikUsername == username);
                    foreach (var korisnik in korisnici)
                    {
                        if (korisnik.KorisnikPassword == password)
                        {
                            Session["Korisnik"] = korisnik.KorisnikId;
                            Session["User"] = korisnik.KorisnikUsername;
                        }
                    }                    
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (Session["Korisnik"] != null)
                return RedirectToAction("Index", "Naslovnica");
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Naslovnica");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registred(Picture picture)
        {
            if (Request.Form["ime"] == String.Empty || Request.Form["prezime"] == String.Empty ||
                Request.Form["username"] == String.Empty || Request.Form["password"] == String.Empty)
                return RedirectToAction("Register");
            using (var db = new MainDatabaseEntities())
            {
                try
                {
                    var korisnik = new Korisnik();
                    korisnik.KorisnikUsername = Request.Form["username"];
                    korisnik.KorisnikIme = Request.Form["ime"];
                    korisnik.KorisnikPrezime = Request.Form["prezime"];
                    korisnik.KorisnikRegistracija = DateTime.Now;
                    korisnik.KorisnikSlika = picture.File.FileName;
                    korisnik.KorisnikPassword = Request.Form["password"];
                    korisnik.KorisnikUsername = Request.Form["username"];
                    db.Korisnik.Add(korisnik);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (picture.File.ContentLength > 0)
            {
                var pic = Path.GetFileName(picture.File.FileName);
                if (pic != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Korisnik"), pic);
                    // file is uploaded               
                    picture.File.SaveAs(path);
                }
            }
            return View();
        }

    }
}
