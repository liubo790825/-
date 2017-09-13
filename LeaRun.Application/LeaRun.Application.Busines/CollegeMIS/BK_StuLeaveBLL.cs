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
    /// �� �ڣ�2017-08-14 09:17
    /// �� ����ѧ����ٱ�
    /// </summary>
    public class BK_StuLeaveBLL
    {
        private BK_StuLeaveIService service = new BK_StuLeaveService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_StuLeaveBLL()
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
        public IEnumerable<BK_StuLeaveEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_StuLeaveEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuLeaveEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }

        //��ȡ�����Ϣ
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveInfo(Pagination pagination, string queryJson)
        {
            return service.GetStuLeaveInfo(conEntity.DbConnection, pagination, queryJson);
        }
        //��ȡ������ټ�¼��ϸ��Ϣ
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveResultInfo( string queryJson)
        {
            return service.GetStuLeaveResultInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��ȡ���ѧ���б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<BK_StuLeaveEntity> GetStuLeaveList(Pagination pagination)
        {
            return service.GetStuLeaveList(conEntity.DbConnection, pagination);
        }


        /// <summary>
        /// ��ȡδ���ѧ������б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<BK_StuLeaveEntity> GetNotReviewStuLeaveList(Pagination pagination, string queryJson)
        {
            return service.GetNotReviewStuLeaveList(conEntity.DbConnection, pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�����ѧ������б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<BK_StuLeaveEntity> GetReviewStuLeaveList(Pagination pagination, string queryJson)
        {
            return service.GetReviewStuLeaveList(conEntity.DbConnection, pagination, queryJson);
        }
        /// <summary>
        /// ��ѯ���ѧ���༶רҵ����Ϣ
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<M_BK_NumberEntity> GetStuLeaveMajorClassInfo(string queryJson)
        {
            return service.GetStuLeaveMajorClassInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public List<M_BK_NumberEntity> Number()
        {
            return service.Number(conEntity.DbConnection);
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
        public void SaveForm(string keyValue, BK_StuLeaveEntity entity)
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
