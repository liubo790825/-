using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:39
    /// 描 述：会员信息表
    /// </summary>
    public class CommunityMemberInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 会员ID号
        /// </summary>
        /// <returns></returns>
        public string CMI_Id { get; set; }
        /// <summary>
        /// 会员学号
        /// </summary>
        /// <returns></returns>
        public string CMI_StuNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string CMI_StuName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string CMI_Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CMI_Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string CMI_IdNo { get; set; }
        /// <summary>
        /// 相片
        /// </summary>
        /// <returns></returns>
        public string CMI_Photo { get; set; }
        /// <summary>
        /// 系部编号
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptNo { get; set; }
        /// <summary>
        /// 系部名称
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptName { get; set; }
        /// <summary>
        /// 专业编号
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorNo { get; set; }
        /// <summary>
        /// 专业名称
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorName { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassNo { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        public string CMI_Phone { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? CMI_Other3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CMI_Other4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CMI_Other5 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CMI_Other6 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CMI_Other7 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string CMI_Other8 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CMI_Id = Guid.NewGuid().ToString();//根据实际需要去修改
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
                //性别代码为偶数是女性奇数为男性
                if (int.Parse(sex) % 2 == 0)
                {
                    this.CMI_Gender = "女";
                }
                else
                {
                    this.CMI_Gender = "男";
                }
            }
        }
        /// <summary>
        /// 编辑调用
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
                //性别代码为偶数是女性奇数为男性
                if (int.Parse(sex) % 2 == 0)
                {
                    this.CMI_Gender = "女";
                }
                else
                {
                    this.CMI_Gender = "男";
                }
            }
        }
        #endregion
    }
}