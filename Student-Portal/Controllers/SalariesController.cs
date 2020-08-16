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
using Microsoft.AspNet.Identity;

namespace Student_Portal.Controllers
{
    public class SalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Salaries
        [AccessDeniedAuthorize(Roles = "Admin, Assistant Professor, Associate Professor, Full Professor, Instructor, Faculty, Non-teaching Staff")]
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var salaries = db.Salaries.Include(s => s.SalaryStructure);
                return View(await salaries.ToListAsync());
            }
            else
            {
                var userName = this.User.Identity.Name;
                var structure = db.Salaries.FirstOrDefault(m => m.Username == userName); 
                return View("Salary", structure);
            }
            
        }

        // GET: Salaries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = await db.Salaries.FindAsync(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        [AccessDeniedAuthorize(Roles = "Admin")]
        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.StructId = new SelectList(db.SalaryStructures, "Id", "Role");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessDeniedAuthorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Username,Role,BaseSalary,PayWidth,MinPay,MaxPay,Allowance,Housing,Medicals,Tax,Pension,NetSalary,StructId")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salaries.Add(salary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StructId = new SelectList(db.SalaryStructures, "Id", "Role", salary.StructId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
        [AccessDeniedAuthorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = await db.Salaries.FindAsync(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.StructId = new SelectList(db.SalaryStructures, "Id", "Role", salary.StructId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessDeniedAuthorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Username,Role,BaseSalary,PayWidth,MinPay,MaxPay,Allowance,Housing,Medicals,Tax,Pension,NetSalary,StructId")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StructId = new SelectList(db.SalaryStructures, "Id", "Role", salary.StructId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        [AccessDeniedAuthorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = await db.Salaries.FindAsync(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AccessDeniedAuthorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Salary salary = await db.Salaries.FindAsync(id);
            db.Salaries.Remove(salary);
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
