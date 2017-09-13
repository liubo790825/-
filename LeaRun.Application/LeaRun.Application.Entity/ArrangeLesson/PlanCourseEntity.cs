using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 15:23
    /// 描 述：TeachingPlan
    /// </summary>
    public class PlanCourseEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PLANCOURSEID")]
        public int? PlanCourseId { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        /// <returns></returns>
        [Column("COURSECODE")]
        public string CourseCode { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        /// <returns></returns>
        [Column("COURSENAME")]
        public string CourseName { get; set; }
        /// <summary>
        /// 课程属性
        /// </summary>
        /// <returns></returns>
        [Column("COURSEPROPERTY")]
        public string CourseProperty { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        /// <returns></returns>
        [Column("COURSETYPE")]
        public string CourseType { get; set; }
        /// <summary>
        /// 授课系部
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGDEPT")]
        public string TeachingDept { get; set; }
        /// <summary>
        /// 总学分
        /// </summary>
        /// <returns></returns>
        [Column("TOTALCREDITS")]
        public int? TotalCredits { get; set; }
        /// <summary>
        /// 总学时
        /// </summary>
        /// <returns></returns>
        [Column("TOTALHOURS")]
        public int? TotalHours { get; set; }
        /// <summary>
        /// 周学时
        /// </summary>
        /// <returns></returns>
        [Column("WEEKHOURS")]
        public int? WeekHours { get; set; }
        /// <summary>
        /// 第几学期
        /// </summary>
        /// <returns></returns>
        [Column("SEMESTER")]
        public int? Semester { get; set; }
        /// <summary>
        /// 参考书
        /// </summary>
        /// <returns></returns>
        [Column("REFERENCEBOOK")]
        public string ReferenceBook { get; set; }
        /// <summary>
        /// 教学计划编号
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANCODE")]
        public string TeachingPlanCode { get; set; }
        /// <summary>
        /// 理论学时
        /// </summary>
        /// <returns></returns>
        [Column("THEORYHOURS")]
        public int? TheoryHours { get; set; }
        /// <summary>
        /// 实践学时
        /// </summary>
        /// <returns></returns>
        [Column("PRACTICEHOURS")]
        public int? PracticeHours { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string Status { get; set; }
        /// <summary>
        /// 考核方式
        /// </summary>
        /// <returns></returns>
        [Column("TESTTYPE")]
        public string TestType { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        /// <returns></returns>
        [Column("SHORTNAME")]
        public string ShortName { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        /// <returns></returns>
        [Column("XUEFEN")]
        public Decimal? Xuefen { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.PlanCourseId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlanCourseId = keyValue;
                                    
        }
        #endregion
    }
}