using LeaRun.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 10:57
    /// �� �������ݵ�����ϸ����
    /// </summary>
    public class FiledsInfoMap : EntityTypeConfiguration<FiledsInfoEntity>
    {
        public FiledsInfoMap()
        {
            #region ������
            //��
            this.ToTable("FiledsInfo");
            //����
            this.HasKey(t => t.F_FiledsInfoId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
