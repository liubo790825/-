using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.IService.ArrangeLesson;
using LeaRun.Application.Service.ArrangeLesson;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.ArrangeLesson
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:21
    /// �� ����InfoTeacher
    /// </summary>
    public class InfoTeacherBLL
    {
        private InfoTeacherIService service = new InfoTeacherService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public InfoTeacherBLL()
        {
            SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
            conEntity = databaseLinkBLL.GetEntity("4481b357-809b-4ae3-aafd-c0c27e48041b");
        }
        #endregion
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<InfoTeacherEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public InfoTeacherEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
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
        public void SaveForm(string keyValue, InfoTeacherEntity entity)
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
