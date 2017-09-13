using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 14:21
    /// 描 述：InfoTeacher
    /// </summary>
    public class InfoTeacherMap : EntityTypeConfiguration<InfoTeacherEntity>
    {
        public InfoTeacherMap()
        {
            #region 表、主键
            //表
            this.ToTable("InfoTeacher");
            //主键
            this.HasKey(t => t.TeacherId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
