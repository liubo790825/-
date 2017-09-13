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
    /// �� �ڣ�2017-08-17 12:29
    /// �� ������������
    /// </summary>
    public class BK_AppChangeBedBLL
    {
        private BK_AppChangeBedIService service = new BK_AppChangeBedService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_AppChangeBedBLL()
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
        public IEnumerable<BK_AppChangeBedEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_AppChangeBedEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_AppChangeBedEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }

        /// <summary>
        /// ��ѯ���ύ����¼��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_AppChangeBedEntity> SelectAppChangeBed(string queryJson)
        {
            return service.SelectAppChangeBed(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// ��ѯ�ҵ����ύ����¼��Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeGetMyInfo(string queryJson)
        {
            return service.DormExchangeGetMyInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ���ҵĽ�������
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> GetMyExchangeList(Pagination pagination, string queryJson)
        {
            return service.GetMyExchangeList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// ��ʦ�˻�ȡ��������
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> TeaGetDormExchangeList(Pagination pagination)
        {
            return service.TeaGetDormExchangeList(conEntity.DbConnection, pagination);
        }

        /// <summary>
        /// ��ʦ�˻�ȡ���ύ�������¼��
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<M_BK_NumberEntity> TeaNumber()
        {
            return service.TeaNumber(conEntity.DbConnection);
        }

        /// <summary>
        /// ���ύ��˫��ѧ����Ϣ
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeStuInfo(string queryJson)
        {
            return service.DormExchangeStuInfo(conEntity.DbConnection, queryJson);
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
        public void SaveForm(string keyValue, BK_AppChangeBedEntity entity)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
