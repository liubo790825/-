using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-13 05:03
    /// 描 述：BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueService : RepositoryFactory, BK_BaodaoYuyueIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_BaodaoYuyueEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_BaodaoYuyueEntity>();
            //参考代码
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["BaodaoOther1"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["BaodaoOther1"].ToString();
                expression = expression.And(t => t.BaodaoOther1.Contains(IdentityCardNo));
            }//*/

            //如果有字段2，字段3也这样写...

            return this.BaseRepository(conn).IQueryable(expression).ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_BaodaoYuyueEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_BaodaoYuyueEntity>();
            //参考代码
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["BaodaoOther1"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["BaodaoOther1"].ToString();
                expression = expression.And(t => t.BaodaoOther1.Contains(IdentityCardNo));
            }//*/
            //如果有字段2，字段3也这样写...

            //var queryParam = queryJson.ToJObject();
            ////查询条件
            //if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            //{
            //    string condition = queryParam["condition"].ToString();
            //    string keyword = queryParam["keyword"].ToString();
            //    switch (condition)
            //    {
            //        case "StuName":            //名称
            //            expression = expression.And(t => t.StuName.Contains(keyword));
            //            break;
            //        case "Telephone":       //电话
            //            expression = expression.And(t => t.Telephone.Contains(keyword));
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //expression = expression.And(t => !string.IsNullOrEmpty(t.YuyueId));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_BaodaoYuyueEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_BaodaoYuyueEntity>(keyValue);
        }


        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BaodaoYuyue");
            strsql.Append(@"  where 1=1");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_BaodaoYuyueEntity entity)
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
