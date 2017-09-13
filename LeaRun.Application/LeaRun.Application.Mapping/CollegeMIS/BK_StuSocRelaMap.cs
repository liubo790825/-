using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-06 09:47
    /// 描 述：新生数据导入      报到确认后的学生数据导入到此表中      同时分班（分配班号） 、学号
    /// </summary>
    public class BK_StuSocRelaMap : EntityTypeConfiguration<BK_StuSocRelaEntity>
    {
        public BK_StuSocRelaMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_StuSocRela");
            //主键
            this.HasKey(t => t.StuSocRelaId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
