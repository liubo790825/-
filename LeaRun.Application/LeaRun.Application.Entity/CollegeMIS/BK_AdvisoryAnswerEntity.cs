using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-09 15:29
    /// 描 述：BK_AdvisoryAnswer
    /// </summary>
    public class BK_AdvisoryAnswerEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string AId { get; set; }
        /// <summary>
        /// 学生信息ID
        /// </summary>
        /// <returns></returns>
        public string stuInfoId { get; set; }
        /// <summary>
        /// 回复
        /// </summary>
        /// <returns></returns>
        public string Answer { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Atime { get; set; }
        /// <summary>
        /// QAOther1
        /// </summary>
        /// <returns></returns>
        public string QAOther1 { get; set; }
        /// <summary>
        /// QAOther2
        /// </summary>
        /// <returns></returns>
        public string QAOther2 { get; set; }
        /// <summary>
        /// QAOther3
        /// </summary>
        /// <returns></returns>
        public string QAOther3 { get; set; }
        /// <summary>
        /// QAOther4
        /// </summary>
        /// <returns></returns>
        public string QAOther4 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.AId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AId = keyValue;
                                    
        }
        #endregion
    }
}