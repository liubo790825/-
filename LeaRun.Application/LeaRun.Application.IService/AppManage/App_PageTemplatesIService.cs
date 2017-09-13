using LeaRun.Application.Entity.AppManage;
using System;
using System.Collections.Generic;

namespace LeaRun.Application.IService.AppManage
{
	public interface App_PageTemplatesIService
	{
		IEnumerable<App_PageTemplatesEntity> GetList(string queryJson);

		App_PageTemplatesEntity GetEntity(string keyValue);

		void RemoveForm(string keyValue);

		void SaveForm(string keyValue, App_PageTemplatesEntity entity);
	}
}
