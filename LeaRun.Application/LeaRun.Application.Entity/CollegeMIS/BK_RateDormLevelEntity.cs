using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-28 09:24
    /// 描 述：宿舍评级记录
    /// </summary>
    public class BK_RateDormLevelEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 宿舍评级记录ID号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 宿舍ID号
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// 升级或降级
        /// </summary>
        /// <returns></returns>
        public string LevelType { get; set; }
        /// <summary>
        /// 升或降多少级
        /// </summary>
        /// <returns></returns>
        public int? LevelNumber { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        /// <returns></returns>
        public string LevelRemark { get; set; }
        /// <summary>
        /// 申请人ID号
        /// </summary>
        /// <returns></returns>
        public string ApplicantId { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        /// <returns></returns>
        public string ApplicantName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ApplicantTime { get; set; }
        /// <summary>
        /// 审核人ID号
        /// </summary>
        /// <returns></returns>
        public string ReviewId { get; set; }
        /// <summary>
        /// 审核者姓名
        /// </summary>
        /// <returns></returns>
        public string ReviewName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ReviewTime { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        /// <returns></returns>
        public string ReviewRemark { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        /// <returns></returns>
        public string IsReviewed { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        /// <returns></returns>
        public string IsPassed { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string RateOther { get; set; }
        /// <summary>
        /// RateOther1
        /// </summary>
        /// <returns></returns>
        public string RateOther1 { get; set; }
        /// <summary>
        /// RateOther2
        /// </summary>
        /// <returns></returns>
        public string RateOther2 { get; set; }
        /// <summary>
        /// RateOther3
        /// </summary>
        /// <returns></returns>
        public string RateOther3 { get; set; }
        /// <summary>
        /// RateOther4
        /// </summary>
        /// <returns></returns>
        public string RateOther4 { get; set; }
        /// <summary>
        /// RateOther5
        /// </summary>
        /// <returns></returns>
        public string RateOther5 { get; set; }
        /// <summary>
        /// RateOther6
        /// </summary>
        /// <returns></returns>
        public string RateOther6 { get; set; }
        /// <summary>
        /// RateOther7
        /// </summary>
        /// <returns></returns>
        public string RateOther7 { get; set; }
        /// <summary>
        /// RateOther8
        /// </summary>
        /// <returns></returns>
        public string RateOther8 { get; set; }
        /// <summary>
        /// RateOther9
        /// </summary>
        /// <returns></returns>
        public string RateOther9 { get; set; }
        /// <summary>
        /// RateOther10
        /// </summary>
        /// <returns></returns>
        public string RateOther10 { get; set; }
        /// <summary>
        /// RateOther11
        /// </summary>
        /// <returns></returns>
        public string RateOther11 { get; set; }
        /// <summary>
        /// RateOther12
        /// </summary>
        /// <returns></returns>
        public string RateOther12 { get; set; }
        /// <summary>
        /// RateOther13
        /// </summary>
        /// <returns></returns>
        public string RateOther13 { get; set; }
        /// <summary>
        /// RateOther14
        /// </summary>
        /// <returns></returns>
        public string RateOther14 { get; set; }
        /// <summary>
        /// RateOther15
        /// </summary>
        /// <returns></returns>
        public DateTime? RateOther15 { get; set; }
        /// <summary>
        /// RateOther16
        /// </summary>
        /// <returns></returns>
        public DateTime? RateOther16 { get; set; }
        /// <summary>
        /// RateOther17
        /// </summary>
        /// <returns></returns>
        public DateTime? RateOther17 { get; set; }
        /// <summary>
        /// RateOther18
        /// </summary>
        /// <returns></returns>
        public int? RateOther18 { get; set; }
        /// <summary>
        /// RateOther19
        /// </summary>
        /// <returns></returns>
        public int? RateOther19 { get; set; }
        /// <summary>
        /// RateOther20
        /// </summary>
        /// <returns></returns>
        public int? RateOther20 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
            this.ApplicantId = OperatorProvider.Provider.Current().UserId;
            this.ApplicantName = OperatorProvider.Provider.Current().UserName;
            this.ApplicantTime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;    
        }
        #endregion
    }
}