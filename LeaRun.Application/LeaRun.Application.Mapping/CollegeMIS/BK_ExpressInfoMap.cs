using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 14:05
    /// �� ����֪ͨ������Ϣ
    /// </summary>
    public class BK_ExpressInfoMap : EntityTypeConfiguration<BK_ExpressInfoEntity>
    {
        public BK_ExpressInfoMap()
        {
            #region ������
            //��
            this.ToTable("BK_ExpressInfo");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
