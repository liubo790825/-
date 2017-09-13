using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 10:33
    /// 描 述：社团基本信息表
    /// </summary>
    public class Community_infoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 社团ID号
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// 社团名称
        /// </summary>
        /// <returns></returns>
        public string C_Name { get; set; }
        /// <summary>
        /// 会长或团长或主席
        /// </summary>
        /// <returns></returns>
        public string C_Chairman { get; set; }
        /// <summary>
        /// 社团类型
        /// </summary>
        /// <returns></returns>
        public string C_Type { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        /// <returns></returns>
        public DateTime? C_BuidDate { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        /// <returns></returns>
        public string C_Briefing { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public string C_Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string C_Tel { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? C_Other { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? C_Other1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? C_Other2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public int? C_Other3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string C_Other4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string C_Other5 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string C_Other6 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string C_Other7 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other8 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other9 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other10 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public DateTime? C_Other11 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public bool? C_Other12 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public bool? C_Other13 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public bool? C_Other14 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public bool? C_Other15 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.C_Id = Guid.NewGuid().ToString();//根据实际需要去修改
            this.C_BuidDate = DateTime.Now;  
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.C_Id = keyValue;
                                    
        }
        #endregion
    }
}