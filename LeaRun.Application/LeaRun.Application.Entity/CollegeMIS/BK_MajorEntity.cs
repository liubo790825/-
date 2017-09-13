using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:57
    /// 描 述：系部
    /// </summary>
    public class BK_MajorEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 标识列
        /// </summary>
        /// <returns></returns>
        [Column("MAJORID")]
        public string MajorId { get; set; }
        /// <summary>
        /// 专业代码   现用（3位）
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNO")]
        public string MajorNo { get; set; }
        /// <summary>
        /// 专业名称
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAME")]
        public string MajorName { get; set; }
        /// <summary>
        /// 专业英文名称
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAMEEN")]
        public string MajorNameEn { get; set; }
        /// <summary>
        /// 专业名称简称
        /// </summary>
        /// <returns></returns>
        [Column("MAJORNAMEBRIEF")]
        public string MajorNameBrief { get; set; }
        /// <summary>
        /// 教委专业代码
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNO")]
        public string GovMajorNo { get; set; }
        /// <summary>
        /// 教委专业名称
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNAME")]
        public string GovMajorName { get; set; }
        /// <summary>
        /// 学制
        /// </summary>
        /// <returns></returns>
        [Column("LENGTHOFSCHOOLING")]
        public decimal? LengthOfSchooling { get; set; }
        /// <summary>
        /// 学科门类代码
        /// </summary>
        /// <returns></returns>
        [Column("SUBJECTSPECIESNO")]
        public string SubjectSpeciesNo { get; set; }
        /// <summary>
        /// 系所代码
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// 专业学位代码（学科门类代码）
        /// </summary>
        /// <returns></returns>
        [Column("SUBJECTSPECIESNO1")]
        public string SubjectSpeciesNo1 { get; set; }
        /// <summary>
        /// 本专科代码
        /// </summary>
        /// <returns></returns>
        [Column("GRADUATENO")]
        public string GraduateNo { get; set; }
        /// <summary>
        /// 专业主任
        /// </summary>
        /// <returns></returns>
        [Column("MAJORDIRECTOR")]
        public string MajorDirector { get; set; }
        /// <summary>
        /// 新生用专业标志，如为1即为新生招生中有的专业
        /// </summary>
        /// <returns></returns>
        [Column("FRESHSTUMARK")]
        public int FreshStuMark { get; set; }
        /// <summary>
        /// 审查标志
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
            this.MajorId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.EnableRemark = 1;
            this.FreshStuMark = 1;
            this.CheckMark = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.MajorId = keyValue;
                                    
        }
        #endregion
    }
}