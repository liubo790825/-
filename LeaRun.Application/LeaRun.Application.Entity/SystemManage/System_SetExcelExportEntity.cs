using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 10:57
    /// �� �������ݵ�����ϸ����
    /// </summary>
    public class System_SetExcelExportEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID��
        /// </summary>
        /// <returns></returns>
        public string F_Id { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        public string F_Name { get; set; }
        /// <summary>
        /// �󶨵�JQgirdId
        /// </summary>
        /// <returns></returns>
        public string F_Gridid { get; set; }
        /// <summary>
        /// ����ģ��ID
        /// </summary>
        /// <returns></returns>
        public string F_MouduleId { get; set; }
        /// <summary>
        /// ��ťId
        /// </summary>
        /// <returns></returns>
        public string F_ModuleBtnId { get; set; }
        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        /// <returns></returns>
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// ��������
        /// </summary>		
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>		
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>		
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>		
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>		
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>		
        public string F_ModifyUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.F_CreateDate = DateTime.Now;
            this.F_EnabledMark = 1;
            this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_Id = keyValue;
            this.F_ModifyDate = DateTime.Now;
            this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}