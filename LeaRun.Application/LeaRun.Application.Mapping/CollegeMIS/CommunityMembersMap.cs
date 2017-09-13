using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 23:21
    /// �� ����CommunityMembers
    /// </summary>
    public class CommunityMembersMap : EntityTypeConfiguration<CommunityMembersEntity>
    {
        public CommunityMembersMap()
        {
            #region ������
            //��
            this.ToTable("vwCommunityMembers");
            //����
            this.HasKey(t => t.CM_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
