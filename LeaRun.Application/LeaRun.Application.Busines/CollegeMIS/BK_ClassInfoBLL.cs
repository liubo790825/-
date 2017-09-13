using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:07
    /// �� ����������
    /// </summary>
    public class BK_ClassInfoBLL
    {
        private BK_ClassInfoIService service = new BK_ClassInfoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_ClassInfoBLL()
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
        public IEnumerable<BK_ClassInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public List<BK_ClassInfoEntity> GetList( string queryJson)
        {
             return service.GetList(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetDetails_old (string keyValue)
        {
            return service.GetDetails_old(conEntity.DbConnection, keyValue);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_ClassInfoEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">�༶ID��</param>
        /// <returns></returns>
        public IEnumerable<BK_StuInfoEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        ///  ��List�ķ�ʽ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">�༶��</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetListDetails( string keyValue)
        {
            return service.GetListDetails(conEntity.DbConnection, keyValue);
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ���ѧ�����༶
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="classid">�༶ID��</param>
        /// <param name="entryList">ѧ��ID��</param>
        /// <returns></returns>
        public int InsertStuCls(string classid, List<BK_StuInfoEntity> entryList)
        {
            return service.InsertStuCls(conEntity.DbConnection, classid, entryList);
        }
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
        public void SaveForm(string keyValue, BK_ClassInfoEntity entity,List<BK_StuClassEntity> entryList)
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
