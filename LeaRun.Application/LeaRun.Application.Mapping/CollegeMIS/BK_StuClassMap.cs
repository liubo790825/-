using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:07
    /// �� ����������
    /// </summary>
    public class BK_StuClassMap : EntityTypeConfiguration<BK_StuClassEntity>
    {
        public BK_StuClassMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuClass");
            //����
            this.HasKey(t => t.StuClassId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
