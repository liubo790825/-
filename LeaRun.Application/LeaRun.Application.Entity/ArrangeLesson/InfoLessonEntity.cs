using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 11:13
    /// 描 述：InfoLesson
    /// </summary>
    public class InfoLessonEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        public int? LessonId { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        /// <returns></returns>
        public Decimal ? Xuefen { get; set; }
        /// <summary>
        /// 是否连上
        /// </summary>
        /// <returns></returns>
        public string IsContinuity { get; set; }
        /// <summary>
        /// 每天最大节数
        /// </summary>
        /// <returns></returns>
        public int? MaxPerDay { get; set; }
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
        /// 周学时
        /// </summary>
        /// <returns></returns>
        public int? WeekHours { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        /// <returns></returns>
        public string ShortName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// 考核类型
        /// </summary>
        /// <returns></returns>
        public string TestType { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.LessonId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.LessonId = keyValue;
                                    
        }
        #endregion
    }
}