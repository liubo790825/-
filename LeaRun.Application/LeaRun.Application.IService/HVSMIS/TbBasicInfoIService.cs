using LeaRun.Application.Entity.HVSMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.HVSMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 11:06
    /// �� �����̲Ļ�����Ϣ���̲ı�š��̲����ơ��̲����ߡ���𡢳����硢���ۡ�����񽱽̲ġ���ְ��ר���̲�ISBN����ע����𡢳��棨ӡˢ��ʱ�䡢�����������ܺš���ʼ��(���ӡˢ����)��
    /// </summary>
    public interface TbBasicInfoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<TbBasicInfoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        TbBasicInfoEntity GetEntity(string conn, int keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string conn, string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string conn, string keyValue, TbBasicInfoEntity entity);
        #endregion
    }
}
