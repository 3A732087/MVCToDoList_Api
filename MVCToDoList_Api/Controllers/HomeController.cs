using MVCToDoList_Api.Models;
using MVCToDoList_Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCToDoList_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToDoList()
        {
            ToDoListService _service = new ToDoListService();
            List<ToDoList> DataList = new List<ToDoList>();
            DataList = _service.GetAllToDoList();
            return View(DataList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}