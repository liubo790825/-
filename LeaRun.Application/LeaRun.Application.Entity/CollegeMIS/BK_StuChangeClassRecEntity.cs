using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-11 14:25
    /// 描 述：学生换班记录
    /// </summary>
    public class BK_StuChangeClassRecEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 学生ID号
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// 原班级ID号
        /// </summary>
        /// <returns></returns>
        public string Old_ClassId { get; set; }
        /// <summary>
        /// 原班级号
        /// </summary>
        /// <returns></returns>
        public string Old_ClassNo { get; set; }
        /// <summary>
        /// 新班级ID号
        /// </summary>
        /// <returns></returns>
        public string New_ClassId { get; set; }
        /// <summary>
        /// 新班级号
        /// </summary>
        /// <returns></returns>
        public string New_ClassNo { get; set; }
        /// <summary>
        /// 换班原因
        /// </summary>
        /// <returns></returns>
        public string ChangeRemark { get; set; }
        /// <summary>
        /// 换班日期
        /// </summary>
        /// <returns></returns>
        public DateTime? ChangeDate { get; set; }
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

        /// <summary>
        /// 原院系ID号
        /// </summary>
        /// <returns></returns>
        public string Old_DeptId { get; set; }

        /// <summary>
        /// 原院系号
        /// </summary>
        /// <returns></returns>
        public string Old_DeptNo { get; set; }
        /// <summary>
        /// 转到院系ID号
        /// </summary>
        /// <returns></returns>
        public string New_DeptId { get; set; }
        /// <summary>
        /// 转到院系号
        /// </summary>
        /// <returns></returns>
        public string New_DeptNo { get; set; }
        /// <summary>
        /// 原专业ID号
        /// </summary>
        /// <returns></returns>
        public string Old_MajorId { get; set; }
        /// <summary>
        /// 原专业号
        /// </summary>
        /// <returns></returns>
        public string Old_MajorNo { get; set; }
        /// <summary>
        /// 新专业ID号
        /// </summary>
        /// <returns></returns>
        public string New_MajorId { get; set; }
        /// <summary>
        /// 新专业号
        /// </summary>
        /// <returns></returns>
        public string New_MajorNo { get; set; }
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
            this.ChangeDate = DateTime.Now;
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