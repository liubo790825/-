using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:37
    /// �� ��������¥����Ϣ
    /// </summary>
    public class BK_DormFloorsEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSID")]
        public string DormFloorsId { get; set; }
        /// <summary>
        /// ��Ԫ���
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITID")]
        public string DormUnitId { get; set; }
        /// <summary>
        /// ����¥ID��
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGID")]
        public string DormBuildingId { get; set; }
        /// <summary>
        /// ����¥������
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSNAME")]
        public string DormFloorsName { get; set; }
        /// <summary>
        /// ����¥����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSNO")]
        public string DormFloorsNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSMANAGER")]
        public string DormFloorsManager { get; set; }
        /// <summary>
        /// ���ͣ�����������Ů��
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSTYPE")]
        public string DormFloorsType { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER")]
        public string DormFloorsOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER1")]
        public string DormFloorsOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER2")]
        public string DormFloorsOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER3")]
        public string DormFloorsOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER4")]
        public string DormFloorsOther4 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.DormFloorsId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormFloorsId = keyValue;
                                    
        }
        #endregion
    }
}