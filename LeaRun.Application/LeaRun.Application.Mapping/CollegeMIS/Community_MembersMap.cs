using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:41
    /// 描 述：社团会员表
    /// </summary>
    public class Community_MembersMap : EntityTypeConfiguration<Community_MembersEntity>
    {
        public Community_MembersMap()
        {
            #region 表、主键
            //表
            this.ToTable("Community_Members");
            //主键
            this.HasKey(t => t.CM_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
