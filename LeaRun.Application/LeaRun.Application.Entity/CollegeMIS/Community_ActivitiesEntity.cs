using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:44
    /// �� �������Ż��
    /// </summary>
    public class Community_ActivitiesEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���ŻID��
        /// </summary>
        /// <returns></returns>
        public string CA_Id { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string CA_Title { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string CA_Initiator { get; set; }
        /// <summary>
        /// ���ϸ����˵��
        /// </summary>
        /// <returns></returns>
        public string CA_Contents { get; set; }
        /// <summary>
        /// ��ٰ��
        /// </summary>
        /// <returns></returns>
        public string CA_Address { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string CA_JoinPeople { get; set; }
        /// <summary>
        /// ��ٰ쿪ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_BeginTime { get; set; }
        /// <summary>
        /// �����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_EndTime { get; set; }
        /// <summary>
        /// ���Ƭ
        /// </summary>
        /// <returns></returns>
        public string CA_Photos { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string CA_Files { get; set; }
        /// <summary>
        /// ���ע˵��
        /// </summary>
        /// <returns></returns>
        public string CA_Remark { get; set; }
        /// <summary>
        /// �����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_AppTime { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string CA_Approver { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_ApproveTime { get; set; }
        /// <summary>
        /// ����ͨ��
        /// </summary>
        /// <returns></returns>
        public bool? CA_ApprovePass { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other5 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other6 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other7 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CA_Other8 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.CA_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CA_Id = keyValue;
                                    
        }
        #endregion
    }
}