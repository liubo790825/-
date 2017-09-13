using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:41
    /// �� ��������¥��Ϣ
    /// </summary>
    public class BK_DormBuildingEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGID")]
        public string DormBuildingId { get; set; }
        /// <summary>
        /// ����¥���
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGNO")]
        public string DormBuildingNo { get; set; }
        /// <summary>
        /// ����¥����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGNAME")]
        public string DormBuildingName { get; set; }
        /// <summary>
        /// ����¥�ƶ�
        /// </summary>
        /// <returns></returns>
        [Column("BEDRULE")]
        public string BedRule { get; set; }
        /// <summary>
        /// ������Ů��
        /// </summary>
        /// <returns></returns>
        [Column("BUILDTYPE")]
        public string BuildType { get; set; }
        /// <summary>
        /// ¥�������Ա
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGMANAGER")]
        public string BuildingManager { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGAREA")]
        public decimal? BuildingArea { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER")]
        public string DormBuildingOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER1")]
        public string DormBuildingOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER2")]
        public string DormBuildingOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER3")]
        public string DormBuildingOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER4")]
        public string DormBuildingOther4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER5")]
        public string DormBuildingOther5 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER6")]
        public string DormBuildingOther6 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER7")]
        public string DormBuildingOther7 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER8")]
        public string DormBuildingOther8 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER9")]
        public string DormBuildingOther9 { get; set; }

        /// <summary>
        /// �ܵ�Ԫ��
        /// </summary>
        /// <returns></returns>
        [Column("UnitCount")]
        public int UnitCount { get; set; }

        /// <summary>
        /// ��Ԫ����������Ů��
        /// </summary>
        /// <returns></returns>
        [Column("UnitType")]
        public string UnitType { get; set; }
        /// <summary>
        /// ��Ԫ����
        /// </summary>
        /// <returns></returns>
        [Column("UnitTypeRule")]
        public string UnitTypeRule { get; set; }
        /// <summary>
        /// ÿ����Ԫ��¥����
        /// </summary>
        /// <returns></returns>
        [Column("FloorsCountForUnit")]
        public int FloorsCountForUnit { get; set; }
        /// <summary>
        /// ¥�����
        /// </summary>
        /// <returns></returns>
        [Column("FloorsTypeRule")]
        public string FloorsTypeRule { get; set; }
        /// <summary>
        /// ¥������������Ů��
        /// </summary>
        /// <returns></returns>
        [Column("FloorsType")]
        public string FloorsType { get; set; }
        /// <summary>
        /// ÿ��¥�ķ�����
        /// </summary>
        /// <returns></returns>
        [Column("DormCountForFloor")]
        public int DormCountForFloor { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("DormTypeRule")]
        public string DormTypeRule { get; set; }
        /// <summary>
        /// ÿ������Ĵ�λ��
        /// </summary>
        /// <returns></returns>
        [Column("BedCountForDorm")]
        public int BedCountForDorm { get; set; }


        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
           this.DormBuildingId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�                              
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormBuildingId = keyValue;
                                    
        }
        #endregion
    }
}