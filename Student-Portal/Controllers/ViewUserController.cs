using Microsoft.AspNet.Identity.EntityFramework;
using Student_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Student_Portal.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class ViewUserController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public ViewUserController()
        {
        }

        public ViewUserController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
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

        // GET: ViewUser
        public ActionResult Index()
        {
            string query = "SELECT * "
                + "FROM [dbo].[AspNetUsers] "
                + "INNER JOIN [dbo].[AspNetUserRoles] ON [dbo].AspNetUsers.Id = [dbo].[AspNetUserRoles].UserId "
                + "INNER JOIN [dbo].[AspNetRoles] ON [dbo].[AspNetUserRoles].RoleId = [dbo].[AspNetRoles].Id ";

            IEnumerable<ViewUserGrid> data = db.Database.SqlQuery<ViewUserGrid>(query);

            //var myusers = db.Database.SqlQuery<ViewUserGrid>("SELECT AspNetUsers.Firstname, AspNetUsers.Lastname, AspNetRoles.Name, AspNetUsers.Email, AspNetUsers.Program, AspNetUsers.YearOfJoining "
            //    + "FROM AspNetUsers "
            //    + "INNER JOIN AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId "
            //    + "INNER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id").ToList();
            return View(data.ToList());
        }

        // GET: ViewUser/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewUserGrid = await UserManager.FindByIdAsync(id);
            if (viewUserGrid == null)
            {
                return HttpNotFound();
            }
            return View(viewUserGrid);
        }


        // GET: ViewUser/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewUserGrid = await UserManager.FindByIdAsync(id);
            if (viewUserGrid == null)
            {
                return HttpNotFound();
            }
            return View(viewUserGrid);
        }

        // POST: ViewUser/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, ApplicationUser model, RoleViewModel roleModel)
        {
            try
            {
                //TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByIdAsync(id);

                    user.Email = model.Email;
                    user.Firstname = model.Firstname;
                    user.Lastname = model.Lastname;
                    user.Program = model.Program;
                    user.YearOfJoining = model.YearOfJoining;

                    UserManager.Update(user);

                }
                //return View(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ViewUser/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewUserGrid = await UserManager.FindByIdAsync(id);
            if (viewUserGrid == null)
            {
                return HttpNotFound();
            }
            return View(viewUserGrid);
        }

        // POST: ViewUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await _userManager.FindByIdAsync(id);
                var logins = user.Logins;
                var rolesForUser = await _userManager.GetRolesAsync(id);

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var login in logins.ToList())
                    {
                        await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    await _userManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult RegisterStudent()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(0, 4);
            list.RemoveRange(1, 3);
            ViewBag.Roles = list;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterStudent(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Fathername = model.Fathername,
                    Mothername = model.Mothername,
                    DateOfBirth = model.DateOfBirth,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    City = model.City,
                    Country = model.Country,
                    Institution = model.Institution,
                    Program = model.Program,
                    YearOfJoining = model.YearOfJoining,
                    PhoneNumber = model.Mobile
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.RoleeName);
                    ViewBag.FacultySuccess = "Successfully Created " + user.Firstname + "as a faculty member.";
                    return RedirectToAction("Index", "ViewUser");
                }
                AddErrors(result);
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(0, 4);
            list.RemoveRange(1, 3);
            ViewBag.Roles = list;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult RegisterFaculty()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            ViewBag.Roles = list;
            list.RemoveRange(4, 2);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterFaculty(RegisterFacultyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    DateOfBirth = model.DateOfBirth,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    City = model.City,
                    Country = model.Country,
                    Institution = model.Institution,
                    Program = model.Program,
                    YearOfJoining = model.YearOfJoining,
                    PhoneNumber = model.Mobile,
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.RoleeName);
                    ViewBag.FacultySuccess = "Successfully Created "+ user.Firstname+ "as a faculty member.";
                    return RedirectToAction("Index", "ViewUser");
                }
                AddErrors(result);
            }
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var rolee in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = rolee.Name, Text = rolee.Name });
            list.RemoveRange(4, 2);
            ViewBag.Roles = list;

            //ViewBag.Ranks = new SelectList(db.FacultyRanks, "Id", "Rank");

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
