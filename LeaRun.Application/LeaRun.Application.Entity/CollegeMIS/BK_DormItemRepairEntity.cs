using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-30 12:15
    /// �� ����BK_DormItemRepair
    /// </summary>
    public class BK_DormItemRepairEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// ¥�����
        /// </summary>
        /// <returns></returns>
        public string DormFloorsId { get; set; }
        /// <summary>
        /// ��Ԫ���
        /// </summary>
        /// <returns></returns>
        public string DormUnitId { get; set; }
        /// <summary>
        /// ����¥���
        /// </summary>
        /// <returns></returns>
        public string DormBuildingId { get; set; }
        /// <summary>
        /// ��������Ʒ
        /// </summary>
        /// <returns></returns>
        public string RepairItem { get; set; }
        /// <summary>
        /// ����۸�
        /// </summary>
        /// <returns></returns>
        public string RepairPrice { get; set; }
        /// <summary>
        /// ��Ʒ�۸�
        /// </summary>
        /// <returns></returns>
        public string ItemPrice { get; set; }
        /// <summary>
        /// �Ƿ��������
        /// </summary>
        /// <returns></returns>
        public string RepairDone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other4 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
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