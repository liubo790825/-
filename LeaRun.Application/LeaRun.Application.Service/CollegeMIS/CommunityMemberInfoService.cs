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
    /// 日 期：2016-12-26 10:39
    /// 描 述：会员信息表
    /// </summary>
    public class CommunityMemberInfoService : RepositoryFactory<CommunityMemberInfoEntity>, CommunityMemberInfoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<CommunityMemberInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<CommunityMemberInfoEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CMI_StuNo"].IsEmpty())
            {
                string CMI_StuNo = queryParam["CMI_StuNo"].ToString();
                expression = expression.And(t => t.CMI_StuNo.Contains(CMI_StuNo));
            }
            expression = expression.And(t => !string.IsNullOrEmpty(t.CMI_Id));
            /*var queryParam = queryJson.ToJObject();
            if (!queryParam["字段1"].IsEmpty()){
                string FullHead = queryParam["字段1"].ToString();
                expression = expression.And(t => t.字段1.Contains(字段1));
            }
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => t.CMI_Id > 0);*/
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CommunityMemberInfoEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public CommunityMemberInfoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public CommunityMemberInfoEntity GetSingleEntity(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<CommunityMemberInfoEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CMI_StuNo"].IsEmpty()){
                string CMI_StuNo = queryParam["CMI_StuNo"].ToString();
                expression = expression.And(t => t.CMI_StuNo.Contains(CMI_StuNo));
            }
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => !string.IsNullOrEmpty(t.CMI_Id));
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
        public void SaveForm(string conn, string keyValue, CommunityMemberInfoEntity entity)
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
