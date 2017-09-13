using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:04
    /// 描 述：专业方向
    /// </summary>
    public class BK_MajorDetailService : RepositoryFactory, BK_MajorDetailIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_MajorDetailEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_MajorDetailEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["majorDetailNo"].IsEmpty())//转换数据用
             {
                 string MajorDetailNo = queryParam["majorDetailNo"].ToString();
                 expression = expression.And(t => t.MajorDetailNo.Equals(MajorDetailNo));
             }

             if (!queryParam["MajorDetailName"].IsEmpty()){
                 string MajorDetailName = queryParam["MajorDetailName"].ToString();
                 expression = expression.And(t => t.MajorDetailName.Contains(MajorDetailName));
             }
            if (!queryParam["MajorName"].IsEmpty())
            {
                string MajorName = queryParam["MajorName"].ToString();
                expression = expression.And(t => t.MajorName.Contains(MajorName));
            }
            if (!queryParam["MajorNo"].IsEmpty())
            {
                string MajorNo = queryParam["MajorNo"].ToString();
                expression = expression.And(t => t.MajorNo.Equals(MajorNo));
            }
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
        public BK_MajorDetailEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_MajorDetailEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_ClassInfoEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_ClassInfoEntity>("select * from BK_ClassInfo where MajorDetailNo='" + keyValue + "'");
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
                db.Delete<BK_MajorDetailEntity>(keyValue);
                db.Delete<BK_ClassInfoEntity>(t => t.MajorDetailNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_MajorDetailEntity entity,List<BK_ClassInfoEntity> entryList)
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
                            if (!string.IsNullOrEmpty( item.ClassId))
                            {
                                item.Modify(item.ClassId);
                                item.MajorDetailNo = entity.MajorDetailNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.MajorDetailNo = entity.MajorDetailNo;
                                db.Insert(item);
                            }
                        }
                    }
                    //明细
                    //db.Delete<BK_ClassInfoEntity>(t => t.MajorDetailNo.Equals(keyValue));
                  
              }
              else
              {
                  //主表
                  entity.Create();
                  db.Insert(entity);
                  //明细
                  foreach (BK_ClassInfoEntity item in entryList)
                  {
                      item.Create();
                      item.MajorDetailNo = entity.ID;
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
