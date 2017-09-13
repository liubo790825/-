using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 11:13
    /// �� ����InfoLesson
    /// </summary>
    public class InfoLessonEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public int? LessonId { get; set; }
        /// <summary>
        /// �γ̺�
        /// </summary>
        /// <returns></returns>
        public string LessonNo { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        public string LessonName { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public Decimal ? Xuefen { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <returns></returns>
        public string IsContinuity { get; set; }
        /// <summary>
        /// ÿ��������
        /// </summary>
        /// <returns></returns>
        public int? MaxPerDay { get; set; }
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
        public int? WeekHours { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ShortName { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// �γ�����
        /// </summary>
        /// <returns></returns>
        public string LessonType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string TestType { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.LessonId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.LessonId = keyValue;
                                    
        }
        #endregion
    }
}