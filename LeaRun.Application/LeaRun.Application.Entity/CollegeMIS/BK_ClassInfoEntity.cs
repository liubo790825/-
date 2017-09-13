using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:04
    /// 描 述：专业方向
    /// </summary>
    public class BK_ClassInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ClassId
        /// </summary>
        /// <returns></returns>
        [Column("CLASSID")]
        public string ClassId { get; set; }
        /// <summary>
        /// 行政班码
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNO")]
        public string ClassNo { get; set; }
        /// <summary>
        /// 行政班名
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNAME")]
        public string ClassName { get; set; }
        /// <summary>
        /// 系所码
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// 专业码
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// 专业方向号（如0，1，2，3，4，5）      0代表无专业方向细分
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNO")]
        public string MajorDetailNo { get; set; }
        /// <summary>
        /// 专业方向名
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDETAILNAME")]
        public string MajorDetailName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        [Column("GRADE")]
        public string Grade { get; set; }
        /// <summary>
        /// 学生人数
        /// </summary>
        /// <returns></returns>
        [Column("STUNUM")]
        public Int16 StuNum { get; set; }
        /// <summary>
        /// 年级内序号
        /// </summary>
        /// <returns></returns>
        [Column("SERIALNUM")]
        public string SerialNum { get; set; }
        /// <summary>
        /// 班主任职工号
        /// </summary>
        /// <returns></returns>
        [Column("CLASSDIREDCTORNO")]
        public string ClassDiredctorNo { get; set; }
        /// <summary>
        /// 辅导员职工号   
        /// </summary>
        /// <returns></returns>
        [Column("CLASSTUTORNO")]
        public string ClassTutorNo { get; set; }
        /// <summary>
        /// 班级名称全称(根据年级、专业名称、序号自动生成）
        /// </summary>
        /// <returns></returns>
        [Column("CLASSNAMEFULL")]
        public string ClassNameFull { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        /// <returns></returns>
        [Column("CHECKMARK")]
        public int CheckMark { get; set; }
        /// <summary>
        /// 有效
        /// </summary>
        [Column("EnableRemark")]
        public int EnableRemark { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ClassId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.CheckMark = 0;
            this.EnableRemark = 1;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ClassId = keyValue;
                                    
        }
        #endregion
    }
}