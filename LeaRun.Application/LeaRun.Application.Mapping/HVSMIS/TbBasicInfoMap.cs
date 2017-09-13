using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-08 11:06
    /// 描 述：教材基本信息（教材编号、教材名称、教材作者、版别、出版社、单价、优秀获奖教材、高职高专、教材ISBN、备注、类别、出版（印刷）时间、库存数量、书架号、初始量(针对印刷材料)）
    /// </summary>
    public class TbBasicInfoMap : EntityTypeConfiguration<TbBasicInfoEntity>
    {
        public TbBasicInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("TbBasicInfo");
            //主键
            this.HasKey(t => t.TeachBookId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
