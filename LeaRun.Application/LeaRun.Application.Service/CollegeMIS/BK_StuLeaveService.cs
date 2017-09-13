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
    /// 日 期：2017-08-14 09:17
    /// 描 述：学生请假表
    /// </summary>
    public class BK_StuLeaveService : RepositoryFactory, BK_StuLeaveIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuLeaveEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuLeaveEntity>();             
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuId"].IsEmpty())
             {
                 string StuId = queryParam["StuId"].ToString();
                 expression = expression.And(t => t.StuId.Equals(StuId));
             }
             if (!queryParam["StuNo"].IsEmpty())
             {
                 string StuNo = queryParam["StuNo"].ToString();
                 expression = expression.And(t => t.StuNo.Equals(StuNo));
             }
             if (!queryParam["StuName"].IsEmpty())
             {
                 string StuName = queryParam["StuName"].ToString();
                 expression = expression.And(t => t.StuName.Contains(StuName));
             }
             if (!queryParam["Telephone"].IsEmpty())
             {
                 string Telephone = queryParam["Telephone"].ToString();
                 expression = expression.And(t => t.Telephone.Equals(Telephone));
             }
             if (!queryParam["LeaveTypeId"].IsEmpty())
             {
                 string LeaveTypeId = queryParam["LeaveTypeId"].ToString();
                 expression = expression.And(t => t.LeaveTypeId.Equals(LeaveTypeId));
             }
             if (!queryParam["LeaveType"].IsEmpty())
             {
                 string LeaveType = queryParam["LeaveType"].ToString();
                 expression = expression.And(t => t.LeaveType.Contains(LeaveType));
             }
             if (!queryParam["BeCancelDate"].IsEmpty())
             {
                 DateTime BeCancelDate = queryParam["BeCancelDate"].ToDate();
                 expression = expression.And(t => t.BeCancelDate == BeCancelDate);
             }
             if (!queryParam["Days"].IsEmpty())
             {
                 int Days = queryParam["Days"].ToInt();
                 expression = expression.And(t => t.Days == Days);
             }
             if (!queryParam["BeginTime"].IsEmpty())
             {
                 DateTime BeginTime = queryParam["BeginTime"].ToDate();
                 expression = expression.And(t => t.BeginTime == BeginTime);
             }
             if (!queryParam["EndTime"].IsEmpty())
             {
                 DateTime EndTime = queryParam["EndTime"].ToDate();
                 expression = expression.And(t => t.EndTime == EndTime);
             }


             return this.BaseRepository(conn).FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuLeaveEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_StuLeaveEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuLeaveEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_StuLeaveEntity>(keyValue);
        }


        //获取请假信息
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveInfo(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuLeaveEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (queryParam["StuNo"] != null && queryParam["StuNo"].ToString() != "")
            {//查询自己请假信息
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Contains(StuNo));
            }
            //*/
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => !string.IsNullOrEmpty(t.ID));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }
        //获取单条请假记录详细信息
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveResultInfo(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuLeaveEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (queryParam["ID"] != null && queryParam["ID"].ToString() != "")
            {//查询自己请假信息
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Contains(ID));
            }
            //*/
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => !string.IsNullOrEmpty(t.ID));
            return this.BaseRepository(conn).FindList(expression);
        }

        /// <summary>
        /// 查询请假学生列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public List<BK_StuLeaveEntity> GetStuLeaveList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select distinct StuName,StuNo");
            strsql.Append(@"  from BK_StuLeave");
            strsql.Append(@"  where 1=1");
            return this.BaseRepository(conn).FindList<BK_StuLeaveEntity>(strsql.ToString(), pagination).ToList();
        }

        /// <summary>
        /// 查询未审核学生请假信息列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public List<BK_StuLeaveEntity> GetNotReviewStuLeaveList(string conn, Pagination pagination, string queryJson)
        {
            string StuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                StuNo = queryParam["StuNo"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select * from BK_StuLeave");
            strsql.Append(@"  where 1=1");
            strsql.Append(string.Format(" and StuNo='{0}'", StuNo));
            strsql.Append(string.Format(" and BeAllow='0'"));

            return this.BaseRepository(conn).FindList<BK_StuLeaveEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// 查询已审核学生请假信息列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public List<BK_StuLeaveEntity> GetReviewStuLeaveList(string conn, Pagination pagination, string queryJson)
        {
            string StuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                StuNo = queryParam["StuNo"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select * from BK_StuLeave");
            strsql.Append(@"  where 1=1");
            strsql.Append(string.Format(" and StuNo='{0}'", StuNo));
            strsql.Append(string.Format(" and BeAllow!='0'"));

            return this.BaseRepository(conn).FindList<BK_StuLeaveEntity>(strsql.ToString()).ToList();
        }


        /// <summary>
        /// 查询请假学生班级专业等信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的学号</param>
        /// <returns></returns>
        public List<M_BK_NumberEntity> GetStuLeaveMajorClassInfo(string conn, string queryJson)
        {
            string StuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                StuNo = queryParam["StuNo"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select a.StuName,b.MajorName,c.ClassName");
            strsql.Append(@"  from dbo.BK_StuInfo a");
            strsql.Append(@"  left join dbo.BK_Major b on a.MajorNo=b.MajorNo");
            strsql.Append(@"  left join  dbo.BK_ClassInfo c on a.ClassNo=c.ClassNo");
            strsql.Append(@"  where 1=1");
            strsql.Append(string.Format(" and a.StuNo='{0}'", StuNo));

            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }


        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_StuLeave");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and BeAllow='0'");
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
            this.BaseRepository(conn).Delete<BK_StuLeaveEntity>(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_StuLeaveEntity entity)
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
