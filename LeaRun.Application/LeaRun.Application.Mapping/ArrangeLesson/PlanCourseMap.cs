using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:23
    /// �� ����TeachingPlan
    /// </summary>
    public class PlanCourseMap : EntityTypeConfiguration<PlanCourseEntity>
    {
        public PlanCourseMap()
        {
            #region ������
            //��
            this.ToTable("PlanCourse");
            //����
            this.HasKey(t => t.PlanCourseId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
