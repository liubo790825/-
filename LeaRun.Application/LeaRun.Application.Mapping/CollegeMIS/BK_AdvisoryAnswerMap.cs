using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-09 15:29
    /// �� ����BK_AdvisoryAnswer
    /// </summary>
    public class BK_AdvisoryAnswerMap : EntityTypeConfiguration<BK_AdvisoryAnswerEntity>
    {
        public BK_AdvisoryAnswerMap()
        {
            #region ������
            //��
            this.ToTable("BK_AdvisoryAnswer");
            //����
            this.HasKey(t => t.AId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
