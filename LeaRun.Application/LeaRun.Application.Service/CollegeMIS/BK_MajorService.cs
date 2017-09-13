using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 10:03
    /// �� ����רҵ
    /// </summary>
    public class BK_MajorService : RepositoryFactory, BK_MajorIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_MajorEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_MajorEntity>();
            //�ο�����
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["majorNo"].IsEmpty())//ת��������
                {
                    string MajorNo = queryParam["majorNo"].ToString();
                    expression = expression.And(t => t.MajorNo.Equals(MajorNo));
                }

                if (!queryParam["MajorName"].IsEmpty())
                {
                    string MajorName = queryParam["MajorName"].ToString();
                    expression = expression.And(t => t.MajorName.Contains(MajorName));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
            }

            //������ֶ�2���ֶ�3Ҳ����д...
            //expression = expression.And(t => t.MajorId > 0);
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
        public BK_MajorEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_MajorEntity>(keyValue);
        }

        /// <summary>
        /// ����������ѯ����
        /// </summary>
        /// <param name="conn">�����ַ�</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public BK_MajorEntity GetEntityByWhere(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_MajorEntity>();

            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["MajorNo"].IsEmpty())
                {
                    string MajorNo = queryParam["MajorNo"].ToString();
                    expression = expression.And(t => t.MajorNo.Equals(MajorNo));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
            }

            return this.BaseRepository(conn).FindEntity(expression);
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_MajorDetailEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_MajorDetailEntity>("select * from BK_MajorDetail where MajorNo='" + keyValue + "'");
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
                db.Delete<BK_MajorEntity>(keyValue);
                db.Delete<BK_MajorDetailEntity>(t => t.MajorNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_MajorEntity entity,List<BK_MajorDetailEntity> entryList)
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
                            if (!string.IsNullOrEmpty(item.ID))
                            {
                                item.Modify(item.ID);
                                item.MajorNo = entity.MajorNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.MajorNo = entity.MajorNo;
                                db.Insert(item);
                            }
                        }
                    }
              }
              else
              {
                  //����
                  entity.Create();
                  db.Insert(entity);
                  //��ϸ
                  foreach (BK_MajorDetailEntity item in entryList)
                  {
                      item.Create();
                      item.MajorNo = entity.MajorId;
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
