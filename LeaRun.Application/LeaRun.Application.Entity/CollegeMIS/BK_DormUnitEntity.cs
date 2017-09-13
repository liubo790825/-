using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:39
    /// �� �������ᵥԪ��Ϣ
    /// </summary>
    public class BK_DormUnitEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
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
        /// ��Ԫ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITNAME")]
        public string DormUnitName { get; set; }
        /// <summary>
        /// ��Ԫ���
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITNO")]
        public string DormUnitNo { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITMANAGER")]
        public string DormUnitManager { get; set; }
        /// <summary>
        /// ��Ԫ���ͣ�����������Ů������ЩѧУ���ﲻ��
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITTYPE")]
        public string DormUnitType { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER")]
        public string DormUnitOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER1")]
        public string DormUnitOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER2")]
        public string DormUnitOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER3")]
        public string DormUnitOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER4")]
        public string DormUnitOther4 { get; set; }

        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
                this.DormUnitId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�            
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormUnitId = keyValue;
                                    
        }
        #endregion
    }
}