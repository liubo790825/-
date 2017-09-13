using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.IService.FormManage;
using LeaRun.Application.Service.FormManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace LeaRun.Application.Busines.FormManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:23
    /// �� ������ģ���
    /// </summary>
    public class Form_ModuleBLL
    {
        private IForm_ModuleService service = new Form_ModuleService();

        #region ��ȡ����
        /// <summary>
        /// ������еı�
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Form_ModuleEntity> GetList()
        {
            return service.GetList();
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Form_ModuleEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Form_ModuleEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡ������ALL(����������)
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            return service.GetAllList();
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Form_ModuleEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<Form_ModuleContentEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(keyValue);
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ���±�ģ��״̬�����ã�ͣ�ã�
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="status">״̬ 1:����;0.ͣ��</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                service.UpdateState(keyValue, state);
            }
            catch (Exception)
            {

                throw;
            }
        }

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
        public void SaveForm(string keyValue, Form_ModuleEntity entity)
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
