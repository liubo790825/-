using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-10 11:42
    /// �� ����ѧ�����м�¼
    /// </summary>
    public class BK_BehaviorRecodeMap : EntityTypeConfiguration<BK_BehaviorRecodeEntity>
    {
        public BK_BehaviorRecodeMap()
        {
            #region ������
            //��
            this.ToTable("BK_BehaviorRecode");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
