using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:21
    /// 描 述：InfoTeacher
    /// </summary>
    public class InfoTeacherEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? TeacherId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        public string TeacherCode { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        /// <returns></returns>
        public string TeacherName { get; set; }
        /// <summary>
        /// 教师类型
        /// </summary>
        /// <returns></returns>
        public string TeacherType { get; set; }
        /// <summary>
        /// 所属系部
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string TeacherStatus { get; set; }
        /// <summary>
        /// 擅长教授课程
        /// </summary>
        /// <returns></returns>
        public string TeachingLesson { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        /// <returns></returns>
        public string PerfessionalTitle { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.TeacherId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeacherId = keyValue;
                                    
        }
        #endregion
    }
}