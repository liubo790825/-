using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:41
    /// �� ��������¥��Ϣ
    /// </summary>
    public class BK_DormBuildingMap : EntityTypeConfiguration<BK_DormBuildingEntity>
    {
        public BK_DormBuildingMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormBuilding");
            //����
            this.HasKey(t => t.DormBuildingId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
