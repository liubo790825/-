using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:59
    /// 描 述：OpenLessonPlan
    /// </summary>
    public class OpenLessonPlanEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? PlanId { get; set; }
        /// <summary>
        /// 学院
        /// </summary>
        /// <returns></returns>
        public string College { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// 班级号
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// 教师号
        /// </summary>
        /// <returns></returns>
        public string TeacherCode { get; set; }
        /// <summary>
        /// 周课时
        /// </summary>
        /// <returns></returns>
        public int? WeekHours { get; set; }
        /// <summary>
        /// WeekForm
        /// </summary>
        /// <returns></returns>
        public string WeekForm { get; set; }
        /// <summary>
        /// 单双周
        /// </summary>
        /// <returns></returns>
        public string DanShuangZhou { get; set; }
        /// <summary>
        /// 授课地点
        /// </summary>
        /// <returns></returns>
        public string DefaultPlace { get; set; }
        /// <summary>
        /// 学生数
        /// </summary>
        /// <returns></returns>
        public int? StuNum { get; set; }
        /// <summary>
        /// 合班号
        /// </summary>
        /// <returns></returns>
        public string HeBanHao { get; set; }
        /// <summary>
        /// HeBanMing
        /// </summary>
        /// <returns></returns>
        public string HeBanMing { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// 上课单位
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>
        /// <returns></returns>
        public string TeacherName { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        /// <returns></returns>
        public int? Credits { get; set; }
        /// <summary>
        /// 理论学时
        /// </summary>
        /// <returns></returns>
        public int? TheoryHours { get; set; }
        /// <summary>
        /// 实践学时
        /// </summary>
        /// <returns></returns>
        public int? PracticeHours { get; set; }
        /// <summary>
        /// 教学方式
        /// </summary>
        /// <returns></returns>
        public string TeachingType { get; set; }
        /// <summary>
        /// 场地类型
        /// </summary>
        /// <returns></returns>
        public string PlaceType { get; set; }
        /// <summary>
        /// 校区
        /// </summary>
        /// <returns></returns>
        public string Campus { get; set; }
        /// <summary>
        /// 连上节数
        /// </summary>
        /// <returns></returns>
        public int? ContinueLessons { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        /// <returns></returns>
        public int? Priority { get; set; }
        /// <summary>
        /// 教室名
        /// </summary>
        /// <returns></returns>
        public string PlaceName { get; set; }
        /// <summary>
        /// 教室号
        /// </summary>
        /// <returns></returns>
        public string PlaceNo { get; set; }
        /// <summary>
        /// 第几学期
        /// </summary>
        /// <returns></returns>
        public int? Semester { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// 已排课时
        /// </summary>
        /// <returns></returns>
        public int? ArrangedHours { get; set; }
        /// <summary>
        /// 剩余课时
        /// </summary>
        /// <returns></returns>
        public int? LeftHours { get; set; }
        /// <summary>
        /// 学年
        /// </summary>
        /// <returns></returns>
        public string Xuenian { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        /// <returns></returns>
        public string Xueqi { get; set; }
        /// <summary>
        /// 状态（标识删除）
        /// </summary>
        /// <returns></returns>
        public string OpMark { get; set; }
        /// <summary>
        /// 是否合班
        /// </summary>
        /// <returns></returns>
        public bool? IsHeban { get; set; }

        /// <summary>
        /// HVS库的TbBasicInfo教材ID号
        /// </summary>
        public int? TeachBookId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.PlanId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlanId = keyValue;
                                    
        }
        #endregion
    }
}