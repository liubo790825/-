using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-02 13:54
    /// �� ����BK_Advisory
    /// </summary>
    public class BK_AdvisoryEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string QAId { get; set; }
        /// <summary>
        /// ѧ����ϢID
        /// </summary>
        /// <returns></returns>
        public string stuInfoId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Questions { get; set; }
        /// <summary>
        /// �ش�
        /// </summary>
        /// <returns></returns>
        public string Answer { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string QAOther1 { get; set; }
        /// <summary>
        /// QAOther2
        /// </summary>
        /// <returns></returns>
        public string QAOther2 { get; set; }
        /// <summary>
        /// QAOther3
        /// </summary>
        /// <returns></returns>
        public string QAOther3 { get; set; }
        /// <summary>
        /// QAOther4
        /// </summary>
        /// <returns></returns>
        public string QAOther4 { get; set; }
        /// <summary>
        /// �ش�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Atime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Qtime { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.QAId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.QAId = keyValue;
                                    
        }
        #endregion
    }
}