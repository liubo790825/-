using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;



namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-06 09:47
    /// 描 述：新生数据导入      报到确认后的学生数据导入到此表中      同时分班（分配班号） 、学号
    /// </summary>
    public class BK_StuInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// stuInfoId
        /// </summary>
        /// <returns></returns>
        [Column("STUINFOID")]
        public string stuInfoId { get; set; }
        /// <summary>
        /// 通知书号
        /// </summary>
        /// <returns></returns>
        [Column("NOTICENO")]
        public string NoticeNo { get; set; }
        /// <summary>
        /// 考生号
        /// </summary>
        /// <returns></returns>
        [Column("KSH")]
        public string ksh { get; set; }
        /// <summary>
        /// 准考证号（发录取通知书时使用，从招生数据中导入）
        /// </summary>
        /// <returns></returns>
        [Column("ZKZH")]
        public string zkzh { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        [Column("STUNO")]
        public string StuNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string StuName { get; set; }
        /// <summary>
        /// 系所号
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Column("GENDER")]
        public string Gender { get; set; }
        /// <summary>
        /// 专业号
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// 专业方向号（如0，1，2，3，4，5）   0代表无专业方向细分
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNOK")]
        public string MajorDetailNok { get; set; }
        /// <summary>
        /// 专业方向名
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNAME")]
        public string MajorDetailName { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        [Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 政治面貌码
        /// </summary>
        /// <returns></returns>
        [Column("PARTYFACENO")]
        public string PartyFaceNo { get; set; }
        /// <summary>
        /// 家庭出身
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYORIGINNO")]
        public string FamilyOriginNo { get; set; }
        /// <summary>
        /// 民族码
        /// </summary>
        /// <returns></returns>
        [Column("NATIONALITYNO")]
        public string NationalityNo { get; set; }
        /// <summary>
        /// 户口类别
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENCENO")]
        public string ResidenceNo { get; set; }
        /// <summary>
        /// 考生类别
        /// </summary>
        /// <returns></returns>
        [Column("TESTSTUSORTNO")]
        public string TestStuSortNo { get; set; }
        /// <summary>
        /// 健康状况
        /// </summary>
        /// <returns></returns>
        [Column("HEALTHSTATUSNO")]
        public string HealthStatusNo { get; set; }
        /// <summary>
        /// 第几志愿
        /// </summary>
        /// <returns></returns>
        [Column("WILLNO")]
        public string WillNo { get; set; }
        /// <summary>
        /// 考生科类
        /// </summary>
        /// <returns></returns>
        [Column("TESTSTUSUBJECTNO")]
        public string TestStuSubjectNo { get; set; }
        /// <summary>
        /// 本专科
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATENO")]
        public string GraduateNo { get; set; }
        /// <summary>
        /// 计划形式
        /// </summary>
        /// <returns></returns>
        [Column("PLANFORMNO")]
        public string PlanFormNo { get; set; }
        /// <summary>
        /// 高考类别
        /// </summary>
        /// <returns></returns>
        [Column("HIGHTESTSORTNO")]
        public string HighTestSortNo { get; set; }
        /// <summary>
        /// 高考总分
        /// </summary>
        /// <returns></returns>
        [Column("HIGHAMOUNTSCORE")]
        public decimal? HighAmountScore { get; set; }
        /// <summary>
        /// 政治成绩
        /// </summary>
        /// <returns></returns>
        [Column("POLITICSSCORE")]
        public decimal? PoliticsScore { get; set; }
        /// <summary>
        /// 语文成绩
        /// </summary>
        /// <returns></returns>
        [Column("CHINESESCORE")]
        public decimal? ChineseScore { get; set; }
        /// <summary>
        /// 数学成绩
        /// </summary>
        /// <returns></returns>
        [Column("MATHSCORE")]
        public decimal? MathScore { get; set; }
        /// <summary>
        /// 物理成绩
        /// </summary>
        /// <returns></returns>
        [Column("PHYSICSSCORE")]
        public decimal? PhysicsScore { get; set; }
        /// <summary>
        /// 化学成绩
        /// </summary>
        /// <returns></returns>
        [Column("CHEMSCORE")]
        public decimal? ChemScore { get; set; }
        /// <summary>
        /// 生物成绩
        /// </summary>
        /// <returns></returns>
        [Column("BIOLOGYSCORE")]
        public decimal? BiologyScore { get; set; }
        /// <summary>
        /// 外语成绩
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGSCORE")]
        public decimal? ForeignLangScore { get; set; }
        /// <summary>
        /// 外语口试成绩
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGORALSCORE")]
        public decimal? ForeignLangOralScore { get; set; }
        /// <summary>
        /// 外语语种
        /// </summary>
        /// <returns></returns>
        [Column("FOREIGNLANGSPECIES")]
        public string ForeignLangSpecies { get; set; }
        /// <summary>
        /// 三好
        /// </summary>
        /// <returns></returns>
        [Column("ISTHREEGOOD")]
        public string IsThreeGood { get; set; }
        /// <summary>
        /// 优干
        /// </summary>
        /// <returns></returns>
        [Column("ISEXCELLENT")]
        public string IsExcellent { get; set; }
        /// <summary>
        /// 一般学干      干部
        /// </summary>
        /// <returns></returns>
        [Column("ISNORMALCADRE")]
        public string IsNormalCadre { get; set; }
        /// <summary>
        /// 省市前三
        /// </summary>
        /// <returns></returns>
        [Column("ISPROVINCEFIRSTTHREE")]
        public string IsProvinceFirstThree { get; set; }
        /// <summary>
        /// 港澳台侨
        /// </summary>
        /// <returns></returns>
        [Column("OVERSEASCHINESENO")]
        public string OverseasChineseNo { get; set; }
        /// <summary>
        /// 录取类别
        /// </summary>
        /// <returns></returns>
        [Column("MATRICULATESORT")]
        public string MatriculateSort { get; set; }
        /// <summary>
        /// 来源地区码
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENO")]
        public string ProvinceNo { get; set; }
        /// <summary>
        /// 原单位码（原中学）
        /// </summary>
        /// <returns></returns>
        [Column("HIGHSCHOOLNO")]
        public string HighSchoolNo { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        /// <returns></returns>
        [Column("REGIONNO")]
        public string RegionNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// 招生年度
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
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [Column("IDENTITYCARDNO")]
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// 原单位（中学）名
        /// </summary>
        /// <returns></returns>
        [Column("HIGHSCHOOLNAME")]
        public string HighSchoolName { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        /// <returns></returns>
        [Column("GOODAT")]
        public string GoodAt { get; set; }
        /// <summary>
        /// 报到日期
        /// </summary>
        /// <returns></returns>
        [Column("ARRIVEDATE")]
        public DateTime? ArriveDate { get; set; }
        /// <summary>
        /// 档案号
        /// </summary>
        /// <returns></returns>
        [Column("ARCHIVESNO")]
        public string ArchivesNo { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        /// <summary>
        /// 学生来自省
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMPROVINCE")]
        public string StuFromProvince { get; set; }
        /// <summary>
        /// 学生来自市
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMCITY")]
        public string StuFromCity { get; set; }
        /// <summary>
        /// 学生来自区
        /// </summary>
        /// <returns></returns>
        [Column("STUFROMDESTRICT")]
        public string StuFromDestrict { get; set; }
        /// <summary>
        /// 家庭所在省
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYPROVINCE")]
        public string FamliyProvince { get; set; }
        /// <summary>
        /// 家庭所在市
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYCITY")]
        public string FamliyCity { get; set; }
        /// <summary>
        /// 家庭所在区
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYDISTRICT")]
        public string FamliyDistrict { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        /// <returns></returns>
        [Column("FAMILYADDRESS")]
        public string FamilyAddress { get; set; }
        /// <summary>
        /// 是否报到注册
        /// </summary>
        /// <returns></returns>
        [Column("REGISTERSTATUS")]
        public string RegisterStatus { get; set; }
        /// <summary>
        /// MailAddress收件人名址（发录取通知书时使用，从招生数据中导入,对应字段jtdz）
        /// </summary>
        /// <returns></returns>
        [Column("MAILADDRESS")]
        public string MailAddress { get; set; }
        /// <summary>
        /// PostalCode邮政编码(发录取通知书时使用，从招生数据中导入,对应字段yzbm)
        /// </summary>
        /// <returns></returns>
        [Column("POSTALCODE")]
        public string PostalCode { get; set; }
        /// <summary>
        /// TransMark归档标志（1为已归档，0为未归档，对已归档的学生不能进行编辑。
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
        /// 家庭总人数
        /// </summary>
        /// <returns></returns>
        [Column("FAMLIYPEOPLES")]
        public int? FamliyPeoples { get; set; }
        /// <summary>
        /// 头像图片
        /// </summary>
        /// <returns></returns>
        [Column("HEADIMG")]
        public string HeadImg { get; set; }
        /// <summary>
        /// 残疾
        /// </summary>
        /// <returns></returns>
        [Column("DEFORMITY")]
        public string Deformity { get; set; }
        /// <summary>
        /// 单亲
        /// </summary>
        /// <returns></returns>
        [Column("SINGLEPARENT")]
        public string SingleParent { get; set; }
        /// <summary>
        /// 是否结婚
        /// </summary>
        /// <returns></returns>
        [Column("ISMARRY")]
        public string IsMarry { get; set; }
        /// <summary>
        /// 孤儿
        /// </summary>
        /// <returns></returns>
        [Column("ORPHAN")]
        public string Orphan { get; set; }
        /// <summary>
        /// 烈士子女
        /// </summary>
        /// <returns></returns>
        [Column("MARTYRCHILDREN")]
        public string MartyrChildren { get; set; }
        /// <summary>
        /// 低保
        /// </summary>
        /// <returns></returns>
        [Column("BASICLIVINGALLOWANCES")]
        public string BasicLivingAllowances { get; set; }
        /// <summary>
        /// 电话卡是否是本人身份证办理
        /// </summary>
        /// <returns></returns>
        [Column("PHONENOUSEID")]
        public string PhoneNoUseId { get; set; }
        /// <summary>
        /// 家长联系电话手机
        /// </summary>
        /// <returns></returns>
        [Column("PARENTPHONE")]
        public string ParentPhone { get; set; }
        /// <summary>
        /// 家长联系电话座机
        /// </summary>
        /// <returns></returns>
        [Column("PARENTTEL")]
        public string ParentTel { get; set; }
        /// <summary>
        /// 是否毕业
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATION")]
        public string Graduation { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <returns></returns>
        [Column("STUPWD")]
        public string StuPwd { get; set; }
        /// <summary>
        /// 分班标志
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER")]
        public string StuOther { get; set; }
        /// <summary>
        /// 培养类别
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER1")]
        public string StuOther1 { get; set; }
        /// <summary>
        /// 培养对象
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER2")]
        public string StuOther2 { get; set; }
        /// <summary>
        /// 办学类型
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER3")]
        public string StuOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER4")]
        public string StuOther4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER5")]
        public string StuOther5 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER6")]
        public string StuOther6 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER7")]
        public string StuOther7 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER8")]
        public string StuOther8 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("STUOTHER9")]
        public string StuOther9 { get; set; }
        /// <summary>
        /// 通知书打印次数
        /// </summary>
        /// <returns></returns>
        [Column("PRINTNOTICE")]
        public int? PrintNotice { get; set; }
        /// <summary>
        /// 通知书最后打印时间
        /// </summary>
        /// <returns></returns>
        [Column("LastPrintTime")]
        public DateTime? LastPrintTime { get; set; }
        /// <summary>
        /// 谁打印的通知书
        /// </summary>
        /// <returns></returns>
        [Column("WhoPrint")]
        public string WhoPrint { get; set;}
        /// <summary>
        /// 新生报到，0为未报到，1为已报到
        /// </summary>
        /// <returns></returns>
        [Column("NewStuReport")]
        public int NewStuReport { get; set; }

        /// <summary>
        /// 新生报到时间
        /// </summary>
        /// <returns></returns>
        [Column("NewStuReportDatetime")]
        public DateTime? NewStuReportDatetime { get; set; }
        /// <summary>
        /// 归档标志，新生‘未归档’老生“已归档”
        /// </summary>
        /// <returns></returns>
        [Column("GuiDangMark")]
        public string GuiDangMark { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.stuInfoId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.NewStuReport = 0;//默认为未报到
            this.GuiDangMark = "未归档";//表示为新生
            if (this.ArriveDate == null)
            {
                this.ArriveDate = null;
            }
        }
        /// <summary>
        /// 编辑调用
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
        /// 按性别排序
        /// </summary>
        /// <param name="city1"></param>
        /// <param name="city2"></param>
        /// <returns></returns>
        public static int CompareByGender(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.Gender, stuinfo2.Gender);
        }

        /// <summary>
        /// 按学生的省排序
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByProv(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromProvince, stuinfo2.StuFromProvince);
        }
        /// <summary>
        /// 按学生的市排序
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByCity(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromCity, stuinfo2.StuFromCity);
        }
        /// <summary>
        /// 按学生的区排序
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByDest(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            return String.Compare(stuinfo1.StuFromDestrict, stuinfo2.StuFromDestrict);
        }

        /// <summary>
        /// 按成绩排序
        /// </summary>
        /// <param name="stuinfo1"></param>
        /// <param name="stuinfo2"></param>
        /// <returns></returns>
        public static int CompareByScore(BK_StuInfoEntity stuinfo1, BK_StuInfoEntity stuinfo2)
        {
            if (stuinfo1.HighAmountScore > stuinfo2.HighAmountScore) return -1;  //返回-1表示mx被认定排序值小于my,所以排在前面
            else if (stuinfo1.HighAmountScore < stuinfo2.HighAmountScore) return 1; //返回1 表示mx被认定排序值大于my,所以排在后面.
            else return 0;
            //return decimal.Compare(stuinfo1.HighAmountScore.Value, stuinfo2.HighAmountScore.Value);
        }
        /// <summary>
        /// 按民族排序
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