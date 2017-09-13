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
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public interface BK_DormIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        IEnumerable<BK_DormEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        BK_DormEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<BK_DormEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        IEnumerable<BK_DormBedEntity> GetDetails(string conn, string keyValue);

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        List<BK_DormEntity> GetDormName(string conn, string queryJson);

        /// <summary>
        /// ��ѯ���ᴲλ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        List<M_BK_DormEntity> GetDormBed(string conn, string queryJson);

        /// <summary>
        /// ��ѯ���ύ����λ��Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        List<M_BK_DormEntity> GetExchangeDormBed(string conn, string keyValue, string queryJson);

        //��ʦ�˲�ѯ����
        List<BK_DormEntity> GetDormId(string conn);
        //��ʦ�˲鿴��λ��Ϣ
        List<M_BK_DormStuInfoEntity> TeaGetDormBed(string conn, string queryJson);

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
        void SaveForm(string conn, string keyValue, BK_DormEntity entity,List<BK_DormBedEntity> entryList);
        #endregion
    }
}
