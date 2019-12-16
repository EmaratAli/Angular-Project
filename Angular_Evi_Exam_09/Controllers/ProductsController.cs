using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_Evi_Exam_09.Models;
using Angular_Evi_Exam_09.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Evi_Exam_09.Controllers
{
    public class ProductsController : Controller
    {
       
        IRepo repo;
        //[Authorize]
        public ProductsController(IRepo repo)
        {
            this.repo = repo;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View(repo.GetData());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                this.repo.Insert(p);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            return View(this.repo.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                this.repo.Update(p);
                return PartialView("_success");
            }
            return PartialView("_fails");
        }
        public ActionResult Delete(int id)
        {
            return View(this.repo.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            this.repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}