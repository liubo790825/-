using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:33
    /// �� �������Ż�����Ϣ��
    /// </summary>
    public class Community_infoMap : EntityTypeConfiguration<Community_infoEntity>
    {
        public Community_infoMap()
        {
            #region ������
            //��
            this.ToTable("Community_info");
            //����
            this.HasKey(t => t.C_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
