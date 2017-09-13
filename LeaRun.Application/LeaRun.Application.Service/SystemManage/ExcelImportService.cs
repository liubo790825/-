using LeaRun.Application.Entity.SystemManage;
using LeaRun.Application.IService.SystemManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System.Data;
using System.Collections;
using System.Text;
using LeaRun.Data;
using System.Data.Common;
using LeaRun.Application.Code;

namespace LeaRun.Application.Service.SystemManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-03-31 15:17
    /// �� ����Excel����ģ���
    /// </summary>
    public class ExcelImportService : RepositoryFactory, ExcelImportIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<ExcelImportEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<ExcelImportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_DbId"].IsEmpty())//ת��������
                {
                    string F_DbId = queryParam["F_DbId"].ToString();
                    expression = expression.And(t => t.F_DbId.Equals(F_DbId));
                }
                if (!queryParam["F_DbTable"].IsEmpty())//ת��������
                {
                    string F_DbTable = queryParam["F_DbTable"].ToString();
                    expression = expression.And(t => t.F_DbTable.Equals(F_DbTable));
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
            return this.BaseRepository().FindList<ExcelImportEntity>(expression, pagination);
        }

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public IEnumerable<ExcelImportEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<ExcelImportEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_DbId"].IsEmpty())//ת��������
                {
                    string F_DbId = queryParam["F_DbId"].ToString();
                    expression = expression.And(t => t.F_DbId.Equals(F_DbId));
                }
                if (!queryParam["F_DbTable"].IsEmpty())//ת��������
                {
                    string F_DbTable = queryParam["F_DbTable"].ToString();
                    expression = expression.And(t => t.F_DbTable.Equals(F_DbTable));
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
            return this.BaseRepository().FindList<ExcelImportEntity>(expression);
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public ExcelImportEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<ExcelImportEntity>(keyValue);
        }
        public ExcelImportEntity GetEntityByModuleId(string keyValue)
        {
            var expression = LinqExtensions.True<ExcelImportEntity>();
            expression = expression.And(t => t.F_ModuleId.Equals(keyValue));
            return this.BaseRepository().FindEntity<ExcelImportEntity>(expression);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<ExcelImportFiledEntity> GetDetails(string keyValue)
        {
            return this.BaseRepository().FindList<ExcelImportFiledEntity>("select * from Base_ExcelImportFiled where F_ImportTemplateId='" + keyValue + "'");
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<ExcelImportEntity>(keyValue);
                db.Delete<ExcelImportFiledEntity>(t => t.F_Id.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        public void UpdateState(string keyValue, int State)
        {
            ExcelImportEntity userEntity = new ExcelImportEntity();
            userEntity.Modify(keyValue);
            userEntity.F_EnabledMark = State;
            this.BaseRepository().Update(userEntity);
        }
        public void ImportExcel(string fid, DataTable dt, out DataTable Result)
        {
           
            //��õ���ģ��
            //ģ������
            ExcelImportEntity base_excellimport = GetEntity(fid);
            //string pkName = DatabaseCommon.GetKeyField("LeaRun.Entity." + base_excellimport.ImportTable).ToString();
            //ģ����ϸ��
            var listBase_ExcelImportDetail = GetDetails(fid);
            //���쵼�뷵�ؽ����
            DataTable Newdt = new DataTable("Result");
            foreach (ExcelImportFiledEntity excelImportDetail in listBase_ExcelImportDetail)
            {
                if (excelImportDetail.F_RelationType == 0 || excelImportDetail.F_RelationType == 2 || excelImportDetail.F_RelationType == 3)
                {
                    Newdt.Columns.Add(excelImportDetail.F_ColName, typeof(System.String));
                }

            }
            Newdt.Columns.Add("learunColOk", typeof(System.String));                 //λ��
            Newdt.Columns.Add("learunColError", typeof(System.String));                 //ԭ��
            //ȡ��Ҫ����ı���
            string tableName = base_excellimport.F_DbTable;////////////////
            if (dt != null && dt.Rows.Count > 0)
            {
                IRepository db = this.BaseRepository().BeginTrans();
                DataBaseLinkEntity linkentity= db.FindEntity<DataBaseLinkEntity>(base_excellimport.F_DbId); 
                db = this.BaseRepository(linkentity.DbConnection).BeginTrans();//���°��������ӻ�����

                try
                {
                    #region ����Excel������
                    //bool IsOk = true;
                    int learunColOk = 1;
                    string strError = "";
                    foreach (DataRow item in dt.Rows)
                    {
                        Hashtable entity = new Hashtable();//����Ҫ�������ݿ��hashtable
                        StringBuilder sb = new StringBuilder();
                        //entity[pkName] = Guid.NewGuid().ToString();//���ȸ�������ֵ
                        DataRow dr = Newdt.NewRow();
                        dr = Newdt.NewRow();
                        
                        
                        #region ����ģ�壬Ϊÿһ����ÿ���ֶ��ҵ�ģ���в���ֵ
                        int i = 0;
                        foreach (ExcelImportFiledEntity excelImportDetail in listBase_ExcelImportDetail)
                        {

                            string value = "";
                            if (excelImportDetail.F_RelationType == 0 || excelImportDetail.F_RelationType == 2 || excelImportDetail.F_RelationType == 3)
                            {
                                value = item[excelImportDetail.F_ColName].ToString();
                                dr[i] = value;
                            }
                          
                            #region �����ֶθ�ֵ
                            switch (excelImportDetail.F_RelationType)
                            {
                                //�ַ���
                                case 0:
                                    entity[excelImportDetail.F_FliedName] = value;
                                    i++;
                                    break;
                                //GUID
                                case 1:
                                    entity[excelImportDetail.F_FliedName] = Guid.NewGuid().ToString();
                                    break;
                                //�����ֵ�
                                case 2:
                                    i++;
                                    
                                    //��ѯExcel�ַ����Ƿ���������   SELECT * FROM CMISFrame.dbo.Base_DataItemDetail
                                    sb = DatabaseCommon.SelectSql("Base_DataItemDetail");//("Base_DataItem");" + excelImportDetail.F_DataItemEncode + "
                                    sb.Append(" and ItemId='" + excelImportDetail.F_DataItemEncode + "' and ItemName='" + value + "'");
                                    DataTable dt0 = this.BaseRepository().FindTable(sb.ToString());
                                    if (dt0.Rows.Count == 0)
                                    {
                                        //�����ڴ����
                                        learunColOk = 0;
                                        strError += "�� �����ֵ� �� �Ҳ�����Ӧ������";
                                    }
                                    else
                                    {
                                        entity[excelImportDetail.F_FliedName] = dt0.Rows[0]["ItemValue"];
                                    }
                                    sb.Remove(0,sb.Length);
                                    break;
                                //���ݱ�
                                case 3:
                                    i++;
                                    //entity[excelImportDetail.F_DbSaveFlied] = value;
                                    IRepository tempdb = this.BaseRepository().BeginTrans();
                                    DataBaseLinkEntity linkentity2 = tempdb.FindEntity<DataBaseLinkEntity>(excelImportDetail.F_DbId); 
                                    //��ѯExcel�ַ����Ƿ���������
                                    sb = DatabaseCommon.SelectSql(excelImportDetail.F_DbTable);
                                    sb.Append(" and " + excelImportDetail.F_DbRelationFlied + "='" + value + "'");
                                    DataTable dt1 = this.BaseRepository(linkentity2.DbConnection).FindTable(sb.ToString());
                                    if (dt1.Rows.Count==0)
                                    {
                                        //�����ڴ����
                                        learunColOk = 0;
                                        strError += "��" + excelImportDetail.F_ColName + "�� �Ҳ�����Ӧ������";
                                    }
                                    else
                                    {
                                        entity[excelImportDetail.F_DbSaveFlied] = dt1.Rows[0][excelImportDetail.F_DbSaveFlied].ToString();
                                    }
                                    sb.Remove(0,sb.Length);
                                    break;
                                //�̶���ֵ
                                case 4:
                                    entity[excelImportDetail.F_FliedName] = excelImportDetail.F_Value;
                                    
                                    break;
                                //������
                                case 5:
                                    entity[excelImportDetail.F_FliedName] = OperatorProvider.Provider.Current().UserId;
                                    break;
                                //����������
                                case 6:
                                    entity[excelImportDetail.F_FliedName] = OperatorProvider.Provider.Current().UserName;
                                    break;
                                //������ʱ��
                                case 7:
                                    entity[excelImportDetail.F_FliedName] = DateTime.Now;
                                    break;
                                default:
                                    break;
                            }
                           
                            #endregion ���ֶθ�ֵ����
                          
                           
                        }
                        dr[i] = learunColOk;
                        dr[i + 1] = strError;
                        #endregion ����ģ�����
                        //д���
                        if (learunColOk == 0)
                        {
                            continue;
                        }
                        StringBuilder strSql = DatabaseCommon.InsertSql(tableName, entity);
                        DbParameter[] parameter = DatabaseCommon.GetParameter(entity);
                        Newdt.Rows.Add(dr);
                        db.ExecuteBySql(strSql.ToString(),parameter);
                        
                    }
                    #endregion ����Excel�����н���
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    throw;
                }

            }
            Result = Newdt;
            
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ExcelImportEntity entity, List<ExcelImportFiledEntity> entryList)
        {
            IRepository db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //��ϸ
                    db.Delete<ExcelImportFiledEntity>(t => t.F_ImportTemplateId.Equals(keyValue));
                    foreach (ExcelImportFiledEntity item in entryList)
                    {
                        item.Create();
                        item.F_ImportTemplateId = entity.F_Id;
                        db.Insert(item);
                    }
                }
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);
                    //��ϸ
                    foreach (ExcelImportFiledEntity item in entryList)
                    {
                        item.Create();
                        item.F_ImportTemplateId = entity.F_Id;
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
