using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-02 13:54
    /// 描 述：BK_Advisory
    /// </summary>
    public class BK_AdvisoryEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string QAId { get; set; }
        /// <summary>
        /// 学生信息ID
        /// </summary>
        /// <returns></returns>
        public string stuInfoId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 问题
        /// </summary>
        /// <returns></returns>
        public string Questions { get; set; }
        /// <summary>
        /// 回答
        /// </summary>
        /// <returns></returns>
        public string Answer { get; set; }
        /// <summary>
        /// 身份证号
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
        /// <summary>
        /// 回答时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Atime { get; set; }
        /// <summary>
        /// 提问时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Qtime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.QAId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.QAId = keyValue;
                                    
        }
        #endregion
    }
}