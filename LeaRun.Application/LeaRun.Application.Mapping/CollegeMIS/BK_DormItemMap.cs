using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-29 10:34
    /// �� ����BK_DormItem
    /// </summary>
    public class BK_DormItemMap : EntityTypeConfiguration<BK_DormItemEntity>
    {
        public BK_DormItemMap()
        {
            #region ������
            //��
            this.ToTable("BK_DormItem");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
