using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.IService.FormManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System;
using System.Data;
using System.Text;

namespace LeaRun.Application.Service.FormManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-25 14:23
    /// 描 述：表单模板表
    /// </summary>
    public class Form_ModuleService : RepositoryFactory, IForm_ModuleService
    {
        #region 获取数据

        /// <summary>
        /// 获得所有的表单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Form_ModuleEntity> GetList()
        {
            return this.BaseRepository().FindList<Form_ModuleEntity>("select * from Form_Module order by Version desc");
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<Form_ModuleEntity> GetPageList( Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<Form_ModuleEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["FrmCategory"].IsEmpty()){
                 string FrmCategory = queryParam["FrmCategory"].ToString();
                 expression = expression.And(t => t.FrmCategory.Contains(FrmCategory));
             }
            if (!queryParam["FrmCode"].IsEmpty())
            {
                string FrmCode = queryParam["FrmCode"].ToString();
                expression = expression.And(t => t.FrmCode.Contains(FrmCode));
            }
            if (!queryParam["FrmType"].IsEmpty())
            {
                int FrmType = queryParam["FrmType"].ToInt();
                expression = expression.And(t => t.FrmType== FrmType);
            }
            if (!queryParam["FrmName"].IsEmpty())
            {
                string FrmName = queryParam["FrmName"].ToString();
                expression = expression.And(t => t.FrmName.Contains(FrmName));
            }

            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<Form_ModuleEntity> GetList( string queryJson)
        {
            var expression = LinqExtensions.True<Form_ModuleEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["FrmCategory"].IsEmpty())
            {
                string FrmCategory = queryParam["FrmCategory"].ToString();
                expression = expression.And(t => t.FrmCategory.Contains(FrmCategory));
            }
            if (!queryParam["FrmCode"].IsEmpty())
            {
                string FrmCode = queryParam["FrmCode"].ToString();
                expression = expression.And(t => t.FrmCode.Contains(FrmCode));
            }
            if (!queryParam["FrmType"].IsEmpty())
            {
                int FrmType = queryParam["FrmType"].ToInt();
                expression = expression.And(t => t.FrmType == FrmType);
            }
            if (!queryParam["FrmName"].IsEmpty())
            {
                string FrmName = queryParam["FrmName"].ToString();
                expression = expression.And(t => t.FrmName.Contains(FrmName));
            }
            if (!queryParam["FrmId"].IsEmpty())
            {
                string FrmId = queryParam["FrmId"].ToString();
                expression = expression.And(t => t.FrmId.Contains(FrmId));
            }
            
            return this.BaseRepository() .IQueryable<Form_ModuleEntity>(expression).ToList();
        }
        
        /// <summary>
        /// 获取表单数据ALL(用于下拉框)
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                            w.FrmId,
	                            w.FrmName,
	                            w.FrmCategory,
							    t2.ItemName AS FrmTypeName
                            FROM
	                            Form_Module w
						    LEFT JOIN 
                                Base_DataItemDetail t2 ON t2.ItemDetailId = w.FrmCategory
                            WHERE w.DeleteMark = 0 and w.EnabledMark = 1 order by w.FrmType");
                return this.BaseRepository().FindTable(strSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Form_ModuleEntity GetEntity( string keyValue)
        {
            return this.BaseRepository().FindEntity<Form_ModuleEntity>(keyValue);
        }


        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<Form_ModuleContentEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<Form_ModuleContentEntity>("select * from Form_ModuleContent where FrmId='" + keyValue + "'");
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm( string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<Form_ModuleEntity>(keyValue);
                db.Delete<Form_ModuleContentEntity>(t => t.FrmId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 更新表单模板状态（启用，停用）
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="status">状态 1:启用;0.停用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Form_ModuleEntity entity = new Form_ModuleEntity();
                entity.Modify(keyValue);
                entity.EnabledMark = state;
                this.BaseRepository().Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm( string keyValue, Form_ModuleEntity entity)
        {
            Random rd = new Random();
            string rdnumber = rd.Next(10000).ToString().PadLeft(4);
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);                
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.Version = "V" + DateTime.Now.ToString("yyyyMMddHHmmssffff"); //entity.CreateDate.Value.ToString("yyyyMMddHHmmss") + rdnumber;//版本号
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
