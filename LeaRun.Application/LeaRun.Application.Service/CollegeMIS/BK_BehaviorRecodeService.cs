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
    /// 日 期：2017-08-10 11:42
    /// 描 述：学生操行记录
    /// </summary>
    public class BK_BehaviorRecodeService : RepositoryFactory, BK_BehaviorRecodeIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_BehaviorRecodeEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_BehaviorRecodeEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuNo"].IsEmpty()){
                 string StuNo = queryParam["StuNo"].ToString();
                 expression = expression.And(t => t.StuNo.Equals(StuNo));
             }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["BreachBehavior"].IsEmpty())
            {
                string BreachBehavior = queryParam["BreachBehavior"].ToString();
                expression = expression.And(t => t.BreachBehavior.Contains(BreachBehavior));
            }
            if (!queryParam["BehaviorTypeId"].IsEmpty())
            {
                string BehaviorTypeId = queryParam["BehaviorTypeId"].ToString();
                expression = expression.And(t => t.BehaviorTypeId.Equals(BehaviorTypeId));
            }
            if (!queryParam["BeginDate"].IsEmpty() && queryParam["EndDate"].IsEmpty())
            {
                DateTime BeginDate = (queryParam["BeginDate"] +" 00:00:00").ToDate();
                DateTime EndDate = (queryParam["EndDate"] + " 23:59:59").ToDate();
                expression = expression.And(t => t.CreateDate>= BeginDate && t.CreateDate<= EndDate);
            }

            //如果有字段2，字段3也这样写...
            return this.BaseRepository(conn).FindList(expression,pagination).OrderByDescending(t=>t.CreateDate);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_BehaviorRecodeEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_BehaviorRecodeEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_BehaviorRecodeEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_BehaviorRecodeEntity>(keyValue);
        }


        /// <summary>
        /// 获取我的违规记录信息获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_BehaviorRecodeEntity> GetMyBehaviorRecodeList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_BehaviorRecodeEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Equals(StuNo));
            }
            //如果有字段2，字段3也这样写...
            return this.BaseRepository(conn).FindList(expression, pagination).OrderByDescending(t => t.BreachTime);
        }


        /// <summary>
        /// 获取我的违规记录详细信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<BK_BehaviorRecodeEntity> TeaGetMyBehaviorRecodeInfo(string conn, string queryJson)
        {
            string StuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                StuNo = queryParam["StuNo"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select a.StuName,a.StuNo,b.DeptName,c.MajorName,d.ClassName,e.BreachBehavior,e.breachTime");
            strsql.Append(@"  from BK_StuInfo a");
            strsql.Append(@"  left join BK_Dept b on b.DeptNo=a.DeptNo");
            strsql.Append(@"  left join BK_Major c on c.MajorNo=a.MajorNo");
            strsql.Append(@"  left join BK_ClassInfo d on d.ClassNo=a.ClassNo");
            strsql.Append(@"  left join BK_BehaviorRecode e on e.StuNo=a.StuNo");
            strsql.Append(@"  where 1=1");


            if (!queryParam["StuNo"].IsEmpty())
            {
                strsql.Append(string.Format(" and a.StuNo='{0}')", StuNo));
            }
            return this.BaseRepository(conn).FindList<BK_BehaviorRecodeEntity>(strsql.ToString()).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_BehaviorRecodeEntity entity)
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
