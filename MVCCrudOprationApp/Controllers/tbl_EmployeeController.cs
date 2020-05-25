using MVCCrudOprationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudOprationApp.Controllers
{
    public class tbl_EmployeeController : Controller
    {
        // GET: tbl_Employee
        public ActionResult Index()
        {
            SqlHelper db = new SqlHelper();
            return View(db.GetAllEmployee().ToList());

        }

        // GET: tbl_Employee/Details/5
        public ActionResult Details(int id)
        {
            SqlHelper db = new SqlHelper();
            return View(db.GetAllEmployee().FirstOrDefault(e => e.Id == id));
        }

        // GET: tbl_Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Employee/Create
        [HttpPost]
        public ActionResult Create(tbl_Employee emp)
        {
            SqlHelper db = new SqlHelper();
            db.InsertEmployee(emp);
            return RedirectToAction("Index");
        }

        // GET: tbl_Employee/Edit/5
        public ActionResult Edit(int id)
        {
            SqlHelper db = new SqlHelper();
            return View(db.GetAllEmployee().FirstOrDefault(e => e.Id == id));
        }

        // POST: tbl_Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(tbl_Employee emp)
        {
            SqlHelper db = new SqlHelper();
            db.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        // GET: tbl_Employee/Delete/5
        public ActionResult Delete(int id)
        {
            SqlHelper db = new SqlHelper();
            return View(db.GetAllEmployee().FirstOrDefault(e => e.Id == id));
        }

        // POST: tbl_Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(tbl_Employee emp)
        {
            SqlHelper db = new SqlHelper();
            db.DelateEmployee(emp);
            return RedirectToAction("Index");
        }
    }
}
