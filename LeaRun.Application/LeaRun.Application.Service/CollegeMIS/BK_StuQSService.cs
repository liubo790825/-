using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System.Data;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-07 16:20
    /// 描 述：学生综合素质记录表
    /// </summary>
    public class BK_StuQSService : RepositoryFactory<BK_StuQSEntity>, BK_StuQSIService
    {
        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuQSEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select sqs.ID,sqs.QualityId,sqs.StuId,sqs.StuThoughts
                            ,oq.Title,oq.Speaker,oq.RunTime,oq.UnitName,oq.RunAddress,oq.[Description]
                            ,stu.StuNo,stu.StuName,stu.Gender,stu.DeptNo,stu.MajorNo,
                            stu.IdentityCardNo,stu.telephone,stu.ClassNo,stu.Grade
                            ,ci.ClassName,ci.ClassNameFull,ci.ClassTutorNo,ci.ClassDiredctorNo
                            ,m.MajorName,d.DeptName
                             from [dbo].[BK_StuQualityScore] sqs
                            left join [BK_OverallQuality] oq on sqs.QualityId = oq.ID
                            left join BK_StuInfo stu on stu.stuInfoId = sqs.StuId
                            left join BK_ClassInfo ci on ci.ClassNo = stu.ClassNo
                            left join BK_Major m on m.MajorNo = stu.MajorNo
                            left join BK_Dept d on d.DeptNo = stu.DeptNo
                            where 1=1
                        ");
            var queryParam = queryJson.ToJObject();
            if (!queryParam["QualityId"].IsEmpty())
            {
                string QualityId = queryParam["QualityId"].ToString();
                strSql.Append(" and sqs.QualityId='" + QualityId + "'");
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                strSql.Append(" and sqs.StuId='" + StuId + "'");
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                strSql.Append(" and stu.StuName like '%" + StuName + "%'");
            }
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                strSql.Append(" and stu.StuNo like '%" + StuNo + "%'");
            }
            if (!queryParam["DeptName"].IsEmpty())
            {
                string DeptName = queryParam["DeptName"].ToString();
                strSql.Append(" and d.DeptName like '%" + DeptName + "%'");
            }
            if (!queryParam["MajorName"].IsEmpty())
            {
                string MajorName = queryParam["MajorName"].ToString();
                strSql.Append(" and m.MajorName like '%" + MajorName + "%'");
            }
            
            return this.BaseRepository(conn).FindList(strSql.ToString(), pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuQSEntity> GetList(string conn, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select sqs.ID,sqs.QualityId,sqs.StuId,sqs.StuThoughts
                            ,oq.Title,oq.Speaker,oq.RunTime,oq.UnitName,oq.RunAddress,oq.[Description]
                            ,stu.StuNo,stu.StuName,stu.Gender,stu.DeptNo,stu.MajorNo,
                            stu.IdentityCardNo,stu.telephone,stu.ClassNo,stu.Grade
                            ,ci.ClassName,ci.ClassNameFull,ci.ClassTutorNo,ci.ClassDiredctorNo
                            ,m.MajorName,d.DeptName
                             from [dbo].[BK_StuQualityScore] sqs
                            left join [BK_OverallQuality] oq on sqs.QualityId = oq.ID
                            left join BK_StuInfo stu on stu.stuInfoId = sqs.StuId
                            left join BK_ClassInfo ci on ci.ClassNo = stu.ClassNo
                            left join BK_Major m on m.MajorNo = stu.MajorNo
                            left join BK_Dept d on d.DeptNo = stu.DeptNo
                            where 1=1
                        ");
            var queryParam = queryJson.ToJObject();
            if (!queryParam["QualityId"].IsEmpty())
            {
                string QualityId = queryParam["QualityId"].ToString();
                strSql.Append(" and sql.QualityId='" + QualityId + "'");
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                strSql.Append(" and sql.StuId='" + StuId + "'");
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                strSql.Append(" and stu.StuName like '%" + StuName + "%'");
            }
            return this.BaseRepository(conn).FindList(strSql.ToString());
            //return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuQSEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }
        #endregion

    }
}
