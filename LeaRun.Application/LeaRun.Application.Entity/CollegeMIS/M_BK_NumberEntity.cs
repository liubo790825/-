using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;



namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class M_BK_NumberEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��¼��
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string number { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string StuName { get; set; }

        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string MajorName { get; set; }

        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string ClassName { get; set; }


        #endregion

    }
}