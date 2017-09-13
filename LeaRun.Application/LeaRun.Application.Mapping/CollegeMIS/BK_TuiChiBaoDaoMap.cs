using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-03 09:59
    /// 描 述：BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoMap : EntityTypeConfiguration<BK_TuiChiBaoDaoEntity>
    {
        public BK_TuiChiBaoDaoMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_TuiChiBaoDao");
            //主键
            this.HasKey(t => t.TuiChiId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
