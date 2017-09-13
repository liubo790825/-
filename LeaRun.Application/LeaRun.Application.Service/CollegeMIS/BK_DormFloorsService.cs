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
    /// 日 期：2017-06-28 16:37
    /// 描 述：宿舍楼层信息
    /// </summary>
    public class BK_DormFloorsService : RepositoryFactory, BK_DormFloorsIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DormFloorsEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DormFloorsEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["dormFloorsId"].IsEmpty())//转换数据用
             {
                 string DormFloorsId = queryParam["dormFloorsId"].ToString();
                 expression = expression.And(t => t.DormFloorsId.Equals(DormFloorsId));
             }
             if (!queryParam["DormBuildingId"].IsEmpty())
             {
                 string DormBuildingId = queryParam["DormBuildingId"].ToString();
                 expression = expression.And(t => t.DormBuildingId.Equals(DormBuildingId));
             }
             if (!queryParam["dormFloorsNo"].IsEmpty())
             {
                 string dormFloorsNo = queryParam["dormFloorsNo"].ToString();
                 expression = expression.And(t => t.DormFloorsNo.Equals(dormFloorsNo));
             }

             if (!queryParam["DormFloorsManager"].IsEmpty()){
                 string DormFloorsManager = queryParam["DormFloorsManager"].ToString();
                 expression = expression.And(t => t.DormFloorsManager.Contains(DormFloorsManager));
             }
            if (!queryParam["DormFloorsName"].IsEmpty())
            {
                string DormFloorsName = queryParam["DormFloorsName"].ToString();
                expression = expression.And(t => t.DormFloorsName.Contains(DormFloorsName));
            }
            if (!queryParam["DormFloorsNo"].IsEmpty())
            {
                string DormFloorsNo = queryParam["DormFloorsNo"].ToString();
                expression = expression.And(t => t.DormFloorsNo.Equals(DormFloorsNo));
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression).OrderBy(s => s.DormFloorsName);
            }
            return this.BaseRepository(conn).FindList(expression,pagination).OrderBy(s=>s.DormFloorsName);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DormFloorsEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormFloorsEntity>(keyValue);
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DormEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DormEntity>("select * from BK_Dorm where DormFloorsId='" + keyValue + "' order by DormName");
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
                db.Delete<BK_DormFloorsEntity>(keyValue);
                db.Delete<BK_DormEntity>(t => t.DormFloorsId.Equals(keyValue));               
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
        public void SaveForm(string conn, string keyValue, BK_DormFloorsEntity entity, List<BK_DormEntity> entryList)
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
                            if (!string.IsNullOrEmpty(item.DormId))
                            {
                                item.Modify(item.DormId);
                                item.DormFloorsId = entity.DormFloorsId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DormFloorsId = entity.DormFloorsId;
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
                    foreach (BK_DormEntity item in entryList)
                    {
                        item.Create();
                        item.DormFloorsId = entity.DormFloorsId;
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
