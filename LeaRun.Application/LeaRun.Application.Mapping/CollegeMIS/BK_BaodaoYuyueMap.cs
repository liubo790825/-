using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-13 05:03
    /// 描 述：BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueMap : EntityTypeConfiguration<BK_BaodaoYuyueEntity>
    {
        public BK_BaodaoYuyueMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_BaodaoYuyue");
            //主键
            this.HasKey(t => t.YuyueId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
