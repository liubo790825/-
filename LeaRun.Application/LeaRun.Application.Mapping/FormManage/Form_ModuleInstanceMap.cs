using LeaRun.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FormManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-25 14:28
    /// 描 述：表单实例表
    /// </summary>
    public class Form_ModuleInstanceMap : EntityTypeConfiguration<Form_ModuleInstanceEntity>
    {
        public Form_ModuleInstanceMap()
        {
            #region 表、主键
            //表
            this.ToTable("Form_ModuleInstance");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
