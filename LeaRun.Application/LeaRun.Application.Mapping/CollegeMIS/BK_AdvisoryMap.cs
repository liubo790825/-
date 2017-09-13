using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-02 13:54
    /// 描 述：BK_Advisory
    /// </summary>
    public class BK_AdvisoryMap : EntityTypeConfiguration<BK_AdvisoryEntity>
    {
        public BK_AdvisoryMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_Advisory");
            //主键
            this.HasKey(t => t.QAId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
