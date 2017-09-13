using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:37
    /// 描 述：社团角色
    /// </summary>
    public class Community_RolesMap : EntityTypeConfiguration<Community_RolesEntity>
    {
        public Community_RolesMap()
        {
            #region 表、主键
            //表
            this.ToTable("Community_Roles");
            //主键
            this.HasKey(t => t.CR_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
