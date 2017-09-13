using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-25 09:43
    /// �� ����Students
    /// </summary>
    public class StudentsMap : EntityTypeConfiguration<StudentsEntity>
    {
        public StudentsMap()
        {
            #region ������
            //��
            this.ToTable("vwStuInfoBasic");
            //����
            this.HasKey(t => t.StuNo);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
