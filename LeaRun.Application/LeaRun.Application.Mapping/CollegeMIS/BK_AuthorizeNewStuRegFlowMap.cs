using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:33
    /// �� ��������������Ȩ��
    /// </summary>
    public class BK_AuthorizeNewStuRegFlowMap : EntityTypeConfiguration<BK_AuthorizeNewStuRegFlowEntity>
    {
        public BK_AuthorizeNewStuRegFlowMap()
        {
            #region ������
            //��
            this.ToTable("BK_AuthorizeNewStuRegFlow");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
