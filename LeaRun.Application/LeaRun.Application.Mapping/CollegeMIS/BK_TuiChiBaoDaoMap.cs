using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-03 09:59
    /// �� ����BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoMap : EntityTypeConfiguration<BK_TuiChiBaoDaoEntity>
    {
        public BK_TuiChiBaoDaoMap()
        {
            #region ������
            //��
            this.ToTable("BK_TuiChiBaoDao");
            //����
            this.HasKey(t => t.TuiChiId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
