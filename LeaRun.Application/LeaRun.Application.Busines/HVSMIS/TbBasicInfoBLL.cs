using LeaRun.Application.Entity.HVSMIS;
using LeaRun.Application.IService.HVSMIS;
using LeaRun.Application.Service.HVSMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.HVSMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-08 11:06
    /// �� �����̲Ļ�����Ϣ���̲ı�š��̲����ơ��̲����ߡ���𡢳����硢���ۡ�����񽱽̲ġ���ְ��ר���̲�ISBN����ע����𡢳��棨ӡˢ��ʱ�䡢�����������ܺš���ʼ��(���ӡˢ����)��
    /// </summary>
    public class TbBasicInfoBLL
    {
        private TbBasicInfoIService service = new TbBasicInfoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region ���췽��ָ��Ҫ�������ݿ�
        public TbBasicInfoBLL()
        {
            SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
            conEntity = databaseLinkBLL.GetEntity("9914ca66-d5ae-4a26-9353-76bddea33179");
        }
        #endregion
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TbBasicInfoEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TbBasicInfoEntity GetEntity(int keyValue)
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
        public void SaveForm(string keyValue, TbBasicInfoEntity entity)
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
