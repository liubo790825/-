using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-13 05:03
    /// �� ����BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueMap : EntityTypeConfiguration<BK_BaodaoYuyueEntity>
    {
        public BK_BaodaoYuyueMap()
        {
            #region ������
            //��
            this.ToTable("BK_BaodaoYuyue");
            //����
            this.HasKey(t => t.YuyueId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
