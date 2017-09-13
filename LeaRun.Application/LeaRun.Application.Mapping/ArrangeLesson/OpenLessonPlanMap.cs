using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:59
    /// �� ����OpenLessonPlan
    /// </summary>
    public class OpenLessonPlanMap : EntityTypeConfiguration<OpenLessonPlanEntity>
    {
        public OpenLessonPlanMap()
        {
            #region ������
            //��
            this.ToTable("OpenLessonPlan");
            //����
            this.HasKey(t => t.PlanId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
