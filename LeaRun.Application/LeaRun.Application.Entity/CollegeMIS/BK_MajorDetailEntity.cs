using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:03
    /// �� ����רҵ
    /// </summary>
    public class BK_MajorDetailEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��ʶ��
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// רҵ����      ���ã�3λ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAME")]
        public string MajorName { get; set; }
        /// <summary>
        /// רҵ����ţ���0��1��2��3��4��5��   0������רҵ����ϸ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNO")]
        public string MajorDetailNo { get; set; }
        /// <summary>
        /// רҵ������
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNAME")]
        public string MajorDetailName { get; set; }
        /// <summary>
        /// ��ίרҵ����
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNO")]
        public string GovMajorNo { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        [Column("EnableRemark")]
        public int EnableRemark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.EnableRemark = 1;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
                                    
        }
        #endregion
    }
}