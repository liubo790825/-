using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:03
    /// �� ����רҵ
    /// </summary>
    public class BK_MajorDetailMap : EntityTypeConfiguration<BK_MajorDetailEntity>
    {
        public BK_MajorDetailMap()
        {
            #region ������
            //��
            this.ToTable("BK_MajorDetail");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
