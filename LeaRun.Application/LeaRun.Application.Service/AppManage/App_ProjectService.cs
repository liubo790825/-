using LeaRun.Application.Entity.AppManage;
using LeaRun.Application.IService.AppManage;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.AppManage
{
	public class App_ProjectService : RepositoryFactory<App_ProjectEntity>, App_ProjectIService
	{
		public IEnumerable<App_ProjectEntity> GetList(string queryJson)
		{
			return base.BaseRepository().IQueryable().ToList<App_ProjectEntity>();
		}

		public App_ProjectEntity GetEntity(string keyValue)
		{
			return base.BaseRepository().FindEntity(keyValue);
		}

		public void RemoveForm(string keyValue)
		{
			base.BaseRepository().Delete(keyValue);
		}

		public void SaveForm(string keyValue, App_ProjectEntity entity)
		{
			if (!string.IsNullOrEmpty(keyValue))
			{
				entity.Modify(keyValue);
				base.BaseRepository().Update(entity);
				return;
			}
			entity.Create();
			base.BaseRepository().Insert(entity);
		}
	}
}
