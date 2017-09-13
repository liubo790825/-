using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-28 09:28
    /// 描 述：学生入住床位记录
    /// </summary>
    public class BK_StuBedDwellEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 学生ID号
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// 床位ID号
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        /// <returns></returns>
        public DateTime? EnterDate { get; set; }
        /// <summary>
        /// 退出时间
        /// </summary>
        /// <returns></returns>
        public DateTime? QuitDate { get; set; }
        /// <summary>
        /// 入住备注
        /// </summary>
        /// <returns></returns>
        public string EnterRemark { get; set; }
        /// <summary>
        /// 退出备注
        /// </summary>
        /// <returns></returns>
        public string QuitRemark { get; set; }
        /// <summary>
        /// 操作者ID号
        /// </summary>
        /// <returns></returns>
        public string OperatorID { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        /// <returns></returns>
        public string Operator { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        /// <returns></returns>
        public DateTime? OperatorTime { get; set; }
        /// <summary>
        /// 记录最后修改人ID号
        /// </summary>
        /// <returns></returns>
        public string DwellOther { get; set; }
        /// <summary>
        /// 记录最后修改人姓名
        /// </summary>
        /// <returns></returns>
        public string DwellOther1 { get; set; }
        /// <summary>
        /// DwellOther2
        /// </summary>
        /// <returns></returns>
        public string DwellOther2 { get; set; }
        /// <summary>
        /// DwellOther3
        /// </summary>
        /// <returns></returns>
        public string DwellOther3 { get; set; }
        /// <summary>
        /// DwellOther4
        /// </summary>
        /// <returns></returns>
        public string DwellOther4 { get; set; }
        /// <summary>
        /// DwellOther5
        /// </summary>
        /// <returns></returns>
        public string DwellOther5 { get; set; }
        /// <summary>
        /// DwellOther6
        /// </summary>
        /// <returns></returns>
        public string DwellOther6 { get; set; }
        /// <summary>
        /// DwellOther7
        /// </summary>
        /// <returns></returns>
        public string DwellOther7 { get; set; }
        /// <summary>
        /// DwellOther8
        /// </summary>
        /// <returns></returns>
        public string DwellOther8 { get; set; }
        /// <summary>
        /// DwellOther9
        /// </summary>
        /// <returns></returns>
        public string DwellOther9 { get; set; }
        /// <summary>
        /// DwellOther10
        /// </summary>
        /// <returns></returns>
        public string DwellOther10 { get; set; }
        /// <summary>
        /// DwellOther11
        /// </summary>
        /// <returns></returns>
        public string DwellOther11 { get; set; }
        /// <summary>
        /// DwellOther12
        /// </summary>
        /// <returns></returns>
        public string DwellOther12 { get; set; }
        /// <summary>
        /// DwellOther13
        /// </summary>
        /// <returns></returns>
        public string DwellOther13 { get; set; }
        /// <summary>
        /// DwellOther14
        /// </summary>
        /// <returns></returns>
        public string DwellOther14 { get; set; }
        /// <summary>
        /// 记录修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther15 { get; set; }
        /// <summary>
        /// DwellOther16
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther16 { get; set; }
        /// <summary>
        /// DwellOther17
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther17 { get; set; }
        /// <summary>
        /// DwellOther18
        /// </summary>
        /// <returns></returns>
        public int? DwellOther18 { get; set; }
        /// <summary>
        /// DwellOther19
        /// </summary>
        /// <returns></returns>
        public int? DwellOther19 { get; set; }
        /// <summary>
        /// DwellOther20
        /// </summary>
        /// <returns></returns>
        public int? DwellOther20 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
            this.OperatorID = OperatorProvider.Provider.Current().UserId;
            this.Operator = OperatorProvider.Provider.Current().UserName;
            this.OperatorTime = DateTime.Now;       
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.DwellOther = OperatorProvider.Provider.Current().UserId;//记录最后修改人
            this.DwellOther1 = OperatorProvider.Provider.Current().UserName;//记录最后修改人
            this.DwellOther15 = DateTime.Now;
        }
        #endregion
    }
}