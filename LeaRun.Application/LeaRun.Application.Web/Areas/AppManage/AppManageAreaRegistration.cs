using System;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.AppManage
{
	public class AppManageAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "AppManage";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute("AppManage_default", "AppManage/{controller}/{action}/{id}", new
			{
				action = "Index",
				id = UrlParameter.Optional
			});
		}
	}
}
