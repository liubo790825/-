using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:36
    /// �� ����InfoClass
    /// </summary>
    public class InfoClassMap : EntityTypeConfiguration<InfoClassEntity>
    {
        public InfoClassMap()
        {
            #region ������
            //��
            this.ToTable("InfoClass");
            //����
            this.HasKey(t => t.ClassId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
