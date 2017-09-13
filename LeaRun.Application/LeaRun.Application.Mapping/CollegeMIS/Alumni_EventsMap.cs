using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-01-20 23:21
    /// 描 述：校友活动
    /// </summary>
    public class Alumni_EventsMap : EntityTypeConfiguration<Alumni_EventsEntity>
    {
        public Alumni_EventsMap()
        {
            #region 表、主键
            //表
            this.ToTable("Alumni_Events");
            //主键
            this.HasKey(t => t.AE_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
