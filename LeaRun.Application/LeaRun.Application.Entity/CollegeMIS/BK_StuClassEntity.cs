using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public class BK_StuClassEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        [Column("STUCLASSID")]
        public string StuClassId { get; set; }
        /// <summary>
        /// 班级序号
        /// </summary>
        /// <returns></returns>
        [Column("CLASSID")]
        public string ClassId { get; set; }
        /// <summary>
        /// 学生序号
        /// </summary>
        /// <returns></returns>
        [Column("STUINFOID")]
        public string stuInfoId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.StuClassId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.StuClassId = keyValue;
                                    
        }
        #endregion
    }
}