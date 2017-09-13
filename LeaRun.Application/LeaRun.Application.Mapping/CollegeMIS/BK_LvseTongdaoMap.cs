using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 10:07
    /// �� ����BK_LvseTongdao
    /// </summary>
    public class BK_LvseTongdaoMap : EntityTypeConfiguration<BK_LvseTongdaoEntity>
    {
        public BK_LvseTongdaoMap()
        {
            #region ������
            //��
            this.ToTable("BK_LvseTongdao");
            //����
            this.HasKey(t => t.LvseId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
