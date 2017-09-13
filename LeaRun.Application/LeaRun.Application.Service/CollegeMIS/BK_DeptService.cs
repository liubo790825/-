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
    /// �� �ڣ�2017-06-19 09:57
    /// �� ����ϵ��
    /// </summary>
    public class BK_DeptService : RepositoryFactory, BK_DeptIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_DeptEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DeptEntity>();
            //�ο�����
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["deptNo"].IsEmpty())//ת��������
                {
                    string DeptNo = queryParam["deptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Equals(DeptNo));
                }
                if (!queryParam["DeptName"].IsEmpty())
                {
                    string DeptName = queryParam["DeptName"].ToString();
                    expression = expression.And(t => t.DeptName.Contains(DeptName));
                }
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression, pagination);

        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_DeptEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DeptEntity>(keyValue);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="where">��ѯ����</param>
        /// <returns></returns>
        public BK_DeptEntity GetEntityByWhere(string conn, string where)
        {
            var expression = LinqExtensions.True<BK_DeptEntity>();
            if (!string.IsNullOrEmpty(where))
            {
                var queryParam = where.ToJObject();
                if (!queryParam["DeptName"].IsEmpty())
                {
                    string DeptName = queryParam["DeptName"].ToString();
                    expression = expression.And(t => t.DeptName.Contains(DeptName));
                }
                if (!queryParam["DeptNo"].IsEmpty())
                {
                    string DeptNo = queryParam["DeptNo"].ToString();
                    expression = expression.And(t => t.DeptNo.Contains(DeptNo));
                }
            }
            return this.BaseRepository(conn).FindEntity<BK_DeptEntity>(expression);
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_MajorEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_MajorEntity>("select * from BK_Major where DeptNo='" + keyValue + "'");
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">Ժϵ��</param>
        /// <returns></returns>
        public List<BK_MajorEntity> GetListDetails(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_MajorEntity>().And(t=>t.DeptNo.Equals(keyValue));
            return this.BaseRepository(conn).FindList<BK_MajorEntity>(expression).OrderBy(t=>t.MajorName).ToList();
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
                db.Delete<BK_DeptEntity>(keyValue);
                db.Delete<BK_MajorEntity>(t => t.DeptNo.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, BK_DeptEntity entity,List<BK_MajorEntity> entryList)
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
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.MajorId))
                            {
                                item.Modify(item.MajorId);
                                item.DeptNo = entity.DeptNo;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DeptNo = entity.DeptNo;
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
                  foreach (BK_MajorEntity item in entryList)
                  {
                      item.Create();
                      item.DeptNo = entity.DeptId;
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
