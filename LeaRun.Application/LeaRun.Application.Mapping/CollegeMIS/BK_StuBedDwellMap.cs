using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-28 09:28
    /// �� ����ѧ����ס��λ��¼
    /// </summary>
    public class BK_StuBedDwellMap : EntityTypeConfiguration<BK_StuBedDwellEntity>
    {
        public BK_StuBedDwellMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuBedDwell");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
