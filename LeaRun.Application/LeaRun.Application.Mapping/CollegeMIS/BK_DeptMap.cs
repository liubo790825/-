using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:54
    /// �� ����У��
    /// </summary>
    public class BK_DeptMap : EntityTypeConfiguration<BK_DeptEntity>
    {
        public BK_DeptMap()
        {
            #region ������
            //��
            this.ToTable("BK_Dept");
            //����
            this.HasKey(t => t.DeptId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
