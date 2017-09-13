using LeaRun.Application.Entity.SystemManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.Application.IService.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-03-31 15:17
    /// �� ����Excel����ģ���
    /// </summary>
    public interface ExcelImportIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<ExcelImportEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        IEnumerable<ExcelImportEntity> GetList(string queryJson);

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        ExcelImportEntity GetEntity(string keyValue);
        /// <summary>
        /// ��ѯ���еİ�ť
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ExcelImportEntity GetEntityByModuleId(string keyValue);
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<ExcelImportFiledEntity> GetDetails(string keyValue);
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, ExcelImportEntity entity,List<ExcelImportFiledEntity> entryList);
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="dt">����</param>
        /// <param name="Result"></param>
        void ImportExcel(string fid, DataTable dt, out DataTable Result);
        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="State"></param>
        void UpdateState(string keyValue, int State);
        #endregion
    }
}
