using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-28 09:24
    /// �� ��������������¼
    /// </summary>
    public class BK_RateDormLevelMap : EntityTypeConfiguration<BK_RateDormLevelEntity>
    {
        public BK_RateDormLevelMap()
        {
            #region ������
            //��
            this.ToTable("BK_RateDormLevel");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
