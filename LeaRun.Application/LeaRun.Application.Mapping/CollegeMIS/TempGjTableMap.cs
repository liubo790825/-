using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-11-28 15:57
    /// 描 述：TempGjTable
    /// </summary>
    public class TempGjTableMap : EntityTypeConfiguration<TempGjTableEntity>
    {
        public TempGjTableMap()
        {
            #region 表、主键
            //表
            this.ToTable("vwStuGJTable");
            //主键
            this.HasKey(t => t.Rowid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
