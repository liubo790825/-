using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 15:59
    /// �� ������λ��Ϣ
    /// </summary>
    public class BK_DormBedEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// ¥��ID��
        /// </summary>
        /// <returns></returns>
        public string DormFloorsId { get; set; }
        /// <summary>
        /// ����¥��ԪID��
        /// </summary>
        /// <returns></returns>
        public string DormUnitId { get; set; }
        /// <summary>
        /// ����¥ID��
        /// </summary>
        /// <returns></returns>
        public string DormBuildingId { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }
        /// <summary>
        /// ��λ���
        /// </summary>
        /// <returns></returns>
        public string BedNo { get; set; }
        /// <summary>
        /// �۸�
        /// </summary>
        /// <returns></returns>
        public decimal? BedPrice { get; set; }
        /// <summary>
        /// �Ƿ�ռ��
        /// </summary>
        /// <returns></returns>
        public string IsDwell { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BedOther { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BedOther1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BedOther2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BedOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string BedOther4 { get; set; }

        /// <summary>
        /// �Ƿ�ַ���0δ�֣�1�ѷ�
        /// </summary>
        /// <returns></returns>
        public int IsDistribute { get; set; }
        /// <summary>
        /// �Ƿ�ʹ�ã�0δʹ�ã�1��ʹ��
        /// </summary>
        /// <returns></returns>
        public int IsUsed { get; set; }
        /// <summary>
        /// רҵID��
        /// </summary>
        /// <returns></returns>
        public string MajorId { get; set; }
        /// <summary>
        /// ��ϸרҵID��
        /// </summary>
        /// <returns></returns>
        public string MajorDetailId { get; set; }
        /// <summary>
        /// �༶ID��
        /// </summary>
        /// <returns></returns>
        public string ClassInfoId { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }





        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.BedId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.BedId = keyValue;
                                    
        }
        #endregion
    }
}