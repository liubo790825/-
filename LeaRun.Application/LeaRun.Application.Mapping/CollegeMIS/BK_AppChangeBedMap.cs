using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 12:29
    /// �� ������������
    /// </summary>
    public class BK_AppChangeBedMap : EntityTypeConfiguration<BK_AppChangeBedEntity>
    {
        public BK_AppChangeBedMap()
        {
            #region ������
            //��
            this.ToTable("BK_AppChangeBed");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
