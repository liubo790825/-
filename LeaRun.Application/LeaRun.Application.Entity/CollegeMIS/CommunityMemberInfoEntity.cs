using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:39
    /// �� ������Ա��Ϣ��
    /// </summary>
    public class CommunityMemberInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��ԱID��
        /// </summary>
        /// <returns></returns>
        public string CMI_Id { get; set; }
        /// <summary>
        /// ��Աѧ��
        /// </summary>
        /// <returns></returns>
        public string CMI_StuNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_StuName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string CMI_Gender { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? CMI_Birthday { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string CMI_IdNo { get; set; }
        /// <summary>
        /// ��Ƭ
        /// </summary>
        /// <returns></returns>
        public string CMI_Photo { get; set; }
        /// <summary>
        /// ϵ�����
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptNo { get; set; }
        /// <summary>
        /// ϵ������
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptName { get; set; }
        /// <summary>
        /// רҵ���
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorNo { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorName { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassNo { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassName { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        public string CMI_Phone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other1 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other2 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_Other4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_Other5 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_Other6 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_Other7 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CMI_Other8 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.CMI_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            if (!string.IsNullOrEmpty( this.CMI_IdNo))
            {
                string identityCard = this.CMI_IdNo;
                string birthday = string.Empty;
                string sex = "1";
                if (identityCard.Length == 18)
                {
                     birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                    sex = identityCard.Substring(14, 3);
                }
                if (identityCard.Length == 15)
                {
                    birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                    sex = identityCard.Substring(12, 3);
                }
                this.CMI_Birthday = Convert.ToDateTime(birthday);
                //�Ա����Ϊż����Ů������Ϊ����
                if (int.Parse(sex) % 2 == 0)
                {
                    this.CMI_Gender = "Ů";
                }
                else
                {
                    this.CMI_Gender = "��";
                }
            }
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CMI_Id = keyValue;
            if (!string.IsNullOrEmpty(this.CMI_IdNo))
            {
                string identityCard = this.CMI_IdNo;
                string birthday = string.Empty;
                string sex = "1";
                if (identityCard.Length == 18)
                {
                    birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                    sex = identityCard.Substring(14, 3);
                }
                if (identityCard.Length == 15)
                {
                    birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                    sex = identityCard.Substring(12, 3);
                }
                this.CMI_Birthday = Convert.ToDateTime(birthday);
                //�Ա����Ϊż����Ů������Ϊ����
                if (int.Parse(sex) % 2 == 0)
                {
                    this.CMI_Gender = "Ů";
                }
                else
                {
                    this.CMI_Gender = "��";
                }
            }
        }
        #endregion
    }
}