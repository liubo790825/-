using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public class BK_StuClassMap : EntityTypeConfiguration<BK_StuClassEntity>
    {
        public BK_StuClassMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_StuClass");
            //主键
            this.HasKey(t => t.StuClassId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
