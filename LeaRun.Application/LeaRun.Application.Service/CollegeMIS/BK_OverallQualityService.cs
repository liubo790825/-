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
    /// 日 期：2017-08-07 15:06
    /// 描 述：综合素质内容表
    /// </summary>
    public class BK_OverallQualityService : RepositoryFactory<BK_OverallQualityEntity>, BK_OverallQualityIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_OverallQualityEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_OverallQualityEntity>().And(t=>t.DeleteMark==0);
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["AcademicTypeId"].IsEmpty()){
                 string AcademicTypeId = queryParam["AcademicTypeId"].ToString();
                 expression = expression.And(t => t.AcademicTypeId.Equals(AcademicTypeId));
             }
            if (!queryParam["UnitName"].IsEmpty())
            {
                string UnitName = queryParam["UnitName"].ToString();
                expression = expression.And(t => t.UnitName.Contains(UnitName));
            }
            if (!queryParam["AcademicTypeName"].IsEmpty())
            {
                string AcademicTypeName = queryParam["AcademicTypeName"].ToString();
                expression = expression.And(t => t.AcademicTypeName.Contains(AcademicTypeName));
            }
            if (!queryParam["Title"].IsEmpty())
            {
                string Title = queryParam["Title"].ToString();
                expression = expression.And(t => t.Title.Contains(Title));
            }
            if (!queryParam["Speaker"].IsEmpty())
            {
                string Speaker = queryParam["Speaker"].ToString();
                expression = expression.And(t => t.Speaker.Contains(Speaker));
            }
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_OverallQualityEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_OverallQualityEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_OverallQualityEntity entity)
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
