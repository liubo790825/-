using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 14:05
    /// 描 述：通知书快递信息
    /// </summary>
    public class BK_ExpressInfoService : RepositoryFactory<BK_ExpressInfoEntity>, BK_ExpressInfoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_ExpressInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_ExpressInfoEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["ExpressCompany"].IsEmpty()){
                 string ExpressCompany = queryParam["ExpressCompany"].ToString();
                 expression = expression.And(t => t.ExpressCompany.Contains(ExpressCompany));
             }
            if (!queryParam["ExpressNo"].IsEmpty())
            {
                string ExpressNo = queryParam["ExpressNo"].ToString();
                expression = expression.And(t => t.ExpressNo.Equals(ExpressNo));
            }
            if (!queryParam["Stuno"].IsEmpty())
            {
                string Stuno = queryParam["Stuno"].ToString();
                expression = expression.And(t => t.Stuno.Equals(Stuno));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Equals(NoticeNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["BeginTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime BeginTime = queryParam["BeginTime"].ToDate();
                DateTime EndTime = queryParam["EndTime"].ToDate();
                expression = expression.And(t => t.SendTime>= BeginTime && t.SendTime<=EndTime);
            }

            //如果有字段2，字段3也这样写...
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_ExpressInfoEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_ExpressInfoEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_ExpressInfoEntity>();
            //参考代码
            var queryParam = keyValue.ToJObject();
            if (!queryParam["ID"].IsEmpty())
            {
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Equals(ID));
            }

            if (!queryParam["ExpressCompany"].IsEmpty())
            {
                string ExpressCompany = queryParam["ExpressCompany"].ToString();
                expression = expression.And(t => t.ExpressCompany.Contains(ExpressCompany));
            }
            if (!queryParam["ExpressNo"].IsEmpty())
            {
                string ExpressNo = queryParam["ExpressNo"].ToString();
                expression = expression.And(t => t.ExpressNo.Equals(ExpressNo));
            }
            if (!queryParam["Stuno"].IsEmpty())
            {
                string Stuno = queryParam["Stuno"].ToString();
                expression = expression.And(t => t.Stuno.Equals(Stuno));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Equals(NoticeNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            return this.BaseRepository(conn).FindEntity(expression);
            //return this.BaseRepository(conn).FindEntity(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_ExpressInfoEntity entity)
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
