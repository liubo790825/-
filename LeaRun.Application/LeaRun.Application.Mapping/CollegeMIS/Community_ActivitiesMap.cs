using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:44
    /// �� �������Ż��
    /// </summary>
    public class Community_ActivitiesMap : EntityTypeConfiguration<Community_ActivitiesEntity>
    {
        public Community_ActivitiesMap()
        {
            #region ������
            //��
            this.ToTable("Community_Activities");
            //����
            this.HasKey(t => t.CA_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
