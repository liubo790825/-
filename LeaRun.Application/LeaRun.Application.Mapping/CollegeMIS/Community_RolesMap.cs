using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:37
    /// �� �������Ž�ɫ
    /// </summary>
    public class Community_RolesMap : EntityTypeConfiguration<Community_RolesEntity>
    {
        public Community_RolesMap()
        {
            #region ������
            //��
            this.ToTable("Community_Roles");
            //����
            this.HasKey(t => t.CR_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
