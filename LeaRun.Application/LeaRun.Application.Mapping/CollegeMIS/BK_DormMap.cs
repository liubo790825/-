using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public class BK_DormMap : EntityTypeConfiguration<BK_DormEntity>
    {
        public BK_DormMap()
        {
            #region ������
            //��
            this.ToTable("BK_Dorm");
            //����
            this.HasKey(t => t.DormId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
