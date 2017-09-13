using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-05 11:34
    /// �� ����InfoMajor
    /// </summary>
    public class InfoMajorEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// MajorId
        /// </summary>
        /// <returns></returns>
        public int? MajorId { get; set; }
        /// <summary>
        /// MajorCode
        /// </summary>
        /// <returns></returns>
        public string MajorCode { get; set; }
        /// <summary>
        /// MajorName
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// LengthOfSchooling
        /// </summary>
        /// <returns></returns>
        public int? LengthOfSchooling { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.MajorId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.MajorId = keyValue;
                                    
        }
        #endregion
    }
}