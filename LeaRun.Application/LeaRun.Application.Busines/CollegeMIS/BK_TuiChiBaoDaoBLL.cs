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
    /// �� �ڣ�2017-08-03 09:59
    /// �� ����BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoBLL
    {
        private BK_TuiChiBaoDaoIService service = new BK_TuiChiBaoDaoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public BK_TuiChiBaoDaoBLL()
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
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_TuiChiBaoDaoEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }


        /// ��ѯ�Ƴٱ���ѧ���༶��Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        public List<BK_TuiChiBaoDaoEntity> GetTuiChiClass()
        {
            return service.GetTuiChiClass(conEntity.DbConnection);
        }
        /// <summary>
        /// ��ѯ�Ƴٱ���ѧ����Ϣ
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_TuiChiBaoDaoEntity> GetTuiChiInfo(string queryJson)
        {
            return service.GetTuiChiInfo(conEntity.DbConnection, queryJson);
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
        public void SaveForm(string keyValue, BK_TuiChiBaoDaoEntity entity)
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
