using LeaRun.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 11:00
    /// �� �������ݵ���
    /// </summary>
    public class ExcelImportTemplateMap : EntityTypeConfiguration<ExcelImportTemplateEntity>
    {
        public ExcelImportTemplateMap()
        {
            #region ������
            //��
            this.ToTable("ExcelImportTemplate");
            //����
            this.HasKey(t => t.F_ExcelImportTemplateId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
