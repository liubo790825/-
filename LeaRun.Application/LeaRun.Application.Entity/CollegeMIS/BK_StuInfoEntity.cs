using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;



namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class BK_StuInfoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// stuInfoId
        /// </summary>
        /// <returns></returns>
        [Column("STUINFOID")]
        public string stuInfoId { get; set; }
        /// <summary>
        /// ֪ͨ���
        /// </summary>
        /// <returns></returns>
        [Column("NOTICENO")]
        public string NoticeNo { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("KSH")]
        public string ksh { get; set; }
        /// <summary>
        /// ׼��֤�ţ���¼ȡ֪ͨ��ʱʹ�ã������������е��룩
        /// </summary>
        /// <returns></returns>
        [Column("ZKZH")]
        public string zkzh { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("STUNO")]
        public string StuNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string StuName { get; set; }
        /// <summary>
        /// ϵ����
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        [Column("GENDER")]
        public string Gender { get; set; }
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// רҵ����ţ���0��1��2��3��4��5��   0������רҵ����ϸ��
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNOK")]
        public string MajorDetailNok { get; set; }
        /// <summary>
        /// רҵ������
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNAME")]
        public string MajorDetailName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// ������ò��
        /// </summary>
        /// <returns></returns>
        [Column("PARTYFACENO")]
        public string PartyFaceNo { get; set; }
        /// <summary>
        /// ��ͥ����
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYORIGINNO")]
        public string FamilyOriginNo { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("NATIONALITYNO")]
        public string NationalityNo { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENCENO")]
        public string ResidenceNo { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("TESTSTUSORTNO")]
        public string TestStuSortNo { get; set; }
        /// <summary>
        /// ����״��
        /// </summary>
        /// <returns></returns>
        [Column("HEALTHSTATUSNO")]
        public string HealthStatusNo { get; set; }
        /// <summary>
        /// �ڼ�־Ը
        /// </summary>
        /// <returns></returns>
        [Column("WILLNO")]
        public string WillNo { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TESTSTUSUBJECTNO")]
        public string TestStuSubjectNo { get; set; }
        /// <summary>
        /// ��ר��
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATENO")]
        public string GraduateNo { get; set; }
        /// <summary>
        /// �ƻ���ʽ
        /// </summary>
        /// <returns></returns>
        [Column("PLANFORMNO")]
        public string PlanFormNo { get; set; }
        /// <summary>
        /// �߿����
        /// </summary>
        /// <returns></returns>
        [Column("HIGHTESTSORTNO")]
        public string HighTestSortNo { get; set; }
        /// <summary>
        /// �߿��ܷ�
        /// </summary>
        /// <returns></returns>
        [Column("HIGHAMOUNTSCORE")]
        public decimal? HighAmountScore { get; set; }
        /// <summary>
        /// ���γɼ�
        /// </summary>
        /// <returns></returns>
        [Column("POLITICSSCORE")]
        public decimal? PoliticsScore { get; set; }
        /// <summary>
        /// ���ĳɼ�
        /// </summary>
        /// <returns></returns>
        [Column("CHINESESCORE")]
        public decimal? ChineseScore { get; set; }
        /// <summary>
        /// ��ѧ�ɼ�
        /// </summary>
        /// <returns></returns>
        [Column("MATHSCORE")]
        public decimal? MathScore { get; set; }
        /// <summary>
        /// ����ɼ�
        /// </summary>
        /// <returns></returns>
        [Column("PHYSICSSCORE")]
        public decimal? PhysicsScore { get; set; }
        /// <summary>
        /// ��ѧ�ɼ�
        /// </summary>
        /// <returns></returns>
        [Column("CHEMSCORE")]
        public decimal? ChemScore { get; set; }
        /// <summary>
        /// ����ɼ�
        /// </summary>
        /// <returns></returns>
        [Column("BIOLOGYSCORE")]
        public decimal? BiologyScore { get; set; }
        /// <summary>
        /// ����ɼ�
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGSCORE")]
        public decimal? ForeignLangScore { get; set; }
        /// <summary>
        /// ������Գɼ�
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGORALSCORE")]
        public decimal? ForeignLangOralScore { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGSPECIES")]
        public string ForeignLangSpecies { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("ISTHREEGOOD")]
        public string IsThreeGood { get; set; }
        /// <summary>
        /// �Ÿ�
        /// </summary>
        /// <returns></returns>
        [Column("ISEXCELLENT")]
        public string IsExcellent { get; set; }
        /// <summary>
        /// һ��ѧ��      �ɲ�
        /// </summary>
        /// <returns></returns>
        [Column("ISNORMALCADRE")]
        public string IsNormalCadre { get; set; }
        /// <summary>
        /// ʡ��ǰ��
        /// </summary>
        /// <returns></returns>
        [Column("ISPROVINCEFIRSTTHREE")]
        public string IsProvinceFirstThree { get; set; }
        /// <summary>
        /// �۰�̨��
        /// </summary>
        /// <returns></returns>
        [Column("OVERSEASCHINESENO")]
        public string OverseasChineseNo { get; set; }
        /// <summary>
        /// ¼ȡ���
        /// </summary>
        /// <returns></returns>
        [Column("MATRICULATESORT")]
        public string MatriculateSort { get; set; }
        /// <summary>
        /// ��Դ������
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENO")]
        public string ProvinceNo { get; set; }
        /// <summary>
        /// ԭ��λ�루ԭ��ѧ��
        /// </summary>
        /// <returns></returns>
        [Column("HIGHSCHOOLNO")]
        public string HighSchoolNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("REGIONNO")]
        public string RegionNo { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("RECRUITYEARDATE")]
        public string RecruitYearDate { get; set; }
        /// <summary>
        /// ClassNo
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNO")]
        public string ClassNo { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITYCARDNO")]
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// ԭ��λ����ѧ����
        /// </summary>
        /// <returns></returns>
        [Column("HIGHSCHOOLNAME")]
        public string HighSchoolName { get; set; }
        /// <summary>
        /// �س�
        /// </summary>
        /// <returns></returns>
        [Column("GOODAT")]
        public string GoodAt { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ARRIVEDATE")]
        public DateTime? ArriveDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("ARCHIVESNO")]
        public string ArchivesNo { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        /// <summary>
        /// ѧ������ʡ
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMPROVINCE")]
        public string StuFromProvince { get; set; }
        /// <summary>
        /// ѧ��������
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMCITY")]
        public string StuFromCity { get; set; }
        /// <summary>
        /// ѧ��������
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMDESTRICT")]
        public string StuFromDestrict { get; set; }
        /// <summary>
        /// ��ͥ����ʡ
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYPROVINCE")]
        public string FamliyProvince { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYCITY")]
        public string FamliyCity { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYDISTRICT")]
        public string FamliyDistrict { get; set; }
        /// <summary>
        /// ��ͥ��ַ
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYADDRESS")]
        public string FamilyAddress { get; set; }
        /// <summary>
        /// �Ƿ񱨵�ע��
        /// </summary>
        /// <returns></returns>
        [Column("REGISTERSTATUS")]
        public string RegisterStatus { get; set; }
        /// <summary>
        /// MailAddress�ռ�����ַ����¼ȡ֪ͨ��ʱʹ�ã������������е���,��Ӧ�ֶ�jtdz��
        /// </summary>
        /// <returns></returns>
        [Column("MAILADDRESS")]
        public string MailAddress { get; set; }
        /// <summary>
        /// PostalCode��������(��¼ȡ֪ͨ��ʱʹ�ã������������е���,��Ӧ�ֶ�yzbm)
        /// </summary>
        /// <returns></returns>
        [Column("POSTALCODE")]
        public string PostalCode { get; set; }
        /// <summary>
        /// TransMark�鵵��־��1Ϊ�ѹ鵵��0Ϊδ�鵵�����ѹ鵵��ѧ�����ܽ��б༭��
        /// </summary>
        /// <returns></returns>
        [Column("TRANSMARK")]
        public string TransMark { get; set; }
        /// <summary>
        /// LogIp
        /// </summary>
        /// <returns></returns>
        [Column("LOGIP")]
        public string LogIp { get; set; }
        /// <summary>
        /// LogNum
        /// </summary>
        /// <returns></returns>
        [Column("LOGNUM")]
        public int? LogNum { get; set; }
        /// <summary>
        /// Logtime
        /// </summary>
        /// <returns></returns>
        [Column("LOGTIME")]
        public DateTime? Logtime { get; set; }
        /// <summary>
        /// RecruitDeptNo
        /// </summary>
        /// <returns></returns>
        [Column("RECRUITDEPTNO")]
        public string RecruitDeptNo { get; set; }
        /// <summary>
        /// RecruitMajorNo
        /// </summary>
        /// <returns></returns>
        [Column("RECRUITMAJORNO")]
        public string RecruitMajorNo { get; set; }
        /// <summary>
        /// RegisterEmpNo
        /// </summary>
        /// <returns></returns>
        [Column("REGISTEREMPNO")]
        public string RegisterEmpNo { get; set; }
        /// <summary>
        /// RegisterEmpName
        /// </summary>
        /// <returns></returns>
        [Column("REGISTEREMPNAME")]
        public string RegisterEmpName { get; set; }
        /// <summary>
        /// ApprovedLeader
        /// </summary>
        /// <returns></returns>
        [Column("APPROVEDLEADER")]
        public string ApprovedLeader { get; set; }
        /// <summary>
        /// ChangeReason
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEREASON")]
        public string ChangeReason { get; set; }
        /// <summary>
        /// ChangeDate
        /// </summary>
        /// <returns></returns>
        [Column("CHANGEDATE")]
        public DateTime? ChangeDate { get; set; }
        /// <summary>
        /// TextNo
        /// </summary>
        /// <returns></returns>
        [Column("TEXTNO")]
        public string TextNo { get; set; }
        /// <summary>
        /// Grade
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYPEOPLES")]
        public int? FamliyPeoples { get; set; }
        /// <summary>
        /// ͷ��ͼƬ
        /// </summary>
        /// <returns></returns>
        [Column("HEADIMG")]
        public string HeadImg { get; set; }
        /// <summary>
        /// �м�
        /// </summary>
        /// <returns></returns>
        [Column("DEFORMITY")]
        public string Deformity { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("SINGLEPARENT")]
        public string SingleParent { get; set; }
        /// <summary>
        /// �Ƿ���
        /// </summary>
        /// <returns></returns>
        [Column("ISMARRY")]
        public string IsMarry { get; set; }
        /// <summary>
        /// �¶�
        /// </summary>
        /// <returns></returns>
        [Column("ORPHAN")]
        public string Orphan { get; set; }
        /// <summary>
        /// ��ʿ��Ů
        /// </summary>
        /// <returns></returns>
        [Column("MARTYRCHILDREN")]
        public string MartyrChildren { get; set; }
        /// <summary>
        /// �ͱ�
        /// </summary>
        /// <returns></returns>
        [Column("BASICLIVINGALLOWANCES")]
        public string BasicLivingAllowances { get; set; }
        /// <summary>
        /// �绰���Ƿ��Ǳ������֤����
        /// </summary>
        /// <returns></returns>
        [Column("PHONENOUSEID")]
        public string PhoneNoUseId { get; set; }
        /// <summary>
        /// �ҳ���ϵ�绰�ֻ�
        /// </summary>
        /// <returns></returns>
        [Column("PARENTPHONE")]
        public string ParentPhone { get; set; }
        /// <summary>
        /// �ҳ���ϵ�绰����
        /// </summary>
        /// <returns></returns>
        [Column("PARENTTEL")]
        public string ParentTel { get; set; }
        /// <summary>
        /// �Ƿ��ҵ
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATION")]
        public string Graduation { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUPWD")]
        public string StuPwd { get; set; }
        /// <summary>
        /// �ְ��־
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER")]
        public string StuOther { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER1")]
        public string StuOther1 { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER2")]
        public string StuOther2 { get; set; }
        /// <summary>
        /// ��ѧ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER3")]
        public string StuOther3 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER4")]
        public string StuOther4 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER5")]
        public string StuOther5 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER6")]
        public string StuOther6 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER7")]
        public string StuOther7 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER8")]
        public string StuOther8 { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER9")]
        public string StuOther9 { get; set; }
        /// <summary>
        /// ֪ͨ���ӡ����
        /// </summary>
        /// <returns></returns>
        [Column("PRINTNOTICE")]
        public int? PrintNotice { get; set; }
        /// <summary>
        /// ֪ͨ������ӡʱ��
        /// </summary>
        /// <returns></returns>
        [Column("LastPrintTime")]
        public DateTime? LastPrintTime { get; set; }
        /// <summary>
        /// ˭��ӡ��֪ͨ��
        /// </summary>
        /// <returns></returns>
        [Column("WhoPrint")]
        public string WhoPrint { get; set;}
        /// <summary>
        /// ����������0Ϊδ������1Ϊ�ѱ���
        /// </summary>
        /// <returns></returns>
        [Column("NewStuReport")]
        public int NewStuReport { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("NewStuReportDatetime")]
        public DateTime? NewStuReportDatetime { get; set; }
        /// <summary>
        /// �鵵��־��������δ�鵵���������ѹ鵵��
        /// </summary>
        /// <returns></returns>
        [Column("GuiDangMark")]
        public string GuiDangMark { get; set; }

        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.stuInfoId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.NewStuReport = 0;//Ĭ��Ϊδ����
            this.GuiDangMark = "δ�鵵";//��ʾΪ����
            if (this.ArriveDate == null)
            {
                this.ArriveDate = null;
            }
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.stuInfoId = keyValue;
            if (this.ArriveDate == null)
            {
                this.ArriveDate = null;
            }
        }

        /// <summary>
        /// ���Ա�����
        /// </summary>
        /// <param name="city1"></param>
        /// <param name="city2"></param>
        /// <returns></returns>
        public static int CompareByGender(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.Gender, stuinfo2.Gender);
        }

        /// <summary>
        /// ��ѧ����ʡ����
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByProv(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromProvince, stuinfo2.StuFromProvince);
        }
        /// <summary>
        /// ��ѧ����������
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByCity(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromCity, stuinfo2.StuFromCity);
        }
        /// <summary>
        /// ��ѧ����������
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByDest(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromDestrict, stuinfo2.StuFromDestrict);
        }

        /// <summary>
        /// ���ɼ�����
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByScore(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            if (stuinfo1.HighAmountScore > stuinfo2.HighAmountScore) return -1;  //����-1��ʾmx���϶�����ֵС��my,��������ǰ��
            else if (stuinfo1.HighAmountScore < stuinfo2.HighAmountScore) return 1; //����1 ��ʾmx���϶�����ֵ����my,�������ں���.
            else return 0;
            //return decimal.Compare(stuinfo1.HighAmountScore.Value, stuinfo2.HighAmountScore.Value);
        }
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByNation(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.NationalityNo, stuinfo2.NationalityNo);            
        }


        #endregion
    }
}