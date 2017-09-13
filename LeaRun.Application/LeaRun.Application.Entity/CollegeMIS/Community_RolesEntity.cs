using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:37
    /// 描 述：社团角色
    /// </summary>
    public class Community_RolesEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 社团角色ID号
        /// </summary>
        /// <returns></returns>
        public string CR_Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        /// <returns></returns>
        public string CR_Name { get; set; }
        /// <summary>
        /// 角色备注
        /// </summary>
        /// <returns></returns>
        public string CR_Remark { get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        /// <returns></returns>
        public bool? CR_Isuse { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public bool? CR_Status { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CR_Id = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CR_Id = keyValue;
                                    
        }
        #endregion
    }
}