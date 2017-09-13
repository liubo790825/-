using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 23:13
    /// 描 述：CommunityActiv
    /// </summary>
    public class CommunityActivMap : EntityTypeConfiguration<CommunityActivEntity>
    {
        public CommunityActivMap()
        {
            #region 表、主键
            //表
            this.ToTable("vwCommunityActiv");
            //主键
            this.HasKey(t => t.CA_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
