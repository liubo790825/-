using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-05 11:34
    /// 描 述：InfoMajor
    /// </summary>
    public class InfoMajorEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// MajorId
        /// </summary>
        /// <returns></returns>
        public int? MajorId { get; set; }
        /// <summary>
        /// MajorCode
        /// </summary>
        /// <returns></returns>
        public string MajorCode { get; set; }
        /// <summary>
        /// MajorName
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// LengthOfSchooling
        /// </summary>
        /// <returns></returns>
        public int? LengthOfSchooling { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.MajorId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.MajorId = keyValue;
                                    
        }
        #endregion
    }
}