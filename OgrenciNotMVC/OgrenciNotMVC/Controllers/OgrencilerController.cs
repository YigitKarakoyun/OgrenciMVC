﻿using OgrenciNotMVC.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace OgrenciNotMVC.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            return View(db.TBLOGRENCILER.ToList());
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m=>m.KULUPID==p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;

            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return  RedirectToAction("Index");
        }
        //List<SelectListItem> items = new List<SelectListItem>();
        //items.Add(new SelectListItem { Text = "Matematik", Value = "0" });
        //    items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });
        //    items.Add(new SelectListItem { Text = "Atatürk İlke ve İnkilapları", Value = "2"});
        //    items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });
        //    items.Add(new SelectListItem { Text = "Edebiyat", Value = "4" });
        //    ViewBag.DersAd = items;
    }
}