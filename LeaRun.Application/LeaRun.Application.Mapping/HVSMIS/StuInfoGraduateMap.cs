using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-12 11:41
    /// 描 述：毕业生基本信息
    /// </summary>
    public class StuInfoGraduateMap : EntityTypeConfiguration<StuInfoGraduateEntity>
    {
        public StuInfoGraduateMap()
        {
            #region 表、主键
            //表
            this.ToTable("StuInfoGraduate");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
