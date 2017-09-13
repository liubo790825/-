using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:03
    /// 描 述：专业
    /// </summary>
    public class BK_MajorDetailMap : EntityTypeConfiguration<BK_MajorDetailEntity>
    {
        public BK_MajorDetailMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_MajorDetail");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
