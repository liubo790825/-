using LeaRun.Application.Entity.AppManage;
using LeaRun.Application.IService.AppManage;
using LeaRun.Application.Service.AppManage;
using System;
using System.Collections.Generic;

namespace LeaRun.Application.Busines.AppManage
{
	public class App_ProjectBLL
	{
		private App_ProjectIService service = new App_ProjectService();

		public IEnumerable<App_ProjectEntity> GetList(string queryJson)
		{
			return this.service.GetList(queryJson);
		}

		public App_ProjectEntity GetEntity(string keyValue)
		{
			return this.service.GetEntity(keyValue);
		}

		public void RemoveForm(string keyValue)
		{
			try
			{
				this.service.RemoveForm(keyValue);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void SaveForm(string keyValue, App_ProjectEntity entity)
		{
			try
			{
				this.service.SaveForm(keyValue, entity);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
