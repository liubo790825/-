using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-13 05:03
    /// �� ����BK_BaodaoYuyue
    /// </summary>
    public class BK_BaodaoYuyueEntity : BaseEntity
    {
        #region ʵ���Ա

        public string Token;

        /// <summary>
        /// ��ʶ��
        /// </summary>
        /// <returns></returns>
        public string YuyueId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ���﷽ʽ
        /// </summary>
        /// <returns></returns>
        public string ArrivalMode { get; set; }
        /// <summary>
        /// ����ص�
        /// </summary>
        /// <returns></returns>
        public string ArrivalPosition { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string Number { get; set; }
        /// <summary>
        /// ������ϵ������
        /// </summary>
        /// <returns></returns>
        public string ParentsName { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }
        /// <summary>
        /// ���õ绰
        /// </summary>
        /// <returns></returns>
        public string SpareTelephone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Massage { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? ArrivalDate { get; set; }
        /// <summary>
        /// BaodaoStatus
        /// </summary>
        /// <returns></returns>
        public string BaodaoStatus { get; set; }
        /// <summary>
        /// BaodaoOther1
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther1 { get; set; }
        /// <summary>
        /// BaodaoOther2
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther2 { get; set; }
        /// <summary>
        /// BaodaoOther3
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther3 { get; set; }
        /// <summary>
        /// BaodaoOther4
        /// </summary>
        /// <returns></returns>
        public string BaodaoOther4 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.YuyueId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.YuyueId = keyValue;
                                    
        }
        #endregion
    }
}