using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:41
    /// �� �������Ż�Ա��
    /// </summary>
    public class Community_MembersEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���Ż�ԱID��
        /// </summary>
        /// <returns></returns>
        public string CM_Id { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// ���Ž�ɫid��
        /// </summary>
        /// <returns></returns>
        public string CR_Id { get; set; }
        /// <summary>
        /// ��Ա��Ϣid��
        /// </summary>
        /// <returns></returns>
        public string CMI_Id { get; set; }
        /// <summary>
        /// �������ŵ�����
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_JoinDate { get; set; }
        /// <summary>
        /// �˳����ŵ�����
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_OutDate { get; set; }
        /// <summary>
        /// �˳�����
        /// </summary>
        /// <returns></returns>
        public bool? CM_IsOut { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string CM_Remark { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CM_Other5 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.CM_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�                   
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CM_Id = keyValue;
                                    
        }
        #endregion
    }
}