using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 15:59
    /// �� ������λ��Ϣ
    /// </summary>
    public class BK_DormBedMap : EntityTypeConfiguration<BK_DormBedEntity>
    {
        public BK_DormBedMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormBed");
            //����
            this.HasKey(t => t.BedId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
