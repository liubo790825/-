using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 14:05
    /// �� ����֪ͨ������Ϣ
    /// </summary>
    public class BK_ExpressInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string Stuno { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// �ռ���ַ
        /// </summary>
        /// <returns></returns>
        public string StuAddress { get; set; }
        /// <summary>
        /// ֪ͨ���
        /// </summary>
        /// <returns></returns>
        public string NoticeNo { get; set; }
        /// <summary>
        /// ��ݹ�˾
        /// </summary>
        /// <returns></returns>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// ��ݺ�
        /// </summary>
        /// <returns></returns>
        public string ExpressNo { get; set; }
        /// <summary>
        /// �Ƿ���
        /// </summary>
        /// <returns></returns>
        public int? Sended { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string Sender { get; set; }
        /// <summary>
        /// ���Ա
        /// </summary>
        /// <returns></returns>
        public string Postman { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string Paker { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;

        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

        }
        #endregion
    }
}