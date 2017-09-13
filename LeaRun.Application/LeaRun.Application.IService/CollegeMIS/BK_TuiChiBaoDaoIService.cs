using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-03 09:59
    /// �� ����BK_TuiChiBaoDao
    /// </summary>
    public interface BK_TuiChiBaoDaoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_TuiChiBaoDaoEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<BK_TuiChiBaoDaoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_TuiChiBaoDaoEntity GetEntity(string conn, string keyValue);


        /// <summary>
        /// ��ѯ�Ƴٱ���ѧ���༶��Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        //List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn);
        List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn);

        /// <summary>
        /// ��ѯ�Ƴٱ���ѧ����Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        List<M_BK_TuiChiBaoDaoEntity> GetTuiChiInfo(string conn, string queryJson);


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
        void SaveForm(string conn, string keyValue, BK_TuiChiBaoDaoEntity entity);
        #endregion
    }
}
