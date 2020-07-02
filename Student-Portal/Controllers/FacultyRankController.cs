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
    public class FacultyRankController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacultyRank
        public async Task<ActionResult> Index()
        {
            return View(await db.FacultyRanks.ToListAsync());
        }

        // GET: FacultyRank/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyRank facultyRank = await db.FacultyRanks.FindAsync(id);
            if (facultyRank == null)
            {
                return HttpNotFound();
            }
            return View(facultyRank);
        }

        // GET: FacultyRank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacultyRank/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Rank")] FacultyRank facultyRank)
        {
            if (ModelState.IsValid)
            {
                db.FacultyRanks.Add(facultyRank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(facultyRank);
        }

        // GET: FacultyRank/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyRank facultyRank = await db.FacultyRanks.FindAsync(id);
            if (facultyRank == null)
            {
                return HttpNotFound();
            }
            return View(facultyRank);
        }

        // POST: FacultyRank/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Rank")] FacultyRank facultyRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyRank).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(facultyRank);
        }

        // GET: FacultyRank/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyRank facultyRank = await db.FacultyRanks.FindAsync(id);
            if (facultyRank == null)
            {
                return HttpNotFound();
            }
            return View(facultyRank);
        }

        // POST: FacultyRank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FacultyRank facultyRank = await db.FacultyRanks.FindAsync(id);
            db.FacultyRanks.Remove(facultyRank);
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
