using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 15:14
    /// �� ����SupplierCheckBooks
    /// </summary>
    public class SupplierCheckBooksEntity : BaseEntity
    {
        #region ʵ���Ա
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

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.checkNo = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.checkNo = keyValue;
                                    
        }
        #endregion
    }
}