using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:41
    /// �� �������Ż�Ա��
    /// </summary>
    public class Community_MembersMap : EntityTypeConfiguration<Community_MembersEntity>
    {
        public Community_MembersMap()
        {
            #region ������
            //��
            this.ToTable("Community_Members");
            //����
            this.HasKey(t => t.CM_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
