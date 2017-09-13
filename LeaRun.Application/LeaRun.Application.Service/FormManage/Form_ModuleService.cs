using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.IService.FormManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System;
using System.Data;
using System.Text;

namespace LeaRun.Application.Service.FormManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:23
    /// �� ������ģ���
    /// </summary>
    public class Form_ModuleService : RepositoryFactory, IForm_ModuleService
    {
        #region ��ȡ����

        /// <summary>
        /// ������еı�
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Form_ModuleEntity> GetList()
        {
            return this.BaseRepository().FindList<Form_ModuleEntity>("select * from Form_Module order by Version desc");
        }


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Form_ModuleEntity> GetPageList( Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<Form_ModuleEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["FrmCategory"].IsEmpty()){
                 string FrmCategory = queryParam["FrmCategory"].ToString();
                 expression = expression.And(t => t.FrmCategory.Contains(FrmCategory));
             }
            if (!queryParam["FrmCode"].IsEmpty())
            {
                string FrmCode = queryParam["FrmCode"].ToString();
                expression = expression.And(t => t.FrmCode.Contains(FrmCode));
            }
            if (!queryParam["FrmType"].IsEmpty())
            {
                int FrmType = queryParam["FrmType"].ToInt();
                expression = expression.And(t => t.FrmType== FrmType);
            }
            if (!queryParam["FrmName"].IsEmpty())
            {
                string FrmName = queryParam["FrmName"].ToString();
                expression = expression.And(t => t.FrmName.Contains(FrmName));
            }

            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Form_ModuleEntity> GetList( string queryJson)
        {
            var expression = LinqExtensions.True<Form_ModuleEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["FrmCategory"].IsEmpty())
            {
                string FrmCategory = queryParam["FrmCategory"].ToString();
                expression = expression.And(t => t.FrmCategory.Contains(FrmCategory));
            }
            if (!queryParam["FrmCode"].IsEmpty())
            {
                string FrmCode = queryParam["FrmCode"].ToString();
                expression = expression.And(t => t.FrmCode.Contains(FrmCode));
            }
            if (!queryParam["FrmType"].IsEmpty())
            {
                int FrmType = queryParam["FrmType"].ToInt();
                expression = expression.And(t => t.FrmType == FrmType);
            }
            if (!queryParam["FrmName"].IsEmpty())
            {
                string FrmName = queryParam["FrmName"].ToString();
                expression = expression.And(t => t.FrmName.Contains(FrmName));
            }
            if (!queryParam["FrmId"].IsEmpty())
            {
                string FrmId = queryParam["FrmId"].ToString();
                expression = expression.And(t => t.FrmId.Contains(FrmId));
            }
            
            return this.BaseRepository() .IQueryable<Form_ModuleEntity>(expression).ToList();
        }
        
        /// <summary>
        /// ��ȡ������ALL(����������)
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                            w.FrmId,
	                            w.FrmName,
	                            w.FrmCategory,
							    t2.ItemName AS FrmTypeName
                            FROM
	                            Form_Module w
						    LEFT JOIN 
                                Base_DataItemDetail t2 ON t2.ItemDetailId = w.FrmCategory
                            WHERE w.DeleteMark = 0 and w.EnabledMark = 1 order by w.FrmType");
                return this.BaseRepository().FindTable(strSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Form_ModuleEntity GetEntity( string keyValue)
        {
            return this.BaseRepository().FindEntity<Form_ModuleEntity>(keyValue);
        }


        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<Form_ModuleContentEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<Form_ModuleContentEntity>("select * from Form_ModuleContent where FrmId='" + keyValue + "'");
        }

        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm( string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<Form_ModuleEntity>(keyValue);
                db.Delete<Form_ModuleContentEntity>(t => t.FrmId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ���±�ģ��״̬�����ã�ͣ�ã�
        /// </summary>
        /// <param name="keyValue">����</param>
        /// <param name="status">״̬ 1:����;0.ͣ��</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Form_ModuleEntity entity = new Form_ModuleEntity();
                entity.Modify(keyValue);
                entity.EnabledMark = state;
                this.BaseRepository().Update(entity);
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
        public void SaveForm( string keyValue, Form_ModuleEntity entity)
        {
            Random rd = new Random();
            string rdnumber = rd.Next(10000).ToString().PadLeft(4);
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);                
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                entity.Version = "V" + DateTime.Now.ToString("yyyyMMddHHmmssffff"); //entity.CreateDate.Value.ToString("yyyyMMddHHmmss") + rdnumber;//�汾��
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
