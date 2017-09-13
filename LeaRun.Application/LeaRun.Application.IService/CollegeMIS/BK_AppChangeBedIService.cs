using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 12:29
    /// �� ������������
    /// </summary>
    public interface BK_AppChangeBedIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_AppChangeBedEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<BK_AppChangeBedEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_AppChangeBedEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// ��ѯ���ύ����¼��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<BK_AppChangeBedEntity> SelectAppChangeBed(string conn, string queryJson);
        /// <summary>
        /// ��ѯ�ҵ����ύ����¼��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<M_BK_AppChangeBedEntity> DormExchangeGetMyInfo(string conn, string queryJson);

        /// <summary>
        /// ���ҵĽ�������
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<M_BK_AppChangeBedEntity> GetMyExchangeList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// ��ʦ�˻�ȡ��������
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<M_BK_AppChangeBedEntity> TeaGetDormExchangeList(string conn, Pagination pagination);

        /// <summary>
        /// ��ʦ�˻�ȡ���ύ�������¼��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<M_BK_NumberEntity> TeaNumber(string conn);
        /// <summary>
        /// ���ύ��˫��ѧ����Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<M_BK_AppChangeBedEntity> DormExchangeStuInfo(string conn, string queryJson);
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
        void SaveForm(string conn, string keyValue, BK_AppChangeBedEntity entity);
        #endregion
    }
}
