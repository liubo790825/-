using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-05 11:34
    /// �� ����InfoMajor
    /// </summary>
    public class InfoMajorMap : EntityTypeConfiguration<InfoMajorEntity>
    {
        public InfoMajorMap()
        {
            #region ������
            //��
            this.ToTable("InfoMajor");
            //����
            this.HasKey(t => t.MajorId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
