using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 10:57
    /// 描 述：数据导出详细设置
    /// </summary>
    public class System_SetExcelExportEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string F_Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <returns></returns>
        public string F_Name { get; set; }
        /// <summary>
        /// 绑定的JQgirdId
        /// </summary>
        /// <returns></returns>
        public string F_Gridid { get; set; }
        /// <summary>
        /// 功能模块ID
        /// </summary>
        /// <returns></returns>
        public string F_MouduleId { get; set; }
        /// <summary>
        /// 按钮Id
        /// </summary>
        /// <returns></returns>
        public string F_ModuleBtnId { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public int? F_EnabledMark { get; set; }
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
            this.F_Id = Guid.NewGuid().ToString();//根据实际需要去修改
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
            this.F_Id = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}