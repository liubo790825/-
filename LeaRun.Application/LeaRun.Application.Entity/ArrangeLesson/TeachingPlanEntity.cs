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
    public class TeachingPlanEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANID")]
        public int? TeachingPlanId { get; set; }
        /// <summary>
        /// 计划编号
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANCODE")]
        public string TeachingPlanCode { get; set; }
        /// <summary>
        /// 计划名称
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANNAME")]
        public string TeachingPlanName { get; set; }
        /// <summary>
        /// 学院
        /// </summary>
        /// <returns></returns>
        [Column("COLLEGE")]
        public string College { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        [Column("MAJOR")]
        public string Major { get; set; }
        /// <summary>
        /// 第几学期
        /// </summary>
        /// <returns></returns>
        [Column("SEMESTER")]
        public int? Semester { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// 学年
        /// </summary>
        /// <returns></returns>
        [Column("XUENIAN")]
        public string Xuenian { get; set; }
        /// <summary>
        /// 学期
        /// </summary>
        /// <returns></returns>
        [Column("XUEQI")]
        public string Xueqi { get; set; }
        /// <summary>
        /// 标志
        /// </summary>
        /// <returns></returns>
        [Column("TPMARK")]
        public string TpMark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string Status { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.TeachingPlanId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeachingPlanId = keyValue;
                                    
        }
        #endregion
    }
}