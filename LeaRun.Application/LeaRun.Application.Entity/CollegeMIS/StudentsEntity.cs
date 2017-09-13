using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-25 09:43
    /// �� ����Students
    /// </summary>
    public class StudentsEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// RegionNo
        /// </summary>
        /// <returns></returns>
        public string RegionNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ֪ͨ���
        /// </summary>
        /// <returns></returns>
        public string NoticeNo { get; set; }
        /// <summary>
        /// Ժϵ
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// SpellFull
        /// </summary>
        /// <returns></returns>
        public string SpellFull { get; set; }
        /// <summary>
        /// SpellBrief
        /// </summary>
        /// <returns></returns>
        public string SpellBrief { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// ������ò
        /// </summary>
        /// <returns></returns>
        public string PartyFace { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Nationality { get; set; }
        /// <summary>
        /// FamilyOrigin
        /// </summary>
        /// <returns></returns>
        public string FamilyOrigin { get; set; }
        /// <summary>
        /// RegionName
        /// </summary>
        /// <returns></returns>
        public string RegionName { get; set; }
        /// <summary>
        /// HealthStatus
        /// </summary>
        /// <returns></returns>
        public string HealthStatus { get; set; }
        /// <summary>
        /// WillNo
        /// </summary>
        /// <returns></returns>
        public string WillNo { get; set; }
        /// <summary>
        /// TestStuSubject
        /// </summary>
        /// <returns></returns>
        public string TestStuSubject { get; set; }
        /// <summary>
        /// GraduateName
        /// </summary>
        /// <returns></returns>
        public string GraduateName { get; set; }
        /// <summary>
        /// PlanForm
        /// </summary>
        /// <returns></returns>
        public string PlanForm { get; set; }
        /// <summary>
        /// IsThreeGood
        /// </summary>
        /// <returns></returns>
        public string IsThreeGood { get; set; }
        /// <summary>
        /// IsExcellent
        /// </summary>
        /// <returns></returns>
        public string IsExcellent { get; set; }
        /// <summary>
        /// IsNormalCadre
        /// </summary>
        /// <returns></returns>
        public string IsNormalCadre { get; set; }
        /// <summary>
        /// MatriculateSort
        /// </summary>
        /// <returns></returns>
        public string MatriculateSort { get; set; }
        /// <summary>
        /// ʡ��
        /// </summary>
        /// <returns></returns>
        public string ProvinceName { get; set; }
        /// <summary>
        /// HighSchoolNo
        /// </summary>
        /// <returns></returns>
        public string HighSchoolNo { get; set; }
        /// <summary>
        /// ��ҵ��ѧ
        /// </summary>
        /// <returns></returns>
        public string HighSchoolName { get; set; }
        /// <summary>
        /// ��Уʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? EntranceDate { get; set; }
        /// <summary>
        /// Religion
        /// </summary>
        /// <returns></returns>
        public string Religion { get; set; }
        /// <summary>
        /// GoodAt
        /// </summary>
        /// <returns></returns>
        public string GoodAt { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// �뵳ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? JoinPartyDate { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? JoinLeagueDate { get; set; }
        /// <summary>
        /// У��סַ
        /// </summary>
        /// <returns></returns>
        public string InSchoolAddress { get; set; }
        /// <summary>
        /// InSchoolTelephone
        /// </summary>
        /// <returns></returns>
        public string InSchoolTelephone { get; set; }
        /// <summary>
        /// AbmormityMoveMark
        /// </summary>
        /// <returns></returns>
        public string AbmormityMoveMark { get; set; }
        /// <summary>
        /// AwardMark
        /// </summary>
        /// <returns></returns>
        public string AwardMark { get; set; }
        /// <summary>
        /// PunishMark
        /// </summary>
        /// <returns></returns>
        public string PunishMark { get; set; }
        /// <summary>
        /// LinkmanMark
        /// </summary>
        /// <returns></returns>
        public string LinkmanMark { get; set; }
        /// <summary>
        /// StuNoChangeMark
        /// </summary>
        /// <returns></returns>
        public string StuNoChangeMark { get; set; }
        /// <summary>
        /// FinishSchoolMark
        /// </summary>
        /// <returns></returns>
        public string FinishSchoolMark { get; set; }
        /// <summary>
        /// CurrentRegisterMark
        /// </summary>
        /// <returns></returns>
        public string CurrentRegisterMark { get; set; }
        /// <summary>
        /// FinishSchoolDate
        /// </summary>
        /// <returns></returns>
        public DateTime? FinishSchoolDate { get; set; }
        /// <summary>
        /// DiplomaNo
        /// </summary>
        /// <returns></returns>
        public string DiplomaNo { get; set; }
        /// <summary>
        /// DiplomaRemark
        /// </summary>
        /// <returns></returns>
        public string DiplomaRemark { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// RegisterDate
        /// </summary>
        /// <returns></returns>
        public DateTime? RegisterDate { get; set; }
        /// <summary>
        /// Photo
        /// </summary>
        /// <returns></returns>
        public string Photo { get; set; }
        /// <summary>
        /// TeachPlanNo
        /// </summary>
        /// <returns></returns>
        public string TeachPlanNo { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string mobile { get; set; }
        /// <summary>
        /// EMail
        /// </summary>
        /// <returns></returns>
        public string EMail { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        /// <returns></returns>
        public string QQ { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string FatherName { get; set; }
        /// <summary>
        /// ����λ
        /// </summary>
        /// <returns></returns>
        public string FatherUnit { get; set; }
        /// <summary>
        /// ���绰
        /// </summary>
        /// <returns></returns>
        public string FatherPhone { get; set; }
        /// <summary>
        /// ĸ����
        /// </summary>
        /// <returns></returns>
        public string MatherName { get; set; }
        /// <summary>
        /// ĸ��λ
        /// </summary>
        /// <returns></returns>
        public string MatherUnit { get; set; }
        /// <summary>
        /// ĸ�绰
        /// </summary>
        /// <returns></returns>
        public string MatherPhone { get; set; }
        /// <summary>
        /// username
        /// </summary>
        /// <returns></returns>
        public string username { get; set; }
        /// <summary>
        /// password
        /// </summary>
        /// <returns></returns>
        public string password { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// Residence
        /// </summary>
        /// <returns></returns>
        public string Residence { get; set; }
        /// <summary>
        /// CheckMark
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// DeptNo
        /// </summary>
        /// <returns></returns>
        public string DeptNo { get; set; }
        /// <summary>
        /// MajorNo
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// IsProvinceFirstThree
        /// </summary>
        /// <returns></returns>
        public string IsProvinceFirstThree { get; set; }
        /// <summary>
        /// OverseasChineseName
        /// </summary>
        /// <returns></returns>
        public string OverseasChineseName { get; set; }
        /// <summary>
        /// ComeProvince
        /// </summary>
        /// <returns></returns>
        public string ComeProvince { get; set; }
        /// <summary>
        /// MailAddress
        /// </summary>
        /// <returns></returns>
        public string MailAddress { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public decimal? LengthOfSchooling { get; set; }
        /// <summary>
        /// DormBuildingNo
        /// </summary>
        /// <returns></returns>
        public string DormBuildingNo { get; set; }
        /// <summary>
        /// UnitNo
        /// </summary>
        /// <returns></returns>
        public byte? UnitNo { get; set; }
        /// <summary>
        /// DormNo
        /// </summary>
        /// <returns></returns>
        public int? DormNo { get; set; }
        /// <summary>
        /// StuDorm
        /// </summary>
        /// <returns></returns>
        public string StuDorm { get; set; }
        /// <summary>
        /// DeptShortName
        /// </summary>
        /// <returns></returns>
        public string DeptShortName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string ksh { get; set; }
        /// <summary>
        /// ����רҵ��
        /// </summary>
        /// <returns></returns>
        public string GovMajorNo { get; set; }
        /// <summary>
        /// ����רҵ��
        /// </summary>
        /// <returns></returns>
        public string GovMajorName { get; set; }
        /// <summary>
        /// PartyFaceNo
        /// </summary>
        /// <returns></returns>
        public string PartyFaceNo { get; set; }
        /// <summary>
        /// NationalityNo
        /// </summary>
        /// <returns></returns>
        public string NationalityNo { get; set; }
        /// <summary>
        /// ProvinceBrief
        /// </summary>
        /// <returns></returns>
        public string ProvinceBrief { get; set; }
        /// <summary>
        /// רҵ�����
        /// </summary>
        /// <returns></returns>
        public string MajorDetailNo { get; set; }
        /// <summary>
        /// רҵ��������
        /// </summary>
        /// <returns></returns>
        public string MajorDetailName { get; set; }
        /// <summary>
        /// GenderNo
        /// </summary>
        /// <returns></returns>
        public string GenderNo { get; set; }
        /// <summary>
        /// ClassTutorNo
        /// </summary>
        /// <returns></returns>
        public string ClassTutorNo { get; set; }
        /// <summary>
        /// ClassDiredctorNo
        /// </summary>
        /// <returns></returns>
        public string ClassDiredctorNo { get; set; }
        /// <summary>
        /// InSchoolStatus
        /// </summary>
        /// <returns></returns>
        public string InSchoolStatus { get; set; }
        /// <summary>
        /// AbmormityMove
        /// </summary>
        /// <returns></returns>
        public string AbmormityMove { get; set; }
        /// <summary>
        /// ResumeCheck
        /// </summary>
        /// <returns></returns>
        public string ResumeCheck { get; set; }
        /// <summary>
        /// RegisterStatus
        /// </summary>
        /// <returns></returns>
        public int? RegisterStatus { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.StuNo = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.StuNo = keyValue;
                                    
        }
        #endregion
    }
}