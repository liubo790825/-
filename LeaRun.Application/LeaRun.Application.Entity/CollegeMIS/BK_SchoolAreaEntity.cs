using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:54
    /// �� ����У��
    /// </summary>
    public class BK_SchoolAreaEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// У��ID
        /// </summary>
        /// <returns></returns>
        [Column("AREAID")]
        public string AreaId { get; set; }
        /// <summary>
        /// У������
        /// </summary>
        /// <returns></returns>
        [Column("AREANAME")]
        public string AreaName { get; set; }
        /// <summary>
        /// У����ַ
        /// </summary>
        /// <returns></returns>
        [Column("AREAADDRESS")]
        public string AreaAddress { get; set; }
        /// <summary>
        /// ��˱�־
        /// </summary>
        /// <returns></returns>
        [Column("CHECKMARK")]
        public string CheckMark { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        /// <returns></returns>
        [Column("ENABLEMRAK")]
        public int? EnableMrak { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.AreaId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.EnableMrak = 1;                  
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AreaId = keyValue;
                                    
        }
        #endregion
    }
}