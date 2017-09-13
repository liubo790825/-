using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.IService.ArrangeLesson;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;


namespace LeaRun.Application.Service.ArrangeLesson
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:42
    /// 描 述：TrainingPlan
    /// </summary>
    public class TrainingPlanService : RepositoryFactory<TrainingPlanEntity>, TrainingPlanIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TrainingPlanEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TrainingPlanEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Contains(FullHead));//.
            }
            //如果有字段2，字段3也这样写...*/
            expression = expression.And(t => t.TrainingPlanId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TrainingPlanEntity> GetPageListForProcess(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TrainingPlanEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Equals(FullHead));
            }
            //如果有字段2，字段3也这样写...*/
            expression = expression.And(t => t.TrainingPlanId > 0);
            return this.BaseRepository(conn).FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TrainingPlanEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<TrainingPlanEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Contains(FullHead));
            }
            return this.BaseRepository(conn).IQueryable().ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="conn">查询参数</param>
        /// <returns></returns>
        public List<TrainingPlanEntity> GetList2(string conn)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }



        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TrainingPlanEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, TrainingPlanEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
