using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 15:06
    /// �� �����ۺ��������ݱ�
    /// </summary>
    public class BK_OverallQualityMap : EntityTypeConfiguration<BK_OverallQualityEntity>
    {
        public BK_OverallQualityMap()
        {
            #region ������
            //��
            this.ToTable("BK_OverallQuality");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
