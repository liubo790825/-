using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.IService.SystemManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

using LeaRun.Util;

using LeaRun.Util.Extension;

namespace LeaRun.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-04-17 12:09
    /// �� ����Excel����
    /// </summary>
    public class ExcelExportService : RepositoryFactory<ExcelExportEntity>, ExcelExportIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ExcelExportEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ExcelExportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_GridId"].IsEmpty())//ת��������
                {
                    string F_GridId = queryParam["F_GridId"].ToString();
                    expression = expression.And(t => t.F_GridId.Equals(F_GridId));
                }
                if (!queryParam["F_Name"].IsEmpty())//ת��������
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
                if (!queryParam["F_ModuleId"].IsEmpty())//ת��������
                {
                    string F_ModuleId = queryParam["F_ModuleId"].ToString();
                    expression = expression.And(t => t.F_ModuleId.Equals(F_ModuleId));
                }
                if (!queryParam["F_ModuleBtnId"].IsEmpty())//ת��������
                {
                    string F_ModuleBtnId = queryParam["F_ModuleBtnId"].ToString();
                    expression = expression.And(t => t.F_ModuleBtnId.Equals(F_ModuleBtnId));
                }
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<ExcelExportEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<ExcelExportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_GridId"].IsEmpty())//ת��������
                {
                    string F_GridId = queryParam["F_GridId"].ToString();
                    expression = expression.And(t => t.F_GridId.Equals(F_GridId));
                }
                if (!queryParam["F_Name"].IsEmpty())//ת��������
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
                if (!queryParam["F_ModuleId"].IsEmpty())//ת��������
                {
                    string F_ModuleId = queryParam["F_ModuleId"].ToString();
                    expression = expression.And(t => t.F_ModuleId.Equals(F_ModuleId));
                }
                if (!queryParam["F_ModuleBtnId"].IsEmpty())//ת��������
                {
                    string F_ModuleBtnId = queryParam["F_ModuleBtnId"].ToString();
                    expression = expression.And(t => t.F_ModuleBtnId.Equals(F_ModuleBtnId));
                }
            }
            return this.BaseRepository().IQueryable(expression).ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public ExcelExportEntity GetEntity(string keyValue)
        {            
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ExcelExportEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
