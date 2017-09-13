using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:21
    /// �� ����InfoTeacher
    /// </summary>
    public class InfoTeacherMap : EntityTypeConfiguration<InfoTeacherEntity>
    {
        public InfoTeacherMap()
        {
            #region ������
            //��
            this.ToTable("InfoTeacher");
            //����
            this.HasKey(t => t.TeacherId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
