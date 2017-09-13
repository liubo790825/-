using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.IService.ArrangeLesson;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.ArrangeLesson
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:23
    /// �� ����TeachingPlan
    /// </summary>
    public class TeachingPlanService : RepositoryFactory, TeachingPlanIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TeachingPlanEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TeachingPlanEntity>();
             //�ο�����
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }
             //������ֶ�2���ֶ�3Ҳ����д...*/
             expression = expression.And(t => t.TeachingPlanId > 0);
             return this.BaseRepository(conn).FindList<TeachingPlanEntity>(expression,pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TeachingPlanEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<TeachingPlanEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<PlanCourseEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<PlanCourseEntity>("select * from PlanCourse where TeachingPlanCode='" + keyValue + "'");
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
                db.Delete<TeachingPlanEntity>(keyValue);
                db.Delete<PlanCourseEntity>(t => t.TeachingPlanCode.Equals(keyValue));
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
        public void SaveForm(string conn, string keyValue, TeachingPlanEntity entity,List<PlanCourseEntity> entryList)
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
                  db.Delete<PlanCourseEntity>(t => t.TeachingPlanCode.Equals(keyValue));
                  foreach (PlanCourseEntity item in entryList)
                  {
                      item.Create();
                      item.TeachingPlanCode = entity.TeachingPlanCode;
                      db.Insert(item);
                  }
              }
              else
              {
                  //����
                  entity.Create();
                  db.Insert(entity);
                  //��ϸ
                  foreach (PlanCourseEntity item in entryList)
                  {
                      item.Create();
                      item.TeachingPlanCode = entity.TeachingPlanCode;
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
