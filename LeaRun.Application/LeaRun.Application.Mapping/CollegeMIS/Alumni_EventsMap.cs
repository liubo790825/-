using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-01-20 23:21
    /// �� ����У�ѻ
    /// </summary>
    public class Alumni_EventsMap : EntityTypeConfiguration<Alumni_EventsEntity>
    {
        public Alumni_EventsMap()
        {
            #region ������
            //��
            this.ToTable("Alumni_Events");
            //����
            this.HasKey(t => t.AE_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
