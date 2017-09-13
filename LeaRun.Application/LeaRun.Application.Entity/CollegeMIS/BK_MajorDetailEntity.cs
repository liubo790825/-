using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:03
    /// 描 述：专业
    /// </summary>
    public class BK_MajorDetailEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 标识列
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 专业代码      现用（3位）
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
        /// 专业方向号（如0，1，2，3，4，5）   0代表无专业方向细分
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
        /// 教委专业代码
        /// </summary>
        /// <returns></returns>
        [Column("GOVMAJORNO")]
        public string GovMajorNo { get; set; }
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
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
            this.EnableRemark = 1;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
                                    
        }
        #endregion
    }
}