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
    public class BK_SchoolAreaMap : EntityTypeConfiguration<BK_SchoolAreaEntity>
    {
        public BK_SchoolAreaMap()
        {
            #region ������
            //��
            this.ToTable("BK_SchoolArea");
            //����
            this.HasKey(t => t.AreaId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
