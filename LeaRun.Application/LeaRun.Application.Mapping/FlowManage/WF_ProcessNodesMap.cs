using LeaRun.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FlowManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-09-08 15:44
    /// �� ����WF_ProcessNodes
    /// </summary>
    public class WF_ProcessNodesMap : EntityTypeConfiguration<WF_ProcessNodesEntity>
    {
        public WF_ProcessNodesMap()
        {
            #region ������
            //��
            this.ToTable("WF_ProcessNodes");
            //����
            this.HasKey(t => t.F_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
