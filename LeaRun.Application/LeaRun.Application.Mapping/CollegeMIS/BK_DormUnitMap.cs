using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:39
    /// �� �������ᵥԪ��Ϣ
    /// </summary>
    public class BK_DormUnitMap : EntityTypeConfiguration<BK_DormUnitEntity>
    {
        public BK_DormUnitMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormUnit");
            //����
            this.HasKey(t => t.DormUnitId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
