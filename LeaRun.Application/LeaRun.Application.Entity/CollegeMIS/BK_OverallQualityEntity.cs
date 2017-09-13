using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-07 15:06
    /// 描 述：综合素质内容表
    /// </summary>
    public class BK_OverallQualityEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 学术类型ID号
        /// </summary>
        /// <returns></returns>
        public string AcademicTypeId { get; set; }
        /// <summary>
        /// 学术名称
        /// </summary>
        /// <returns></returns>
        public string AcademicTypeName { get; set; }
        /// <summary>
        /// 综合素质编号
        /// </summary>
        /// <returns></returns>
        public string AcademicNumber { get; set; }
        /// <summary>
        /// 题目
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// 主讲人
        /// </summary>
        /// <returns></returns>
        public string Speaker { get; set; }
        /// <summary>
        /// 开讲时间
        /// </summary>
        /// <returns></returns>
        public DateTime? RunTime { get; set; }
        /// <summary>
        /// 举办单位
        /// </summary>
        /// <returns></returns>
        public string UnitName { get; set; }
        /// <summary>
        /// 讲座地点
        /// </summary>
        /// <returns></returns>
        public string RunAddress { get; set; }
        /// <summary>
        /// 删除标示
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 主要内容、主要观点与结论
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        /// <summary>
        /// Other
        /// </summary>
        /// <returns></returns>
        public string Other { get; set; }
        /// <summary>
        /// Other1
        /// </summary>
        /// <returns></returns>
        public string Other1 { get; set; }
        /// <summary>
        /// Other2
        /// </summary>
        /// <returns></returns>
        public string Other2 { get; set; }
        /// <summary>
        /// Other3
        /// </summary>
        /// <returns></returns>
        public string Other3 { get; set; }
        /// <summary>
        /// Other4
        /// </summary>
        /// <returns></returns>
        public string Other4 { get; set; }
        /// <summary>
        /// Other5
        /// </summary>
        /// <returns></returns>
        public string Other5 { get; set; }
        /// <summary>
        /// Other6
        /// </summary>
        /// <returns></returns>
        public string Other6 { get; set; }
        /// <summary>
        /// Other7
        /// </summary>
        /// <returns></returns>
        public string Other7 { get; set; }
        /// <summary>
        /// Other8
        /// </summary>
        /// <returns></returns>
        public string Other8 { get; set; }
        /// <summary>
        /// Other9
        /// </summary>
        /// <returns></returns>
        public string Other9 { get; set; }
        /// <summary>
        /// Other10
        /// </summary>
        /// <returns></returns>
        public string Other10 { get; set; }
        /// <summary>
        /// Other11
        /// </summary>
        /// <returns></returns>
        public string Other11 { get; set; }
        /// <summary>
        /// Other12
        /// </summary>
        /// <returns></returns>
        public string Other12 { get; set; }
        /// <summary>
        /// Other13
        /// </summary>
        /// <returns></returns>
        public string Other13 { get; set; }
        /// <summary>
        /// Other14
        /// </summary>
        /// <returns></returns>
        public string Other14 { get; set; }
        /// <summary>
        /// Other15
        /// </summary>
        /// <returns></returns>
        public string Other15 { get; set; }
        /// <summary>
        /// Other16
        /// </summary>
        /// <returns></returns>
        public int? Other16 { get; set; }
        /// <summary>
        /// Other17
        /// </summary>
        /// <returns></returns>
        public int? Other17 { get; set; }
        /// <summary>
        /// Other18
        /// </summary>
        /// <returns></returns>
        public DateTime? Other18 { get; set; }
        /// <summary>
        /// Other19
        /// </summary>
        /// <returns></returns>
        public DateTime? Other19 { get; set; }
        /// <summary>
        /// Other120
        /// </summary>
        /// <returns></returns>
        public DateTime? Other120 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.EnabledMark = 1;//有效标记
            this.DeleteMark = 0;//删除标记
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

        }
        #endregion
    }
}