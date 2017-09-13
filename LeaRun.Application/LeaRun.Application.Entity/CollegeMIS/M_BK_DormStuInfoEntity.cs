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
    public class M_BK_DormStuInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string StuName { get; set; }
       
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        
        
        /// <summary>
        /// ͷ��ͼƬ
        /// </summary>
        /// <returns></returns>
        [Column("HEADIMG")]
        public string HeadImg { get; set; }

        /// <summary>
        /// ��Դ������
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENO")]
        public string ProvinceNo { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("NATIONALITYNO")]
        public string NationalityNo { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }

        #endregion

    }
}