using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
namespace OgrenciNotMVC.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Dersler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            return View(db.TBLDERSLER.ToList());
        }
    }
}