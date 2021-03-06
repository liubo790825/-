using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public class BK_DormMap : EntityTypeConfiguration<BK_DormEntity>
    {
        public BK_DormMap()
        {
            #region 表、主键
            //表
            this.ToTable("BK_Dorm");
            //主键
            this.HasKey(t => t.DormId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
