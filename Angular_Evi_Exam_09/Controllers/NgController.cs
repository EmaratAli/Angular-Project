using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_Evi_Exam_09.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Evi_Exam_09.Controllers
{
    public class NgController : Controller
    {
        IRepo repo;
        public NgController(IRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(this.repo.GetData());
        }
    }
}