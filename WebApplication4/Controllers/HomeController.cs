using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  // comment
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult GetLog()
        {
            List<LogModel> Log = RunnerLogDb.GetLogsFromDatabase();
            return View(Log);
        }

        public ActionResult InsertLog()
        {
            LogModel log = new LogModel();
            log.RunDate = DateTime.Now;
            return View(log);
        }

        [HttpPost]
        public ActionResult InsertLog(LogModel log)
        {
            RunnerLogDb.InserLog(log);
            return RedirectToAction("GetLog");
        }

        public ActionResult DeleteLog(int id)
        {
            RunnerLogDb.DeleteLog(id);
            return RedirectToAction("GetLog");
        }

        public ActionResult EditLog(int id)
        {
            LogModel log = RunnerLogDb.GetRunnerLog(id);
            return View(log);
        }
    }
}
