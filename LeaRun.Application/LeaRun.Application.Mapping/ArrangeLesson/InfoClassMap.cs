using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 15:36
    /// 描 述：InfoClass
    /// </summary>
    public class InfoClassMap : EntityTypeConfiguration<InfoClassEntity>
    {
        public InfoClassMap()
        {
            #region 表、主键
            //表
            this.ToTable("InfoClass");
            //主键
            this.HasKey(t => t.ClassId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
