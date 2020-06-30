﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Student_Portal.Models;

namespace Student_Portal.Controllers
{
    //[Authorize(Roles = "Student")]
    [AccessDeniedAuthorize(Roles ="Student")]
    public class RegisterCourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterCourse
        public ActionResult Index()
        {
            ViewBag.Course = new SelectList(db.Course, "Id", "CourseName");
            ViewBag.RegError = TempData["ErrorMessage"] as string;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterCourse cour)
        {
            if (ModelState.IsValid)     
            {
                cour.UserId = this.User.Identity.GetUserId().ToString();
                cour.EnrollmentDate = DateTime.Now.ToString("U");
                var checkcourse = db.RegisterCourse.Where(v => v.CourseId == cour.CourseId && v.UserId == cour.UserId).Count();
                if (checkcourse == 0)
                {
                    db.RegisterCourse.Add(cour);
                    await db.SaveChangesAsync();
                    ViewBag.Course = new SelectList(db.Course, "CourseId", "CourseName");
                    return RedirectToAction("Index");
                }
                else
                {
                    //ModelState.AddModelError("error", "You have already registered this course");
                    ViewBag.Course = new SelectList(db.Course, "CourseId", "CourseName");
                    TempData["ErrorMessage"] = "You have already registered this course";
                    return RedirectToAction("index");
                }
                
                //db.RegisterCourse.Add(cour);
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }


            ViewBag.Course = new SelectList(db.Course, "CourseId", "CourseName");
            return View();
        }

        public ActionResult ShowCourse()
        {
            //List<Course> Course = db.Course.ToList();
            //List<RegisterCourse> RegisterCourse = db.RegisterCourse.ToList();

            //var RegisteredCourse = from r in RegisterCourse
            //                       join c in Course on r.CourseId equals c.Id
            //                       //where r.CourseId == c.Id
            //                       orderby r.CourseId ascending
            //                       select new ViewModel
            //                       {
            //                          Course = c,                                      
            //                          RegisterCourse = r  
            //                       };
            //return View(RegisteredCourse);




            List<Course> Course = db.Course.ToList();
            List<RegisterCourse> RegisterCourse = db.RegisterCourse.ToList();

            var RegisteredCourse = from r in RegisterCourse
                                   join c in Course on r.CourseId equals c.Id
                                   where r.UserId == User.Identity.GetUserId()
                                   orderby r.CourseId ascending
                                   select new ViewModel
                                   {
                                       CourseName = c.CourseName,
                                       CourseCode = c.CourseCode,
                                       CourseUnit = c.CourseUnit,
                                   };
            return View(RegisteredCourse);

        }
    }
}