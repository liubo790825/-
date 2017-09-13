using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-07 16:20
    /// 描 述：临时表，为配合查询
    /// </summary>
    public class BK_StuQSEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 综合素质ID号
        /// </summary>
        /// <returns></returns>
        public string QualityId { get; set; }
        /// <summary>
        /// 学生ID号
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// DeleteMark
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// EnabledMark
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 获益之处及感想
        /// </summary>
        /// <returns></returns>
        public string StuThoughts { get; set; }
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
        /// 活动主题
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// 主讲人
        /// </summary>
        /// <returns></returns>
        public string Speaker { get; set; }
        /// <summary>
        /// 听讲时间
        /// </summary>
        /// <returns></returns>
        public DateTime? RunTime { get; set; }
        /// <summary>
        /// 举办单位
        /// </summary>
        /// <returns></returns>
        public string UnitName { get; set; }
        /// <summary>
        /// 举办地点
        /// </summary>
        /// <returns></returns>
        public string RunAddress { get; set; }
        /// <summary>
        /// 主要内容、主要观点与结论
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
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
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// 系部号
        /// </summary>
        /// <returns></returns>
        public string DeptNo { get; set; }
        /// <summary>
        /// 专业号
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string telephone { get; set; }
        /// <summary>
        /// 班级号
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// 班级全称
        /// </summary>
        /// <returns></returns>
        public string ClassNameFull { get; set; }
        /// <summary>
        /// ClassTutorNo
        /// </summary>
        /// <returns></returns>
        public string ClassTutorNo { get; set; }
        /// <summary>
        /// ClassDiredctorNo
        /// </summary>
        /// <returns></returns>
        public string ClassDiredctorNo { get; set; }
        /// <summary>
        /// 专业名称
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 所属系部
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
           
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
           

        }
        #endregion
    }
}