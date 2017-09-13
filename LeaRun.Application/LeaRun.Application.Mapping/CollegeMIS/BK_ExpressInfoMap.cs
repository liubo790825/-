using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 14:05
    /// 描 述：通知书快递信息
    /// </summary>
    public class BK_ExpressInfoMap : EntityTypeConfiguration<BK_ExpressInfoEntity>
    {
        public BK_ExpressInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_ExpressInfo");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
