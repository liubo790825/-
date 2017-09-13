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
    /// 日 期：2017-06-28 16:39
    /// 描 述：宿舍单元信息
    /// </summary>
    public class BK_DormUnitService : RepositoryFactory, BK_DormUnitIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DormUnitEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DormUnitEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["dormUnitId"].IsEmpty())//转换数据用
             {
                 string DormUnitId = queryParam["dormUnitId"].ToString();
                 expression = expression.And(t => t.DormUnitId.Equals(DormUnitId));
             }
             if (!queryParam["dormUnitNo"].IsEmpty())//转换数据用
             {
                 string DormUnitNo = queryParam["dormUnitNo"].ToString();
                 expression = expression.And(t => t.DormUnitNo.Equals(DormUnitNo));
             }

             if (!queryParam["DormUnitManager"].IsEmpty()){
                 string DormUnitManager = queryParam["DormUnitManager"].ToString();
                 expression = expression.And(t => t.DormUnitManager.Contains(DormUnitManager));              
             }
            if (!queryParam["DormUnitName"].IsEmpty())
            {
                string DormUnitName = queryParam["DormUnitName"].ToString();
                expression = expression.And(t => t.DormUnitName.Contains(DormUnitName));               
            }
            if (!queryParam["DormUnitNo"].IsEmpty())
            {
                string DormUnitNo = queryParam["DormUnitNo"].ToString();
                expression = expression.And(t => t.DormUnitNo.Contains(DormUnitNo));
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
        public BK_DormUnitEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormUnitEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DormFloorsEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DormFloorsEntity>("select * from BK_DormFloors where DormUnitId='" + keyValue + "' order by DormFloorsName");
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
                db.Delete<BK_DormUnitEntity>(keyValue);
                db.Delete<BK_DormFloorsEntity>(t => t.DormUnitId.Equals(keyValue));
                db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//再删除房间
                db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//先删除床位


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
        public void SaveForm(string conn, string keyValue, BK_DormUnitEntity entity,List<BK_DormFloorsEntity> entryList)
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
                            if (!string.IsNullOrEmpty(item.DormFloorsId))
                            {
                                item.Modify(item.DormFloorsId);
                                item.DormUnitId = entity.DormUnitId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DormUnitId = entity.DormUnitId;
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
                  foreach (BK_DormFloorsEntity item in entryList)
                  {
                      item.Create();
                      item.DormUnitId = entity.DormUnitId;
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
