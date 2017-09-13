using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-01-20 23:21
    /// 描 述：校友活动
    /// </summary>
    public class Alumni_EventsEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID号
        /// </summary>
        /// <returns></returns>
        public string AE_Id { get; set; }
        /// <summary>
        /// 活动主题
        /// </summary>
        /// <returns></returns>
        public string AE_Title { get; set; }
        /// <summary>
        /// 活动详细内容
        /// </summary>
        /// <returns></returns>
        public string AE_Content { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime? AE_BeginDate { get; set; }
        /// <summary>
        /// AE_Other
        /// </summary>
        /// <returns></returns>
        public string AE_Other { get; set; }
        /// <summary>
        /// AE_Other1
        /// </summary>
        /// <returns></returns>
        public string AE_Other1 { get; set; }
        /// <summary>
        /// AE_Other2
        /// </summary>
        /// <returns></returns>
        public string AE_Other2 { get; set; }
        /// <summary>
        /// AE_Other3
        /// </summary>
        /// <returns></returns>
        public string AE_Other3 { get; set; }
        /// <summary>
        /// AE_Other4
        /// </summary>
        /// <returns></returns>
        public string AE_Other4 { get; set; }
        /// <summary>
        /// AE_Other5
        /// </summary>
        /// <returns></returns>
        public string AE_Other5 { get; set; }
        /// <summary>
        /// AE_Other6
        /// </summary>
        /// <returns></returns>
        public string AE_Other6 { get; set; }
        /// <summary>
        /// AE_Other7
        /// </summary>
        /// <returns></returns>
        public string AE_Other7 { get; set; }
        /// <summary>
        /// AE_Other8
        /// </summary>
        /// <returns></returns>
        public string AE_Other8 { get; set; }
        /// <summary>
        /// AE_Other9
        /// </summary>
        /// <returns></returns>
        public string AE_Other9 { get; set; }
        /// <summary>
        /// AE_Other10
        /// </summary>
        /// <returns></returns>
        public string AE_Other10 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.AE_Id = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AE_Id = keyValue;
                                    
        }
        #endregion
    }
}