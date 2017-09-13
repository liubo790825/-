using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-12 11:41
    /// 描 述：毕业生基本信息
    /// </summary>
    public class StuInfoGraduateEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 学生ID
        /// </summary>
        /// <returns></returns>
        public int? Id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 准考证号
        /// </summary>
        /// <returns></returns>
        public string zkzhao { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 曾用名
        /// </summary>
        /// <returns></returns>
        public string OldName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string sfzhao { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        /// <returns></returns>
        public string Nation { get; set; }
        /// <summary>
        /// 校区名称
        /// </summary>
        /// <returns></returns>
        public string SchoolArea { get; set; }
        /// <summary>
        /// 系部名称
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 专业代号
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 班级代号
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// 专业级别
        /// </summary>
        /// <returns></returns>
        public string gzjgong { get; set; }
        /// <summary>
        /// 学制
        /// </summary>
        /// <returns></returns>
        public string xzhi { get; set; }
        /// <summary>
        /// 入学时间
        /// </summary>
        /// <returns></returns>
        public DateTime? rxsjian { get; set; }
        /// <summary>
        /// 第几级
        /// </summary>
        /// <returns></returns>
        public string InSchoolYear { get; set; }
        /// <summary>
        /// 毕业年
        /// </summary>
        /// <returns></returns>
        public string OutSchoolYear { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        /// <returns></returns>
        public string CultureDegree { get; set; }
        /// <summary>
        /// 省市
        /// </summary>
        /// <returns></returns>
        public string Province { get; set; }
        /// <summary>
        /// 县市区
        /// </summary>
        /// <returns></returns>
        public string xsqu { get; set; }
        /// <summary>
        /// 考生情况
        /// </summary>
        /// <returns></returns>
        public string ksqkuang { get; set; }
        /// <summary>
        /// 报考类别
        /// </summary>
        /// <returns></returns>
        public string bklbie { get; set; }
        /// <summary>
        /// 入学类别
        /// </summary>
        /// <returns></returns>
        public string rxlb { get; set; }
        /// <summary>
        /// 原毕业学校
        /// </summary>
        /// <returns></returns>
        public string ybyxx { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        /// <returns></returns>
        public string PartyFace { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        /// <returns></returns>
        public string jguan { get; set; }
        /// <summary>
        /// 面试
        /// </summary>
        /// <returns></returns>
        public float? mshi { get; set; }
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public float? cshi { get; set; }
        /// <summary>
        /// 体侧
        /// </summary>
        /// <returns></returns>
        public float? tce { get; set; }
        /// <summary>
        /// 语数
        /// </summary>
        /// <returns></returns>
        public float? yshu { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        /// <returns></returns>
        public string xxing { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        /// <returns></returns>
        public decimal? sgao { get; set; }
        /// <summary>
        /// 实习区域
        /// </summary>
        /// <returns></returns>
        public string PracRegion { get; set; }
        /// <summary>
        /// 实习单位
        /// </summary>
        /// <returns></returns>
        public string PracUnit { get; set; }
        /// <summary>
        /// 实习开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime? PracStartDate { get; set; }
        /// <summary>
        /// 实习类型
        /// </summary>
        /// <returns></returns>
        public string PracType { get; set; }
        /// <summary>
        /// 实习状态
        /// </summary>
        /// <returns></returns>
        public string PracStatus { get; set; }
        /// <summary>
        /// 实习次数
        /// </summary>
        /// <returns></returns>
        public int? PracTimes { get; set; }
        /// <summary>
        /// 毕业总评
        /// </summary>
        /// <returns></returns>
        public string byzping { get; set; }
        /// <summary>
        /// 专业课程
        /// </summary>
        /// <returns></returns>
        public string zykcheng { get; set; }
        /// <summary>
        /// 毕业时间
        /// </summary>
        /// <returns></returns>
        public DateTime? bysjian { get; set; }
        /// <summary>
        /// 毕业去向
        /// </summary>
        /// <returns></returns>
        public string byqxiang { get; set; }
        /// <summary>
        /// 工种鉴定证书信息
        /// </summary>
        /// <returns></returns>
        public string GzjdInfo { get; set; }
        /// <summary>
        /// 再安置意向
        /// </summary>
        /// <returns></returns>
        public string zazyxiang { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        /// <returns></returns>
        public string yhtchang { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        /// <returns></returns>
        public string zwu { get; set; }
        /// <summary>
        /// 健康状况
        /// </summary>
        /// <returns></returns>
        public string jkzkuang { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        /// <returns></returns>
        public string hkszdi { get; set; }
        /// <summary>
        /// 户口类别
        /// </summary>
        /// <returns></returns>
        public string hklbie { get; set; }
        /// <summary>
        /// 家庭通讯地址
        /// </summary>
        /// <returns></returns>
        public string txdzhi { get; set; }
        /// <summary>
        /// 家庭邮政编码
        /// </summary>
        /// <returns></returns>
        public string yzbma { get; set; }
        /// <summary>
        /// 家庭电话号码
        /// </summary>
        /// <returns></returns>
        public string dhhma { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        public string lxren { get; set; }
        /// <summary>
        /// 家庭出身
        /// </summary>
        /// <returns></returns>
        public string jtcsheng { get; set; }
        /// <summary>
        /// 派遣时间
        /// </summary>
        /// <returns></returns>
        public DateTime? pqsjian { get; set; }
        /// <summary>
        /// 派遣证号
        /// </summary>
        /// <returns></returns>
        public string pqzhao { get; set; }
        /// <summary>
        /// 毕业证号
        /// </summary>
        /// <returns></returns>
        public string byzhao { get; set; }
        /// <summary>
        /// 父姓名
        /// </summary>
        /// <returns></returns>
        public string fxming { get; set; }
        /// <summary>
        /// 父单位
        /// </summary>
        /// <returns></returns>
        public string fdwei { get; set; }
        /// <summary>
        /// 父职务
        /// </summary>
        /// <returns></returns>
        public string fzwu { get; set; }
        /// <summary>
        /// 父电话
        /// </summary>
        /// <returns></returns>
        public string fdhua { get; set; }
        /// <summary>
        /// 母姓名
        /// </summary>
        /// <returns></returns>
        public string mxming { get; set; }
        /// <summary>
        /// 母单位
        /// </summary>
        /// <returns></returns>
        public string mdwei { get; set; }
        /// <summary>
        /// 母职务
        /// </summary>
        /// <returns></returns>
        public string mzwu { get; set; }
        /// <summary>
        /// 母电话
        /// </summary>
        /// <returns></returns>
        public string mdhua { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        public string lxdhua { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        /// <returns></returns>
        public string qqnumber { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        /// <returns></returns>
        public string BankNo { get; set; }
        /// <summary>
        /// 家庭总收入
        /// </summary>
        /// <returns></returns>
        public string zongsru { get; set; }
        /// <summary>
        /// 人均收入
        /// </summary>
        /// <returns></returns>
        public string junsru { get; set; }
        /// <summary>
        /// 是否低保
        /// </summary>
        /// <returns></returns>
        public string dibao { get; set; }
        /// <summary>
        /// 收入来源
        /// </summary>
        /// <returns></returns>
        public string srlyuan { get; set; }
        /// <summary>
        /// 助学金标志
        /// </summary>
        /// <returns></returns>
        public string StipendMark { get; set; }
        /// <summary>
        /// 一卡通号
        /// </summary>
        /// <returns></returns>
        public string ykthao { get; set; }
        /// <summary>
        /// 一卡通账号
        /// </summary>
        /// <returns></returns>
        public string yktzhao { get; set; }
        /// <summary>
        /// 住宿信息
        /// </summary>
        /// <returns></returns>
        public string DormInfo { get; set; }
        /// <summary>
        /// 奖励信息
        /// </summary>
        /// <returns></returns>
        public string PrizeInfo { get; set; }
        /// <summary>
        /// 处分信息
        /// </summary>
        /// <returns></returns>
        public string PunishInfo { get; set; }
        /// <summary>
        /// 图书借阅信息
        /// </summary>
        /// <returns></returns>
        public string BooksLend { get; set; }
        /// <summary>
        /// 欠费信息
        /// </summary>
        /// <returns></returns>
        public string OweFeeInfo { get; set; }
        /// <summary>
        /// 简历
        /// </summary>
        /// <returns></returns>
        public string jli { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string bzhu { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string Col1 { get; set; }
        /// <summary>
        /// 备用2
        /// </summary>
        /// <returns></returns>
        public string Col2 { get; set; }
        /// <summary>
        /// 备用3
        /// </summary>
        /// <returns></returns>
        public string Col3 { get; set; }
        /// <summary>
        /// shbzhi
        /// </summary>
        /// <returns></returns>
        public string shbzhi { get; set; }
        /// <summary>
        /// lxing
        /// </summary>
        /// <returns></returns>
        public string lxing { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = 1;// Guid.NewGuid().ToString();//根据实际需要去修改
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.Id = keyValue;
                                            }
        #endregion
    }
}