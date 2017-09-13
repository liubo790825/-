using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 17:53
    /// �� ����ѧ����������
    /// </summary>
    public class BK_StuFilesEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ֪ͨ���
        /// </summary>
        /// <returns></returns>
        public string NoticeNo { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string FileNo { get; set; }
        /// <summary>
        /// ��ŵص�
        /// </summary>
        /// <returns></returns>
        public string SaveAddress { get; set; }
        /// <summary>
        /// ��ʼ���ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? SaveTime { get; set; }
        /// <summary>
        /// ����״̬��1�����У�2���ᵵ��3��ʧ
        /// </summary>
        /// <returns></returns>
        public int? SaveState { get; set; }
        /// <summary>
        /// �ᵵ��
        /// </summary>
        /// <returns></returns>
        public string Taker { get; set; }
        /// <summary>
        /// �ᵵʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? TakeTime { get; set; }
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