using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXMVC.Demo.Models;
using DevExpress.Web.Mvc;

namespace DXMVC.Demo.Controllers
{
    public class HomeController : Controller
    {
        private WebsiteDbContext db = new WebsiteDbContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

		  DXMVC.Demo.Models.WebsiteDbContext db1 = new DXMVC.Demo.Models.WebsiteDbContext();

		  [ValidateInput(false)]
		  public ActionResult GridViewPartial()
		  {
				var model = db1.Customers;
				return PartialView("_GridViewPartial", model.ToList());
		  }

		  [HttpPost, ValidateInput(false)]
		  public ActionResult GridViewPartialAddNew(DXMVC.Demo.Models.Customer item)
		  {
				var model = db1.Customers;
				if (ModelState.IsValid)
				{
					 try
					 {
						  model.Add(item);
						  db1.SaveChanges();
					 }
					 catch (Exception e)
					 {
						  ViewData["EditError"] = e.Message;
					 }
				}
				else
					 ViewData["EditError"] = "Please, correct all errors.";
				return PartialView("_GridViewPartial", model.ToList());
		  }
		  [HttpPost, ValidateInput(false)]
		  public ActionResult GridViewPartialUpdate(DXMVC.Demo.Models.Customer item)
		  {
				var model = db1.Customers;
				if (ModelState.IsValid)
				{
					 try
					 {
						  var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
						  if (modelItem != null)
						  {
								this.UpdateModel(modelItem);
								db1.SaveChanges();
						  }
					 }
					 catch (Exception e)
					 {
						  ViewData["EditError"] = e.Message;
					 }
				}
				else
					 ViewData["EditError"] = "Please, correct all errors.";
				return PartialView("_GridViewPartial", model.ToList());
		  }
		  [HttpPost, ValidateInput(false)]
		  public ActionResult GridViewPartialDelete(System.Int32 ID)
		  {
				var model = db1.Customers;
				if (ID >= 0)
				{
					 try
					 {
						  var item = model.FirstOrDefault(it => it.ID == ID);
						  if (item != null)
								model.Remove(item);
						  db1.SaveChanges();
					 }
					 catch (Exception e)
					 {
						  ViewData["EditError"] = e.Message;
					 }
				}
				return PartialView("_GridViewPartial", model.ToList());
		  }
    }
}