using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:39
    /// �� ������Ա��Ϣ��
    /// </summary>
    public class CommunityMemberInfoMap : EntityTypeConfiguration<CommunityMemberInfoEntity>
    {
        public CommunityMemberInfoMap()
        {
            #region ������
            //��
            this.ToTable("Community_Member_Info");
            //����
            this.HasKey(t => t.CMI_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
