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
    /// �� �ڣ�2017-06-28 16:33
    /// �� ����������Ϣ
    /// </summary>
    public class BK_DormBLL
    {
        private BK_DormIService service = new BK_DormService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_DormBLL()
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
        public IEnumerable<BK_DormEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_DormEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BK_DormEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_DormBedEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }

        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<BK_DormEntity> GetDormName(string queryJson)
        {
            return service.GetDormName(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��ѯ���ᴲλ��Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetDormBed(string queryJson)
        {
            return service.GetDormBed(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// ��ѯ���ᴲλ��Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetExchangeDormBed(string keyValue, string queryJson)
        {
            return service.GetExchangeDormBed(conEntity.DbConnection, keyValue, queryJson);
        }

        //��ʦ�˲�ѯ����
        public List<BK_DormEntity> GetDormId()
        {
            return service.GetDormId(conEntity.DbConnection);
        }
        //��ʦ�˲�ѯ��λ
        public List<M_BK_DormStuInfoEntity> TeaGetDormBed(string queryJson)
        {
            return service.TeaGetDormBed(conEntity.DbConnection, queryJson);
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
        public void SaveForm(string keyValue, BK_DormEntity entity,List<BK_DormBedEntity> entryList)
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
