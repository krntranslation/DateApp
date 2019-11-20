using CommonDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommonDate.Controllers
{

    public class ImageController : Controller
    {
        ApplicationDbContext context;

        public ImageController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.Images.ToList());
        }

        // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            Image image = context.Images.Where(u => u.Id == id).FirstOrDefault();
            return View(image);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
