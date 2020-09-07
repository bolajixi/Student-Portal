using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Student_Portal.Models;

namespace Student_Portal.Controllers
{
    public class CourseParticipantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AccessDeniedAuthorize(Roles = "Assistant Professor, Associate Professor, Full Professor, Instructor, Faculty, Non-teaching Staff")]
        // GET: CourseParticipants
        public ActionResult Index()
        {
            List<Course> Course = db.Course.ToList();
            List<RegisterCourse> RegisterCourse = db.RegisterCourse.ToList();
            List<ApplicationUser> ApplicationUser = db.Users.ToList();

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.CurrentCourse = currentUser.Course.CourseCode;

            ApproveViewModel approveViewModel = new ApproveViewModel();

            var AppprovedStudents = from r in RegisterCourse
                                     join a in ApplicationUser on r.UserId equals a.Id
                                     where r.CourseId == currentUser.Course.Id && r.ApprovalStatus == true
                                   orderby r.CourseId ascending
                                   select new ApprovedStudents
                                   {
                                       StudentName = a.Firstname+" "+a.Lastname,
                                       EnrollmentDate = r.EnrollmentDate,
                                       ApprovalDate = r.ApprovalDate,
                                       ApprovedBy = r.ApprovedBy,
                                   };
            return View(AppprovedStudents);
        }

        public ActionResult Approval()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentFaculty = manager.FindById(User.Identity.GetUserId());

            var RegisteredStudents = db.RegisterCourse;
            var UnapprovedStudents = RegisteredStudents.Where(v => v.ApprovalStatus == false && v.CourseId == currentFaculty.Course.Id);
            var viewModel = new List<ApprovalViewModel>();

            foreach (var student in UnapprovedStudents.ToList())
            {
                viewModel.Add(new ApprovalViewModel
                {
                    StudentID = student.UserId,
                    StudentName = $"{student.ApplicationUser.Firstname} {student.ApplicationUser.Lastname}",
                    Approved = student.ApprovalStatus,
                });

            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approval(string[] unapprovedStudents)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentFaculty = manager.FindById(User.Identity.GetUserId());

            if (unapprovedStudents == null)
            {
                ViewBag.Message = "Aproved 0 students.";
            }
            var unapprovedStudentsHS = new HashSet<string>(unapprovedStudents);
            foreach (var student in db.RegisterCourse.ToList())
            {
                if (unapprovedStudentsHS.Contains(student.UserId) && currentFaculty.Course.Id == student.CourseId)
                {
                    student.ApprovalStatus = true;
                    student.ApprovedBy = $"{currentFaculty.Firstname} {currentFaculty.Lastname}";
                    student.ApprovalDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}