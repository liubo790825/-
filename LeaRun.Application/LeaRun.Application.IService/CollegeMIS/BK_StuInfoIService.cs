using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public interface BK_StuInfoIService
    {
        #region ��ȡ����

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        DataTable GetTablePageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ����������ͳ����������������
        /// ���� 2017��8��4��17:21:12
        /// </summary>
        /// <param name="conn">�����ַ���</param>
        /// <param name="pagination">ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        DataTable GetNewStuCountPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// ѧ�����ֻ���¼(by allen)
        /// </summary>
        /// <param name="username">���֤��</param>
        /// <param name="pass">����</param>
        /// <returns></returns>
        BK_StuInfoEntity StuLogin(string conn, string username, string pass);

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_StuInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        List<BK_StuInfoEntity> GetList(string conn,  string queryJson);


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_StuInfoEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// ����������ȡʵ��
        /// </summary>
        /// <param name="queryJson">����ֵ</param>
        /// <returns></returns>
        BK_StuInfoEntity GetEntityByWhere(string conn, string queryJson);
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<BK_StuSocRelaEntity> GetDetails(string conn, string keyValue);



        /// <summary>
        /// ��ѯ�ҵ�����
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        List<M_BK_DormStuInfoEntity> GetMyDormers(string conn, string queryJson);


        /// <summary>
        /// ��ѯ�ҵ�ͬѧ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        IEnumerable<BK_StuInfoEntity> GetMyClassmatesList(string conn, Pagination pagination, string queryJson);


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
        void SaveForm(string conn, string keyValue, BK_StuInfoEntity entity,List<BK_StuSocRelaEntity> entryList);
        #endregion
    }
}
