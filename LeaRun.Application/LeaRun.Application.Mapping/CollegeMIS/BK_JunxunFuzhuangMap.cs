using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin2017-7-21 ������
    /// �� �ڣ�2017-07-21 11:00
    /// �� ����BK_JunxunFuzhuang
    /// </summary>
    public class BK_JunxunFuzhuangMap : EntityTypeConfiguration<BK_JunxunFuzhuangEntity>
    {
        public BK_JunxunFuzhuangMap()
        {
            #region ������
            //��
            this.ToTable("BK_JunxunFuzhuang");
            //����
            this.HasKey(t => t.FuzhuangId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
