using LeaRun.Application.Entity.HVSMIS;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 11:06
    /// �� �����̲Ļ�����Ϣ���̲ı�š��̲����ơ��̲����ߡ���𡢳����硢���ۡ�����񽱽̲ġ���ְ��ר���̲�ISBN����ע����𡢳��棨ӡˢ��ʱ�䡢�����������ܺš���ʼ��(���ӡˢ����)��
    /// </summary>
    public class TbBasicInfoMap : EntityTypeConfiguration<TbBasicInfoEntity>
    {
        public TbBasicInfoMap()
        {
            #region ������
            //��
            this.ToTable("TbBasicInfo");
            //����
            this.HasKey(t => t.TeachBookId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
