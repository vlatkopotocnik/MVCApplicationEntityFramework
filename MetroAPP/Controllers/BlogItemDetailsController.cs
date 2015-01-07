using System;
using System.Web.Mvc;

namespace MetroAPP.Controllers
{
    public class BlogItemDetailsController : Controller
    {
        //
        // GET: /BlogItemDetails/

        public ActionResult Index(int blogId)
        {
            using (var db = new MainDatabaseEntities())
            {
                var blogItem = db.BlogItem.Find(blogId);
                return View(blogItem);
            }
        }

        public ActionResult MessagePost()
        {
            using (var db = new MainDatabaseEntities())
            {

                var blogComment = new BlogComment();

                blogComment.CommentIdBlog = Int32.Parse(Request.Form["CommentIdBlog"]);
                blogComment.CommentText = Request.Form["message"];
                blogComment.CommentDate = DateTime.Now;
                blogComment.KorisnikId = Int32.Parse(Session["Korisnik"].ToString());
                db.BlogComment.Add(blogComment);
                db.SaveChanges();
            }
            return View("messagePost", null, Request.Form["CommentIdBlog"]);
        }

    }
}
