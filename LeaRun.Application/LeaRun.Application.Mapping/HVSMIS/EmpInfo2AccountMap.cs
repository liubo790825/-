using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-13 12:14
    /// �� �����̹������˻�
    /// </summary>
    public class EmpInfo2AccountMap : EntityTypeConfiguration<EmpInfo2AccountEntity>
    {
        public EmpInfo2AccountMap()
        {
            #region ������
            //��
            this.ToTable("EmpInfo");
            //����
            this.HasKey(t => t.EmpID);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
