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
    public class M_BK_DormStuInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        [Column("STUNAME")]
        public string StuName { get; set; }
       
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        
        
        /// <summary>
        /// 头像图片
        /// </summary>
        /// <returns></returns>
        [Column("HEADIMG")]
        public string HeadImg { get; set; }

        /// <summary>
        /// 来源地区码
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENO")]
        public string ProvinceNo { get; set; }

        /// <summary>
        /// 民族码
        /// </summary>
        /// <returns></returns>
        [Column("NATIONALITYNO")]
        public string NationalityNo { get; set; }
        /// <summary>
        /// 床位名称
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }

        #endregion

    }
}