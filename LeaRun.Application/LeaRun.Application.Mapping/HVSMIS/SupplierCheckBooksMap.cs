using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 15:14
    /// �� ����SupplierCheckBooks
    /// </summary>
    public class SupplierCheckBooksMap : EntityTypeConfiguration<SupplierCheckBooksEntity>
    {
        public SupplierCheckBooksMap()
        {
            #region ������
            //��
            this.ToTable("vwSupplierCheckBooks");
            //����
            this.HasKey(t => t.checkNo);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
