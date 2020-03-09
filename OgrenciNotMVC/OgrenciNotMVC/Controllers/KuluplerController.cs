using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
namespace OgrenciNotMVC.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER temp)
        {
            db.TBLKULUPLER.Add(temp);
            db.SaveChanges();
            return View();
        }

        //[HttpGet]
        public ActionResult Sil(int id)
        {
            TBLKULUPLER kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();

            return RedirectToAction("Index","Kulupler");
        }
    }
}