using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-17 10:36
    /// �� ������ְԱ���˺�����
    /// </summary>
    public class EmpInfo2LoginUserMap : EntityTypeConfiguration<EmpInfo2LoginUserEntity>
    {
        public EmpInfo2LoginUserMap()
        {
            #region ������
            //��
            this.ToTable("vwEmpInfo");
            //����
            this.HasKey(t => t.EmpNo);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
