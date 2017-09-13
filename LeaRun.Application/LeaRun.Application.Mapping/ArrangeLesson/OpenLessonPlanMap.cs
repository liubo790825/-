using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:59
    /// 描 述：OpenLessonPlan
    /// </summary>
    public class OpenLessonPlanMap : EntityTypeConfiguration<OpenLessonPlanEntity>
    {
        public OpenLessonPlanMap()
        {
            #region 表、主键
            //表
            this.ToTable("OpenLessonPlan");
            //主键
            this.HasKey(t => t.PlanId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
