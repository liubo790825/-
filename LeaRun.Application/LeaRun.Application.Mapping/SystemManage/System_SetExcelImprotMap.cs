using LeaRun.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.SystemManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-12 11:00
    /// 描 述：数据导入
    /// </summary>
    public class System_SetExcelImprotMap : EntityTypeConfiguration<System_SetExcelImprotEntity>
    {
        public System_SetExcelImprotMap()
        {
            #region 表、主键
            //表
            this.ToTable("System_SetExcelImprot");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
