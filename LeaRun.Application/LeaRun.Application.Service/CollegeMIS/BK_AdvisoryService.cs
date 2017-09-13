using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-02 13:54
    /// �� ����BK_Advisory
    /// </summary>
    public class BK_AdvisoryService : RepositoryFactory, BK_AdvisoryIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_AdvisoryEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_AdvisoryEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (queryParam["QAOther1"] != null && queryParam["QAOther1"].ToString() != "")
            {//��ѯͬ��ͬѧ
                string QAOther1 = queryParam["QAOther1"].ToString();
                expression = expression.And(t => t.QAOther1.Contains(QAOther1));
            }
            //*/
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => !string.IsNullOrEmpty(t.QAId));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// ��ʦ�˻�ȡ��ѯ�����б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_AdvisoryEntity> TeaGetPageList(string conn, Pagination pagination, string queryJson)
        {
            string stuinfoid = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                stuinfoid = queryParam["stuInfoId"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select *");
            strsql.Append(@"  from BK_Advisory");
            strsql.Append(@"  where 1=1");
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                strsql.Append(string.Format(@"  and stuInfoId = '{0}'", stuinfoid));
            }
            return this.BaseRepository(conn).FindList<BK_AdvisoryEntity>(strsql.ToString(), pagination).ToList();
        }


        /// <summary>
        /// ��ʦ�˻�ȡ��ѯѧ���б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_AdvisoryEntity> TeaGetStuList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select DISTINCT StuName,stuInfoId,QAOther1");
            strsql.Append(@"  from BK_Advisory");
            //strsql.Append(@"  where (Answer is not null) and (Answer <> '')");

            return this.BaseRepository(conn).FindList<BK_AdvisoryEntity>(strsql.ToString(), pagination).ToList();
        }


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_AdvisoryEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_AdvisoryEntity>().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_AdvisoryEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_AdvisoryEntity>(keyValue);
        }

        //��¼����
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT( DISTINCT stuInfoId) number ");
            strsql.Append(@"  from BK_Advisory");
            strsql.Append(@"  where 1=1");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_AdvisoryEntity entity)
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
