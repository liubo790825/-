using LeaRun.Application.Entity.AppManage;
using System;
using System.Collections.Generic;

namespace LeaRun.Application.IService.AppManage
{
	public interface App_ProjectIService
	{
		IEnumerable<App_ProjectEntity> GetList(string queryJson);

		App_ProjectEntity GetEntity(string keyValue);

		void RemoveForm(string keyValue);

		void SaveForm(string keyValue, App_ProjectEntity entity);
	}
}
