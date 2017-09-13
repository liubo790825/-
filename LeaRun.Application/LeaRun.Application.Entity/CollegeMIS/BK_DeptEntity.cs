using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:54
    /// 描 述：校区
    /// </summary>
    public class BK_DeptEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 系所ID
        /// </summary>
        /// <returns></returns>
        [Column("DEPTID")]
        public string DeptId { get; set; }
        /// <summary>
        /// 校区ID
        /// </summary>
        /// <returns></returns>
        [Column("AREAID")]
        public string AreaId { get; set; }
        /// <summary>
        /// 系所代码（部门号）
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNO")]
        public string DeptNo { get; set; }
        /// <summary>
        /// 系所名称(部门名）
        /// </summary>
        /// <returns></returns>
        [Column("DEPTNAME")]
        public string DeptName { get; set; }
        /// <summary>
        /// 系所（部门）简称   Attr
        /// </summary>
        /// <returns></returns>
        [Column("DEPTSHORTNAME")]
        public string DeptShortName { get; set; }
        /// <summary>
        /// 系所英文简称
        /// </summary>
        /// <returns></returns>
        [Column("DEPTENBRIEF")]
        public string DeptEnBrief { get; set; }
        /// <summary>
        /// 所属科类   只有教学部门才会出现教务、学工等二级操作
        /// </summary>
        /// <returns></returns>
        [Column("DEPTSORT")]
        public string DeptSort { get; set; }
        /// <summary>
        /// 系所英文简称
        /// </summary>
        /// <returns></returns>
        [Column("DEPTENSHORT")]
        public string DeptEnShort { get; set; }
        /// <summary>
        /// 系主任的职工号
        /// </summary>
        /// <returns></returns>
        [Column("DEPTDIRECTOR")]
        public string DeptDirector { get; set; }
        /// <summary>
        /// 教学秘书的职工号
        /// </summary>
        /// <returns></returns>
        [Column("TEACHSECRETARY")]
        public string TeachSecretary { get; set; }
        /// <summary>
        /// 曾用名
        /// </summary>
        /// <returns></returns>
        [Column("DEPTOLDNAME")]
        public string DeptOldName { get; set; }
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
            this.DeptId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.EnableRemark = 1;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DeptId = keyValue;
                                    
        }
        #endregion
    }
}