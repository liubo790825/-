using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:28
    /// �� ���������������̱�
    /// </summary>
    public class BK_NewStuRegFlowMap : EntityTypeConfiguration<BK_NewStuRegFlowEntity>
    {
        public BK_NewStuRegFlowMap()
        {
            #region ������
            //��
            this.ToTable("BK_NewStuRegFlow");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
