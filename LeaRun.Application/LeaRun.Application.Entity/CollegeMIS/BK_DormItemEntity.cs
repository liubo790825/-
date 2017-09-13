using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-29 10:34
    /// �� ����BK_DormItem
    /// </summary>
    public class BK_DormItemEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ����Id
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// ������Ʒ����
        /// </summary>
        /// <returns></returns>
        public string DormItemName { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <returns></returns>
        public string ItemNumber { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        /// <returns></returns>
        public string ItemPrice { get; set; }
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
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Other5 { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// ¥��Id
        /// </summary>
        /// <returns></returns>
        public string DormFloorsId { get; set; }
        /// <summary>
        /// ��ԪId
        /// </summary>
        /// <returns></returns>
        public string DormUnitId { get; set; }
        /// <summary>
        /// ¥��Id
        /// </summary>
        /// <returns></returns>
        public string DormBUildingId { get; set; }
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