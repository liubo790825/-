using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-12 11:41
    /// �� ������ҵ��������Ϣ
    /// </summary>
    public class StuInfoGraduateMap : EntityTypeConfiguration<StuInfoGraduateEntity>
    {
        public StuInfoGraduateMap()
        {
            #region ������
            //��
            this.ToTable("StuInfoGraduate");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
