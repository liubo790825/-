using LeaRun.Application.Entity.FormManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FormManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:31
    /// �� ������������
    /// </summary>
    public class Form_ModuleRelationMap : EntityTypeConfiguration<Form_ModuleRelationEntity>
    {
        public Form_ModuleRelationMap()
        {
            #region ������
            //��
            this.ToTable("Form_ModuleRelation");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
