using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.IService.ArrangeLesson;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.ArrangeLesson
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 15:23
    /// 描 述：TeachingPlan
    /// </summary>
    public class TeachingPlanService : RepositoryFactory, TeachingPlanIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TeachingPlanEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TeachingPlanEntity>();
             //参考代码
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }
             //如果有字段2，字段3也这样写...*/
             expression = expression.And(t => t.TeachingPlanId > 0);
             return this.BaseRepository(conn).FindList<TeachingPlanEntity>(expression,pagination);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TeachingPlanEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<TeachingPlanEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<PlanCourseEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<PlanCourseEntity>("select * from PlanCourse where TeachingPlanCode='" + keyValue + "'");
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<TeachingPlanEntity>(keyValue);
                db.Delete<PlanCourseEntity>(t => t.TeachingPlanCode.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, TeachingPlanEntity entity,List<PlanCourseEntity> entryList)
        {
          IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
              if (!string.IsNullOrEmpty(keyValue))
              {
                  //主表
                  entity.Modify(keyValue);
                  db.Update(entity);
                  //明细
                  db.Delete<PlanCourseEntity>(t => t.TeachingPlanCode.Equals(keyValue));
                  foreach (PlanCourseEntity item in entryList)
                  {
                      item.Create();
                      item.TeachingPlanCode = entity.TeachingPlanCode;
                      db.Insert(item);
                  }
              }
              else
              {
                  //主表
                  entity.Create();
                  db.Insert(entity);
                  //明细
                  foreach (PlanCourseEntity item in entryList)
                  {
                      item.Create();
                      item.TeachingPlanCode = entity.TeachingPlanCode;
                      db.Insert(item);
                  }
              }
              db.Commit();
          }
          catch (Exception)
          {
              db.Rollback();
              throw;
          }
        }
        #endregion
    }
}
