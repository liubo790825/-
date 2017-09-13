using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.IService.SystemManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using LeaRun.Util;

using LeaRun.Util.Extension;

namespace LeaRun.Application.Service.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-04-17 12:09
    /// 描 述：Excel导出
    /// </summary>
    public class ExcelExportService : RepositoryFactory<ExcelExportEntity>, ExcelExportIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<ExcelExportEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ExcelExportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_GridId"].IsEmpty())//转换数据用
                {
                    string F_GridId = queryParam["F_GridId"].ToString();
                    expression = expression.And(t => t.F_GridId.Equals(F_GridId));
                }
                if (!queryParam["F_Name"].IsEmpty())//转换数据用
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
                if (!queryParam["F_ModuleId"].IsEmpty())//转换数据用
                {
                    string F_ModuleId = queryParam["F_ModuleId"].ToString();
                    expression = expression.And(t => t.F_ModuleId.Equals(F_ModuleId));
                }
                if (!queryParam["F_ModuleBtnId"].IsEmpty())//转换数据用
                {
                    string F_ModuleBtnId = queryParam["F_ModuleBtnId"].ToString();
                    expression = expression.And(t => t.F_ModuleBtnId.Equals(F_ModuleBtnId));
                }
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<ExcelExportEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<ExcelExportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_GridId"].IsEmpty())//转换数据用
                {
                    string F_GridId = queryParam["F_GridId"].ToString();
                    expression = expression.And(t => t.F_GridId.Equals(F_GridId));
                }
                if (!queryParam["F_Name"].IsEmpty())//转换数据用
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
                if (!queryParam["F_ModuleId"].IsEmpty())//转换数据用
                {
                    string F_ModuleId = queryParam["F_ModuleId"].ToString();
                    expression = expression.And(t => t.F_ModuleId.Equals(F_ModuleId));
                }
                if (!queryParam["F_ModuleBtnId"].IsEmpty())//转换数据用
                {
                    string F_ModuleBtnId = queryParam["F_ModuleBtnId"].ToString();
                    expression = expression.And(t => t.F_ModuleBtnId.Equals(F_ModuleBtnId));
                }
            }
            return this.BaseRepository().IQueryable(expression).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ExcelExportEntity GetEntity(string keyValue)
        {            
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ExcelExportEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
