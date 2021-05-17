using FirstWEbSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWEbSite.Controllers
{
    public class StudentController : Controller
    {
        ITIEntity context;//= new ITIEntity();
        public StudentController(ITIEntity context)//built service injection
        {
            this.context = context;
        }
        public IActionResult Index()
        {
        //    return Content("jjj");
            return View(context.Student.ToList());
        }
        //create new student
        [HttpGet]
        public IActionResult NEw()
        {
            ViewBag.DeptId = context.Department.ToList();
            return View(new Student());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NEw(Student std)
        {
            ViewBag.DeptId = context.Department.ToList();
            if (ModelState.IsValid == false)
            {
                return View(std);
            }
            
            context.Student.Add(std);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
