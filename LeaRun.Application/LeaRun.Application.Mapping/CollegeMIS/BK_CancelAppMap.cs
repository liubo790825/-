using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-18 15:12
    /// �� �������������¼
    /// </summary>
    public class BK_CancelAppMap : EntityTypeConfiguration<BK_CancelAppEntity>
    {
        public BK_CancelAppMap()
        {
            #region ������
            //��
            this.ToTable("BK_CancelApp");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
