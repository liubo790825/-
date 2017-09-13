using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:44
    /// 描 述：社团活动表
    /// </summary>
    public class Community_ActivitiesMap : EntityTypeConfiguration<Community_ActivitiesEntity>
    {
        public Community_ActivitiesMap()
        {
            #region 表、主键
            //表
            this.ToTable("Community_Activities");
            //主键
            this.HasKey(t => t.CA_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
