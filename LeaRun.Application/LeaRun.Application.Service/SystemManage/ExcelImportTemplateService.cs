using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.IService.SystemManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;


namespace LeaRun.Application.Service.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 11:00
    /// 描 述：数据导入
    /// </summary>
    public class ExcelImportTemplateService : RepositoryFactory, IExcelImportTemplateService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<ExcelImportTemplateEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<ExcelImportTemplateEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["F_Name"].IsEmpty()){
                 string F_Name = queryParam["F_Name"].ToString();
                 expression = expression.And(t => t.F_Name.Contains(F_Name));
             }
             //如果有字段2，字段3也这样写...
            // expression = expression.And(t => t.F_ExcelImportTemplateId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<ExcelImportTemplateEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<ExcelImportTemplateEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_Name"].IsEmpty())
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
            }
            //如果有字段2，字段3也这样写...
            // expression = expression.And(t => t.F_ExcelImportTemplateId > 0);
            return this.BaseRepository(conn).FindList(expression);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ExcelImportTemplateEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<ExcelImportTemplateEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<FiledsInfoEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository().FindList<FiledsInfoEntity>("select * from FiledsInfo where F_ExcelImportTemplateId='" + keyValue + "'");
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
                db.Delete<ExcelImportTemplateEntity>(keyValue);
                db.Delete<FiledsInfoEntity>(t => t.F_ExcelImportTemplateId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }


        /// <summary>
        /// 保存表单（新增、修改）,不包含子对象的数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, ExcelImportTemplateEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);                    
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);                    
                }
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
        public void SaveForm(string conn, string keyValue, ExcelImportTemplateEntity entity,List<FiledsInfoEntity> entryList)
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
                  db.Delete<FiledsInfoEntity>(t => t.F_ExcelImportTemplateId.Equals(keyValue));
                    foreach (FiledsInfoEntity item in entryList)
                    {
                        item.Create();
                        item.F_ExcelImportTemplateId = entity.F_ExcelImportTemplateId;
                        item.F_DbId = entity.F_DbId;
                        item.F_DbTable = entity.F_DbTable;
                        db.Insert(item);
                    }
              }
              else
              {
                  //主表
                  entity.Create();
                  db.Insert(entity);
                    //明细
                    foreach (FiledsInfoEntity item in entryList)
                    {
                        item.Create();
                        item.F_ExcelImportTemplateId = entity.F_ExcelImportTemplateId;
                        item.F_DbId = entity.F_DbId;
                        item.F_DbTable = entity.F_DbTable;
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
