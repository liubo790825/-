using LeaRun.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FormManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:23
    /// �� ������ģ���
    /// </summary>
    public class Form_ModuleMap : EntityTypeConfiguration<Form_ModuleEntity>
    {
        public Form_ModuleMap()
        {
            #region ������
            //��
            this.ToTable("Form_Module");
            //����
            this.HasKey(t => t.FrmId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
