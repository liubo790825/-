using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-09 15:29
    /// 描 述：BK_AdvisoryAnswer
    /// </summary>
    public class BK_AdvisoryAnswerMap : EntityTypeConfiguration<BK_AdvisoryAnswerEntity>
    {
        public BK_AdvisoryAnswerMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_AdvisoryAnswer");
            //主键
            this.HasKey(t => t.AId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
