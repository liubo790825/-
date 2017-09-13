using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-13 12:14
    /// �� �����̹������˻�
    /// </summary>
    public class EmpInfo2AccountEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public int? EmpID { get; set; }
        /// <summary>
        /// ְ����
        /// </summary>
        /// <returns></returns>
        public string EmpNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string EmpName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Nation { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string Sfzhao { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// ���ڲ���
        /// </summary>
        /// <returns></returns>
        public string Department { get; set; }
        /// <summary>
        /// ��λ
        /// </summary>
        /// <returns></returns>
        public string EmpPosition { get; set; }
        /// <summary>
        /// ְ��
        /// </summary>
        /// <returns></returns>
        public string TechTitle { get; set; }
        /// <summary>
        /// Ա������ϵ��
        /// </summary>
        /// <returns></returns>
        public string EmpSort { get; set; }
        /// <summary>
        /// ��ͬ���BsContractType��
        /// </summary>
        /// <returns></returns>
        public string ContractType { get; set; }
        /// <summary>
        /// רְ��
        /// </summary>
        /// <returns></returns>
        public string ZjzhiMark { get; set; }
        /// <summary>
        /// ��Ƹ��
        /// </summary>
        /// <returns></returns>
        public string PrztaiMark { get; set; }
        /// <summary>
        /// סַ
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// �̶��绰
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        /// <summary>
        /// ��ʦ֤
        /// </summary>
        /// <returns></returns>
        public string TeacherCertificate { get; set; }
        /// <summary>
        /// ������ʼ����
        /// </summary>
        /// <returns></returns>
        public DateTime? WorkstartDate { get; set; }
        /// <summary>
        /// ��У����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? InSchoolDate { get; set; }
        /// <summary>
        /// ������ò
        /// </summary>
        /// <returns></returns>
        public string PartyFace { get; set; }
        /// <summary>
        /// ������֯ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? PartyDate { get; set; }
        /// <summary>
        /// ��ᱣ��
        /// </summary>
        /// <returns></returns>
        public string SocialSecurity { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string jiguan { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string Major { get; set; }
        /// <summary>
        /// ��һѧ��
        /// </summary>
        /// <returns></returns>
        public string firstxueli { get; set; }
        /// <summary>
        /// ��һѧ����ҵ��
        /// </summary>
        /// <returns></returns>
        public string firstxlgradufrom { get; set; }
        /// <summary>
        /// ��һѧ��ʱ��
        /// </summary>
        /// <returns></returns>
        public string firstxuelidate { get; set; }
        /// <summary>
        /// ���ѧ��
        /// </summary>
        /// <returns></returns>
        public string lastxueli { get; set; }
        /// <summary>
        /// ���ѧ����ҵ��
        /// </summary>
        /// <returns></returns>
        public string lastxlgradufrom { get; set; }
        /// <summary>
        /// ���ѧ��ʱ��
        /// </summary>
        /// <returns></returns>
        public string lastxldate { get; set; }
        /// <summary>
        /// ȡ��ְ������
        /// </summary>
        /// <returns></returns>
        public string TechTitledate { get; set; }
        /// <summary>
        /// ְ��Ƹ������
        /// </summary>
        /// <returns></returns>
        public string TechTitleUsedate { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string MarryMark { get; set; }
        /// <summary>
        /// ��ͥ��Ա
        /// </summary>
        /// <returns></returns>
        public string FamilyMembers { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Resume { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// ¼������
        /// </summary>
        /// <returns></returns>
        public DateTime? InputDate { get; set; }
        /// <summary>
        /// �Ƿ��ν�
        /// </summary>
        /// <returns></returns>
        public string TeachMark { get; set; }
        /// <summary>
        /// ��ʦ����
        /// </summary>
        /// <returns></returns>
        public string TeacherSort { get; set; }
        /// <summary>
        /// һ��ͨ��
        /// </summary>
        /// <returns></returns>
        public string ykthao { get; set; }
        /// <summary>
        /// һ��ͨ�˺�
        /// </summary>
        /// <returns></returns>
        public string yktzhao { get; set; }
        /// <summary>
        /// �ֻ�С��
        /// </summary>
        /// <returns></returns>
        public string Col1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        public string Col2 { get; set; }
        /// <summary>
        /// ����3
        /// </summary>
        /// <returns></returns>
        public string Col3 { get; set; }
        /// <summary>
        /// ��˱�־
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// Photo
        /// </summary>
        /// <returns></returns>
        //public string Photo { get; set; }
        /// <summary>
        /// ȡ��ְҵ�ʸ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? GetMajorDate { get; set; }
        /// <summary>
        /// �����γ�
        /// </summary>
        /// <returns></returns>
        public string TeachingCourses { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.EmpID = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.EmpID = 0;// keyValue;
                                    
        }
        #endregion
    }
}