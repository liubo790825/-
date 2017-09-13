using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:07
    /// �� ����������
    /// </summary>
    public interface BK_ClassInfoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_ClassInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        List<BK_ClassInfoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        List<BK_StuInfoEntity> GetDetails_old(string conn, string keyValue);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_ClassInfoEntity GetEntity(string conn, string keyValue);

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<BK_StuInfoEntity> GetDetails(string conn, string keyValue);
        /// <summary>
        ///  ��List�ķ�ʽ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">�༶��</param>
        /// <returns></returns>
        List<BK_StuInfoEntity> GetListDetails(string conn, string keyValue);
        #endregion

        #region �ύ����

        /// <summary>
        /// ���ѧ�����༶
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="classid">�༶ID��</param>
        /// <param name="stuinfoid">ѧ��ID��</param>
        /// <returns></returns>
        int InsertStuCls(string conn, string classid, List<BK_StuInfoEntity> entryList);

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
        void SaveForm(string conn, string keyValue, BK_ClassInfoEntity entity,List<BK_StuClassEntity> entryList);
        #endregion
    }
}
