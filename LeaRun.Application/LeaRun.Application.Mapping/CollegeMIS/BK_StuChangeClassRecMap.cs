using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-11 14:25
    /// �� ����ѧ�������¼
    /// </summary>
    public class BK_StuChangeClassRecMap : EntityTypeConfiguration<BK_StuChangeClassRecEntity>
    {
        public BK_StuChangeClassRecMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuChangeClassRec");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
