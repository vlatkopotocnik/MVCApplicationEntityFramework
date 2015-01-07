﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetroAPP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MainDatabaseEntities : DbContext
    {
        public MainDatabaseEntities()
            : base("name=MainDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlogComment> BlogComment { get; set; }
        public virtual DbSet<BlogItem> BlogItem { get; set; }
        public virtual DbSet<GalleryAndSliderAndNaslovnica> GalleryAndSliderAndNaslovnica { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CHECKKorisnik(string korisnikUsername)
        {
            var korisnikUsernameParameter = korisnikUsername != null ?
                new ObjectParameter("KorisnikUsername", korisnikUsername) :
                new ObjectParameter("KorisnikUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CHECKKorisnik", korisnikUsernameParameter);
        }
    
        public virtual int DELETEGalleryItem(Nullable<int> pictureId)
        {
            var pictureIdParameter = pictureId.HasValue ?
                new ObjectParameter("PictureId", pictureId) :
                new ObjectParameter("PictureId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETEGalleryItem", pictureIdParameter);
        }
    
        public virtual int DELETEHellsBells(Nullable<int> proizvodId)
        {
            var proizvodIdParameter = proizvodId.HasValue ?
                new ObjectParameter("ProizvodId", proizvodId) :
                new ObjectParameter("ProizvodId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETEHellsBells", proizvodIdParameter);
        }
    
        public virtual int DELETEKorisnikItem(Nullable<int> korisnikId)
        {
            var korisnikIdParameter = korisnikId.HasValue ?
                new ObjectParameter("KorisnikId", korisnikId) :
                new ObjectParameter("KorisnikId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETEKorisnikItem", korisnikIdParameter);
        }
    
        public virtual int DELETENaslovnicaItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETENaslovnicaItem", idParameter);
        }
    
        public virtual int INSERTBlogComment(Nullable<int> commentIdBlog, string commentText, Nullable<System.DateTime> commentDate, Nullable<int> korisnikId)
        {
            var commentIdBlogParameter = commentIdBlog.HasValue ?
                new ObjectParameter("CommentIdBlog", commentIdBlog) :
                new ObjectParameter("CommentIdBlog", typeof(int));
    
            var commentTextParameter = commentText != null ?
                new ObjectParameter("CommentText", commentText) :
                new ObjectParameter("CommentText", typeof(string));
    
            var commentDateParameter = commentDate.HasValue ?
                new ObjectParameter("CommentDate", commentDate) :
                new ObjectParameter("CommentDate", typeof(System.DateTime));
    
            var korisnikIdParameter = korisnikId.HasValue ?
                new ObjectParameter("KorisnikId", korisnikId) :
                new ObjectParameter("KorisnikId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTBlogComment", commentIdBlogParameter, commentTextParameter, commentDateParameter, korisnikIdParameter);
        }
    
        public virtual int INSERTGalleryItem(string pictureSrc, string picturePage, string itemHTMLplace)
        {
            var pictureSrcParameter = pictureSrc != null ?
                new ObjectParameter("PictureSrc", pictureSrc) :
                new ObjectParameter("PictureSrc", typeof(string));
    
            var picturePageParameter = picturePage != null ?
                new ObjectParameter("PicturePage", picturePage) :
                new ObjectParameter("PicturePage", typeof(string));
    
            var itemHTMLplaceParameter = itemHTMLplace != null ?
                new ObjectParameter("ItemHTMLplace", itemHTMLplace) :
                new ObjectParameter("ItemHTMLplace", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTGalleryItem", pictureSrcParameter, picturePageParameter, itemHTMLplaceParameter);
        }
    
        public virtual int INSERTHellsBells(string proizvodImgSrc, string proizvodNaziv, Nullable<decimal> proizvodCijena, Nullable<int> proizvodPage, string proizvodCategory, string proizvodOpis)
        {
            var proizvodImgSrcParameter = proizvodImgSrc != null ?
                new ObjectParameter("ProizvodImgSrc", proizvodImgSrc) :
                new ObjectParameter("ProizvodImgSrc", typeof(string));
    
            var proizvodNazivParameter = proizvodNaziv != null ?
                new ObjectParameter("ProizvodNaziv", proizvodNaziv) :
                new ObjectParameter("ProizvodNaziv", typeof(string));
    
            var proizvodCijenaParameter = proizvodCijena.HasValue ?
                new ObjectParameter("ProizvodCijena", proizvodCijena) :
                new ObjectParameter("ProizvodCijena", typeof(decimal));
    
            var proizvodPageParameter = proizvodPage.HasValue ?
                new ObjectParameter("ProizvodPage", proizvodPage) :
                new ObjectParameter("ProizvodPage", typeof(int));
    
            var proizvodCategoryParameter = proizvodCategory != null ?
                new ObjectParameter("ProizvodCategory", proizvodCategory) :
                new ObjectParameter("ProizvodCategory", typeof(string));
    
            var proizvodOpisParameter = proizvodOpis != null ?
                new ObjectParameter("ProizvodOpis", proizvodOpis) :
                new ObjectParameter("ProizvodOpis", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTHellsBells", proizvodImgSrcParameter, proizvodNazivParameter, proizvodCijenaParameter, proizvodPageParameter, proizvodCategoryParameter, proizvodOpisParameter);
        }
    
        public virtual int INSERTKorisnik(string korisnikIme, string korisnikPrezime, Nullable<System.DateTime> korisnikRegistracija, string korisnikSlika, string korisnikPassword, string korisnikUsername)
        {
            var korisnikImeParameter = korisnikIme != null ?
                new ObjectParameter("KorisnikIme", korisnikIme) :
                new ObjectParameter("KorisnikIme", typeof(string));
    
            var korisnikPrezimeParameter = korisnikPrezime != null ?
                new ObjectParameter("KorisnikPrezime", korisnikPrezime) :
                new ObjectParameter("KorisnikPrezime", typeof(string));
    
            var korisnikRegistracijaParameter = korisnikRegistracija.HasValue ?
                new ObjectParameter("KorisnikRegistracija", korisnikRegistracija) :
                new ObjectParameter("KorisnikRegistracija", typeof(System.DateTime));
    
            var korisnikSlikaParameter = korisnikSlika != null ?
                new ObjectParameter("KorisnikSlika", korisnikSlika) :
                new ObjectParameter("KorisnikSlika", typeof(string));
    
            var korisnikPasswordParameter = korisnikPassword != null ?
                new ObjectParameter("KorisnikPassword", korisnikPassword) :
                new ObjectParameter("KorisnikPassword", typeof(string));
    
            var korisnikUsernameParameter = korisnikUsername != null ?
                new ObjectParameter("KorisnikUsername", korisnikUsername) :
                new ObjectParameter("KorisnikUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTKorisnik", korisnikImeParameter, korisnikPrezimeParameter, korisnikRegistracijaParameter, korisnikSlikaParameter, korisnikPasswordParameter, korisnikUsernameParameter);
        }
    
        public virtual int INSERTNaslovnicaItem(string pictureSrc, string naslovnicaItemNaslov, string naslovnicaItemText, string naslovnicaItemActionLink, string sliderListItemActive, string itemHTMLplace)
        {
            var pictureSrcParameter = pictureSrc != null ?
                new ObjectParameter("PictureSrc", pictureSrc) :
                new ObjectParameter("PictureSrc", typeof(string));
    
            var naslovnicaItemNaslovParameter = naslovnicaItemNaslov != null ?
                new ObjectParameter("NaslovnicaItemNaslov", naslovnicaItemNaslov) :
                new ObjectParameter("NaslovnicaItemNaslov", typeof(string));
    
            var naslovnicaItemTextParameter = naslovnicaItemText != null ?
                new ObjectParameter("NaslovnicaItemText", naslovnicaItemText) :
                new ObjectParameter("NaslovnicaItemText", typeof(string));
    
            var naslovnicaItemActionLinkParameter = naslovnicaItemActionLink != null ?
                new ObjectParameter("NaslovnicaItemActionLink", naslovnicaItemActionLink) :
                new ObjectParameter("NaslovnicaItemActionLink", typeof(string));
    
            var sliderListItemActiveParameter = sliderListItemActive != null ?
                new ObjectParameter("SliderListItemActive", sliderListItemActive) :
                new ObjectParameter("SliderListItemActive", typeof(string));
    
            var itemHTMLplaceParameter = itemHTMLplace != null ?
                new ObjectParameter("ItemHTMLplace", itemHTMLplace) :
                new ObjectParameter("ItemHTMLplace", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTNaslovnicaItem", pictureSrcParameter, naslovnicaItemNaslovParameter, naslovnicaItemTextParameter, naslovnicaItemActionLinkParameter, sliderListItemActiveParameter, itemHTMLplaceParameter);
        }
    
        public virtual ObjectResult<SEARCHKorisnik_Result> SEARCHKorisnik(string korisnikUsername, string korisnikPassword)
        {
            var korisnikUsernameParameter = korisnikUsername != null ?
                new ObjectParameter("KorisnikUsername", korisnikUsername) :
                new ObjectParameter("KorisnikUsername", typeof(string));
    
            var korisnikPasswordParameter = korisnikPassword != null ?
                new ObjectParameter("KorisnikPassword", korisnikPassword) :
                new ObjectParameter("KorisnikPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SEARCHKorisnik_Result>("SEARCHKorisnik", korisnikUsernameParameter, korisnikPasswordParameter);
        }
    
        public virtual ObjectResult<SEARCHProizvod_Result> SEARCHProizvod(string proizvodName)
        {
            var proizvodNameParameter = proizvodName != null ?
                new ObjectParameter("ProizvodName", proizvodName) :
                new ObjectParameter("ProizvodName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SEARCHProizvod_Result>("SEARCHProizvod", proizvodNameParameter);
        }
    
        public virtual ObjectResult<SELECTAllBlogComment_Result> SELECTAllBlogComment(Nullable<int> commentIdBlog)
        {
            var commentIdBlogParameter = commentIdBlog.HasValue ?
                new ObjectParameter("CommentIdBlog", commentIdBlog) :
                new ObjectParameter("CommentIdBlog", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllBlogComment_Result>("SELECTAllBlogComment", commentIdBlogParameter);
        }
    
        public virtual ObjectResult<SELECTAllBlogDetails_Result> SELECTAllBlogDetails(Nullable<int> blogId)
        {
            var blogIdParameter = blogId.HasValue ?
                new ObjectParameter("BlogId", blogId) :
                new ObjectParameter("BlogId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllBlogDetails_Result>("SELECTAllBlogDetails", blogIdParameter);
        }
    
        public virtual ObjectResult<SELECTAllBlogItem_Result> SELECTAllBlogItem(Nullable<int> blockPage)
        {
            var blockPageParameter = blockPage.HasValue ?
                new ObjectParameter("BlockPage", blockPage) :
                new ObjectParameter("BlockPage", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllBlogItem_Result>("SELECTAllBlogItem", blockPageParameter);
        }
    
        public virtual ObjectResult<SELECTAllBlogKorisnik_Result> SELECTAllBlogKorisnik(Nullable<int> korisnikId)
        {
            var korisnikIdParameter = korisnikId.HasValue ?
                new ObjectParameter("KorisnikId", korisnikId) :
                new ObjectParameter("KorisnikId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllBlogKorisnik_Result>("SELECTAllBlogKorisnik", korisnikIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SELECTAllBlogPages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SELECTAllBlogPages");
        }
    
        public virtual ObjectResult<SELECTAllBlogRecentComments_Result> SELECTAllBlogRecentComments()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllBlogRecentComments_Result>("SELECTAllBlogRecentComments");
        }
    
        public virtual ObjectResult<SELECTAllGalleryImage_Result> SELECTAllGalleryImage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllGalleryImage_Result>("SELECTAllGalleryImage");
        }
    
        public virtual ObjectResult<SELECTAllKorisnik_Result> SELECTAllKorisnik()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllKorisnik_Result>("SELECTAllKorisnik");
        }
    
        public virtual ObjectResult<SELECTAllNaslovnicaDataListItem_Result> SELECTAllNaslovnicaDataListItem()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllNaslovnicaDataListItem_Result>("SELECTAllNaslovnicaDataListItem");
        }
    
        public virtual ObjectResult<SELECTAllNaslovnicaSliderListItem_Result> SELECTAllNaslovnicaSliderListItem()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllNaslovnicaSliderListItem_Result>("SELECTAllNaslovnicaSliderListItem");
        }
    
        public virtual ObjectResult<SELECTAllProizvod_Result> SELECTAllProizvod(Nullable<int> proizvodPage)
        {
            var proizvodPageParameter = proizvodPage.HasValue ?
                new ObjectParameter("ProizvodPage", proizvodPage) :
                new ObjectParameter("ProizvodPage", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTAllProizvod_Result>("SELECTAllProizvod", proizvodPageParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SELECTDistinctAllProizvodPages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SELECTDistinctAllProizvodPages");
        }
    
        public virtual ObjectResult<SELECTOrSearchProizvod_Result> SELECTOrSearchProizvod(Nullable<int> proizvodPage, string proizvodSearch)
        {
            var proizvodPageParameter = proizvodPage.HasValue ?
                new ObjectParameter("ProizvodPage", proizvodPage) :
                new ObjectParameter("ProizvodPage", typeof(int));
    
            var proizvodSearchParameter = proizvodSearch != null ?
                new ObjectParameter("ProizvodSearch", proizvodSearch) :
                new ObjectParameter("ProizvodSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTOrSearchProizvod_Result>("SELECTOrSearchProizvod", proizvodPageParameter, proizvodSearchParameter);
        }
    
        public virtual ObjectResult<SELECTOrSearchProizvodDescription_Result> SELECTOrSearchProizvodDescription(string proizvodSearch)
        {
            var proizvodSearchParameter = proizvodSearch != null ?
                new ObjectParameter("ProizvodSearch", proizvodSearch) :
                new ObjectParameter("ProizvodSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTOrSearchProizvodDescription_Result>("SELECTOrSearchProizvodDescription", proizvodSearchParameter);
        }
    
        public virtual ObjectResult<SELECTOrSearchProizvodId_Result> SELECTOrSearchProizvodId(Nullable<int> proizvodSearch)
        {
            var proizvodSearchParameter = proizvodSearch.HasValue ?
                new ObjectParameter("ProizvodSearch", proizvodSearch) :
                new ObjectParameter("ProizvodSearch", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECTOrSearchProizvodId_Result>("SELECTOrSearchProizvodId", proizvodSearchParameter);
        }
    }
}