using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-02 13:54
    /// �� ����BK_Advisory
    /// </summary>
    public class BK_AdvisoryMap : EntityTypeConfiguration<BK_AdvisoryEntity>
    {
        public BK_AdvisoryMap()
        {
            #region ������
            //��
            this.ToTable("BK_Advisory");
            //����
            this.HasKey(t => t.QAId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
