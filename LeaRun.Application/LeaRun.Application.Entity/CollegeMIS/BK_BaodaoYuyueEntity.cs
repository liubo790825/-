using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-13 05:03
    /// 描 述：BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueEntity : BaseEntity
    {
        #region 实体成员

        public string Token;

        /// <summary>
        /// 标识列
        /// </summary>
        /// <returns></returns>
        public string YuyueId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 到达方式
        /// </summary>
        /// <returns></returns>
        public string ArrivalMode { get; set; }
        /// <summary>
        /// 到达地点
        /// </summary>
        /// <returns></returns>
        public string ArrivalPosition { get; set; }
        /// <summary>
        /// 随行人数
        /// </summary>
        /// <returns></returns>
        public string Number { get; set; }
        /// <summary>
        /// 紧急联系人姓名
        /// </summary>
        /// <returns></returns>
        public string ParentsName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }
        /// <summary>
        /// 备用电话
        /// </summary>
        /// <returns></returns>
        public string SpareTelephone { get; set; }
        /// <summary>
        /// 留言
        /// </summary>
        /// <returns></returns>
        public string Massage { get; set; }
        /// <summary>
        /// 到达日期
        /// </summary>
        /// <returns></returns>
        public DateTime? ArrivalDate { get; set; }
        /// <summary>
        /// BaodaoStatus
        /// </summary>
        /// <returns></returns>
        public string BaodaoStatus { get; set; }
        /// <summary>
        /// BaodaoOther1
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther1 { get; set; }
        /// <summary>
        /// BaodaoOther2
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther2 { get; set; }
        /// <summary>
        /// BaodaoOther3
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther3 { get; set; }
        /// <summary>
        /// BaodaoOther4
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther4 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.YuyueId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.YuyueId = keyValue;
                                    
        }
        #endregion
    }
}