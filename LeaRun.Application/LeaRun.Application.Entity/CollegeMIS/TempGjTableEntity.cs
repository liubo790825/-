using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-11-28 15:57
    /// 描 述：TempGjTable
    /// </summary>
    public class TempGjTableEntity : BaseEntity
    {
        #region 实体成员

        /// <summary>
        /// id号
        /// </summary>
        public int Rowid { get; set; }

        /// <summary>
        /// 专业名称
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 专业号
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// 学生数量
        /// </summary>
        /// <returns></returns>
        public int? StuCount { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.TeachBookId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
           // this.TeachBookId = keyValue;
                                    
        }
        #endregion
    }
}