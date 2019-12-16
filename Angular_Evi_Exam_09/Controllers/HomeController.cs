using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular_Evi_Exam_09.Models;
using Angular_Evi_Exam_09.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Angular_Evi_Exam_09.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}