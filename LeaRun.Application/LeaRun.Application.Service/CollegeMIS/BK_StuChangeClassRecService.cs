using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-11 14:25
    /// �� ����ѧ�������¼
    /// </summary>
    public class BK_StuChangeClassRecService : RepositoryFactory, BK_StuChangeClassRecIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuChangeClassRecEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuChangeClassRecEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["Old_ClassId"].IsEmpty()){
                 string Old_ClassId = queryParam["Old_ClassId"].ToString();
                 expression = expression.And(t => t.Old_ClassId.Equals(Old_ClassId));
             }
            if (!queryParam["Old_ClassNo"].IsEmpty())
            {
                string Old_ClassNo = queryParam["Old_ClassNo"].ToString();
                expression = expression.And(t => t.Old_ClassNo.Equals(Old_ClassNo));
            }
            if (!queryParam["New_ClassId"].IsEmpty())
            {
                string New_ClassId = queryParam["New_ClassId"].ToString();
                expression = expression.And(t => t.New_ClassId.Equals(New_ClassId));
            }
            if (!queryParam["New_ClassNo"].IsEmpty())
            {
                string New_ClassNo = queryParam["New_ClassNo"].ToString();
                expression = expression.And(t => t.New_ClassNo.Equals(New_ClassNo));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_StuChangeClassRecEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_StuChangeClassRecEntity>().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuChangeClassRecEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_StuChangeClassRecEntity>(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_StuChangeClassRecEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();

            try
            {
                BK_StuInfoEntity stuEntity = db.FindEntity<BK_StuInfoEntity>(s => s.stuInfoId.Equals(entity.StuId));
                BK_DormBedEntity bedEntity = db.FindEntity<BK_DormBedEntity>(t => t.StuId.Equals(entity.StuId));
                //�޸�ѧ���İ༶��Ϣ
                stuEntity.ClassNo = entity.New_ClassNo;//�޸�ѧ���İ༶��
                stuEntity.MajorNo = entity.New_MajorNo;//�޸�ѧ����רҵ
                stuEntity.DeptNo = entity.New_DeptNo;//�޸�ѧ����Ժϵ

                db.Update<BK_StuInfoEntity>(stuEntity);//�޸�ѧ���İ༶��

                if (bedEntity!=null)
                {
                    bedEntity.MajorId = entity.New_MajorNo;//ͬʱ��ѧ���Ĵ�λ�����רҵҲ�޸���
                    db.Update<BK_DormBedEntity>(bedEntity);
                }
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
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
