using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-19 16:28
    /// 描 述：新生报到流程表
    /// </summary>
    public class BK_NewStuRegFlowService : RepositoryFactory, BK_NewStuRegFlowIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_NewStuRegFlowEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_NewStuRegFlowEntity>();
             //参考代码
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }*/
             //如果有字段2，字段3也这样写...
             expression = expression.And(t => t.DeleteMark!=1);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_NewStuRegFlowEntity> GetList(string conn, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select u.* from [BK_NewStuRegFlow] u
                            left join BK_AuthorizeNewStuRegFlow a on u.id=a.flowid
                            where u.DeleteMark<>1  ");
            string uid = Code.OperatorProvider.Provider.Current().UserId;//如果是超级管理员查出全部，如果不是就按授权来查询
            if (uid != "System")
            {
                strSql.Append(" and a.userid='" + uid + "'");
            }
            return this.BaseRepository(conn).IQueryable<BK_NewStuRegFlowEntity>().ToList();
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_AuthorizeNewStuRegFlowEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_AuthorizeNewStuRegFlowEntity>("select * from BK_AuthorizeNewStuRegFlow where FlowId='" + keyValue + "' order by CreateDate");
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_NewStuRegFlowEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_NewStuRegFlowEntity>(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_NewStuRegFlowEntity entity)
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


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entryList">子实体对象列表</param>
        /// <returns></returns>
        public void SaveChildList(string conn, string keyValue, List<BK_AuthorizeNewStuRegFlowEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Delete<BK_AuthorizeNewStuRegFlowEntity>(s => s.FlowId == keyValue);//先删除所有的授权
                    //明细
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            item.Create();
                            item.FlowId = keyValue;
                            db.Insert(item);
                        }
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
