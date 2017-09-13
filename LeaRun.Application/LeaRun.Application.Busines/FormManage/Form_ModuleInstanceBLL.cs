using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.IService.FormManage;
using LeaRun.Application.Service.FormManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.FormManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:28
    /// �� ������ʵ����
    /// </summary>
    public class Form_ModuleInstanceBLL
    {
        private IForm_ModuleInstanceService service = new Form_ModuleInstanceService();

        //private Entity.SystemManage.DataBaseLinkEntity conEntity;
        //#region ���췽��ָ��Ҫ�������ݿ�
        //public Form_ModuleInstanceBLL()
        //{
        //    SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
        //    conEntity = databaseLinkBLL.GetEntity("3bd3fa00-aac2-42d4-b9fc-03977de1790c");
        //}
        //#endregion
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Form_ModuleInstanceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Form_ModuleInstanceEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Form_ModuleInstanceEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
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
                service.RemoveForm(keyValue);
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
        public void SaveForm(string keyValue, Form_ModuleInstanceEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
