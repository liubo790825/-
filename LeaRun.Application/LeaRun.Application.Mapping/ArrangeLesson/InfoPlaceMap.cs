using LeaRun.Application.Entity.ArrangeLesson;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 12:31
    /// �� ����InfoPlace
    /// </summary>
    public class InfoPlaceMap : EntityTypeConfiguration<InfoPlaceEntity>
    {
        public InfoPlaceMap()
        {
            #region ������
            //��
            this.ToTable("InfoPlace");
            //����
            this.HasKey(t => t.PlaceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
