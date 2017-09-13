using System;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.AppManage.Controllers
{
	public class AppDesignController : Controller
	{
		public ActionResult Index()
		{
			return base.View();
		}

		public ActionResult PhoneDIndex()
		{
			return base.View();
		}
	}
}
