using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 11:00
    /// 描 述：数据导入
    /// </summary>
    public class ExcelImportTemplateEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        [Column("F_EXCELIMPORTTEMPLATEID")]
        public string F_ExcelImportTemplateId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        [Column("F_NAME")]
        public string F_Name { get; set; }
        /// <summary>
        /// 功能页面ID
        /// </summary>
        /// <returns></returns>
        [Column("F_MODULEID")]
        public string F_ModuleId { get; set; }
        /// <summary>
        /// 功能页面的按钮ID号
        /// </summary>
        /// <returns></returns>
        [Column("F_MODULEBTNID")]
        public string F_ModuleBtnId { get; set; }
        /// <summary>
        /// 数据库ID号
        /// </summary>
        /// <returns></returns>
        [Column("F_DBID")]
        public string F_DbId { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        /// <returns></returns>
        [Column("F_DBTABLE")]
        public string F_DbTable { get; set; }
        /// <summary>
        /// 导入错误时的类型，跳过或终止
        /// </summary>
        /// <returns></returns>
        [Column("F_ERRORTYPE")]
        public string F_ErrorType { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 关联类型
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>		
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>		
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>		
        public string F_ModifyUserName { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.F_ExcelImportTemplateId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.F_CreateDate = DateTime.Now;
            this.F_EnabledMark = 1;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_ExcelImportTemplateId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}