using LeaRun.Application.Entity.ArrangeLesson;
using LeaRun.Application.IService.ArrangeLesson;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;


namespace LeaRun.Application.Service.ArrangeLesson
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 14:42
    /// �� ����TrainingPlan
    /// </summary>
    public class TrainingPlanService : RepositoryFactory<TrainingPlanEntity>, TrainingPlanIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TrainingPlanEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<TrainingPlanEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Contains(FullHead));//.
            }
            //������ֶ�2���ֶ�3Ҳ����д...*/
            expression = expression.And(t => t.TrainingPlanId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TrainingPlanEntity> GetPageListForProcess(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TrainingPlanEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Equals(FullHead));
            }
            //������ֶ�2���ֶ�3Ҳ����д...*/
            expression = expression.And(t => t.TrainingPlanId > 0);
            return this.BaseRepository(conn).FindList(expression, pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TrainingPlanEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<TrainingPlanEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["Major"].IsEmpty())
            {
                string FullHead = queryParam["Major"].ToString();
                expression = expression.And(t => t.Major.Contains(FullHead));
            }
            return this.BaseRepository(conn).IQueryable().ToList();
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="conn">��ѯ����</param>
        /// <returns></returns>
        public List<TrainingPlanEntity> GetList2(string conn)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }



        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TrainingPlanEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
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
        public void SaveForm(string conn, string keyValue, TrainingPlanEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
