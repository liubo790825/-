using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.FormManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:23
    /// �� ������ģ���
    /// </summary>
    public class Form_ModuleEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��ģ��Id
        /// </summary>
        /// <returns></returns>
        public string FrmId { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string FrmCode { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string FrmName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string FrmCategory { get; set; }
        /// <summary>
        /// ������0�Զ����1�Զ����(����)2ϵͳ��
        /// </summary>
        /// <returns></returns>
        public int? FrmType { get; set; }
        /// <summary>
        /// ���ݿ�Id
        /// </summary>
        /// <returns></returns>
        public string FrmDbId { get; set; }
        /// <summary>
        /// ���ݱ�
        /// </summary>
        /// <returns></returns>
        public string FrmDbTable { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string FrmDbPkey { get; set; }
        /// <summary>
        /// �汾��
        /// </summary>
        /// <returns></returns>
        public string Version { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string FrmContent { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? SortCode { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ״̬0ͣ��1����3�ݸ�
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�ID
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸���id
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸���
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
            this.FrmId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
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
            this.FrmId = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

        }
        #endregion
    }
}