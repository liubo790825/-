using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-28 09:28
    /// �� ����ѧ����ס��λ��¼
    /// </summary>
    public class BK_StuBedDwellEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID��
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// ��λID��
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// ��סʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? EnterDate { get; set; }
        /// <summary>
        /// �˳�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? QuitDate { get; set; }
        /// <summary>
        /// ��ס��ע
        /// </summary>
        /// <returns></returns>
        public string EnterRemark { get; set; }
        /// <summary>
        /// �˳���ע
        /// </summary>
        /// <returns></returns>
        public string QuitRemark { get; set; }
        /// <summary>
        /// ������ID��
        /// </summary>
        /// <returns></returns>
        public string OperatorID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string Operator { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? OperatorTime { get; set; }
        /// <summary>
        /// ��¼����޸���ID��
        /// </summary>
        /// <returns></returns>
        public string DwellOther { get; set; }
        /// <summary>
        /// ��¼����޸�������
        /// </summary>
        /// <returns></returns>
        public string DwellOther1 { get; set; }
        /// <summary>
        /// DwellOther2
        /// </summary>
        /// <returns></returns>
        public string DwellOther2 { get; set; }
        /// <summary>
        /// DwellOther3
        /// </summary>
        /// <returns></returns>
        public string DwellOther3 { get; set; }
        /// <summary>
        /// DwellOther4
        /// </summary>
        /// <returns></returns>
        public string DwellOther4 { get; set; }
        /// <summary>
        /// DwellOther5
        /// </summary>
        /// <returns></returns>
        public string DwellOther5 { get; set; }
        /// <summary>
        /// DwellOther6
        /// </summary>
        /// <returns></returns>
        public string DwellOther6 { get; set; }
        /// <summary>
        /// DwellOther7
        /// </summary>
        /// <returns></returns>
        public string DwellOther7 { get; set; }
        /// <summary>
        /// DwellOther8
        /// </summary>
        /// <returns></returns>
        public string DwellOther8 { get; set; }
        /// <summary>
        /// DwellOther9
        /// </summary>
        /// <returns></returns>
        public string DwellOther9 { get; set; }
        /// <summary>
        /// DwellOther10
        /// </summary>
        /// <returns></returns>
        public string DwellOther10 { get; set; }
        /// <summary>
        /// DwellOther11
        /// </summary>
        /// <returns></returns>
        public string DwellOther11 { get; set; }
        /// <summary>
        /// DwellOther12
        /// </summary>
        /// <returns></returns>
        public string DwellOther12 { get; set; }
        /// <summary>
        /// DwellOther13
        /// </summary>
        /// <returns></returns>
        public string DwellOther13 { get; set; }
        /// <summary>
        /// DwellOther14
        /// </summary>
        /// <returns></returns>
        public string DwellOther14 { get; set; }
        /// <summary>
        /// ��¼�޸�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther15 { get; set; }
        /// <summary>
        /// DwellOther16
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther16 { get; set; }
        /// <summary>
        /// DwellOther17
        /// </summary>
        /// <returns></returns>
        public DateTime? DwellOther17 { get; set; }
        /// <summary>
        /// DwellOther18
        /// </summary>
        /// <returns></returns>
        public int? DwellOther18 { get; set; }
        /// <summary>
        /// DwellOther19
        /// </summary>
        /// <returns></returns>
        public int? DwellOther19 { get; set; }
        /// <summary>
        /// DwellOther20
        /// </summary>
        /// <returns></returns>
        public int? DwellOther20 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.OperatorID = OperatorProvider.Provider.Current().UserId;
            this.Operator = OperatorProvider.Provider.Current().UserName;
            this.OperatorTime = DateTime.Now;       
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.DwellOther = OperatorProvider.Provider.Current().UserId;//��¼����޸���
            this.DwellOther1 = OperatorProvider.Provider.Current().UserName;//��¼����޸���
            this.DwellOther15 = DateTime.Now;
        }
        #endregion
    }
}