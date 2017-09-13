using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-07-19 16:33
    /// 描 述：报到流程授权表
    /// </summary>
    public class BK_AuthorizeNewStuRegFlowMap : EntityTypeConfiguration<BK_AuthorizeNewStuRegFlowEntity>
    {
        public BK_AuthorizeNewStuRegFlowMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_AuthorizeNewStuRegFlow");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
