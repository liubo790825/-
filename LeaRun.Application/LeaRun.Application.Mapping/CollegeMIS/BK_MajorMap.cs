using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:57
    /// �� ����ϵ��
    /// </summary>
    public class BK_MajorMap : EntityTypeConfiguration<BK_MajorEntity>
    {
        public BK_MajorMap()
        {
            #region ������
            //��
            this.ToTable("BK_Major");
            //����
            this.HasKey(t => t.MajorId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
