using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.IService.SystemManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;


namespace LeaRun.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 11:00
    /// �� �������ݵ���
    /// </summary>
    public class ExcelImportTemplateService : RepositoryFactory, IExcelImportTemplateService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ExcelImportTemplateEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<ExcelImportTemplateEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["F_Name"].IsEmpty()){
                 string F_Name = queryParam["F_Name"].ToString();
                 expression = expression.And(t => t.F_Name.Contains(F_Name));
             }
             //������ֶ�2���ֶ�3Ҳ����д...
            // expression = expression.And(t => t.F_ExcelImportTemplateId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ExcelImportTemplateEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<ExcelImportTemplateEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_Name"].IsEmpty())
                {
                    string F_Name = queryParam["F_Name"].ToString();
                    expression = expression.And(t => t.F_Name.Contains(F_Name));
                }
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            // expression = expression.And(t => t.F_ExcelImportTemplateId > 0);
            return this.BaseRepository(conn).FindList(expression);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public ExcelImportTemplateEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<ExcelImportTemplateEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<FiledsInfoEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository().FindList<FiledsInfoEntity>("select * from FiledsInfo where F_ExcelImportTemplateId='" + keyValue + "'");
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<ExcelImportTemplateEntity>(keyValue);
                db.Delete<FiledsInfoEntity>(t => t.F_ExcelImportTemplateId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }


        /// <summary>
        /// ��������������޸ģ�,�������Ӷ��������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, ExcelImportTemplateEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);                    
                }
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);                    
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }


        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, ExcelImportTemplateEntity entity,List<FiledsInfoEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
              if (!string.IsNullOrEmpty(keyValue))
              {
                  //����
                  entity.Modify(keyValue);
                  db.Update(entity);
                  //��ϸ
                  db.Delete<FiledsInfoEntity>(t => t.F_ExcelImportTemplateId.Equals(keyValue));
                    foreach (FiledsInfoEntity item in entryList)
                    {
                        item.Create();
                        item.F_ExcelImportTemplateId = entity.F_ExcelImportTemplateId;
                        item.F_DbId = entity.F_DbId;
                        item.F_DbTable = entity.F_DbTable;
                        db.Insert(item);
                    }
              }
              else
              {
                  //����
                  entity.Create();
                  db.Insert(entity);
                    //��ϸ
                    foreach (FiledsInfoEntity item in entryList)
                    {
                        item.Create();
                        item.F_ExcelImportTemplateId = entity.F_ExcelImportTemplateId;
                        item.F_DbId = entity.F_DbId;
                        item.F_DbTable = entity.F_DbTable;
                        db.Insert(item);
                    }
              }
              db.Commit();
          }
          catch (Exception)
          {
              db.Rollback();
              throw;
          }
        }
        #endregion
    }
}
