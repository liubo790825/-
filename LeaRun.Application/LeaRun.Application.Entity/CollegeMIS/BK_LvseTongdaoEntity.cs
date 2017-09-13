using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-07 10:07
    /// 描 述：BK_LvseTongdao
    /// </summary>
    public class BK_LvseTongdaoEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string LvseId { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        /// <returns></returns>
        public string StuInfoId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 户籍类别
        /// </summary>
        /// <returns></returns>
        public string HujiLeibie { get; set; }
        /// <summary>
        /// 家庭类型
        /// </summary>
        /// <returns></returns>
        public string FamilyType { get; set; }
        /// <summary>
        /// 姓名1
        /// </summary>
        /// <returns></returns>
        public string Name1 { get; set; }
        /// <summary>
        /// 关系1
        /// </summary>
        /// <returns></returns>
        public string Relationship1 { get; set; }
        /// <summary>
        /// 政治面貌1
        /// </summary>
        /// <returns></returns>
        public string ZhengZhiMianMao1 { get; set; }
        /// <summary>
        /// 工作单位1
        /// </summary>
        /// <returns></returns>
        public string GongZuoDanWei1 { get; set; }
        /// <summary>
        /// 职位1
        /// </summary>
        /// <returns></returns>
        public string Position1 { get; set; }
        /// <summary>
        /// 姓名2
        /// </summary>
        /// <returns></returns>
        public string Name2 { get; set; }
        /// <summary>
        /// 关系2
        /// </summary>
        /// <returns></returns>
        public string Relationship2 { get; set; }
        /// <summary>
        /// 政治面貌2
        /// </summary>
        /// <returns></returns>
        public string ZhengZhiMianMao2 { get; set; }
        /// <summary>
        /// 工作单位2
        /// </summary>
        /// <returns></returns>
        public string GongZuoDanWei2 { get; set; }
        /// <summary>
        /// 职位2
        /// </summary>
        /// <returns></returns>
        public string Position2 { get; set; }
        /// <summary>
        /// 家庭总人数
        /// </summary>
        /// <returns></returns>
        public int? FamilyNumber { get; set; }
        /// <summary>
        /// 家庭月收入
        /// </summary>
        /// <returns></returns>
        public int? FamilyMonthIncome { get; set; }
        /// <summary>
        /// 人均月收入
        /// </summary>
        /// <returns></returns>
        public int? OneMonthIncome { get; set; }
        /// <summary>
        /// 家庭经济困难说明
        /// </summary>
        /// <returns></returns>
        public string JingjiKunnan { get; set; }
        /// <summary>
        /// 生源地贷款银行
        /// </summary>
        /// <returns></returns>
        public string LoanBank { get; set; }
        /// <summary>
        /// 贷款金额
        /// </summary>
        /// <returns></returns>
        public int? LoanAmount { get; set; }
        /// <summary>
        /// 回执单或证明函件图片
        /// </summary>
        /// <returns></returns>
        public string ProveImg { get; set; }
        /// <summary>
        /// 国开行回执校验码
        /// </summary>
        /// <returns></returns>
        public string HuiZhiMa { get; set; }
        /// <summary>
        /// 提交日期
        /// </summary>
        /// <returns></returns>
        public string LvseOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string LvseOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string LvseOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string LvseOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string LvseOther4 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.LvseId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.LvseId = keyValue;
                                    
        }
        #endregion
    }
}