using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-14 09:17
    /// �� ����ѧ����ٱ�
    /// </summary>
    public interface BK_StuLeaveIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_StuLeaveEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<BK_StuLeaveEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_StuLeaveEntity GetEntity(string conn, string keyValue);
        /// <summary>
        ///��ȡ�����Ϣ
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_StuLeaveEntity> GetStuLeaveInfo(string conn, Pagination pagination, string queryJson);
        /// <summary>
        ///��ȡ������ټ�¼��ϸ��Ϣ
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_StuLeaveEntity> GetStuLeaveResultInfo(string conn, string queryJson);

        /// <summary>
        /// ��ȡ���ѧ���б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        List<BK_StuLeaveEntity> GetStuLeaveList(string conn, Pagination pagination);

        /// <summary>
        /// ��ȡδ���ѧ������б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        List<BK_StuLeaveEntity> GetNotReviewStuLeaveList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�����ѧ������б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        List<BK_StuLeaveEntity> GetReviewStuLeaveList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// ��ѯ���ѧ���༶רҵ����Ϣ
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        List<M_BK_NumberEntity> GetStuLeaveMajorClassInfo(string conn, string queryJson);
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        List<M_BK_NumberEntity> Number(string conn);

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
        void SaveForm(string conn, string keyValue, BK_StuLeaveEntity entity);
        #endregion
    }
}
