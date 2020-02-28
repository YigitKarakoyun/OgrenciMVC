using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
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
    }
}