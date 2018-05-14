using Authentica.Models;
using Authentica.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Authentica.Controllers
{
    public class StudentController : Controller
    {
         // GET: Student
        public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            Result<Student> result = await WebService.GetStudentsAsync("/api/Student/all");
            if (result.Status == status.Ok)
            {
                return View("Index", result.resultList);
            }
            else
            {
                //do logging
                return View("~/Views/Error/Index.cshtml", null);
            }
        }


        public async Task<ViewResult> Enrollment(int id)
        {
            Result<Enrollment> result = await WebService.GetStudentEnrollmentHistory(string.Format("/api/Student/EnrollmentHistory?studentId={0}", id));
            if (result.Status == status.Ok)
            {
                return View("~/Views/Enrollment/Index.cshtml", result.resultList);
            }
            else
            {
                //do logging
                return View("~/Views/Error/Index.cshtml", null);
            }

        }

        public async Task<ViewResult> Assignment(int id)
        {
                Result<Assignment> result = await WebService.GetStudentAssignmentHistory(string.Format("/api/Student/AssignmentHistory?studentId={0}", id));
                if (result.Status == status.Ok)
                {
                    return View("~/Views/Assignment/Index.cshtml", result.resultList);
                }
                else
                {
                    //do logging
                    return View("~/Views/Error/Index.cshtml", null);
                }
            }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
