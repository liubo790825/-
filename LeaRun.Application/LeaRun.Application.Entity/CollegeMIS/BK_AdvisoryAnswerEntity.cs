using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-09 15:29
    /// �� ����BK_AdvisoryAnswer
    /// </summary>
    public class BK_AdvisoryAnswerEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string AId { get; set; }
        /// <summary>
        /// ѧ����ϢID
        /// </summary>
        /// <returns></returns>
        public string stuInfoId { get; set; }
        /// <summary>
        /// �ظ�
        /// </summary>
        /// <returns></returns>
        public string Answer { get; set; }
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? Atime { get; set; }
        /// <summary>
        /// QAOther1
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
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.AId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AId = keyValue;
                                    
        }
        #endregion
    }
}