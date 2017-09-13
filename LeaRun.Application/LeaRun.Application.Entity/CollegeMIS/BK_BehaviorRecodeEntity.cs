using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-10 11:42
    /// �� ����ѧ�����м�¼
    /// </summary>
    public class BK_BehaviorRecodeEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
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
        /// ��������ID��
        /// </summary>
        /// <returns></returns>
        public string BehaviorTypeId { get; set; }
        /// <summary>
        /// Υ���Ĳ���
        /// </summary>
        /// <returns></returns>
        public string BreachBehavior { get; set; }
        /// <summary>
        /// Υ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? BreachTime { get; set; }
        /// <summary>
        /// �ύ��
        /// </summary>
        /// <returns></returns>
        public string Submiter { get; set; }
        /// <summary>
        /// �Ƿ�����0δ������1���������У�2����
        /// </summary>
        /// <returns></returns>
        public int? IsCanceled { get; set; }
        /// <summary>
        /// ���볷���Ĵ���
        /// </summary>
        /// <returns></returns>
        public int? AppCancel { get; set; }
        /// <summary>
        /// �Ƿ�������볷����������볷��������3�������ߣ������ٴ�����
        /// </summary>
        /// <returns></returns>
        public int? CanCancel { get; set; }
        /// <summary>
        /// ɾ����ǣ�0δɾ����1ɾ��
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ��Ч��ǣ�1��Ч��0ʧЧ
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
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
            this.CanCancel = 0;
            this.AppCancel = 0;
            this.DeleteMark = 0;
            this.EnabledMark = 1;
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