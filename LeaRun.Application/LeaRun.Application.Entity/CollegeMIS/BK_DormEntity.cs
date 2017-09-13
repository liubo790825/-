using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public class BK_DormEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DORMID")]
        public string DormId { get; set; }
        /// <summary>
        /// ¥�����
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
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("DORMNAME")]
        public string DormName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("DORMNO")]
        public string DormNo { get; set; }
        /// <summary>
        /// ��׼
        /// </summary>
        /// <returns></returns>
        [Column("STANDARD")]
        public string standard { get; set; }
        /// <summary>
        /// �۸�
        /// </summary>
        /// <returns></returns>
        [Column("PRICE")]
        public decimal Price { get; set; }
        /// <summary>
        /// ��λ�ܺ�
        /// </summary>
        /// <returns></returns>
        [Column("BEDS")]
        public int? Beds { get; set; }
        /// <summary>
        /// �Ǽ�
        /// </summary>
        /// <returns></returns>
        [Column("STARLEVEL")]
        public int? StarLevel { get; set; }
        /// <summary>
        /// �Ƿ�������䣨��ͨ�䣬��������ߵ��䣩
        /// </summary>
        /// <returns></returns>
        [Column("ADVANCEDMARK")]
        public string AdvancedMark { get; set; }
        /// <summary>
        /// ����绰
        /// </summary>
        /// <returns></returns>
        [Column("DORMTEL")]
        public string DormTel { get; set; }
        /// <summary>
        /// ����IP��ַ
        /// </summary>
        /// <returns></returns>
        [Column("DORMIP")]
        public string DormIp { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER")]
        public string DormOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER1")]
        public string DormOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER2")]
        public string DormOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER3")]
        public string DormOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER4")]
        public string DormOther4 { get; set; }

        /// <summary>
        /// ��ʹ�ô�λ��
        /// </summary>
        /// <returns></returns>
        [Column("UsedBeds")]
        public int UsedBeds { get; set; }
        /// <summary>
        /// δʹ�ô�λ��
        /// </summary>
        /// <returns></returns>
        [Column("NotUseBeds")]
        public int NotUseBeds { get; set; }
        /// <summary>
        /// רҵID��
        /// </summary>
        /// <returns></returns>
        [Column("MajorId")]
        public string MajorId { get; set; }
        /// <summary>
        /// ��ϸרҵID��
        /// </summary>
        /// <returns></returns>
        [Column("MajorDetailId")]
        public string MajorDetailId { get; set; }
        /// <summary>
        /// �༶ID��
        /// </summary>
        /// <returns></returns>
        [Column("ClassInfoId")]
        public string ClassInfoId { get; set; }
        /// <summary>
        /// �ѷַ���λ
        /// </summary>
        /// <returns></returns>
        [Column("DistributeBeds")]
        public int DistributeBeds { get; set; }
        /// <summary>
        /// δ�ַ���λ
        /// </summary>
        /// <returns></returns>
        [Column("NotDistributeBeds")]
        public int NotDistributeBeds { get; set; }




        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.DormId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormId = keyValue;
                                    
        }
        #endregion
    }
}