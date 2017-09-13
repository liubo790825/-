using LeaRun.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-09-08 15:44
    /// 描 述：WF_ProcessNodes
    /// </summary>
    public class WF_ProcessNodesMap : EntityTypeConfiguration<WF_ProcessNodesEntity>
    {
        public WF_ProcessNodesMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_ProcessNodes");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
