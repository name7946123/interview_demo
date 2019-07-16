using interview_demo.DAL;
using interview_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace interview_demo.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryContext db = new CategoryContext();
        
        //首頁
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        //資料詳細頁
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        //建立資料頁
        public ActionResult Create()
        {
            return View();
        }

        //建立資料流程
        [HttpPost]
        public ActionResult Create([Bind(Include = "title, is_published")]Category categoey)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoey.created_at = DateTime.Now;
                    categoey.modified_at = DateTime.Now;
                    db.Categories.Add(categoey);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }

            return View(categoey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
