using LeaRun.Application.Entity.FormManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.Application.IService.FormManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:23
    /// �� ������ģ���
    /// </summary>
    public interface IForm_ModuleService
    {
        #region ��ȡ����
        /// <summary>
        /// ������еı�
        /// </summary>
        /// <returns></returns>
        IEnumerable<Form_ModuleEntity> GetList();
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<Form_ModuleEntity> GetPageList( Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<Form_ModuleEntity> GetList( string queryJson);

        /// <summary>
        /// ��ȡ������ALL(����������)
        /// </summary>
        /// <returns></returns>
        DataTable GetAllList();
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        Form_ModuleEntity GetEntity( string keyValue);

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<Form_ModuleContentEntity> GetDetails(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ���±�ģ��״̬�����ã�ͣ�ã�
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="status">״̬ 1:����;0.ͣ��</param>
        void UpdateState(string keyValue, int state);
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm( string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm( string keyValue, Form_ModuleEntity entity);
        #endregion
    }
}
