using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:03
    /// �� ����רҵ
    /// </summary>
    public interface BK_MajorIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_MajorEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_MajorEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// ����������ѯ����
        /// </summary>
        /// <param name="conn">�����ַ�</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        BK_MajorEntity GetEntityByWhere(string conn, string queryJson);

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<BK_MajorDetailEntity> GetDetails(string conn, string keyValue);
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
        void SaveForm(string conn, string keyValue, BK_MajorEntity entity,List<BK_MajorDetailEntity> entryList);
        #endregion
    }
}
