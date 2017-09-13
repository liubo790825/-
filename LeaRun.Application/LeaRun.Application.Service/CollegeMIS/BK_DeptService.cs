using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:57
    /// 描 述：系部
    /// </summary>
    public class BK_DeptService : RepositoryFactory, BK_DeptIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DeptEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DeptEntity>();
            //参考代码
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["deptNo"].IsEmpty())//转换数据用
                {
                    string DeptNo = queryParam["deptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
                if (!queryParam["DeptName"].IsEmpty())
                {
                    string DeptName = queryParam["DeptName"].ToString();
                    expression = expression.And(t => t.DeptName.Contains(DeptName));
                }
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression, pagination);

        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DeptEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DeptEntity>(keyValue);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public BK_DeptEntity GetEntityByWhere(string conn, string where)
        {
            var expression = LinqExtensions.True<BK_DeptEntity>();
            if (!string.IsNullOrEmpty(where))
            {
                var queryParam = where.ToJObject();
                if (!queryParam["DeptName"].IsEmpty())
                {
                    string DeptName = queryParam["DeptName"].ToString();
                    expression = expression.And(t => t.DeptName.Contains(DeptName));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Contains(DeptNo));
                }
            }
            return this.BaseRepository(conn).FindEntity<BK_DeptEntity>(expression);
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_MajorEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_MajorEntity>("select * from BK_Major where DeptNo='" + keyValue + "'");
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">院系号</param>
        /// <returns></returns>
        public List<BK_MajorEntity> GetListDetails(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_MajorEntity>().And(t=>t.DeptNo.Equals(keyValue));
            return this.BaseRepository(conn).FindList<BK_MajorEntity>(expression).OrderBy(t=>t.MajorName).ToList();
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
                db.Delete<BK_DeptEntity>(keyValue);
                db.Delete<BK_MajorEntity>(t => t.DeptNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_DeptEntity entity,List<BK_MajorEntity> entryList)
        {
          IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
              if (!string.IsNullOrEmpty(keyValue))
              {
                  //主表
                  entity.Modify(keyValue);
                  db.Update(entity);
                    //明细
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.MajorId))
                            {
                                item.Modify(item.MajorId);
                                item.DeptNo = entity.DeptNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DeptNo = entity.DeptNo;
                                db.Insert(item);
                            }
                        }
                    }
              }
              else
              {
                  //主表
                  entity.Create();
                  db.Insert(entity);
                  //明细
                  foreach (BK_MajorEntity item in entryList)
                  {
                      item.Create();
                      item.DeptNo = entity.DeptId;
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
