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
    /// 日 期：2016-12-26 10:41
    /// 描 述：社团会员表
    /// </summary>
    public class Community_MembersService : RepositoryFactory<Community_MembersEntity>, Community_MembersIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Community_MembersEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<Community_MembersEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
            /*if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }
             //如果有字段2，字段3也这样写...
             expression = expression.And(t => t.CM_Id > 0);*/
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<Community_MembersEntity> GetList(string conn, string queryJson)
        {
            
            return this.BaseRepository(conn).IQueryable().ToList();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public Community_MembersEntity GetSingleEntity(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<Community_MembersEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CM_Id"].IsEmpty())
            {
                string CM_Id = queryParam["CM_Id"].ToString();
                expression = expression.And(t => t.CM_Id.Equals(CM_Id));
            }
            if (!queryParam["C_Id"].IsEmpty())
            {
                string C_Id = queryParam["C_Id"].ToString();
                expression = expression.And(t => t.C_Id.Equals(C_Id));
            }
            //如果有字段2，字段3也这样写...
            expression = expression.And(t => !string.IsNullOrEmpty(t.CM_Id));
            return this.BaseRepository(conn).FindEntity(expression);
        }


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Community_MembersEntity GetEntity(string conn, string keyValue)
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
        public void SaveForm(string conn, string keyValue, Community_MembersEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                //先要查询表里面是否已经添加了这个学生到这个社团里，如果已经添加了，就不添加了
                /*string jsonStr = "{";
                jsonStr += "\"CMI_Id\":" + "\"" + entity.CMI_Id + "\"";
                jsonStr += ",\"C_Id\":"+"\""+ entity.C_Id + "\"" ;
                jsonStr += "}";
                Community_MembersEntity model = this.GetSingleEntity(conn, jsonStr);
                if (model == null)*/
                {
                    entity.Create();
                    this.BaseRepository(conn).Insert(entity);
                }
                
            }
        }
        #endregion
    }
}
