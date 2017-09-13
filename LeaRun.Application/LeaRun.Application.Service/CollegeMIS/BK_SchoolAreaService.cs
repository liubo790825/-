using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:54
    /// 描 述：校区
    /// </summary>
    public class BK_SchoolAreaService : RepositoryFactory, BK_SchoolAreaIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_SchoolAreaEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_SchoolAreaEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["AreaName"].IsEmpty()){
                 string AreaName = queryParam["AreaName"].ToString();
                 expression = expression.And(t => t.AreaName.Contains(AreaName));
             }
             //如果有字段2，字段3也这样写...
             //expression = expression.And(t => t.AreaId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_SchoolAreaEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_SchoolAreaEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["areaId"].IsEmpty())//转换数据用
            {
                string AreaId = queryParam["areaId"].ToString();
                expression = expression.And(t => t.AreaId.Equals(AreaId));
            }
            if (!queryParam["AreaName"].IsEmpty())
            {
                string AreaName = queryParam["AreaName"].ToString();
                expression = expression.And(t => t.AreaName.Contains(AreaName));
            }
            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.AreaId > 0);
            return this.BaseRepository(conn).FindList(expression);
        }



        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_SchoolAreaEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_SchoolAreaEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DeptEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DeptEntity>("select * from BK_Dept where AreaId='" + keyValue + "'");
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
                db.Delete<BK_SchoolAreaEntity>(keyValue);
                db.Delete<BK_DeptEntity>(t => t.AreaId.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_SchoolAreaEntity entity, List<BK_DeptEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.DeptId))
                            {
                                item.Modify(item.DeptId);
                                item.AreaId = entity.AreaId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.AreaId = entity.AreaId;
                                db.Insert(item);
                            }
                        }
                    }
                    //明细
                    //db.Delete<BK_DeptEntity>(t => t.AreaId.Equals(keyValue));
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);
                    //明细
                    foreach (BK_DeptEntity item in entryList)
                    {
                        item.Create();
                        item.AreaId = entity.AreaId;
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
