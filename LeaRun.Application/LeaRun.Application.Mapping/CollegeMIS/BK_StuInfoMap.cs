using LeaRun.Application.Entity.CollegeMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class BK_StuInfoMap : EntityTypeConfiguration<BK_StuInfoEntity>
    {
        public BK_StuInfoMap()
        {
            #region ������
            //��
            this.ToTable("BK_StuInfo");
            //����
            this.HasKey(t => t.stuInfoId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
