using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-11-28 15:57
    /// �� ����TempGjTable
    /// </summary>
    public class TempGjTableMap : EntityTypeConfiguration<TempGjTableEntity>
    {
        public TempGjTableMap()
        {
            #region ������
            //��
            this.ToTable("vwStuGJTable");
            //����
            this.HasKey(t => t.Rowid);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
