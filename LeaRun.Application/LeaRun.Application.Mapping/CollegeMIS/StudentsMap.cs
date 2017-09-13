using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-25 09:43
    /// 描 述：Students
    /// </summary>
    public class StudentsMap : EntityTypeConfiguration<StudentsEntity>
    {
        public StudentsMap()
        {
            #region 表、主键
            //表
            this.ToTable("vwStuInfoBasic");
            //主键
            this.HasKey(t => t.StuNo);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
