using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-17 10:36
    /// 描 述：高职员工账号生成
    /// </summary>
    public class EmpInfo2LoginUserMap : EntityTypeConfiguration<EmpInfo2LoginUserEntity>
    {
        public EmpInfo2LoginUserMap()
        {
            #region 表、主键
            //表
            this.ToTable("vwEmpInfo");
            //主键
            this.HasKey(t => t.EmpNo);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
