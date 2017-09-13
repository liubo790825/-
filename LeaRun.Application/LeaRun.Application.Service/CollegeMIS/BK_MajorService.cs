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
    /// 日 期：2017-06-19 10:03
    /// 描 述：专业
    /// </summary>
    public class BK_MajorService : RepositoryFactory, BK_MajorIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_MajorEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_MajorEntity>();
            //参考代码
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["majorNo"].IsEmpty())//转换数据用
                {
                    string MajorNo = queryParam["majorNo"].ToString();
                    expression = expression.And(t => t.MajorNo.Equals(MajorNo));
                }

                if (!queryParam["MajorName"].IsEmpty())
                {
                    string MajorName = queryParam["MajorName"].ToString();
                    expression = expression.And(t => t.MajorName.Contains(MajorName));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
            }

            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.MajorId > 0);
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_MajorEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_MajorEntity>(keyValue);
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="conn">连接字符</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public BK_MajorEntity GetEntityByWhere(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_MajorEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["MajorNo"].IsEmpty())
                {
                    string MajorNo = queryParam["MajorNo"].ToString();
                    expression = expression.And(t => t.MajorNo.Equals(MajorNo));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
            }

            return this.BaseRepository(conn).FindEntity(expression);
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_MajorDetailEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_MajorDetailEntity>("select * from BK_MajorDetail where MajorNo='" + keyValue + "'");
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
                db.Delete<BK_MajorEntity>(keyValue);
                db.Delete<BK_MajorDetailEntity>(t => t.MajorNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_MajorEntity entity,List<BK_MajorDetailEntity> entryList)
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
                            if (!string.IsNullOrEmpty(item.ID))
                            {
                                item.Modify(item.ID);
                                item.MajorNo = entity.MajorNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.MajorNo = entity.MajorNo;
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
                  foreach (BK_MajorDetailEntity item in entryList)
                  {
                      item.Create();
                      item.MajorNo = entity.MajorId;
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
