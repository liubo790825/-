using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:35
    /// �� ������¼��������
    /// </summary>
    public class BK_StuPassFlowEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        /// <returns></returns>
        public string FlowId { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string stuInfoId { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// �Ƿ���ɣ�1��ɣ�0δ���
        /// </summary>
        /// <returns></returns>
        public int? Flished { get; set; }
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
        /// CreateName
        /// </summary>
        /// <returns></returns>
        public string CreateName { get; set; }
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
            this.CreateName = OperatorProvider.Provider.Current().UserName;
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