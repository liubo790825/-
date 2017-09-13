using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.FormManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-25 14:23
    /// 描 述：表单模板表
    /// </summary>
    public class Form_ModuleEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 表单模板Id
        /// </summary>
        /// <returns></returns>
        public string FrmId { get; set; }
        /// <summary>
        /// 表单编号
        /// </summary>
        /// <returns></returns>
        public string FrmCode { get; set; }
        /// <summary>
        /// 表单名称
        /// </summary>
        /// <returns></returns>
        public string FrmName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        /// <returns></returns>
        public string FrmCategory { get; set; }
        /// <summary>
        /// 表单类型0自定义表单1自定义表单(建表)2系统表单
        /// </summary>
        /// <returns></returns>
        public int? FrmType { get; set; }
        /// <summary>
        /// 数据库Id
        /// </summary>
        /// <returns></returns>
        public string FrmDbId { get; set; }
        /// <summary>
        /// 数据表
        /// </summary>
        /// <returns></returns>
        public string FrmDbTable { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        public string FrmDbPkey { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        /// <returns></returns>
        public string Version { get; set; }
        /// <summary>
        /// 表单内容
        /// </summary>
        /// <returns></returns>
        public string FrmContent { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 状态0停用1启用3草稿
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户ID
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改人id
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.FrmId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.FrmId = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

        }
        #endregion
    }
}