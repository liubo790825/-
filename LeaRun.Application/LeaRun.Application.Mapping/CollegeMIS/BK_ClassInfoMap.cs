using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:04
    /// �� ����רҵ����
    /// </summary>
    public class BK_ClassInfoMap : EntityTypeConfiguration<BK_ClassInfoEntity>
    {
        public BK_ClassInfoMap()
        {
            #region ������
            //��
            this.ToTable("BK_ClassInfo");
            //����
            this.HasKey(t => t.ClassId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
