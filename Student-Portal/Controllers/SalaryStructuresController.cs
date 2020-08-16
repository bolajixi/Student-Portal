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
using Microsoft.AspNet.Identity.Owin;

namespace Student_Portal.Controllers
{
    [AccessDeniedAuthorize(Roles ="Admin")]
    public class SalaryStructuresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public SalaryStructuresController()
        {
        }

        public SalaryStructuresController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: SalaryStructures
        public async Task<ActionResult> Index()
        {
            return View(await db.SalaryStructures.ToListAsync());
        }

        // GET: SalaryStructures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStructure salaryStructure = await db.SalaryStructures.FindAsync(id);
            if (salaryStructure == null)
            {
                return HttpNotFound();
            }
            return View(salaryStructure);
        }

        // GET: SalaryStructures/Create
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(4, 2);
            ViewBag.Roles = list;
            return View();
        }

        // POST: SalaryStructures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Role,BaseSalary,PayWidth,MinPay,MaxPay,Allowance,Housing,Medicals,Tax,Pension,NetSalary")] SalaryStructure salaryStructure)
        {
            if (ModelState.IsValid)
            {
                db.SalaryStructures.Add(salaryStructure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(4, 2);
            ViewBag.Roles = list;

            return View(salaryStructure);
        }

        // GET: SalaryStructures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStructure salaryStructure = await db.SalaryStructures.FindAsync(id);
            if (salaryStructure == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(4, 2);
            ViewBag.Roles = list;
            return View(salaryStructure);
        }

        // POST: SalaryStructures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Role,BaseSalary,PayWidth,MinPay,MaxPay,Allowance,Housing,Medicals,Tax,Pension,NetSalary")] SalaryStructure salaryStructure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryStructure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(4, 2);
            ViewBag.Roles = list;
            return View(salaryStructure);
        }

        // GET: SalaryStructures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStructure salaryStructure = await db.SalaryStructures.FindAsync(id);
            if (salaryStructure == null)
            {
                return HttpNotFound();
            }
            return View(salaryStructure);
        }

        // POST: SalaryStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SalaryStructure salaryStructure = await db.SalaryStructures.FindAsync(id);
            db.SalaryStructures.Remove(salaryStructure);
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
