using LeaRun.Application.Entity.FormManage;
using LeaRun.Application.IService.FormManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System.Text;
using LeaRun.Application.Entity.AuthorizeManage;
using System.Data;

namespace LeaRun.Application.Service.FormManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:31
    /// �� ������������
    /// </summary>
    public class Form_ModuleRelationService : RepositoryFactory<Form_ModuleRelationEntity>, IForm_ModuleRelationService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<Form_ModuleRelationEntity> GetPageList( Pagination pagination, string queryJson)
        {

            var strSql = new StringBuilder();
            strSql.Append(@"select Id,ModuleContentId,a.FrmId,a.FrmName,FrmVersion,Version as NewVersion,FrmKind,ObjectId,ObjectButtonId,ObjectName,a.CreateDate,a.CreateUserId,a.CreateUserName from Form_ModuleRelation a LEFT JOIN Form_Module b ON a.FrmId = b.FrmId where 1=1");
            var queryParam = queryJson.ToJObject();
            //���ݿ�Id��ѯ
            if (!queryParam["FrmKind"].IsEmpty())
            {
                string FrmKind = queryParam["FrmKind"].ToString();
                strSql.Append(" and FrmKind=" + FrmKind + "");
            }
            if (!queryParam["Keyword"].IsEmpty())
            {
                string keyword = queryParam["Keyword"].ToString();
                strSql.Append(" and ObjectName like '%" + keyword + "%'");
            }
            return this.BaseRepository().FindList(strSql.ToString(), pagination);

            /*
            var expression = LinqExtensions.True<Form_ModuleRelationEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["FrmKind"].IsEmpty()){
                int FrmKind = queryParam["FrmKind"].ToInt();
                 expression = expression.And(t => t.FrmKind== FrmKind);
             }
            if (!queryParam["ObjectButtonId"].IsEmpty())
            {
                string ObjectButtonId = queryParam["ObjectButtonId"].ToString();
                expression = expression.And(t => t.ObjectButtonId.Equals(ObjectButtonId));
            }
            if (!queryParam["FrmId"].IsEmpty())
            {
                string FrmId = queryParam["FrmId"].ToString();
                expression = expression.And(t => t.FrmId.Equals(FrmId));
            }
            if (!queryParam["FrmName"].IsEmpty())
            {
                string FrmName = queryParam["FrmName"].ToString();
                expression = expression.And(t => t.FrmName.Contains(FrmName));
            }
            if (!queryParam["ObjectId"].IsEmpty())
            {
                string ObjectId = queryParam["ObjectId"].ToString();
                expression = expression.And(t => t.ObjectId.Equals(ObjectId));
            }
            return this.BaseRepository().FindList(expression,pagination);*/
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<Form_ModuleRelationEntity> GetList( string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public Form_ModuleRelationEntity GetEntity( string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
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
                db.Delete<Form_ModuleRelationEntity>(keyValue);
                Form_ModuleRelationEntity entity = db.FindEntity<Form_ModuleRelationEntity>(keyValue);
                db.Delete<ModuleEntity>(t => t.ModuleId.Equals(entity.ObjectId));
                db.Delete<ModuleButtonEntity>(t => t.ModuleId.Equals(entity.ObjectId));//ɾ�����İ�ť
                db.Delete<ModuleColumnEntity>(t => t.ModuleId.Equals(entity.ObjectId));//ɾ��������

                db.Commit();
            }


            catch (System.Exception)
            {
                db.Rollback();
                throw;
            }

            //this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="keyValue"></param>
        public void UpdateForm(string keyValue)
        {
            Form_ModuleRelationEntity entity = new Form_ModuleRelationEntity();
            Form_ModuleRelationEntity entity1 = this.BaseRepository().FindEntity(keyValue);

            DataTable dt = this.BaseRepository().FindTable("select top 1 Id,FrmVersion from Form_ModuleContent where FrmId='" + entity1.FrmId + "' order by FrmVersion desc");

            entity.ModuleContentId = dt.Rows[0][0].ToString();
            entity.FrmVersion = dt.Rows[0][1].ToString();
            entity.Modify(keyValue);
            this.BaseRepository().Update(entity);
        }




        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm( string keyValue, Form_ModuleRelationEntity entity)
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

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, Form_ModuleRelationEntity entity, ModuleEntity module)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //ģ��,��ɾ������������
                }
                else
                {
                    //ȡ��ModuleCotentId
                    DataTable dt = this.BaseRepository().FindTable("select top 1 Id from Form_ModuleContent where FrmId='" + entity.FrmId + "' order by FrmVersion desc");
                    entity.ModuleContentId = dt.Rows[0][0].ToString();
                    //��������
                    entity.Create();
                    entity.ObjectId = System.Guid.NewGuid().ToString();
                    db.Insert(entity);
                    //ģ��
                    if (entity.FrmKind == 0)
                    {
                        module.Create();
                        module.ModuleId = entity.ObjectId;
                        module.UrlAddress = module.UrlAddress + "?Id=" + entity.Id;
                        db.Insert(module);
                    }
                }
                db.Commit();
            }
            catch (System.Exception)
            {
                db.Rollback();
                throw;
            }
        }



        #endregion
    }
}
