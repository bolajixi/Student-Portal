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
    [AccessDeniedAuthorize(Roles ="Admin")]
    public class CollegeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: College
        public async Task<ActionResult> Index()
        {
            return View(await db.Colleges.ToListAsync());
        }

        // GET: College/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // GET: College/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: College/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CollegeName,CollegeCode,numDept")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Colleges.Add(college);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(college);
        }

        // GET: College/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: College/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CollegeName,CollegeCode,numDept")] College college)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(college);
        }

        // GET: College/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            College college = await db.Colleges.FindAsync(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        // POST: College/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            College college = await db.Colleges.FindAsync(id);
            db.Colleges.Remove(college);
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
