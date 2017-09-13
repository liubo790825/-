using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-13 12:14
    /// 描 述：教工生成账户
    /// </summary>
    public class EmpInfo2AccountEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        public int? EmpID { get; set; }
        /// <summary>
        /// 职工号
        /// </summary>
        /// <returns></returns>
        public string EmpNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string EmpName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        /// <returns></returns>
        public string Nation { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string Sfzhao { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 所在部门
        /// </summary>
        /// <returns></returns>
        public string Department { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        /// <returns></returns>
        public string EmpPosition { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        /// <returns></returns>
        public string TechTitle { get; set; }
        /// <summary>
        /// 员工分类系列
        /// </summary>
        /// <returns></returns>
        public string EmpSort { get; set; }
        /// <summary>
        /// 合同类别（BsContractType）
        /// </summary>
        /// <returns></returns>
        public string ContractType { get; set; }
        /// <summary>
        /// 专职否
        /// </summary>
        /// <returns></returns>
        public string ZjzhiMark { get; set; }
        /// <summary>
        /// 在聘否
        /// </summary>
        /// <returns></returns>
        public string PrztaiMark { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        /// <summary>
        /// 教师证
        /// </summary>
        /// <returns></returns>
        public string TeacherCertificate { get; set; }
        /// <summary>
        /// 工作起始日期
        /// </summary>
        /// <returns></returns>
        public DateTime? WorkstartDate { get; set; }
        /// <summary>
        /// 入校工作时间
        /// </summary>
        /// <returns></returns>
        public DateTime? InSchoolDate { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        /// <returns></returns>
        public string PartyFace { get; set; }
        /// <summary>
        /// 加入组织时间
        /// </summary>
        /// <returns></returns>
        public DateTime? PartyDate { get; set; }
        /// <summary>
        /// 社会保险
        /// </summary>
        /// <returns></returns>
        public string SocialSecurity { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        /// <returns></returns>
        public string jiguan { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        public string Major { get; set; }
        /// <summary>
        /// 第一学历
        /// </summary>
        /// <returns></returns>
        public string firstxueli { get; set; }
        /// <summary>
        /// 第一学历毕业于
        /// </summary>
        /// <returns></returns>
        public string firstxlgradufrom { get; set; }
        /// <summary>
        /// 第一学历时间
        /// </summary>
        /// <returns></returns>
        public string firstxuelidate { get; set; }
        /// <summary>
        /// 最高学历
        /// </summary>
        /// <returns></returns>
        public string lastxueli { get; set; }
        /// <summary>
        /// 最高学历毕业于
        /// </summary>
        /// <returns></returns>
        public string lastxlgradufrom { get; set; }
        /// <summary>
        /// 最高学历时间
        /// </summary>
        /// <returns></returns>
        public string lastxldate { get; set; }
        /// <summary>
        /// 取得职称日期
        /// </summary>
        /// <returns></returns>
        public string TechTitledate { get; set; }
        /// <summary>
        /// 职称聘用日期
        /// </summary>
        /// <returns></returns>
        public string TechTitleUsedate { get; set; }
        /// <summary>
        /// 婚否
        /// </summary>
        /// <returns></returns>
        public string MarryMark { get; set; }
        /// <summary>
        /// 家庭成员
        /// </summary>
        /// <returns></returns>
        public string FamilyMembers { get; set; }
        /// <summary>
        /// 简历
        /// </summary>
        /// <returns></returns>
        public string Resume { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 录入日期
        /// </summary>
        /// <returns></returns>
        public DateTime? InputDate { get; set; }
        /// <summary>
        /// 是否任教
        /// </summary>
        /// <returns></returns>
        public string TeachMark { get; set; }
        /// <summary>
        /// 教师类型
        /// </summary>
        /// <returns></returns>
        public string TeacherSort { get; set; }
        /// <summary>
        /// 一卡通号
        /// </summary>
        /// <returns></returns>
        public string ykthao { get; set; }
        /// <summary>
        /// 一卡通账号
        /// </summary>
        /// <returns></returns>
        public string yktzhao { get; set; }
        /// <summary>
        /// 手机小号
        /// </summary>
        /// <returns></returns>
        public string Col1 { get; set; }
        /// <summary>
        /// 备用2
        /// </summary>
        /// <returns></returns>
        public string Col2 { get; set; }
        /// <summary>
        /// 备用3
        /// </summary>
        /// <returns></returns>
        public string Col3 { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// Photo
        /// </summary>
        /// <returns></returns>
        //public string Photo { get; set; }
        /// <summary>
        /// 取得职业资格的时间
        /// </summary>
        /// <returns></returns>
        public DateTime? GetMajorDate { get; set; }
        /// <summary>
        /// 主讲课程
        /// </summary>
        /// <returns></returns>
        public string TeachingCourses { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.EmpID = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.EmpID = 0;// keyValue;
                                    
        }
        #endregion
    }
}