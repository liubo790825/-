using LeaRun.Application.Busines.AppManage;
using LeaRun.Application.Entity.AppManage;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Areas.AppManage.Controllers
{
	public class AppProjectsController : MvcControllerBase
	{
		private App_ProjectBLL app_projectbll = new App_ProjectBLL();

		[HttpGet]
		public ActionResult Index()
		{
			return base.View();
		}

		[HttpGet]
		public ActionResult GetListJson(string queryJson)
		{
			IEnumerable<App_ProjectEntity> list = this.app_projectbll.GetList(queryJson);
			return this.ToJsonResult(list);
		}

		[HttpGet]
		public ActionResult GetFormJson(string keyValue)
		{
			App_ProjectEntity entity = this.app_projectbll.GetEntity(keyValue);
			return this.ToJsonResult(entity);
		}

		[AjaxOnly(false), HttpPost, ValidateAntiForgeryToken]
		public ActionResult RemoveForm(string keyValue)
		{
			this.app_projectbll.RemoveForm(keyValue);
			return this.Success("删除成功。");
		}

		[HttpPost]
		public ActionResult SaveForm(string keyValue, App_ProjectEntity entity)
		{
			this.app_projectbll.SaveForm(keyValue, entity);
			return this.Success("操作成功。");
		}
	}
}
