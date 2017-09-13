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
    public class BK_StuSocRelaEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        [Column("STUSOCRELAID")]
        public string StuSocRelaId { get; set; }
        /// <summary>
        /// 学生ID号
        /// </summary>
        /// <returns></returns>
        [Column("STUINFOID")]
        public string stuInfoId { get; set; }
        /// <summary>
        /// 成员姓名
        /// </summary>
        /// <returns></returns>
        [Column("SOCRELANAME")]
        public string SocRelaName { get; set; }
        /// <summary>
        /// 成员类型
        /// </summary>
        /// <returns></returns>
        [Column("RELATYPE")]
        public string RelaType { get; set; }
        /// <summary>
        /// 与学生的关系
        /// </summary>
        /// <returns></returns>
        [Column("STURELA")]
        public string StuRela { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <returns></returns>
        [Column("AGE")]
        public int? Age { get; set; }
        /// <summary>
        /// 工作（学习）单位
        /// </summary>
        /// <returns></returns>
        [Column("WORKPLACE")]
        public string WorkPlace { get; set; }
        /// <summary>
        /// 工作名称
        /// </summary>
        /// <returns></returns>
        [Column("WORKNAME")]
        public string WorkName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [Column("SOCRELAIDNO")]
        public string SocRelaIdNo { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        [Column("SOCRELAPHONE")]
        public string SocRelaPhone { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("SOCRELAOTHER")]
        public string SocRelaOther { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.StuSocRelaId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.StuSocRelaId = keyValue;
                                    
        }
        #endregion
    }
}