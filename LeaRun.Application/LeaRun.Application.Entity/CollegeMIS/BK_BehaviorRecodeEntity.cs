using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-10 11:42
    /// 描 述：学生操行记录
    /// </summary>
    public class BK_BehaviorRecodeEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 操行类型ID号
        /// </summary>
        /// <returns></returns>
        public string BehaviorTypeId { get; set; }
        /// <summary>
        /// 违反的操行
        /// </summary>
        /// <returns></returns>
        public string BreachBehavior { get; set; }
        /// <summary>
        /// 违反时间
        /// </summary>
        /// <returns></returns>
        public DateTime? BreachTime { get; set; }
        /// <summary>
        /// 提交者
        /// </summary>
        /// <returns></returns>
        public string Submiter { get; set; }
        /// <summary>
        /// 是否撤消，0未撤消，1撤消申请中，2撤消
        /// </summary>
        /// <returns></returns>
        public int? IsCanceled { get; set; }
        /// <summary>
        /// 申请撤消的次数
        /// </summary>
        /// <returns></returns>
        public int? AppCancel { get; set; }
        /// <summary>
        /// 是否可以申请撤消，如果申请撤消次数达3次以上者，不可再次申请
        /// </summary>
        /// <returns></returns>
        public int? CanCancel { get; set; }
        /// <summary>
        /// 删除标记，0未删除，1删除
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 有效标记，1有效，0失效
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
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
            this.CanCancel = 0;
            this.AppCancel = 0;
            this.DeleteMark = 0;
            this.EnabledMark = 1;
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