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
    /// 日 期：2017-08-02 13:54
    /// 描 述：BK_Advisory
    /// </summary>
    public class BK_AdvisoryService : RepositoryFactory, BK_AdvisoryIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_AdvisoryEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_AdvisoryEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (queryParam["QAOther1"] != null && queryParam["QAOther1"].ToString() != "")
            {//查询同班同学
                string QAOther1 = queryParam["QAOther1"].ToString();
                expression = expression.And(t => t.QAOther1.Contains(QAOther1));
            }
            //*/
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => !string.IsNullOrEmpty(t.QAId));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// 教师端获取咨询问题列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_AdvisoryEntity> TeaGetPageList(string conn, Pagination pagination, string queryJson)
        {
            string stuinfoid = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                stuinfoid = queryParam["stuInfoId"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select *");
            strsql.Append(@"  from BK_Advisory");
            strsql.Append(@"  where 1=1");
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                strsql.Append(string.Format(@"  and stuInfoId = '{0}'", stuinfoid));
            }
            return this.BaseRepository(conn).FindList<BK_AdvisoryEntity>(strsql.ToString(), pagination).ToList();
        }


        /// <summary>
        /// 教师端获取咨询学生列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_AdvisoryEntity> TeaGetStuList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select DISTINCT StuName,stuInfoId,QAOther1");
            strsql.Append(@"  from BK_Advisory");
            //strsql.Append(@"  where (Answer is not null) and (Answer <> '')");

            return this.BaseRepository(conn).FindList<BK_AdvisoryEntity>(strsql.ToString(), pagination).ToList();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_AdvisoryEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_AdvisoryEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_AdvisoryEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_AdvisoryEntity>(keyValue);
        }

        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT( DISTINCT stuInfoId) number ");
            strsql.Append(@"  from BK_Advisory");
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
        public void SaveForm(string conn, string keyValue, BK_AdvisoryEntity entity)
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
