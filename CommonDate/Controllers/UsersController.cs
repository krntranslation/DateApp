using CommonDate.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CommonDate.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context;
        public UsersController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User users = new User();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                string id = User.Identity.GetUserId();
                user.ApplicationId = id;
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                User editedUser = context.Users.Where(u => u.Id == id).FirstOrDefault();
                editedUser.FirstName = user.FirstName;
                editedUser.LastName = user.LastName;
                editedUser.EmailAddress = user.EmailAddress;
                editedUser.StreetAddress = user.StreetAddress;
                editedUser.City = user.City;
                editedUser.StateCode = user.StateCode;
                editedUser.Zipcode = user.Zipcode;
                editedUser.PhoneNumber = user.PhoneNumber;
                editedUser.Gender = user.Gender;
                editedUser.GenderPreference = user.GenderPreference;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                User userDelete = context.Users.Where(u => id == id).FirstOrDefault();
                context.Users.Remove(userDelete);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
