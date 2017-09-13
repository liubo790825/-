using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-01-20 23:21
    /// �� ����У�ѻ
    /// </summary>
    public class Alumni_EventsEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID��
        /// </summary>
        /// <returns></returns>
        public string AE_Id { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string AE_Title { get; set; }
        /// <summary>
        /// ���ϸ����
        /// </summary>
        /// <returns></returns>
        public string AE_Content { get; set; }
        /// <summary>
        /// ���ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? AE_BeginDate { get; set; }
        /// <summary>
        /// AE_Other
        /// </summary>
        /// <returns></returns>
        public string AE_Other { get; set; }
        /// <summary>
        /// AE_Other1
        /// </summary>
        /// <returns></returns>
        public string AE_Other1 { get; set; }
        /// <summary>
        /// AE_Other2
        /// </summary>
        /// <returns></returns>
        public string AE_Other2 { get; set; }
        /// <summary>
        /// AE_Other3
        /// </summary>
        /// <returns></returns>
        public string AE_Other3 { get; set; }
        /// <summary>
        /// AE_Other4
        /// </summary>
        /// <returns></returns>
        public string AE_Other4 { get; set; }
        /// <summary>
        /// AE_Other5
        /// </summary>
        /// <returns></returns>
        public string AE_Other5 { get; set; }
        /// <summary>
        /// AE_Other6
        /// </summary>
        /// <returns></returns>
        public string AE_Other6 { get; set; }
        /// <summary>
        /// AE_Other7
        /// </summary>
        /// <returns></returns>
        public string AE_Other7 { get; set; }
        /// <summary>
        /// AE_Other8
        /// </summary>
        /// <returns></returns>
        public string AE_Other8 { get; set; }
        /// <summary>
        /// AE_Other9
        /// </summary>
        /// <returns></returns>
        public string AE_Other9 { get; set; }
        /// <summary>
        /// AE_Other10
        /// </summary>
        /// <returns></returns>
        public string AE_Other10 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.AE_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AE_Id = keyValue;
                                    
        }
        #endregion
    }
}