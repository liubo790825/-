using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 14:05
    /// 描 述：通知书快递信息
    /// </summary>
    public class BK_ExpressInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string Stuno { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 收件地址
        /// </summary>
        /// <returns></returns>
        public string StuAddress { get; set; }
        /// <summary>
        /// 通知书号
        /// </summary>
        /// <returns></returns>
        public string NoticeNo { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        /// <returns></returns>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// 快递号
        /// </summary>
        /// <returns></returns>
        public string ExpressNo { get; set; }
        /// <summary>
        /// 是否发送
        /// </summary>
        /// <returns></returns>
        public int? Sended { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        /// <returns></returns>
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 发送者
        /// </summary>
        /// <returns></returns>
        public string Sender { get; set; }
        /// <summary>
        /// 快递员
        /// </summary>
        /// <returns></returns>
        public string Postman { get; set; }
        /// <summary>
        /// 打包者
        /// </summary>
        /// <returns></returns>
        public string Paker { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// ModifyUserName
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
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
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
            this.ID = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

        }
        #endregion
    }
}