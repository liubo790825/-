using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-08 11:06
    /// 描 述：教材基本信息（教材编号、教材名称、教材作者、版别、出版社、单价、优秀获奖教材、高职高专、教材ISBN、备注、类别、出版（印刷）时间、库存数量、书架号、初始量(针对印刷材料)）
    /// </summary>
    public class TbBasicInfoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 教材编号
        /// </summary>
        /// <returns></returns>
        public int? TeachBookId { get; set; }
        /// <summary>
        /// 教材名称
        /// </summary>
        /// <returns></returns>
        public string TeachBook { get; set; }
        /// <summary>
        /// 教材作者
        /// </summary>
        /// <returns></returns>
        public string Author { get; set; }
        /// <summary>
        /// 版别
        /// </summary>
        /// <returns></returns>
        public string Version { get; set; }
        /// <summary>
        /// 出版社 （关联表CdPubCompany)
        /// </summary>
        /// <returns></returns>
        public string PubCompany { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        public decimal? Price { get; set; }
        /// <summary>
        /// 优秀获奖教材(1为优秀获奖教材，0不是）
        /// </summary>
        /// <returns></returns>
        public string IsExcellent { get; set; }
        /// <summary>
        /// 高职高专(1为高职高专教材，0不是）
        /// </summary>
        /// <returns></returns>
        public string IsProfessional { get; set; }
        /// <summary>
        /// 教材ISBN
        /// </summary>
        /// <returns></returns>
        public string ISBN { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// CheckMark
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// PublishDate
        /// </summary>
        /// <returns></returns>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// 教材类别（分为正规教材、自编教材、印刷材料）
        /// </summary>
        /// <returns></returns>
        public string Sort { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        /// <returns></returns>
        public int? StockSum { get; set; }
        /// <summary>
        /// 书架号
        /// </summary>
        /// <returns></returns>
        public string BookCaseNo { get; set; }
        /// <summary>
        /// 印刷时间（自编教材）
        /// </summary>
        /// <returns></returns>
        public DateTime? PressDate { get; set; }
        /// <summary>
        /// 印刷数量（自编教材初始印刷数量）
        /// </summary>
        /// <returns></returns>
        public int? PressSum { get; set; }
        /// <summary>
        /// 教材、自编教材（资料）内容说明
        /// </summary>
        /// <returns></returns>
        public string Detail { get; set; }
        /// <summary>
        /// DeptNo
        /// </summary>
        /// <returns></returns>
        public string DeptNo { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.TeachBookId = 1;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.TeachBookId = keyValue;
                                    
        }
        #endregion
    }
}