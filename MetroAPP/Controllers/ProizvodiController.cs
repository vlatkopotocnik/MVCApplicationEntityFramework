using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using MetroAPP.Models.Picture;
using MetroAPP.Models.Proizvodi;

namespace MetroAPP.Controllers
{
    public class ProizvodiController : Controller
    {
        //
        // GET: /Proizvodi/

        public ActionResult Index()
        {
            if (Request.Form["search"] == null)
            {
                using (var db = new MainDatabaseEntities())
                {
                    var listProizvoda = db.Proizvod.ToList();
                    return View(listProizvoda);
                }
            }

            using (var db = new MainDatabaseEntities())
            {
                int idSearch;
                if (Int32.TryParse(Request.Form["search"], out idSearch))
                {
                    var searchedProizvod = db.Proizvod.Where(id => id.ProizvodId == idSearch).ToList();
                    return View(searchedProizvod);
                }
                else
                {
                    string nameSearch = Request.Form["search"];
                    var searchedProizvod = db.Proizvod.Where(name => name.ProizvodNaziv == nameSearch).ToList();
                    if (searchedProizvod.Count == 0)
                    {
                        searchedProizvod = db.Proizvod.Where(des => des.ProizvodOpis.Contains(nameSearch)).ToList();
                    }
                    return View(searchedProizvod);
                }

            }
        }

        public ActionResult AddToCart(int proizvodId, string proizvodImgSrc, string proizvodNaziv, decimal proizvodCijena)
        {
            var itemCart = new Cart();
            var listCart = new List<Cart>(); 
            if(Session["listCart"] != null) 
                listCart = (List<Cart>)Session["listCart"];
            itemCart.ProizvodId = proizvodId;
            itemCart.ProizvodImgSrc = proizvodImgSrc;
            itemCart.ProizvodCijena = proizvodCijena;
            itemCart.ProizvodNaziv = proizvodNaziv;
            listCart.Add(itemCart);
            Session["listCart"] = listCart;
            Session["itemNumber"] = listCart.Count;
            return RedirectToAction("Index", "Proizvodi");
        }

        public ActionResult CartDetails()
        {
            var listCart = (List<Cart>) Session["listCart"];
            var listCartAndTotalPrice = new CartAndTotalPrice(0);
            if (listCart != null)
                foreach (var item in listCart)
                {
                    listCartAndTotalPrice.TotalPrice += item.ProizvodCijena;
                }
            listCartAndTotalPrice.ListCart = listCart;
            return View(listCartAndTotalPrice);
        }

        public ActionResult RemoveItem(int proizvodId = 0)
        {
            var listCart = (List<Cart>)Session["listCart"];
            var listCartAndTotalPrice = new CartAndTotalPrice(0);
            listCart.Remove( listCart.Single(i => i.ProizvodId ==  proizvodId));
            Session["listCart"] = listCart;
            foreach (var item in listCart)
            {
                listCartAndTotalPrice.TotalPrice += item.ProizvodCijena;
            }
            listCartAndTotalPrice.ListCart = listCart;
            Session["itemNumber"] = listCart.Count();       
            return RedirectToAction("CartDetails", listCartAndTotalPrice);
        }

        public ActionResult HellsBellsAdd(Picture picture)
        {
            var pic = Path.GetFileName(picture.File.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/Products/" + Request.Form["proizvodKategorija"]), pic);
            // file is uploaded               
            picture.File.SaveAs(path);

            using (var db = new MainDatabaseEntities())
            {
                var proizvod = new Proizvod();
                proizvod.ProizvodImgSrc = "/" + Request.Form["proizvodKategorija"] + "/" + picture.File.FileName;
                proizvod.ProizvodNaziv = Request.Form["proizvodNaziv"];
                proizvod.ProizvodCijena = Decimal.Parse(Request.Form["proizvodCijena"]);
                proizvod.ProizvodPage = Int32.Parse(Request.Form["proizvodPage"]);
                proizvod.ProizvodCategory = Request.Form["proizvodKategorija"];
                proizvod.ProizvodOpis = Request.Form["proizvodOpis"];
                db.Proizvod.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index", "Proizvodi");
            }
        }

        public ActionResult HellsBellsRemove(int proizvodId, string proizvodImgSrc)
        {
            string fullPath = Request.MapPath("~/Images/Products" + proizvodImgSrc);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            using (var db = new MainDatabaseEntities())
            {
                var proizvod = db.Proizvod.Find(proizvodId);
                db.Proizvod.Remove(proizvod);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Proizvodi");
        }
    }
}
