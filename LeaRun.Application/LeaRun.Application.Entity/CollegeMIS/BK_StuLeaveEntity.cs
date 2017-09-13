using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-14 09:17
    /// �� ����ѧ����ٱ�
    /// </summary>
    public class BK_StuLeaveEntity : BaseEntity
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
        /// Ԥ���绰
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }
        /// <summary>
        /// �������ID��
        /// </summary>
        /// <returns></returns>
        public string LeaveTypeId { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string LeaveType { get; set; }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? Days { get; set; }
        /// <summary>
        /// ���ԭ��
        /// </summary>
        /// <returns></returns>
        public string LeaveRemark { get; set; }
        /// <summary>
        /// �Ƿ�����0Ϊδ��ˣ�1����2������
        /// </summary>
        /// <returns></returns>
        public int? BeAllow { get; set; }
        /// <summary>
        /// �Ƿ����٣�0δ���٣�1������
        /// </summary>
        /// <returns></returns>
        public int? BeCancel { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? BeCancelDate { get; set; }
        /// <summary>
        /// ������ԭ��
        /// </summary>
        /// <returns></returns>
        public string NotBeAllowRemarkable { get; set; }
        /// <summary>
        /// Other
        /// </summary>
        /// <returns></returns>
        public string Other { get; set; }
        /// <summary>
        /// Other1
        /// </summary>
        /// <returns></returns>
        public string Other1 { get; set; }
        /// <summary>
        /// Other2
        /// </summary>
        /// <returns></returns>
        public string Other2 { get; set; }
        /// <summary>
        /// Other3
        /// </summary>
        /// <returns></returns>
        public string Other3 { get; set; }
        /// <summary>
        /// Other4
        /// </summary>
        /// <returns></returns>
        public string Other4 { get; set; }
        /// <summary>
        /// Other5
        /// </summary>
        /// <returns></returns>
        public string Other5 { get; set; }
        /// <summary>
        /// Other6
        /// </summary>
        /// <returns></returns>
        public string Other6 { get; set; }
        /// <summary>
        /// Other7
        /// </summary>
        /// <returns></returns>
        public string Other7 { get; set; }
        /// <summary>
        /// Other8
        /// </summary>
        /// <returns></returns>
        public string Other8 { get; set; }
        /// <summary>
        /// Other9
        /// </summary>
        /// <returns></returns>
        public string Other9 { get; set; }
        /// <summary>
        /// Other10
        /// </summary>
        /// <returns></returns>
        public string Other10 { get; set; }
        /// <summary>
        /// Other11
        /// </summary>
        /// <returns></returns>
        public string Other11 { get; set; }
        /// <summary>
        /// Other12
        /// </summary>
        /// <returns></returns>
        public string Other12 { get; set; }
        /// <summary>
        /// Other13
        /// </summary>
        /// <returns></returns>
        public string Other13 { get; set; }
        /// <summary>
        /// Other14
        /// </summary>
        /// <returns></returns>
        public string Other14 { get; set; }
        /// <summary>
        /// Other15
        /// </summary>
        /// <returns></returns>
        public DateTime? Other15 { get; set; }
        /// <summary>
        /// Other16
        /// </summary>
        /// <returns></returns>
        public DateTime? Other16 { get; set; }
        /// <summary>
        /// Other17
        /// </summary>
        /// <returns></returns>
        public DateTime? Other17 { get; set; }
        /// <summary>
        /// Other18
        /// </summary>
        /// <returns></returns>
        public int? Other18 { get; set; }
        /// <summary>
        /// Other19
        /// </summary>
        /// <returns></returns>
        public int? Other19 { get; set; }
        /// <summary>
        /// Other20
        /// </summary>
        /// <returns></returns>
        public int? Other20 { get; set; }
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