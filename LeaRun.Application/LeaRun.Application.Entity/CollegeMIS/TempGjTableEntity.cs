using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-11-28 15:57
    /// �� ����TempGjTable
    /// </summary>
    public class TempGjTableEntity : BaseEntity
    {
        #region ʵ���Ա

        /// <summary>
        /// id��
        /// </summary>
        public int Rowid { get; set; }

        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public int? StuCount { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            //this.TeachBookId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
           // this.TeachBookId = keyValue;
                                    
        }
        #endregion
    }
}