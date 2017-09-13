using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-08 15:14
    /// 描 述：SupplierCheckBooks
    /// </summary>
    public class SupplierCheckBooksEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 
        /// </summary>
        public string checkNo { get; set; }

        /// <summary>
        /// PlanId
        /// </summary>
        /// <returns></returns>
        public int? PlanId { get; set; }
        /// <summary>
        /// College
        /// </summary>
        /// <returns></returns>
        public string College { get; set; }
        /// <summary>
        /// MajorName
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// ClassName
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// StuNum
        /// </summary>
        /// <returns></returns>
        public int? StuNum { get; set; }
        /// <summary>
        /// TeachBook
        /// </summary>
        /// <returns></returns>
        public string TeachBook { get; set; }
        /// <summary>
        /// Author
        /// </summary>
        /// <returns></returns>
        public string Author { get; set; }
        /// <summary>
        /// PubCompany
        /// </summary>
        /// <returns></returns>
        public string PubCompany { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        /// <returns></returns>
        public string ISBN { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.checkNo = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.checkNo = keyValue;
                                    
        }
        #endregion
    }
}