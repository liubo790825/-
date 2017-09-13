using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:04
    /// �� ����רҵ����
    /// </summary>
    public class BK_MajorDetailService : RepositoryFactory, BK_MajorDetailIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_MajorDetailEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_MajorDetailEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["majorDetailNo"].IsEmpty())//ת��������
             {
                 string MajorDetailNo = queryParam["majorDetailNo"].ToString();
                 expression = expression.And(t => t.MajorDetailNo.Equals(MajorDetailNo));
             }

             if (!queryParam["MajorDetailName"].IsEmpty()){
                 string MajorDetailName = queryParam["MajorDetailName"].ToString();
                 expression = expression.And(t => t.MajorDetailName.Contains(MajorDetailName));
             }
            if (!queryParam["MajorName"].IsEmpty())
            {
                string MajorName = queryParam["MajorName"].ToString();
                expression = expression.And(t => t.MajorName.Contains(MajorName));
            }
            if (!queryParam["MajorNo"].IsEmpty())
            {
                string MajorNo = queryParam["MajorNo"].ToString();
                expression = expression.And(t => t.MajorNo.Equals(MajorNo));
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_MajorDetailEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_MajorDetailEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_ClassInfoEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_ClassInfoEntity>("select * from BK_ClassInfo where MajorDetailNo='" + keyValue + "'");
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
                db.Delete<BK_MajorDetailEntity>(keyValue);
                db.Delete<BK_ClassInfoEntity>(t => t.MajorDetailNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_MajorDetailEntity entity,List<BK_ClassInfoEntity> entryList)
        {
          IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
              if (!string.IsNullOrEmpty(keyValue))
              {
                  //����
                  entity.Modify(keyValue);
                  db.Update(entity);
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty( item.ClassId))
                            {
                                item.Modify(item.ClassId);
                                item.MajorDetailNo = entity.MajorDetailNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.MajorDetailNo = entity.MajorDetailNo;
                                db.Insert(item);
                            }
                        }
                    }
                    //��ϸ
                    //db.Delete<BK_ClassInfoEntity>(t => t.MajorDetailNo.Equals(keyValue));
                  
              }
              else
              {
                  //����
                  entity.Create();
                  db.Insert(entity);
                  //��ϸ
                  foreach (BK_ClassInfoEntity item in entryList)
                  {
                      item.Create();
                      item.MajorDetailNo = entity.ID;
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
