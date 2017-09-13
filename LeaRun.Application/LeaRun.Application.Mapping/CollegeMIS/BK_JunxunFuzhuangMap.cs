using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin2017-7-21 唐世杰
    /// 日 期：2017-07-21 11:00
    /// 描 述：BK_JunxunFuzhuang
    /// </summary>
    public class BK_JunxunFuzhuangMap : EntityTypeConfiguration<BK_JunxunFuzhuangEntity>
    {
        public BK_JunxunFuzhuangMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_JunxunFuzhuang");
            //主键
            this.HasKey(t => t.FuzhuangId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
