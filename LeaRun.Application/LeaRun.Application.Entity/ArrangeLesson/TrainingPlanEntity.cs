using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:42
    /// �� ����TrainingPlan
    /// </summary>
    public class TrainingPlanEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? TrainingPlanId { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanCode { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string TrainingPlanIntro { get; set; }
        /// <summary>
        /// ѧԺ
        /// </summary>
        /// <returns></returns>
        public string College { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string Major { get; set; }
        /// <summary>
        /// �ڼ�ѧ��
        /// </summary>
        /// <returns></returns>
        public int? Semester { get; set; }
        /// <summary>
        /// �γ̺�
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// �γ���
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// ���˷�ʽ
        /// </summary>
        /// <returns></returns>
        public string TestType { get; set; }
        /// <summary>
        /// ������ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? WeekTheoryHours { get; set; }
        /// <summary>
        /// ��ʵ��ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? WeekPracticeHourse { get; set; }
        /// <summary>
        /// ����ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? TheoryHours { get; set; }
        /// <summary>
        /// ʵ��ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? PracticeHourse { get; set; }
        /// <summary>
        /// ��ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? TotalHours { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public Decimal? Xuefen { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int? WeekTotal { get; set; }

        /// <summary>
        /// ��ѧʱ
        /// </summary>
        public int? EveryWeekStudyTimes { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.TrainingPlanId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TrainingPlanId = keyValue;
                                    
        }
        #endregion
    }
}