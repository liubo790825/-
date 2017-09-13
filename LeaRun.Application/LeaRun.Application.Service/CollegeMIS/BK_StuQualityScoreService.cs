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
    public class BK_StuQualityScoreService : RepositoryFactory<BK_StuQualityScoreEntity>, BK_StuQualityScoreIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuQualityScoreEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuQualityScoreEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["QualityId"].IsEmpty()){
                 string QualityId = queryParam["QualityId"].ToString();
                 expression = expression.And(t => t.QualityId.Equals(QualityId));
             }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
         
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public DataTable GetPageListByDataSet(string conn, Pagination pagination, string queryJson)
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
            return this.BaseRepository(conn).FindTable(strSql.ToString(), pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuQualityScoreEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuQualityScoreEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_StuQualityScoreEntity>();
            //参考代码
            var queryParam = keyValue.ToJObject();
            if (!queryParam["ID"].IsEmpty())
            {
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Equals(ID));
            }
            if (!queryParam["QualityId"].IsEmpty())
            {
                string QualityId = queryParam["QualityId"].ToString();
                expression = expression.And(t => t.QualityId.Equals(QualityId));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }

            return this.BaseRepository(conn).FindEntity(expression); //.FindEntity(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_StuQualityScoreEntity entity)
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
