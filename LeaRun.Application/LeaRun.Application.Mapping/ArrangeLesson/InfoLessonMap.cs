using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 11:13
    /// 描 述：InfoLesson
    /// </summary>
    public class InfoLessonMap : EntityTypeConfiguration<InfoLessonEntity>
    {
        public InfoLessonMap()
        {
            #region 表、主键
            //表
            this.ToTable("InfoLesson");
            //主键
            this.HasKey(t => t.LessonId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
