using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-30 12:15
    /// �� ����BK_DormItemRepair
    /// </summary>
    public class BK_DormItemRepairMap : EntityTypeConfiguration<BK_DormItemRepairEntity>
    {
        public BK_DormItemRepairMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormItemRepair");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
