using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-13 12:14
    /// 描 述：教工生成账户
    /// </summary>
    public class EmpInfo2AccountMap : EntityTypeConfiguration<EmpInfo2AccountEntity>
    {
        public EmpInfo2AccountMap()
        {
            #region 表、主键
            //表
            this.ToTable("EmpInfo");
            //主键
            this.HasKey(t => t.EmpID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
