using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:33
    /// 描 述：社团基本信息表
    /// </summary>
    public class Community_infoMap : EntityTypeConfiguration<Community_infoEntity>
    {
        public Community_infoMap()
        {
            #region 表、主键
            //表
            this.ToTable("Community_info");
            //主键
            this.HasKey(t => t.C_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
