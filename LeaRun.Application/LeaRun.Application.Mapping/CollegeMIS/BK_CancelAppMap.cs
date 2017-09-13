using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-18 15:12
    /// 描 述：撤消申请记录
    /// </summary>
    public class BK_CancelAppMap : EntityTypeConfiguration<BK_CancelAppEntity>
    {
        public BK_CancelAppMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_CancelApp");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
