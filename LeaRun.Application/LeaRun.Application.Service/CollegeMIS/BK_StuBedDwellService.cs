using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-28 09:28
    /// 描 述：学生入住床位记录
    /// </summary>
    public class BK_StuBedDwellService : RepositoryFactory<BK_StuBedDwellEntity>, BK_StuBedDwellIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuBedDwellEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuBedDwellEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuId"].IsEmpty()){
                 string StuId = queryParam["StuId"].ToString();
                 expression = expression.And(t => t.StuId.Equals(StuId));
             }
            if (!queryParam["BedId"].IsEmpty())
            {
                string BedId = queryParam["BedId"].ToString();
                expression = expression.And(t => t.BedId.Equals(BedId));
            }

            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuBedDwellEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuBedDwellEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="queryJson">查询的条件</param>
        /// <returns></returns>
        public BK_StuBedDwellEntity GetEntityByWhere(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuBedDwellEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            if (!queryParam["BedId"].IsEmpty())
            {
                string BedId = queryParam["BedId"].ToString();
                expression = expression.And(t => t.BedId.Equals(BedId));
            }
            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindEntity(expression);
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
        public void SaveForm(string conn, string keyValue, BK_StuBedDwellEntity entity)
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
