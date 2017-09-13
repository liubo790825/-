using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:21
    /// �� ����InfoTeacher
    /// </summary>
    public class InfoTeacherEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? TeacherId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string TeacherCode { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        /// <returns></returns>
        public string TeacherName { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        /// <returns></returns>
        public string TeacherType { get; set; }
        /// <summary>
        /// ����ϵ��
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string TeacherStatus { get; set; }
        /// <summary>
        /// �ó����ڿγ�
        /// </summary>
        /// <returns></returns>
        public string TeachingLesson { get; set; }
        /// <summary>
        /// ְ��
        /// </summary>
        /// <returns></returns>
        public string PerfessionalTitle { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.TeacherId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeacherId = keyValue;
                                    
        }
        #endregion
    }
}