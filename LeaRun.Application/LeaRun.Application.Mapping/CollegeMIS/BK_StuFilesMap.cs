using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 17:53
    /// �� ����ѧ����������
    /// </summary>
    public class BK_StuFilesMap : EntityTypeConfiguration<BK_StuFilesEntity>
    {
        public BK_StuFilesMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuFiles");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
