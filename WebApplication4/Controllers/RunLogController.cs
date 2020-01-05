using System;

public class RunLogController: Controller
{
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
