using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:59
    /// �� ����OpenLessonPlan
    /// </summary>
    public class OpenLessonPlanEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? PlanId { get; set; }
        /// <summary>
        /// ѧԺ
        /// </summary>
        /// <returns></returns>
        public string College { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// �γ̺�
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// ��ʦ��
        /// </summary>
        /// <returns></returns>
        public string TeacherCode { get; set; }
        /// <summary>
        /// �ܿ�ʱ
        /// </summary>
        /// <returns></returns>
        public int? WeekHours { get; set; }
        /// <summary>
        /// WeekForm
        /// </summary>
        /// <returns></returns>
        public string WeekForm { get; set; }
        /// <summary>
        /// ��˫��
        /// </summary>
        /// <returns></returns>
        public string DanShuangZhou { get; set; }
        /// <summary>
        /// �ڿεص�
        /// </summary>
        /// <returns></returns>
        public string DefaultPlace { get; set; }
        /// <summary>
        /// ѧ����
        /// </summary>
        /// <returns></returns>
        public int? StuNum { get; set; }
        /// <summary>
        /// �ϰ��
        /// </summary>
        /// <returns></returns>
        public string HeBanHao { get; set; }
        /// <summary>
        /// HeBanMing
        /// </summary>
        /// <returns></returns>
        public string HeBanMing { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// �Ͽε�λ
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        /// <returns></returns>
        public string TeacherName { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public int? Credits { get; set; }
        /// <summary>
        /// ����ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? TheoryHours { get; set; }
        /// <summary>
        /// ʵ��ѧʱ
        /// </summary>
        /// <returns></returns>
        public int? PracticeHours { get; set; }
        /// <summary>
        /// ��ѧ��ʽ
        /// </summary>
        /// <returns></returns>
        public string TeachingType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string PlaceType { get; set; }
        /// <summary>
        /// У��
        /// </summary>
        /// <returns></returns>
        public string Campus { get; set; }
        /// <summary>
        /// ���Ͻ���
        /// </summary>
        /// <returns></returns>
        public int? ContinueLessons { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? Priority { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string PlaceName { get; set; }
        /// <summary>
        /// ���Һ�
        /// </summary>
        /// <returns></returns>
        public string PlaceNo { get; set; }
        /// <summary>
        /// �ڼ�ѧ��
        /// </summary>
        /// <returns></returns>
        public int? Semester { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// ���ſ�ʱ
        /// </summary>
        /// <returns></returns>
        public int? ArrangedHours { get; set; }
        /// <summary>
        /// ʣ���ʱ
        /// </summary>
        /// <returns></returns>
        public int? LeftHours { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string Xuenian { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string Xueqi { get; set; }
        /// <summary>
        /// ״̬����ʶɾ����
        /// </summary>
        /// <returns></returns>
        public string OpMark { get; set; }
        /// <summary>
        /// �Ƿ�ϰ�
        /// </summary>
        /// <returns></returns>
        public bool? IsHeban { get; set; }

        /// <summary>
        /// HVS���TbBasicInfo�̲�ID��
        /// </summary>
        public int? TeachBookId { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.PlanId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlanId = keyValue;
                                    
        }
        #endregion
    }
}