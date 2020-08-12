using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Portal.Models;

namespace Student_Portal.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departments
        public async Task<ActionResult> Index()
        {
            var departments = db.Departments.Include(d => d.College);
            return View(await departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = await db.Departments.FindAsync(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.CollegeId = new SelectList(db.Colleges, "ID", "CollegeName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DeptID,DeptName,CollegeId")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CollegeId = new SelectList(db.Colleges, "ID", "CollegeName", departments.CollegeId);
            return View(departments);
        }

        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = await db.Departments.FindAsync(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "ID", "CollegeName", departments.CollegeId);
            return View(departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DeptID,DeptName,CollegeId")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departments).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CollegeId = new SelectList(db.Colleges, "ID", "CollegeName", departments.CollegeId);
            return View(departments);
        }

        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = await db.Departments.FindAsync(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Departments departments = await db.Departments.FindAsync(id);
            db.Departments.Remove(departments);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
