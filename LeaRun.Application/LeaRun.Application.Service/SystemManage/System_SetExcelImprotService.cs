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
    public class System_SetExcelImprotService : RepositoryFactory, ISystem_SetExcelImprotService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<System_SetExcelImprotEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["F_Name"].IsEmpty()){
                 string F_Name = queryParam["F_Name"].ToString();
                 expression = expression.And(t => t.F_Name.Contains(F_Name));
             }
             //������ֶ�2���ֶ�3Ҳ����д...
            // expression = expression.And(t => t.F_Id > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<System_SetExcelImprotEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<System_SetExcelImprotEntity>();

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
            // expression = expression.And(t => t.F_Id > 0);
            return this.BaseRepository(conn).FindList(expression);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public System_SetExcelImprotEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<System_SetExcelImprotEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<System_SetExcelImportFiledEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository().FindList<System_SetExcelImportFiledEntity>("select * from System_SetExcelImportFiled where F_ImportTemplateId='" + keyValue + "'");
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
                db.Delete<System_SetExcelImprotEntity>(keyValue);
                db.Delete<System_SetExcelImportFiledEntity>(t => t.F_Id.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, System_SetExcelImprotEntity entity)
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
        public void SaveForm(string conn, string keyValue, System_SetExcelImprotEntity entity,List<System_SetExcelImportFiledEntity> entryList)
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
                  db.Delete<System_SetExcelImportFiledEntity>(t => t.F_Id.Equals(keyValue));
                    foreach (System_SetExcelImportFiledEntity item in entryList)
                    {
                        item.Create();
                        item.F_ImportTemplateId = entity.F_Id;
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
                    foreach (System_SetExcelImportFiledEntity item in entryList)
                    {
                        item.Create();
                        item.F_ImportTemplateId = entity.F_Id;
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

        public System_SetExcelImprotEntity GetEntityByModuleId(string keyValue)
        {
            var expression = LinqExtensions.True<System_SetExcelImprotEntity>();
            expression = expression.And(t => t.F_ModuleId.Equals(keyValue));
            return this.BaseRepository().FindEntity<System_SetExcelImprotEntity>(expression);
        }
        #endregion
    }
}
