using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:35
    /// �� ������¼��������
    /// </summary>
    public class BK_StuPassFlowMap : EntityTypeConfiguration<BK_StuPassFlowEntity>
    {
        public BK_StuPassFlowMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuPassFlow");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
