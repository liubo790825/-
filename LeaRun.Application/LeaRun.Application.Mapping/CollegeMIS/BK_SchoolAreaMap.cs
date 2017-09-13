using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:54
    /// 描 述：校区
    /// </summary>
    public class BK_SchoolAreaMap : EntityTypeConfiguration<BK_SchoolAreaEntity>
    {
        public BK_SchoolAreaMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_SchoolArea");
            //主键
            this.HasKey(t => t.AreaId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
