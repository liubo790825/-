using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 16:20
    /// �� ����ѧ���ۺ����ʼ�¼��
    /// </summary>
    public class BK_StuQualityScoreMap : EntityTypeConfiguration<BK_StuQualityScoreEntity>
    {
        public BK_StuQualityScoreMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuQualityScore");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
