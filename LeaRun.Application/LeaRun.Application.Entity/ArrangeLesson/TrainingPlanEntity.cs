using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:42
    /// 描 述：TrainingPlan
    /// </summary>
    public class TrainingPlanEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? TrainingPlanId { get; set; }
        /// <summary>
        /// 方案编号
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanCode { get; set; }
        /// <summary>
        /// 方案名称
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanName { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanIntro { get; set; }
        /// <summary>
        /// 学院
        /// </summary>
        /// <returns></returns>
        public string College { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        public string Major { get; set; }
        /// <summary>
        /// 第几学期
        /// </summary>
        /// <returns></returns>
        public int? Semester { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// 课程名
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// 考核方式
        /// </summary>
        /// <returns></returns>
        public string TestType { get; set; }
        /// <summary>
        /// 周理论学时
        /// </summary>
        /// <returns></returns>
        public int? WeekTheoryHours { get; set; }
        /// <summary>
        /// 周实践学时
        /// </summary>
        /// <returns></returns>
        public int? WeekPracticeHourse { get; set; }
        /// <summary>
        /// 理论学时
        /// </summary>
        /// <returns></returns>
        public int? TheoryHours { get; set; }
        /// <summary>
        /// 实践学时
        /// </summary>
        /// <returns></returns>
        public int? PracticeHourse { get; set; }
        /// <summary>
        /// 总学时
        /// </summary>
        /// <returns></returns>
        public int? TotalHours { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        /// <returns></returns>
        public Decimal? Xuefen { get; set; }

        /// <summary>
        /// 周数
        /// </summary>
        public int? WeekTotal { get; set; }

        /// <summary>
        /// 周学时
        /// </summary>
        public int? EveryWeekStudyTimes { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.TrainingPlanId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TrainingPlanId = keyValue;
                                    
        }
        #endregion
    }
}