using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:07
    /// �� ����������
    /// </summary>
    public class BK_StuClassEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("STUCLASSID")]
        public string StuClassId { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        /// <returns></returns>
        [Column("CLASSID")]
        public string ClassId { get; set; }
        /// <summary>
        /// ѧ�����
        /// </summary>
        /// <returns></returns>
        [Column("STUINFOID")]
        public string stuInfoId { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.StuClassId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.StuClassId = keyValue;
                                    
        }
        #endregion
    }
}