using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:42
    /// �� ����TrainingPlan
    /// </summary>
    public class TrainingPlanMap : EntityTypeConfiguration<TrainingPlanEntity>
    {
        public TrainingPlanMap()
        {
            #region ������
            //��
            this.ToTable("TrainingPlan");
            //����
            this.HasKey(t => t.TrainingPlanId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
