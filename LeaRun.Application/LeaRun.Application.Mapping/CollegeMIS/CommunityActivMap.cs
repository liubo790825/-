using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 23:13
    /// �� ����CommunityActiv
    /// </summary>
    public class CommunityActivMap : EntityTypeConfiguration<CommunityActivEntity>
    {
        public CommunityActivMap()
        {
            #region ������
            //��
            this.ToTable("vwCommunityActiv");
            //����
            this.HasKey(t => t.CA_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
