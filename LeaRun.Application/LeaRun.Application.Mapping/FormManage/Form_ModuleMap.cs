using LeaRun.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FormManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-25 14:23
    /// 描 述：表单模板表
    /// </summary>
    public class Form_ModuleMap : EntityTypeConfiguration<Form_ModuleEntity>
    {
        public Form_ModuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("Form_Module");
            //主键
            this.HasKey(t => t.FrmId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
