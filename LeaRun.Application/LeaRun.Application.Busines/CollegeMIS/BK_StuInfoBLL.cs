using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class BK_StuInfoBLL
    {
        private BK_StuInfoIService service = new BK_StuInfoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_StuInfoBLL()
        {
            SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
            conEntity = databaseLinkBLL.GetEntity("9914ca66-d5ae-4a26-9353-76bddea33179");
        }
        #endregion
        #region ��ȡ����

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public DataTable GetTablePageList(Pagination pagination, string queryJson)
        {
            return service.GetTablePageList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// ����������ͳ����������������
        /// ���� 2017��8��4��17:21:12
        /// </summary>
        /// <param name="conn">�����ַ���</param>
        /// <param name="pagination">ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public DataTable GetNewStuCountPageList(Pagination pagination, string queryJson)
        {
            return service.GetNewStuCountPageList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// ѧ�����ֻ���¼(by allen)
        /// </summary>
        /// <param name="username">���֤��</param>
        /// <param name="pass">����</param>
        /// <returns></returns>
        public BK_StuInfoEntity StuLogin(string username, string pass)
        {
            return service.StuLogin(conEntity.DbConnection, username, pass);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// ����������ȡʵ��
        /// </summary>
        /// <param name="queryJson">����ֵ</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntityByWhere( string queryJson)
        {
            return service.GetEntityByWhere(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<BK_StuInfoEntity> GetList( string queryJson)
        {
            return service.GetList(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_StuSocRelaEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }


        /// ��ѯ�ҵ�����
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        public List<M_BK_DormStuInfoEntity> GetMyDormers(string queryJson)
        {
            return service.GetMyDormers(conEntity.DbConnection, queryJson);
        }


        /// ��ѯ�ҵ�ͬ��ͬѧ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        public IEnumerable<BK_StuInfoEntity> GetMyClassmatesList(Pagination pagination, string queryJson)
        {
            return service.GetMyClassmatesList(conEntity.DbConnection, pagination, queryJson);
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(conEntity.DbConnection,keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BK_StuInfoEntity entity,List<BK_StuSocRelaEntity> entryList)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity, entryList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
