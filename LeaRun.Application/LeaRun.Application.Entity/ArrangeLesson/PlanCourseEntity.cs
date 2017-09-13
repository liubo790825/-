using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:23
    /// �� ����TeachingPlan
    /// </summary>
    public class PlanCourseEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("PLANCOURSEID")]
        public int? PlanCourseId { get; set; }
        /// <summary>
        /// �γ̺�
        /// </summary>
        /// <returns></returns>
        [Column("COURSECODE")]
        public string CourseCode { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        [Column("COURSENAME")]
        public string CourseName { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        [Column("COURSEPROPERTY")]
        public string CourseProperty { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        [Column("COURSETYPE")]
        public string CourseType { get; set; }
        /// <summary>
        /// �ڿ�ϵ��
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGDEPT")]
        public string TeachingDept { get; set; }
        /// <summary>
        /// ��ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("TOTALCREDITS")]
        public int? TotalCredits { get; set; }
        /// <summary>
        /// ��ѧʱ
        /// </summary>
        /// <returns></returns>
        [Column("TOTALHOURS")]
        public int? TotalHours { get; set; }
        /// <summary>
        /// ��ѧʱ
        /// </summary>
        /// <returns></returns>
        [Column("WEEKHOURS")]
        public int? WeekHours { get; set; }
        /// <summary>
        /// �ڼ�ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("SEMESTER")]
        public int? Semester { get; set; }
        /// <summary>
        /// �ο���
        /// </summary>
        /// <returns></returns>
        [Column("REFERENCEBOOK")]
        public string ReferenceBook { get; set; }
        /// <summary>
        /// ��ѧ�ƻ����
        /// </summary>
        /// <returns></returns>
        [Column("TEACHINGPLANCODE")]
        public string TeachingPlanCode { get; set; }
        /// <summary>
        /// ����ѧʱ
        /// </summary>
        /// <returns></returns>
        [Column("THEORYHOURS")]
        public int? TheoryHours { get; set; }
        /// <summary>
        /// ʵ��ѧʱ
        /// </summary>
        /// <returns></returns>
        [Column("PRACTICEHOURS")]
        public int? PracticeHours { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string Status { get; set; }
        /// <summary>
        /// ���˷�ʽ
        /// </summary>
        /// <returns></returns>
        [Column("TESTTYPE")]
        public string TestType { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("SHORTNAME")]
        public string ShortName { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("XUEFEN")]
        public Decimal? Xuefen { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.PlanCourseId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlanCourseId = keyValue;
                                    
        }
        #endregion
    }
}