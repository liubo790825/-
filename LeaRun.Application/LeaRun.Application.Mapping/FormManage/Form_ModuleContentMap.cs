using LeaRun.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FormManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:27
    /// �� ������ģ�����ݱ�
    /// </summary>
    public class Form_ModuleContentMap : EntityTypeConfiguration<Form_ModuleContentEntity>
    {
        public Form_ModuleContentMap()
        {
            #region ������
            //��
            this.ToTable("Form_ModuleContent");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
