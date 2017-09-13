using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.FlowManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-09-08 15:44
    /// �� ����WF_ProcessNodes
    /// </summary>
    public class WF_ProcessNodesEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// F_Id
        /// </summary>
        /// <returns></returns>
        public string F_Id { get; set; }
        /// <summary>
        /// F_ProcessId
        /// </summary>
        /// <returns></returns>
        public string F_ProcessId { get; set; }
        /// <summary>
        /// F_NodeId
        /// </summary>
        /// <returns></returns>
        public string F_NodeId { get; set; }
        /// <summary>
        /// F_NodeName
        /// </summary>
        /// <returns></returns>
        public string F_NodeName { get; set; }
        /// <summary>
        /// F_NodeType
        /// </summary>
        /// <returns></returns>
        public string F_NodeType { get; set; }
        /// <summary>
        /// F_IsActivtyId
        /// </summary>
        /// <returns></returns>
        public int? F_IsActivtyId { get; set; }
        /// <summary>
        /// F_NodeSate
        /// </summary>
        /// <returns></returns>
        public int? F_NodeSate { get; set; }
        /// <summary>
        /// F_PreviousId
        /// </summary>
        /// <returns></returns>
        public string F_PreviousId { get; set; }
        /// <summary>
        /// F_PreviousName
        /// </summary>
        /// <returns></returns>
        public string F_PreviousName { get; set; }
        /// <summary>
        /// F_UserList
        /// </summary>
        /// <returns></returns>
        public string F_UserList { get; set; }
        /// <summary>
        /// F_CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// F_CreateUserId
        /// </summary>
        /// <returns></returns>
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// F_CreateUserName
        /// </summary>
        /// <returns></returns>
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// F_ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// F_ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// F_ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// F_ConfluenceOkNum
        /// </summary>
        /// <returns></returns>
        public int? F_ConfluenceOkNum { get; set; }
        /// <summary>
        /// F_ConfluenceNoNum
        /// </summary>
        /// <returns></returns>
        public int? F_ConfluenceNoNum { get; set; }
        /// <summary>
        /// F_Description
        /// </summary>
        /// <returns></returns>
        public string F_Description { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_Id = keyValue;
                                    
        }
        #endregion
    }
}