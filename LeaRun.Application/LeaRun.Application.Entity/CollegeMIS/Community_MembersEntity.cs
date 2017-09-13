using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:41
    /// 描 述：社团会员表
    /// </summary>
    public class Community_MembersEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 社团会员ID号
        /// </summary>
        /// <returns></returns>
        public string CM_Id { get; set; }
        /// <summary>
        /// 社团ID号
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// 社团角色id号
        /// </summary>
        /// <returns></returns>
        public string CR_Id { get; set; }
        /// <summary>
        /// 会员信息id号
        /// </summary>
        /// <returns></returns>
        public string CMI_Id { get; set; }
        /// <summary>
        /// 加入社团的日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_JoinDate { get; set; }
        /// <summary>
        /// 退出社团的日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_OutDate { get; set; }
        /// <summary>
        /// 退出社团
        /// </summary>
        /// <returns></returns>
        public bool? CM_IsOut { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string CM_Remark { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CM_Other5 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CM_Id = Guid.NewGuid().ToString();//根据实际需要去修改                   
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CM_Id = keyValue;
                                    
        }
        #endregion
    }
}