using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-14 09:17
    /// �� ����ѧ����ٱ�
    /// </summary>
    public class BK_StuLeaveMap : EntityTypeConfiguration<BK_StuLeaveEntity>
    {
        public BK_StuLeaveMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuLeave");
            //����
            this.HasKey(t => t.ID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
