using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 11:13
    /// �� ����InfoLesson
    /// </summary>
    public class InfoLessonMap : EntityTypeConfiguration<InfoLessonEntity>
    {
        public InfoLessonMap()
        {
            #region ������
            //��
            this.ToTable("InfoLesson");
            //����
            this.HasKey(t => t.LessonId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
