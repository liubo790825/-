using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-08 15:14
    /// 描 述：SupplierCheckBooks
    /// </summary>
    public class SupplierCheckBooksMap : EntityTypeConfiguration<SupplierCheckBooksEntity>
    {
        public SupplierCheckBooksMap()
        {
            #region 表、主键
            //表
            this.ToTable("vwSupplierCheckBooks");
            //主键
            this.HasKey(t => t.checkNo);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
