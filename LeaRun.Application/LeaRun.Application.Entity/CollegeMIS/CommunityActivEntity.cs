using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 23:13
    /// �� ����CommunityActiv
    /// </summary>
    public class CommunityActivEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// CA_Id
        /// </summary>
        /// <returns></returns>
        public string CA_Id { get; set; }
        /// <summary>
        /// C_Id
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// CA_Title
        /// </summary>
        /// <returns></returns>
        public string CA_Title { get; set; }
        /// <summary>
        /// CA_Initiator
        /// </summary>
        /// <returns></returns>
        public string CA_Initiator { get; set; }
        /// <summary>
        /// CA_Contents
        /// </summary>
        /// <returns></returns>
        public string CA_Contents { get; set; }
        /// <summary>
        /// CA_Address
        /// </summary>
        /// <returns></returns>
        public string CA_Address { get; set; }
        /// <summary>
        /// CA_JoinPeople
        /// </summary>
        /// <returns></returns>
        public string CA_JoinPeople { get; set; }
        /// <summary>
        /// CA_BeginTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_BeginTime { get; set; }
        /// <summary>
        /// CA_EndTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_EndTime { get; set; }
        /// <summary>
        /// CA_Photos
        /// </summary>
        /// <returns></returns>
        public string CA_Photos { get; set; }
        /// <summary>
        /// CA_Files
        /// </summary>
        /// <returns></returns>
        public string CA_Files { get; set; }
        /// <summary>
        /// CA_Remark
        /// </summary>
        /// <returns></returns>
        public string CA_Remark { get; set; }
        /// <summary>
        /// CA_AppTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_AppTime { get; set; }
        /// <summary>
        /// CA_Approver
        /// </summary>
        /// <returns></returns>
        public string CA_Approver { get; set; }
        /// <summary>
        /// CA_ApproveTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CA_ApproveTime { get; set; }
        /// <summary>
        /// CA_ApprovePass
        /// </summary>
        /// <returns></returns>
        public bool? CA_ApprovePass { get; set; }
        /// <summary>
        /// C_Name
        /// </summary>
        /// <returns></returns>
        public string C_Name { get; set; }
        /// <summary>
        /// C_Chairman
        /// </summary>
        /// <returns></returns>
        public string C_Chairman { get; set; }
        /// <summary>
        /// C_Type
        /// </summary>
        /// <returns></returns>
        public string C_Type { get; set; }
        /// <summary>
        /// C_BuidDate
        /// </summary>
        /// <returns></returns>
        public DateTime? C_BuidDate { get; set; }
        /// <summary>
        /// C_Briefing
        /// </summary>
        /// <returns></returns>
        public string C_Briefing { get; set; }
        /// <summary>
        /// C_Address
        /// </summary>
        /// <returns></returns>
        public string C_Address { get; set; }
        /// <summary>
        /// C_Tel
        /// </summary>
        /// <returns></returns>
        public string C_Tel { get; set; }
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