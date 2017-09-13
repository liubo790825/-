using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-28 09:28
    /// 描 述：学生入住床位记录
    /// </summary>
    public class BK_StuBedDwellMap : EntityTypeConfiguration<BK_StuBedDwellEntity>
    {
        public BK_StuBedDwellMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_StuBedDwell");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
