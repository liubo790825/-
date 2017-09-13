using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:44
    /// 描 述：社团活动表
    /// </summary>
    public class Community_ActivitiesEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 社团活动ID号
        /// </summary>
        /// <returns></returns>
        public string CA_Id { get; set; }
        /// <summary>
        /// 社团ID号
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// 活动主题
        /// </summary>
        /// <returns></returns>
        public string CA_Title { get; set; }
        /// <summary>
        /// 活动发起人
        /// </summary>
        /// <returns></returns>
        public string CA_Initiator { get; set; }
        /// <summary>
        /// 活动详细内容说明
        /// </summary>
        /// <returns></returns>
        public string CA_Contents { get; set; }
        /// <summary>
        /// 活动举办地
        /// </summary>
        /// <returns></returns>
        public string CA_Address { get; set; }
        /// <summary>
        /// 活动参与者
        /// </summary>
        /// <returns></returns>
        public string CA_JoinPeople { get; set; }
        /// <summary>
        /// 活动举办开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_BeginTime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_EndTime { get; set; }
        /// <summary>
        /// 活动照片
        /// </summary>
        /// <returns></returns>
        public string CA_Photos { get; set; }
        /// <summary>
        /// 活动附件
        /// </summary>
        /// <returns></returns>
        public string CA_Files { get; set; }
        /// <summary>
        /// 活动备注说明
        /// </summary>
        /// <returns></returns>
        public string CA_Remark { get; set; }
        /// <summary>
        /// 活动申请时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_AppTime { get; set; }
        /// <summary>
        /// 活动审批人
        /// </summary>
        /// <returns></returns>
        public string CA_Approver { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_ApproveTime { get; set; }
        /// <summary>
        /// 审批通过
        /// </summary>
        /// <returns></returns>
        public bool? CA_ApprovePass { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other5 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other6 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other7 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CA_Other8 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CA_Id = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CA_Id = keyValue;
                                    
        }
        #endregion
    }
}