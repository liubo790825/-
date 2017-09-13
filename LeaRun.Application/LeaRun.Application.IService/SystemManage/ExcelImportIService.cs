using LeaRun.Application.Entity.SystemManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.Application.IService.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-03-31 15:17
    /// 描 述：Excel导入模板表
    /// </summary>
    public interface ExcelImportIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<ExcelImportEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 查询导入数据
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        IEnumerable<ExcelImportEntity> GetList(string queryJson);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ExcelImportEntity GetEntity(string keyValue);
        /// <summary>
        /// 查询所有的按钮
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ExcelImportEntity GetEntityByModuleId(string keyValue);
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        IEnumerable<ExcelImportFiledEntity> GetDetails(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, ExcelImportEntity entity,List<ExcelImportFiledEntity> entryList);
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="dt">表名</param>
        /// <param name="Result"></param>
        void ImportExcel(string fid, DataTable dt, out DataTable Result);
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="State"></param>
        void UpdateState(string keyValue, int State);
        #endregion
    }
}
