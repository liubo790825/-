using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:33
    /// �� �������Ż�����Ϣ��
    /// </summary>
    public class Community_infoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����ID��
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string C_Name { get; set; }
        /// <summary>
        /// �᳤���ų�����ϯ
        /// </summary>
        /// <returns></returns>
        public string C_Chairman { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string C_Type { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? C_BuidDate { get; set; }
        /// <summary>
        /// ˵��
        /// </summary>
        /// <returns></returns>
        public string C_Briefing { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        /// <returns></returns>
        public string C_Address { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string C_Tel { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? C_Other { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? C_Other1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? C_Other2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? C_Other3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string C_Other4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string C_Other5 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string C_Other6 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string C_Other7 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other8 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other9 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other10 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other11 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool? C_Other12 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool? C_Other13 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool? C_Other14 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public bool? C_Other15 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.C_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.C_BuidDate = DateTime.Now;  
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.C_Id = keyValue;
                                    
        }
        #endregion
    }
}