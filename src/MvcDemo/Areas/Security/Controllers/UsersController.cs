using MvcDemo.Areas.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        private IList<UserViewModel> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserViewModel>() {
                        new UserViewModel {
                            Id = Guid.NewGuid(),
                            FirstName = "John",
                            LastName = "Doe",
                            Age = 29,
                            Gender = "Male"
                        },
                        new UserViewModel {
                            Id = Guid.NewGuid(),
                            FirstName = "Jane",
                            LastName = "Doe",
                            Age = 33,
                            Gender = "Female"
                        }
                    };
                }
                return Session["data"] as  List<UserViewModel>;
            }
        }
        public ActionResult Index()
        {


            return View(Users);
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id, UserViewModel viewModel)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Genders = new List<SelectListItem> {
                new SelectListItem
                {
                        Value = "Male",
                        Text = "Male"
                },
                new SelectListItem
                {
                        Value = "Female",
                        Text = "Female"
       
                }
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            try
            {
                Users.Add(new UserViewModel
                 {
                     Id = Guid.NewGuid(),
                     FirstName = viewModel.FirstName,
                     LastName = viewModel.LastName,
                     Age = viewModel.Age,
                     Gender = viewModel.Gender
                 });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(Guid id)

        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            ViewBag.Genders = new List<SelectListItem> {
                new SelectListItem
                {
                        Value = "Male",
                        Text = "Male"
                },
                new SelectListItem
                {
                        Value = "Female",
                        Text = "Female"
       
                }


             };
            return View(u);
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserViewModel viewModel)
        {
            try
            {
                var u = Users.FirstOrDefault(user => user.Id == id);
                u.FirstName = viewModel.FirstName;
                u.LastName = viewModel.LastName;
                u.Age = viewModel.Age;
                u.Gender = viewModel.Gender;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var u = Users.FirstOrDefault(user => user.Id == id);
                Users.Remove(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
