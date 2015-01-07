using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web.Mvc;
using MetroAPP.Models.Picture;

namespace MetroAPP.Controllers
{
    public class NaslovnicaController : Controller
    {
        //
        // GET: /Naslovnica/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(string email)
        {
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                mail.To.Add(ConfigurationManager.AppSettings["EmailTo"]);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailTo"]);
                mail.Subject = "Subscriber";
                string body = email;
                mail.Body = body;
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            return View();
        }
        public ActionResult AddItemNaslovnica(Picture picture)
        {
            var pic = Path.GetFileName(picture.File.FileName);
            var pictureSrc = picture.File.FileName;
            if (Request.Form["directory"] == "Slider")
            {
                pictureSrc = "'/Images/Naslovnica/Slider/" + picture.File.FileName + "'";
            }
            var path = Path.Combine(Server.MapPath("~/Images/Naslovnica/" + Request.Form["directory"] + "/"), pic);
            // file is uploaded               
            picture.File.SaveAs(path);

            using (var db = new MainDatabaseEntities())
            {
                var naslovnicaItemDb = db.GalleryAndSliderAndNaslovnica;
                var naslovnicaItem = new GalleryAndSliderAndNaslovnica();
                naslovnicaItem.ItemHTMLplace = Request.Form["itemHtmLplace"];
                naslovnicaItem.NaslovnicaItemActionLink = Request.Form["actionLink"];
                naslovnicaItem.NaslovnicaItemNaslov = Request.Form["pictureTitle"];
                naslovnicaItem.SliderListItemActive = Request.Form["itemActive"];
                naslovnicaItem.PictureSrc = pictureSrc;
                naslovnicaItem.NaslovnicaItemText = Request.Form["pictureTitle"];
                naslovnicaItemDb.Add(naslovnicaItem);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Naslovnica");
        }
        public ActionResult RemoveItemNaslovnica(int pictureId, string pictureSrc, string directory)
        {
            var truePictureSrc = pictureSrc;
            if (directory == "Slider")
            {
                truePictureSrc = pictureSrc.Substring(pictureSrc.LastIndexOf('/') + 1);
                truePictureSrc = truePictureSrc.TrimEnd('\'');
            }
            string fullPath = Request.MapPath("~/Images/Naslovnica/" + directory + "/" + truePictureSrc);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            using (var db = new MainDatabaseEntities())
            {
                var item = db.GalleryAndSliderAndNaslovnica.Find(pictureId);
                db.GalleryAndSliderAndNaslovnica.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Naslovnica");
        }
    }
}
