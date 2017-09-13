using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-05 11:34
    /// 描 述：InfoMajor
    /// </summary>
    public class InfoMajorMap : EntityTypeConfiguration<InfoMajorEntity>
    {
        public InfoMajorMap()
        {
            #region 表、主键
            //表
            this.ToTable("InfoMajor");
            //主键
            this.HasKey(t => t.MajorId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
