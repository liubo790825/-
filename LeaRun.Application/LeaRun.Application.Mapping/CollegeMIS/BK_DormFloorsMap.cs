using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:37
    /// �� ��������¥����Ϣ
    /// </summary>
    public class BK_DormFloorsMap : EntityTypeConfiguration<BK_DormFloorsEntity>
    {
        public BK_DormFloorsMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormFloors");
            //����
            this.HasKey(t => t.DormFloorsId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
